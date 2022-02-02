using System;
using System.Windows;
using System.Windows.Threading;
using Shared;
using Shared.Repositories;

namespace Television
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        static SqlRepository repo = new SqlRepository();
        public MainWindow()
        {
            InitializeComponent();

            //als er veranderingen zijn in de database; deze functie aanspreken
            Worker.Instance.PropertyChanged += WorkerPropertyChanged;
            Worker.Instance.StartWorking();
        }

        private void WorkerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (Worker.Instance.TvOn.HasValue)
                    {

                        btn_ChannelUp.IsEnabled = Worker.Instance.TvOn.Value;
                        btn_ChannelDown.IsEnabled = Worker.Instance.TvOn.Value;
                        btn_Source.IsEnabled = Worker.Instance.TvOn.Value;
                        btn_VolumeUp.IsEnabled = Worker.Instance.TvOn.Value;
                        btn_VolumeDown.IsEnabled = Worker.Instance.TvOn.Value;

                        if (Worker.Instance.TvOn.Value)
                        {


                            var tv = Worker.Instance.LatestCurrentTv;
                            if (tv == null) return;
                            switch (tv.Source)
                            {
                                case 1:
                                    txt_CurrentSource.Text = "Current Source: tv";
                                    break;
                                case 2:
                                    txt_CurrentSource.Text = "Current Source: hdmi1";
                                    break;
                                case 3:
                                    txt_CurrentSource.Text = "Current Source: hdmi2";
                                    break;

                                default:
                                    txt_CurrentSource.Text = null;
                                    break;
                            }

                            txt_CurrentChannel.Text = "Current Channel: " + tv.Channel.ToString();
                            txt_CurrentVolume.Text = "Current Volume: " + tv.Volume.ToString();
                        }
                        else
                        {
                            txt_CurrentSource.Text = "Current Source: ";
                            txt_CurrentChannel.Text = "Current Channel: ";
                            txt_CurrentVolume.Text = "Current Volume: ";

                        }
                    }
                });
            }
            catch (OperationCanceledException)
            {
            }
        }

        public void btn_OnOff_Click(object sender, RoutedEventArgs e)
        {
            var tv = repo.GetLastTvSettings();
            // update on/off button
            if (!repo.GetPowerStatus())
            {
                repo.SetCurrentTv(tv.Channel, tv.Volume, tv.Source);
                repo.SetPowerStatus(true);
            }
            else
            {
                //stopzetten van Startworking en scherm op default waarden plaatsen
                repo.SetPowerStatus(false);
            }
        }
        //sluiten van window wanneer tv nog aanligt.
        private void Window_Closed(object sender, EventArgs e)
        {
            Worker.Instance.StopWorking();
            repo.SetPowerStatus(false);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void btn_ChannelUp_Click(object sender, RoutedEventArgs e)
        {
            //aanvullen bij source 2 (hdmi1) en 3 (hdmi2) niet mogelijk om kanalen te wijzigen
            if (repo.GetPowerStatus() && repo.GetSource() == 1)
            {
                repo.ChannelUp();
            }
        }

        private void btn_ChannelDown_Click(object sender, RoutedEventArgs e)
        {
            //aanvullen bij source 2 (hdmi1) en 3 (hdmi2) niet mogelijk om kanalen te wijzigen
            if (repo.GetPowerStatus() && repo.GetSource() == 1)
            {
                repo.ChannelDown();
            }

        }

        private void btn_VolumeUp_Click(object sender, RoutedEventArgs e)
        {
            if (repo.GetPowerStatus())
            {
                repo.VolumeUp();
            }
        }

        private void btn_VolumeDown_Click(object sender, RoutedEventArgs e)
        {
            if (repo.GetPowerStatus())
            {
                repo.VolumeDown();
            }

        }

        private void btn_Source_Click(object sender, RoutedEventArgs e)
        {
            if (repo.GetPowerStatus())
            {
                repo.SetSource();
            }
        }
    }
}
