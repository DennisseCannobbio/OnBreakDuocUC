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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using OnBreak.Negocios;

namespace OnBreak.Presentación
{
    /// <summary>
    /// Lógica de interacción para AdministracionClientes.xaml
    /// </summary>
    public partial class AdministracionClientes : MetroWindow
    {
        Manejadora mane = new Negocios.Manejadora();
        // blank = si carga con los datos en blanco o usa cli
        // cli = objeto cliente de Listado Cliente
        public AdministracionClientes(bool blank,Cliente cli)
        {
            InitializeComponent();
            cmbActividadEmpresa.ItemsSource = Enum.GetValues(typeof(ActividadEmpresa));
            cmbTipoEmpresa.ItemsSource = Enum.GetValues(typeof(TipoEmpresa));
            cmbActividadEmpresa.SelectedIndex = 0;
            cmbTipoEmpresa.SelectedIndex = 0;
            if (!blank)
            {
                this.FillClient(cli);
            }
        }

        private void FillClient(Cliente cli)
        {
            // llena los campos con el cliente traido desde
            // el listado
            txtRutCliente.Text = cli.Rut;
            txtRazonSocial.Text = cli.RazonSocial;
            txtDireccionCliente.Text = cli.Direccion;
            txtNombreCliente.Text = cli.NombreContacto;
            txtEmailCliente.Text = cli.Email;
            txtTelefonoCliente.Text = cli.Telefono;
            cmbActividadEmpresa.SelectedItem = cli.ActividadEmpresa;
            cmbTipoEmpresa.SelectedItem = cli.TipoEmpresa;
        }

        private void btnLimpiarCliente_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtRutCliente.Text = "";
            txtRazonSocial.Text = "";
            txtDireccionCliente.Text = "";
            txtNombreCliente.Text = "";
            txtEmailCliente.Text = "";
            txtTelefonoCliente.Text = "";
            cmbActividadEmpresa.SelectedIndex = 0;
            cmbTipoEmpresa.SelectedIndex = 0;
        }

        private async void BtnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente(txtRutCliente.Text, txtRazonSocial.Text, txtDireccionCliente.Text, txtNombreCliente.Text, txtEmailCliente.Text, txtTelefonoCliente.Text, (int)cmbActividadEmpresa.SelectedValue,
                                            (int)cmbTipoEmpresa.SelectedValue);
                if (cli.Read())
                {
                    await this.ShowMessageAsync("Aviso", string.Format(
                       "Cliente ya existe, no se puede agregar."));
                }

                else
                {


                    if (cli.Create())
                        await this.ShowMessageAsync("Aviso", string.Format(
                        "Cliente creado con éxito."));

                    else
                        await this.ShowMessageAsync("Error", string.Format(
                        "No se pudo agregar el cliente."));
                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Limpiar();
        }

        private async void BtnActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    Rut = txtRutCliente.Text,
                    RazonSocial = txtRazonSocial.Text,
                    Direccion = txtDireccionCliente.Text,
                    NombreContacto = txtNombreCliente.Text,
                    Email = txtEmailCliente.Text,
                    Telefono = txtTelefonoCliente.Text,
                    ActividadEmpresa = (ActividadEmpresa)(cmbActividadEmpresa.SelectedValue),
                    TipoEmpresa = (TipoEmpresa)(cmbTipoEmpresa.SelectedValue)
                };

                if (cli.Update())
                {
                    Limpiar();
                    await this.ShowMessageAsync("Aviso", string.Format(
                    "Cliente actualizado con éxito."));
                }

                else
                {
                    await this.ShowMessageAsync("Error", string.Format(
                    "No fue posible actualizar el Cliente"));
                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
            }
        }

        private async void BtnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    Rut = txtRutCliente.Text
                };



                if(cli.Delete())
                {
                    Limpiar();
                    await this.ShowMessageAsync("Aviso", string.Format(
                    "Cliente eliminado con éxito."));

                }

                else
                {
                    Limpiar();
                    await this.ShowMessageAsync("Aviso", string.Format(
                    "No fue posible eliminar el cliente."));
                }
            }
            catch (Exception zz )
            {
                MessageBox.Show(zz.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
            }
        }

        private async void BtnBuscarClienteRut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    Rut = txtRutCliente.Text
                };

                if(cli.Read())
                {
                    txtRutCliente.Text = cli.Rut;
                    txtRazonSocial.Text = cli.RazonSocial;
                    txtDireccionCliente.Text = cli.Direccion;
                    txtNombreCliente.Text = cli.NombreContacto;
                    txtEmailCliente.Text = cli.Email;
                    txtTelefonoCliente.Text = cli.Telefono;
                    cmbActividadEmpresa.SelectedValue = cli.ActividadEmpresa;
                    cmbTipoEmpresa.SelectedValue = cli.TipoEmpresa;
                }

                else
                {
                    Limpiar();
                    await this.ShowMessageAsync("¡Ups!", string.Format(
                    "No se ha encontrado el Cliente {0}" , txtRutCliente.Text));
                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClienteListado_Click(object sender, RoutedEventArgs e)
        {
            VentanaListadoClientes list = new VentanaListadoClientes(true, false);
            list.Show();
            this.Close();
        }
    }
}
