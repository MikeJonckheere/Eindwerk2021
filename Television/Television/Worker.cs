using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Television.Repositories;


namespace Television
{
    public sealed class Worker
    {
        private static readonly Lazy<Worker> lazy = new Lazy<Worker>(() => new Worker());
        public static Worker Instance { get { return lazy.Value; } }
        public bool TvIsOn { get; set; }
        BackgroundWorker worker = new BackgroundWorker();

        private Worker()
        {
            worker.DoWork += Worker_DoWork;
        }

        /// <summary>
        /// Execute this on when u set TvIsOn to true.
        /// </summary>
        public void StartWorking()
        {
            worker.RunWorkerAsync();
        }
        static sqlRepository repo = new sqlRepository();

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {

            while (TvIsOn)
            {
                //var tvs = repo.GetCurrentValues();
                //foreach (var tv in tvs)
                //{
                //    txtCurrentChannel.Text = "Current Channel: " + tv.SettingsChannel.ToString();
                //    txtCurrentVolume.Text = "Current Volume: " + tv.SettingsVolume.ToString();
                //}

            }
        }
    }
}
