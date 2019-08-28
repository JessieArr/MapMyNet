using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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
    /// Interaction logic for IPv4View.xaml
    /// </summary>
    public partial class IPv4View : UserControl
    {
        public IPv4View()
        {
            InitializeComponent();

            IPAddress myIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                myIP = endPoint.Address;
                MyIPAddress.Content = myIP.ToString();
            }

            foreach (var adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (myIP.Equals(unicastIPAddressInformation.Address))
                        {
                            SubnetMask.Content = unicastIPAddressInformation.IPv4Mask.ToString();
                        }
                    }
                }
            }
        }
    }
}
