using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Television.Models;
using Television.Repositories;

namespace Television
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        static sqlRepository repo = new sqlRepository();
        public MainWindow()
        {
            InitializeComponent();
            var worker = Worker.Instance;
            repo.SetPowerStatus((byte)0);
        }

        public void btn_OnOff_Click(object sender, RoutedEventArgs e)
        {
            var tvs = repo.GetTvSettings();
            Worker.Instance.TvIsOn = repo.GetPowerStatus();

            if (!Worker.Instance.TvIsOn)
            {
                foreach (var tv in tvs)
                {
                    repo.SetCurrentTv(tv.Channel, tv.Volume, tv.Source);
                }

                Worker.Instance.TvIsOn = true;
                Worker.Instance.StartWorking();
                repo.SetPowerStatus((byte)1);
            }
            else
            {
                //stopzetten van Startworking en scherm op default waarden plaatsen
                Worker.Instance.TvIsOn = false;
                Worker.Instance.StopWorking();
                repo.SetPowerStatus((byte)0);

                Application.Current.Dispatcher.BeginInvoke(
                  DispatcherPriority.Background,
                  new Action(() =>
                  {
                      txt_CurrentChannel.Text = "Current Channel: ";
                      txt_CurrentVolume.Text = "Current Volume: ";
                  }));
            }
        }
        //sluiten van window wanneer tv nog aanligt.
        private void Window_Closed(object sender, EventArgs e)
        {
            Worker.Instance.TvIsOn = false;
            Worker.Instance.StopWorking();
            repo.SetPowerStatus((byte)0);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void btn_ChannelUp_Click(object sender, RoutedEventArgs e)
        {
            if (Worker.Instance.TvIsOn)
            {
                repo.ChannelUp();
            }
        }

        private void btn_ChannelDown_Click(object sender, RoutedEventArgs e)
        {
            if (Worker.Instance.TvIsOn)
            {
                repo.ChannelDown();
            }

        }

        private void btn_VolumeUp_Click(object sender, RoutedEventArgs e)
        {
            if (Worker.Instance.TvIsOn)
            {
                repo.VolumeUp();
            }
        }

        private void btn_VolumeDown_Click(object sender, RoutedEventArgs e)
        {
            if (Worker.Instance.TvIsOn)
            {
                repo.VolumeDown();
            }

        }
    }
}
