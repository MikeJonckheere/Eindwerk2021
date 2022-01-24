using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using Shared.Repositories;

namespace Television
{
    public sealed class Worker
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
            worker.DoWork += Worker_DoWork;
        }

        public bool TvIsOn { get; set; }
        BackgroundWorker worker = new BackgroundWorker();
        static SqlRepository repo = new SqlRepository();

        /// <summary>
        /// Execute this on when u set TvIsOn to true.
        /// </summary>
        public void StartWorking()
        {
            worker.RunWorkerAsync();
        }
        public void StopWorking()
        {
            worker.WorkerSupportsCancellation = true;
            worker.CancelAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (TvIsOn)
            {
                if (repo.GetPowerStatus())
                {
                    try
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            var tvs = repo.GetCurrentTv();
                            foreach (var tv in tvs)
                            {
                                switch (tv.Source)
                                {
                                    case 1:
                                        ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentSource.Text = "Current Source: tv";
                                        break;
                                    case 2:
                                        ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentSource.Text = "Current Source: hdmi1";
                                        break;
                                    case 3:
                                        ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentSource.Text = "Current Source: hdmi2";
                                        break;

                                    default:
                                        break;
                                }
                                ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentChannel.Text = "Current Channel: " + tv.Channel.ToString();
                                ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentVolume.Text = "Current Volume: " + tv.Volume.ToString();
                            }
                        });
                    }
                    catch (OperationCanceledException)
                    {
                    }
                }
                else
                {
                    try
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentSource.Text = "Current Source: ";
                            ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentChannel.Text = "Current Channel: ";
                            ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentVolume.Text = "Current Volume: ";
                        });

                    }
                    catch (OperationCanceledException)
                    {
                    }

                }

                //Er mag een kleine timeout zitten tussen executies om de processor wat te sparen
                System.Threading.Thread.Sleep(100);

            }
            ///A ui elememt can only be accessed by one UI Thread. CheckBox Requires UI Thread and your timer runs on different thread. 
            ///Simple code to use Dispatcher
            ///if you receive error an object reference is required for the non-static field, method.
            ///
            //Try catch om error te voorkomen wanneer de gebruiker de toepassing sluit (via sluitknop) wanneer de tv staat nog aan.
        }
    }
}
