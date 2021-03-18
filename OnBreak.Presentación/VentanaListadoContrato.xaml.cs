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
using System.Data;
using System.Data.Common;

namespace OnBreak.Presentación
{
    /// <summary>
    /// Lógica de interacción para VentanaListadoContrato.xaml
    /// </summary>
    public partial class VentanaListadoContrato : MetroWindow
    {
        Manejadora mane = new Manejadora();
        List<Contract> aux;
        public bool summ; //Variable estática para ver si se llamo desde Administración de Clientes
        public bool filter = false;
        protected DataSet dataSet;
        public VentanaListadoContrato(bool inv)
        {
            InitializeComponent();
            cmbTipoEventoFiltro.ItemsSource = Enum.GetValues(typeof(TipoEvento));
            cmbTipoEventoFiltro.SelectedIndex = 0;
            rbtNoFilter.IsChecked = true;
            filter = false;
            if (!inv)
            {
                btnEditarContrato.Visibility = Visibility.Hidden;
                summ = false;
            }
            else
            {
                summ = true;
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void BtnMostrarListContratos_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dtgListarContrato.ItemsSource = (
                                                 from contr in mane.ListarContratos()
                                                 select new
                                                 {
                                                     Numero = contr.Number,
                                                     Creacion = contr.Creation,
                                                     Termino = contr.End,
                                                     RutCliente = contr.Client,
                                                     IdModalidad = contr.Mod,
                                                     IdTipoEvento = contr.EvType,
                                                     FechaHoraInicio = contr.Start,
                                                     FechaHoraTermino = contr.Finish,
                                                     Asistentes = contr.Assist,
                                                     PersonalAdicional = contr.Additional,
                                                     Realizado = contr.Realized,
                                                     ValorTotalContrato = contr.Total,
                                                     Observaciones = contr.Observation
                                                 }).ToList();

            }
            catch (Exception zz)
            {
                await this.ShowMessageAsync("Error", string.Format(
                    "No se ha encontrado contratos"));
            }
        }

        private async void BtnEditarContrato_Click(object sender, RoutedEventArgs e)
        {
            int pos = dtgListarContrato.SelectedIndex;
            if (dtgListarContrato.SelectedItem != null)
            {
                if (!filter)
                {
                    Contract transfer = mane.ListarContratos()[pos];
                    AdministracionContrato ven = new AdministracionContrato(true, null, false, true, transfer);
                    ven.Show();
                    this.Close();
                }
                else
                {
                    Contract transfer = aux[pos];
                    AdministracionContrato aco = new AdministracionContrato(true, null, false, true, transfer);
                    aco.Show();
                    this.Close();
                }
            }
            else
            {
                await this.ShowMessageAsync("¡Ups!", string.Format(
                    "Debe seleccionar un contrato."));
            }
        }

        private void CmbTipoEventoFiltro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbTipoEventoFiltro.SelectedIndex)
            {
                case 0:
                    cmbModalidadServicioFiltro.ItemsSource = Enum.GetValues(typeof(TipoCoff));
                    cmbModalidadServicioFiltro.SelectedIndex = 0;
                    break;

                case 1:
                    cmbModalidadServicioFiltro.ItemsSource = Enum.GetValues(typeof(TipoCock));
                    cmbModalidadServicioFiltro.SelectedIndex = 0;
                    break;

                case 2:
                    cmbModalidadServicioFiltro.ItemsSource = Enum.GetValues(typeof(TipoCena));
                    cmbModalidadServicioFiltro.SelectedIndex = 0;
                    break;
            }
        }

        private void BtnFiltrarList_Click(object sender, RoutedEventArgs e)
        {

            var resultCB = mane.ListarContratos().OfType<Contract>().Where(c => c.EvType ==
                                       (int)((TipoEvento)cmbTipoEventoFiltro.SelectedItem) &&
                                        c.Mod == cmbModalidadServicioFiltro.SelectedItem.ToString()); //Item es para string u objeto INdex es el orden
            aux = resultCB.ToList(); // --> Traspasa el resultado del filtro a una lista auxiliar :3 1)

            if ((bool)rbtRut.IsChecked)
            {
                resultCB = aux.OfType<Contract>().Where(c => c.Client.StartsWith(txtRutFiltro.Text)); //Filtra la lista aux por Rut
                aux = resultCB.ToList(); //Actualiza la lista auxiliar con el nuevo filtro Rut
                filter = true; // --> Establece que se ha utilizado un filtro.
                dtgListarContrato.ItemsSource = resultCB; //Muestra en el datagrid
            }

            else if ((bool)rbtConNumb.IsChecked)
            {
                resultCB = aux.OfType<Contract>().Where(c => c.Number.StartsWith(txtNumero.Text)); //Filtra la lista aux por Rut
                aux = resultCB.ToList(); //Actualiza la lista auxiliar con el nuevo filtro Rut
                filter = true; // --> Establece que se ha utilizado un filtro.
                dtgListarContrato.ItemsSource = resultCB; //Muestra en el datagrid
            }
            else if ((bool)rbtNoFilter.IsChecked)
            {
                filter = true;
                dtgListarContrato.ItemsSource = resultCB;
            }
        }
    }
}
