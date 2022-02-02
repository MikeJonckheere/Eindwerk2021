using Remote.Repositories;
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
using Remote.Models;

namespace Remote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static sqlRepository repo = new sqlRepository();
        public static string numPad;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Onoff_Click(object sender, RoutedEventArgs e)
        {
            numPad = null;
            var remote = repo.GetTvSettings();
            if (!repo.GetPowerStatus())
            {
                repo.SetCurrentTv(remote[0].Channel, remote[0].Volume, remote[0].Source);
                repo.SetPowerStatus((byte)1);
                txt_Log.Text = txt_Log.Text + $"Power on\n";
            }
            else
            {
                repo.SetPowerStatus((byte)0);
                txt_Log.Text = txt_Log.Text + $"Power off\n";
                repo.ClearCurrentTV();
            }
            txt_Log.ScrollToEnd();
        }

        private void btn_ChannelUp_Click(object sender, RoutedEventArgs e)
        {
            numPad = null;
            if (repo.GetPowerStatus() && repo.GetSource() == 1)
            {
                (int oldChannel, int newChannel) = repo.ChannelUp(); ;
                txt_Log.Text = txt_Log.Text + $"Channel +1 from {oldChannel} to {newChannel}\n";
            }
            else if (!repo.GetPowerStatus())
            {
                txt_Log.Text = txt_Log.Text + $"Power off - no channel+ change allowed\n";
            }
            else
            {
                txt_Log.Text = txt_Log.Text + $"No channels available in this source\n";
            }
            txt_Log.ScrollToEnd();
        }

        private void btn_ChannelDown_Click(object sender, RoutedEventArgs e)
        {
            numPad = null;
            if (repo.GetPowerStatus() && repo.GetSource() == 1)
            {
                (int oldChannel, int newChannel) = repo.ChannelDown(); ;
                txt_Log.Text = txt_Log.Text + $"Channel -1 from {oldChannel} to {newChannel}\n";
            }
            else if (!repo.GetPowerStatus())
            {
                txt_Log.Text = txt_Log.Text + $"Power off - no channel- change allowed\n";
            }
            else
            {
                txt_Log.Text = txt_Log.Text + $"No channels available in this source\n";
            }
            txt_Log.ScrollToEnd();

        }

        private void btn_VolumeUp_Click(object sender, RoutedEventArgs e)
        {
            numPad = null;
            if (repo.GetPowerStatus())
            {
                (int oldVolume, int newVolume) = repo.VolumeUp();
                txt_Log.Text = txt_Log.Text + $"Volume +1 from {oldVolume} to {newVolume}\n";
            }
            else
            {
                txt_Log.Text = txt_Log.Text + $"Power off - no volume+ change allowed\n";
            }
            txt_Log.ScrollToEnd();
        }

        private void btn_VolumeDown_Click(object sender, RoutedEventArgs e)
        {
            numPad = null;
            if (repo.GetPowerStatus())
            {
                (int oldVolume, int newVolume) = repo.VolumeDown();
                txt_Log.Text = txt_Log.Text + $"Volume -1 from {oldVolume} to {newVolume}\n";
            }
            else
            {
                txt_Log.Text = txt_Log.Text + $"Power off - no volume- change allowed\n";
            }
            txt_Log.ScrollToEnd();
        }

        private void btn_Source_Click(object sender, RoutedEventArgs e)
        {
            numPad = null;
            if (repo.GetPowerStatus())
            {
                (string oldSource, string newSource) = repo.SetSource();
                txt_Log.Text = txt_Log.Text + $"Change source from {oldSource} to {newSource}\n";
            }
            else
            {
                txt_Log.Text = txt_Log.Text + $"Power off - no source change allowed\n";
            }
            txt_Log.ScrollToEnd();
        }

        private void btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            numPad = null;
            if (repo.GetPowerStatus())
            {
                (int channel, int volume, int source) = repo.SetTvSettings();
                txt_Log.Text = txt_Log.Text + $"Save channel:{channel}, volume:{volume}, source:{source} as startup settings \n";
            }
            else
            {
                txt_Log.Text = txt_Log.Text + $"Power off - no settings save allowed\n";
            }
            txt_Log.ScrollToEnd();

        }
        private void btn_Numpad_Click(object sender, RoutedEventArgs e)
        {
            if (repo.GetPowerStatus() && repo.GetSource() == 1 && (numPad == null || numPad.Length < 3))
            {
                Button btn = e.Source as Button;
                numPad = numPad + btn.Content.ToString();
                txt_Log.Text = txt_Log.Text + $"channel:{numPad} \n";
            }
            else if (repo.GetPowerStatus() && repo.GetSource() == 1 && numPad.Length >= 3)
            {
                txt_Log.Text = txt_Log.Text + $"Value too high. Enter new value \n";
                numPad = null;
            }
            else if (repo.GetPowerStatus() && repo.GetSource() != 1)
            {
                txt_Log.Text = txt_Log.Text + $"Source must be TV to change channel. \n";
                numPad = null;
            }
            else
            {
                txt_Log.Text = txt_Log.Text + $"Power off - no sending allowed\n";
            }
            txt_Log.ScrollToEnd();

        }

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            if (repo.GetPowerStatus() && numPad != null && repo.GetSource() == 1)
            {
                if (repo.SendChannelNumPad(numPad))
                {
                    txt_Log.Text = txt_Log.Text + $"value numpad sended successfull \n";
                }
                else
                {
                    txt_Log.Text = txt_Log.Text + $"value numpad not valid \n";
                }
                numPad = null;
            }
            else if (repo.GetPowerStatus() && numPad == null && repo.GetSource() == 1)
            {
                txt_Log.Text = txt_Log.Text + $"No channel entered in numpad. \n";
            }
            else if (repo.GetPowerStatus() && repo.GetSource() != 1)
            {
                txt_Log.Text = txt_Log.Text + $"Source must be TV to change channel. \n";
            }
            else
            {
                txt_Log.Text = txt_Log.Text + $"Power off - no sending allowed\n";
            }
            txt_Log.ScrollToEnd();
        }


        //Onderstaande is puur zodat je de programma nog kan afsluiten en verplaatsen, zelf zonder bar bovenaan.

        private void btn_Closeapp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


    }
}
