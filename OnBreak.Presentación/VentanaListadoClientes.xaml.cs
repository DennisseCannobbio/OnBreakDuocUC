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
    /// Lógica de interacción para VentanaListadoClientes.xaml
    /// </summary>
    public partial class VentanaListadoClientes : MetroWindow
    {

        Manejadora mane = new Manejadora();
        List<Cliente> aux; // List auxiliar para los reultados de filtro -> los va a guardar 
        public bool summ; //Variable estatica para ver si se llamo desde Administración de Clientes
        public bool filter = false; //PAra ver si hay filtros activos
        public bool cont = false;

        // Constructor pide un bool para determinar si es instanciado desde la main o
        // administracion de clientes
        public VentanaListadoClientes(bool inv, bool ctr)
        {
            InitializeComponent();
            cmbActividadEmpresaFiltro.ItemsSource = Enum.GetValues(typeof(ActividadEmpresa));
            cmbTipoEmpresaFiltro.ItemsSource = Enum.GetValues(typeof(TipoEmpresa));
            cmbActividadEmpresaFiltro.SelectedIndex = 0;
            cmbTipoEmpresaFiltro.SelectedIndex = 0;
            filter = false;
            // Comprueba el estado del bool, ocultando los botones pertinentes
            if (!inv) //Para ocultar el boton de editar en la seccion de Listado Clientes.
            {
                btnEditar.Visibility = Visibility.Hidden;
                summ = false;
            }
            else
            {
                summ = true;
                if(!ctr)
                {
                    cont = false;
                } else
                {
                    cont = true;
                }
            }
        }

        private async void BtnMostrarListClientes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dtgListadoClientes.ItemsSource = (
                                                    from ent in mane.ListarClientes()
                                                    select new
                                                    {
                                                        Rut = ent.Rut,
                                                        RazonSocial = ent.RazonSocial,
                                                        Direccion = ent.Direccion,
                                                        NombreContacto = ent.NombreContacto,
                                                        Email = ent.Email,
                                                        Telefono = ent.Telefono,
                                                        ActividadEmpresa = ent.ActividadEmpresa,
                                                        TipoEmpresa = ent.TipoEmpresa
                                                    }).ToList();
            }
            catch (Exception zz)
            {
                await this.ShowMessageAsync("Error", string.Format(
                    "No se han encontrado clientes."));
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            if (!summ)
            {
                this.Close();
            }
            else //Si  se llama de administracion -> vacío
            {
                if (cont)
                {
                    AdministracionContrato aco = new AdministracionContrato(true, null, false, false, null);
                    aco.Show();
                    this.Close();
                }
                else
                {
                    AdministracionClientes ven = new AdministracionClientes(true, null);
                    ven.Show();
                    this.Close();
                }
            }
        }

        private async void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            // Obtiene la posicion del cliente seleccionado
            int pos = dtgListadoClientes.SelectedIndex;
            // Comprueba si hay un cliente seleccionado
            if (dtgListadoClientes.SelectedItem != null)
            {
                if (!filter)
                {
                    // busca el indice en el list y asigna a objeto transfer
                    Cliente transfer = mane.ListarClientes()[pos];
                    if (cont)
                    {
                        AdministracionContrato aco = new AdministracionContrato(false, transfer, false, false, null);
                        aco.Show();
                        this.Close();
                    }
                    else
                    { 
                    AdministracionClientes ven = new AdministracionClientes(false, transfer);
                    ven.Show();
                    this.Close();
                    }
                }
                else
                {
                    //Se busca el indice en el list auxiliar y se asigna al objeto transfer
                    Cliente transfer = aux[pos];
                    if (cont)
                    {
                        AdministracionContrato aco = new AdministracionContrato(false, transfer, false, false, null);
                        aco.Show();
                        this.Close();
                    }
                    else
                    {
                        AdministracionClientes ven = new AdministracionClientes(false, transfer);
                        ven.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                await this.ShowMessageAsync("¡Ups!", string.Format(
                    "Debe seleccionar un cliente."));
            }
        }

        private void BtnFiltrarList_Click(object sender, RoutedEventArgs e)
        {
            //var -> buscar que es -> varible de c# 
            // En este metodo se crea la lista filtrada en el que la condicion sea Tipo Empresa y Actvidad empresa.
           
               var result = mane.ListarClientes().OfType<Cliente>().Where(c => c.TipoEmpresa ==
                                               (TipoEmpresa)cmbTipoEmpresaFiltro.SelectedItem &&
                                                c.ActividadEmpresa == (ActividadEmpresa)cmbActividadEmpresaFiltro.SelectedItem); //Item es para string u objeto INdex es el orden
                aux = result.ToList(); // --> Traspasa el resultado del filtro a una lista auxiliar :3 1)

            if (txtRutFiltro.Text != null)
            {
                result = aux.OfType<Cliente>().Where(c => c.Rut.StartsWith(txtRutFiltro.Text)); //Filtra la lista aux por Rut
                aux = result.ToList(); //Actualiza la lista auxiliar con el nuevo filtro Rut
                filter = true; // --> Establece que se ha utilizado un filtro.
                dtgListadoClientes.ItemsSource = result; //Muestra en el datagrid
            }

            else
            {
                filter = true;
                dtgListadoClientes.ItemsSource = result;
            }
        }
    }
}
