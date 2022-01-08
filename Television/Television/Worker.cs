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

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (TvIsOn)
            {
                ///A ui elememt can only be accessed by one UI Thread. CheckBox Requires UI Thread and your timer runs on different thread. 
                ///Simple code to use Dispatcher
                ///if you receive error an object reference is required for the non-static field, method.
                ///
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var tvs = repo.GetCurrentValues();
                    foreach (var tv in tvs)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentChannel.Text = "Current Channel: " + tv.SettingsChannel.ToString();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).txt_CurrentVolume.Text = "Current Volume: " + tv.SettingsVolume.ToString();
                    }
                });
            }
        }
    }
}
