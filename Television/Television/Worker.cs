using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using Television.Repositories;



namespace Television
{
    public sealed class Worker
    {
        private static readonly Lazy<Worker> lazy = new Lazy<Worker>(() => new Worker());
        public static Worker Instance { get { return lazy.Value; } }
        public bool TvIsOn { get; set; }
        BackgroundWorker worker = new BackgroundWorker();
        static sqlRepository repo = new sqlRepository();
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

            }
                ///A ui elememt can only be accessed by one UI Thread. CheckBox Requires UI Thread and your timer runs on different thread. 
                ///Simple code to use Dispatcher
                ///if you receive error an object reference is required for the non-static field, method.
                ///
                //Try catch om error te voorkomen wanneer de gebruiker de toepassing sluit (via sluitknop) wanneer de tv staat nog aan.
        }
    }
}
