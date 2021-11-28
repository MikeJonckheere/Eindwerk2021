using Remote.Program;
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


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
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


    }
}
