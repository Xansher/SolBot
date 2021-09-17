using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;


namespace SolBot
{
    /// <summary>
    /// Logika interakcji dla klasy ChooserWindow.xaml
    /// </summary>
    public partial class ChooserWindow : Window
    {
        public ChooserWindow()
        {
            InitializeComponent();
            Process[] x = Process.GetProcessesByName("Imperianic OpenGL");
            Process[] p = Process.GetProcessesByName("RealeraOGL");
            Process[] l = Process.GetProcessesByName("otclient_gl");
            Process[] d = Process.GetProcessesByName("Giveria");
            Process[] t = Process.GetProcessesByName("DBKOx32");
            this.clients = t;
            List<TibiaClient> items = new List<TibiaClient>();
           /* for (int i = 0; i < p.Length; i++)
            {
                items.Add(new TibiaClient() { Id = i, Pid = p[i].Id, Client = p[i].MainWindowTitle });
            }*/
            for (int i = 0; i < t.Length; i++)
            {
                items.Add(new TibiaClient() { Id = i, Pid = t[i].Id, Client = t[i].MainWindowTitle });
            }


            ClientsList.ItemsSource = items;
        }
        Process[] clients;
        
        private void OpenWindow(object sender, RoutedEventArgs e)
        {
         
            MainWindow main = new MainWindow(clients[ClientsList.SelectedIndex]);
            this.Visibility = Visibility.Hidden;
            this.Close();
            main.Show();
        }
    }
    public class TibiaClient
    {
        public int Id { get; set; }

        public int Pid { get; set; }

        public string Client { get; set; }
    }
}
