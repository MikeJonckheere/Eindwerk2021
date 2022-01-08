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

        public MainWindow()
        {
            InitializeComponent();
            var worker = Worker.Instance;
        }

        public void btn_OnOff_Click(object sender, RoutedEventArgs e)
        {

            //stopzetten van Startworking en scherm op default waarden plaatsen
            if (Worker.Instance.TvIsOn)
            {
                Worker.Instance.TvIsOn = false;
                
                //stopzetten RunWorkerAsync
                //txt_CurrentChannel.Text = "Current Channel: test off button";
                //txt_CurrentVolume.Text = "Current Volume: test off button";

            }
            else
            {
                Worker.Instance.TvIsOn = true;
                Worker.Instance.StartWorking();
            }
        }
    }
}
