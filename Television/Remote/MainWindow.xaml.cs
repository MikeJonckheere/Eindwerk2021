
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

namespace Remote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        static bool Onoff = false; // we moeten dit een prop van maken + nog van de sql halen zodat het aangepast wordt bij wijzigen van tv. ook worker mss of iets anders? 
        static string keypad;
        static int channel;

        public MainWindow()
        {
            InitializeComponent();
            ListBox lbox_Logging = new ListBox();
            UpdateLoggingBox("Remote opgestart");
        }

        public void UpdateLoggingBox(string newevent) //stuur een string met de event naar hier.
        { 
            DateTime date1 = DateTime.Now;
            newevent = date1.ToLongTimeString() + "=> " + newevent;
            lbox_Logging.Items.Add(newevent);
        }

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            UpdateLoggingBox("Verzenden naar DB");

            //ProgRemote.send();
        }

        private void btn_OnoffR_Click(object sender, RoutedEventArgs e)
        {
            
            if (!Onoff)
            {
                Onoff = true;
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
                Onoff = false;
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
            Keypad("1");
        }

        private void btn_Num2_Click(object sender, RoutedEventArgs e)
        {
            Keypad("2");
        }

        private void btn_Num3_Click(object sender, RoutedEventArgs e)
        {
            Keypad("3");
        }

        private void btn_Num4_Click(object sender, RoutedEventArgs e)
        {
            Keypad("4");
        }

        private void btn_Num5_Click(object sender, RoutedEventArgs e)
        {
            Keypad("5");
        }

        private void btn_Num6_Click(object sender, RoutedEventArgs e)
        {
            Keypad("6");
        }

        private void btn_Num7_Click(object sender, RoutedEventArgs e)
        {
            Keypad("7");
        }

        private void btn_Num8_Click(object sender, RoutedEventArgs e)
        {
            Keypad("8");
        }

        private void btn_Num9_Click(object sender, RoutedEventArgs e)
        {
            Keypad("9");
        }

        private void btn_Num0_Click(object sender, RoutedEventArgs e)
        {
            Keypad("0");
        }
        public void Keypad(string input) //input van keypad.
        {
            
            
            keypad = keypad + string.Join("", input);
            channel = int.Parse(keypad);
            
            UpdateLoggingBox("Ingevoerde kanaal: "+channel);
        }


    }
}
