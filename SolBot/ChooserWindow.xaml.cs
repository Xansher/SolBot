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
            var processList = new List<Process[]>();
            Process[] x = Process.GetProcessesByName("Imperianic OpenGL");
            Process[] p = Process.GetProcessesByName("RealeraGL");
            Process[] l = Process.GetProcessesByName("otclient_gl");
            Process[] d = Process.GetProcessesByName("Giveria");
            Process[] t = Process.GetProcessesByName("DBKOx32");
            Process[] dbl = Process.GetProcessesByName("DBLClient");
            Process[] realesta = Process.GetProcessesByName("RealeraGL-1654182380-1658507991-1663507042-1669398384");
            processList.Add(x);
            processList.Add(p);
            processList.Add(l);
            processList.Add(d);
            processList.Add(t);
            processList.Add(dbl);
            processList.Add(realesta);
            //this.clients = t;
            List<TibiaClient> items = new List<TibiaClient>();


            /* for (int i = 0; i < p.Length; i++)
             {
                 items.Add(new TibiaClient() { Id = i, Pid = p[i].Id, Client = p[i].MainWindowTitle });
             }*/
            var id = 0;
            processList.ForEach(process =>
           {
               
               for (int i = 0; i < process.Length; i++)
               {
                   items.Add(new TibiaClient() { Id = id, Pid = process[i].Id, Client = process[i].MainWindowTitle });
                   clients.Add(process[i]);
                   id++;
               }
           });
            /*
            for (int i = 0; i < t.Length; i++)
            {
                items.Add(new TibiaClient() { Id = i, Pid = t[i].Id, Client = t[i].MainWindowTitle });
            }*/


            ClientsList.ItemsSource = items;
           
        }
        List<Process> clients = new List<Process>();
        
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
