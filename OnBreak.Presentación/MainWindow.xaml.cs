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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using OnBreak.Negocios;
using System.IO;

namespace OnBreak.Presentación
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Datos.bin"))
            {
                BackupRestore();
            }
        }

       private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TileAdmCli_Click(object sender, RoutedEventArgs e)
        {
            AdministracionClientes ac = new AdministracionClientes(true, null);
            ac.Show();
        }

        private void TileAdmCon_Click(object sender, RoutedEventArgs e)
        {
            AdministracionContrato acon = new AdministracionContrato(true, null, false, false, null);
            acon.Show();
        }

        private  void TileListCon_Click(object sender, RoutedEventArgs e)
        {
            VentanaListadoContrato  vcon = new VentanaListadoContrato(false);
            vcon.Show();
        }

        private void TileListCli_Click(object sender, RoutedEventArgs e)
        {
            VentanaListadoClientes vc = new VentanaListadoClientes(false, false);
            vc.Show();
        }
        
        private void BackupRestore()
        {
            MessageBoxResult result = MessageBox.Show("Se ha detectado un respaldo de la sesión anterior." +
                " ¿Desea restaurarlo?",
                                          "Confirmación",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                AdministracionContrato acon = new AdministracionContrato(true, null, true, false, null);
                acon.Show();
            }
            else if (result == MessageBoxResult.No)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Datos.bin";
                File.Delete(path);
            }
        }
    }
}