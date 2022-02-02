using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Shared.Models;
using Shared.Repositories;

namespace Shared
{
    public sealed class Worker : IDisposable, INotifyPropertyChanged
    {
        private static Lazy<Worker> lazy;
        public static Worker Instance
        {
            get
            {
                if (lazy?.Value == null) lazy = new Lazy<Worker>(() => new Worker());
                return lazy.Value;
            }
        }
        private Worker()
        {
            _worker.DoWork += Worker_DoWork;
        }

        private readonly BackgroundWorker _worker = new BackgroundWorker();
        static readonly SqlRepository Repo = new SqlRepository();
        private bool _disposing = false;

        private bool? _tvOn;
        private Tele _latestCurrentTv;

        public Tele LatestCurrentTv
        {
            get => _latestCurrentTv;
            set
            {
                _latestCurrentTv = value;
                OnPropertyChanged();
            }
        }

        public void StartWorking()
        {
            _worker.RunWorkerAsync();
        }
        public void StopWorking()
        {
            _worker.WorkerSupportsCancellation = true;
            _worker.CancelAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_disposing)
            {
                var latestCurrentTv = Repo.GetLastTvCurrentTv();
                if (LatestCurrentTv == null || LatestCurrentTv.Id != latestCurrentTv.Id)
                {
                    LatestCurrentTv = latestCurrentTv;
                }

                var latestPowerStatus = Repo.GetPowerStatus();
                if (TvOn != latestPowerStatus)
                {
                    TvOn = latestPowerStatus;
                }

                //Er mag een kleine timeout zitten tussen executies om de processor wat te sparen
                System.Threading.Thread.Sleep(100);
            }
        }

        public bool? TvOn
        {
            get => _tvOn;
            set
            {
                _tvOn = value;
                OnPropertyChanged();
            }
        }

        public void Dispose()
        {
            _disposing = true;
            StopWorking();
            _worker?.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
