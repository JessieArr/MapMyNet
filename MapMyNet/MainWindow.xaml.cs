using MapMyNet.Services;
using MapMyNet.Views;
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

namespace MapMyNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            mDNSService.Start();
            InitializeComponent();
            this.MainContent.Content = new NetworkInterfacesView();
        }

        private void NetworkInterfaces_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new NetworkInterfacesView();
        }

        private void mDNS_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new mDNSView();
        }

        private void IPv4_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new IPv4View();
        }
    }
}
