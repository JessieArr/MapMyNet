using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace MapMyNet.Views
{
    /// <summary>
    /// Interaction logic for NetworkInterfacesView.xaml
    /// </summary>
    public partial class NetworkInterfacesView : UserControl
    {
        public NetworkInterfacesView()
        {
            InitializeComponent();

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterfaceList.ItemsSource = networkInterfaces;
        }
    }
}
