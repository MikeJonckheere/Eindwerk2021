﻿using System;
using System.Windows;
using System.Windows.Threading;
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
            repo.SetPowerStatus((byte)0);
            Worker.Instance.TvIsOn = true;
            Worker.Instance.StartWorking();
        }

        public void btn_OnOff_Click(object sender, RoutedEventArgs e)
        {
            var tv = repo.GetLastTvSettings();
            // update on/off button
            if (!repo.GetPowerStatus())
            {
                repo.SetCurrentTv(tv.Channel, tv.Volume, tv.Source);
                repo.SetPowerStatus((byte)1);
            }
            else
            {
                //stopzetten van Startworking en scherm op default waarden plaatsen
                repo.SetPowerStatus((byte)0);
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