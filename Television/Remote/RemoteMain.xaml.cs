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
using Shared.Repositories;

namespace Remote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SqlRepository repo = new SqlRepository();
        private static bool _volumeSaved = true;

        static bool OnOff { get; set; } = false; // we moeten dit een prop van maken + nog van de sql halen zodat het aangepast wordt bij wijzigen van tv. ook worker mss of iets anders? 
        static string Keypad { get; set; }
        static int Channel { get; set; }
        private int Source { get; set; }

        public static int Volume { get; private set; }

        public MainWindow()
        {

            InitializeComponent();
            UpdateLoggingBox("Remote opgestart");
        }

        public void UpdateLoggingBox(string newevent) //stuur een string met de event naar hier.
        {
            DateTime date1 = DateTime.Now;
            newevent = date1.ToLongTimeString() + "=> " + newevent;
            lbox_Logging.Items.Add(newevent);

            //Laatste Item Selecteren
            lbox_Logging.SelectedIndex = lbox_Logging.Items.Count - 1;
            lbox_Logging.ScrollIntoView(lbox_Logging.SelectedItem);

        }

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            UpdateLoggingBox("Verzenden naar DB");

            repo.SetCurrentTv(Channel, Volume, Source);
            _volumeSaved = true;
            Keypad =string.Empty;
        }

        private void btn_OnoffR_Click(object sender, RoutedEventArgs e)
        {

            if (!OnOff)
            {
                OnOff = true;
                btn_Num1.IsEnabled = true;
                btn_Num2.IsEnabled = true;
                btn_Num3.IsEnabled = true;
                btn_Num4.IsEnabled = true;
                btn_Num5.IsEnabled = true;
                btn_Num6.IsEnabled = true;
                btn_Num7.IsEnabled = true;
                btn_Num8.IsEnabled = true;
                btn_Num9.IsEnabled = true;
                btn_Num0.IsEnabled = true;
            }
            else
            {
                OnOff = false;
                btn_Num1.IsEnabled = false;
                btn_Num2.IsEnabled = false;
                btn_Num3.IsEnabled = false;
                btn_Num4.IsEnabled = false;
                btn_Num5.IsEnabled = false;
                btn_Num6.IsEnabled = false;
                btn_Num7.IsEnabled = false;
                btn_Num8.IsEnabled = false;
                btn_Num9.IsEnabled = false;
                btn_Num0.IsEnabled = false;
            }
        }

        private void lbox_Logging_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Num1_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("1");
        }

        private void btn_Num2_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("2");
        }

        private void btn_Num3_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("3");
        }

        private void btn_Num4_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("4");
        }

        private void btn_Num5_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("5");
        }

        private void btn_Num6_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("6");
        }

        private void btn_Num7_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("7");
        }

        private void btn_Num8_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("8");
        }

        private void btn_Num9_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("9");
        }

        private void btn_Num0_Click(object sender, RoutedEventArgs e)
        {
            ChangeChannelNr("0");
        }
        public void ChangeChannelNr(string input) //input van keypad.
        {
            //als huidig aantal nummers 3 (of groter); dan reset je eerst de kepad naar een lege string zodat je weer opnieuw begint intypen
            if (Keypad?.Length >= 3)
                Keypad = string.Empty;

            Keypad = Keypad + input;
            Channel = int.Parse(Keypad);

            UpdateLoggingBox($"Ingevoerde kanaal: {Channel}");
        }

        private void btn_TV_Click(object sender, RoutedEventArgs e)
        {
            //1 = Current Source: tv"
            //2 = Current Source: hdmi1"
            //3 = Current Source: hdmi2"
            Source = 1;

            UpdateLoggingBox("Source naar: TV");
        }

        private void btn_HDMI1_Click(object sender, RoutedEventArgs e)
        {
            //1 = Current Source: tv"
            //2 = Current Source: hdmi1"
            //3 = Current Source: hdmi2"
            Source = 2;

            UpdateLoggingBox("Source naar: HDMI1");
        }

        private void btn_HDMI2_Click(object sender, RoutedEventArgs e)
        {
            //1 = Current Source: tv"
            //2 = Current Source: hdmi1"
            //3 = Current Source: hdmi2"
            Source = 3;

            UpdateLoggingBox("Source naar: HDMI2");
        }

        private void btn_Volume_Up_Click(object sender, RoutedEventArgs e)
        {
            VolumeUp();
        }

        private void VolumeUp()
        {
            GetVolumeIfUnsaved();
            if (Volume < 10) Volume += 1;
            _volumeSaved = false;
            UpdateLoggingBox($"Volume: {Volume}");
        }

        private static void GetVolumeIfUnsaved()
        {
            if (_volumeSaved)
            {
                var tv = repo.GetLastTvCurrentTv();
                Volume = tv.Volume;
            }
        }

        private void btn_Volume_Down_Click(object sender, RoutedEventArgs e)
        {
            btnDown();
        }

        private void btnDown()
        {
            GetVolumeIfUnsaved();
            if (Volume > 0) Volume -= 1;
            _volumeSaved = false;
            UpdateLoggingBox($"Volume: {Volume}");
        }
    }
}
