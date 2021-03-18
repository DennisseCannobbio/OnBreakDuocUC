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
using System.Windows.Threading;


namespace OnBreak.Presentación
{
    /// <summary>
    /// Lógica de interacción para AdministracionClientes.xaml
    /// </summary>
    public partial class AdministracionContrato : MetroWindow
    {
        Manejadora mane = new Negocios.Manejadora();

        public AdministracionContrato(bool blank, Cliente cli, bool rest, bool cort, Contract cnt)
        {
            InitializeComponent();
            DispatcherTimer crono = new System.Windows.Threading.DispatcherTimer();
            crono.Tick += new EventHandler(dispatcherTimer_Tick);
            crono.Interval = new TimeSpan(0, 5, 0);
            crono.Start();
            HideAll();
            AllInit();
            grbCoffeeBreak.Visibility = Visibility.Visible;
            HideAmb();
            if (rest)
            {
                Restore();
            }
            if (!blank)
            {
                Restore();
                this.FillClient(cli);
            }
            if (cort)
            {
                this.FillContract(cnt);
                HideUnmod();
            }
        }

        public void AllInit()
        {
            txtBuscar.Text = "";
            txtRutCliente.Text = "";
            txtCAss.Text = "";
            txtObservacion.Text = "";
            txtPersonalAdicional.Text = "";
            txtUf.Text = "";
            lbRazon.Content = "";
            cmbTipoEv.ItemsSource = Enum.GetValues(typeof(TipoEvento));
            cmbTipoEv.SelectedIndex = 0;
            cmbCofMod.ItemsSource = Enum.GetValues(typeof(TipoCoff));
            cmbCofMod.SelectedIndex = 0;
            cmbCockMod.ItemsSource = Enum.GetValues(typeof(TipoCock));
            cmbCockMod.SelectedIndex = 0;
            cmbAmbCk.ItemsSource = Enum.GetValues(typeof(Ambientacion));
            cmbAmbCk.SelectedIndex = 0;
            cmbCenaMod.ItemsSource = Enum.GetValues(typeof(TipoCena));
            cmbCenaMod.SelectedIndex = 0;
            cmbAmbCe.ItemsSource = Enum.GetValues(typeof(Ambientacion));
            cmbAmbCe.SelectedIndex = 0;
            lblFecIni.Visibility = Visibility.Visible;
            dpkStartDte.Visibility = Visibility.Visible;
            dpkStartDte.SelectedDate = DateTime.Now.AddDays(1);
            lblFecTer.Visibility = Visibility.Visible;
            dpkFTerm.Visibility = Visibility.Visible;
            dpkFTerm.SelectedDate = DateTime.Now.AddDays(3);
            dpkStartDte.SelectedDate = DateTime.Now.AddDays(1);
            dpkFTerm.SelectedDate = DateTime.Now.AddDays(3);
            cbkRealized.IsChecked = false;
            lbNumberContract.Content = "";

        }

        private void FillClient(Cliente cli)
        {
            txtRutCliente.Text = cli.Rut;
            lbRazon.Content = cli.RazonSocial;
        }

        private void FillContract(Contract cnt)
        {
            txtRutCliente.Text = cnt.Client;
            dpkStartDte.SelectedDate = cnt.Start;
            dpkFTerm.SelectedDate = cnt.Finish;
            txtCAss.Text = cnt.Assist.ToString();
            txtPersonalAdicional.Text = cnt.Additional.ToString();
            txtObservacion.Text = cnt.Observation;
            cmbTipoEv.SelectedItem = (TipoEvento)cnt.EvType;
            lbNumberContract.Content = cnt.Number;
            dpkCreacionContrato.SelectedDate = cnt.Creation;
            dpkTerminarContrato.SelectedDate = cnt.End;
            cbkRealized.IsChecked = cnt.Realized;

            Cliente cli = new Cliente()
            {
                Rut = cnt.Client
            };
            cli.Read();
            lbRazon.Content = cli.RazonSocial;
            switch (cmbTipoEv.SelectedIndex)
            {
                case 0:
                    CofeeBreak coff = new CofeeBreak()
                    {
                        Number = cnt.Number
                    };
                    coff.Read();

                    cmbCofMod.SelectedItem = coff.Mod;
                    cbkVeg.IsChecked = coff.Veg;
                    break;

                case 1:
                    Cocktail cock = new Cocktail()
                    {
                        Number = cnt.Number
                    };
                    cock.Read();

                    cmbCockMod.SelectedItem = cock.Mod;
                    cbkAmbCk.IsChecked = cock.HasAmbient;
                    cmbAmbCk.SelectedItem = cock.Ambient;
                    cbkAmbMusCk.IsChecked = cock.AmbientMusic;
                    cbkCliMusCk.IsChecked = cock.ClientMusic;
                    break;

                case 2:
                    Cena cen = new Cena()
                    {
                        Number = cnt.Number
                    };
                    cen.Read();

                    cmbCenaMod.SelectedItem = cen.Mod;
                    cmbAmbCe.SelectedItem = cen.IdTipoAmbientacion;
                    cbkAmbMusCe.IsChecked = cen.MusicaAmbiental;
                    rbtLocalOb.IsChecked = cen.LocalOnBreak;
                    rbtLocalOt.IsChecked = cen.OtroLocalOnBreak;
                    txtUf.Text = cen.ValorArriendo.ToString();
                    break;


            }
        }

        private void btnLimpiarCliente_Click(object sender, RoutedEventArgs e)
        {
            AllInit();
        }

        private async void BtnAgregarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (CliCheck())
            {
                try
                {
                    switch (cmbTipoEv.SelectedIndex)
                    {
                        case 0:
                            CofeeBreak cb = new CofeeBreak(DateTime.Today, DateTime.Today.AddDays(2), txtRutCliente.Text, (DateTime)dpkStartDte.SelectedDate,
                                        (DateTime)dpkFTerm.SelectedDate, int.Parse(txtCAss.Text), int.Parse(txtPersonalAdicional.Text), txtObservacion.Text, (bool)cbkVeg.IsChecked, cmbCofMod.SelectedItem.ToString());

                            if (cb.Read())
                            {
                                await this.ShowMessageAsync("Aviso", string.Format(
                               "Contrato ya existe, no se puede agregar."));
                            }

                            else
                            {


                                if (cb.Create())
                                    await this.ShowMessageAsync("Aviso", string.Format(
                                    "Contrato creado con éxito."));

                                else
                                    await this.ShowMessageAsync("Error", string.Format(
                                    "No se pudo agregar el contrato."));
                            }
                            break;

                        case 1:
                            Cocktail ck = new Cocktail(DateTime.Today, DateTime.Today.AddDays(2), txtRutCliente.Text, (DateTime)dpkStartDte.SelectedDate,
                                        (DateTime)dpkFTerm.SelectedDate, int.Parse(txtCAss.Text), int.Parse(txtPersonalAdicional.Text), txtObservacion.Text,
                                        (bool)cbkAmbCk.IsChecked, (bool)cbkAmbMusCk.IsChecked, (bool)cbkCliMusCk.IsChecked, cmbCockMod.SelectedItem.ToString(),
                                        (int)cmbAmbCk.SelectedItem);

                            if (ck.Read())
                            {
                                await this.ShowMessageAsync("Aviso", string.Format(
                               "Contrato ya existe, no se puede agregar."));
                            }

                            else
                            {


                                if (ck.Create())
                                    await this.ShowMessageAsync("Aviso", string.Format(
                                    "Contrato creado con éxito."));

                                else
                                    await this.ShowMessageAsync("Error", string.Format(
                                    "No se pudo agregar el contrato."));
                            }
                            break;

                        case 2:
                            Cena ce = new Cena(DateTime.Today, DateTime.Today.AddDays(2), txtRutCliente.Text, (DateTime)dpkStartDte.SelectedDate,
                                                                    (DateTime)dpkFTerm.SelectedDate, int.Parse(txtCAss.Text), int.Parse(txtPersonalAdicional.Text), txtObservacion.Text,
                                                                    (int)cmbAmbCe.SelectedItem, (bool)cbkAmbMusCe.IsChecked, (bool)rbtLocalOb.IsChecked, (bool)rbtLocalOt.IsChecked,
                                                                    int.Parse(txtUf.Text), cmbCenaMod.SelectedItem.ToString());

                            if (ce.Read())
                            {
                                await this.ShowMessageAsync("Aviso", string.Format(
                               "Contrato ya existe, no se puede agregar."));
                            }

                            else
                            {


                                if (ce.Create())
                                    await this.ShowMessageAsync("Aviso", string.Format(
                                    "Contrato creado con éxito."));

                                else
                                    await this.ShowMessageAsync("Error", string.Format(
                                    "No se pudo agregar el contrato."));
                            }
                            break;
                    }
                }
                catch (Exception zz)
                {
                    MessageBox.Show(zz.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                AllInit();
            } else
            {
                await this.ShowMessageAsync("Error", string.Format(
                                    "El cliente no se encuentra registrado."));
            }
        }

        private async void BtnActualizarContrato_Click(object sender, RoutedEventArgs e)
        {

            if (UpdateContratoh())
            {
                AllInit();
                await this.ShowMessageAsync("Aviso", string.Format(
                "Contrato actualizado con éxito."));
            }

            else
            {
                await this.ShowMessageAsync("Error", string.Format(
                "No fue posible actualizar el Contrato"));
            }

        }

        private async void BtnTerminarContrato_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea terminar el contrato?." +
               " (Esta acción no se puede deshacer)",
                                         "Confirmación",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (DateTime.Now > (DateTime)dpkTerminarContrato.SelectedDate)
                    {
                        cbkRealized.IsChecked = true;
                        if (UpdateContratoh())
                        {
                            AllInit();
                            await this.ShowMessageAsync("Aviso", string.Format(
                            "Contrato terminado con éxito."));
                        }

                        else
                        {
                            await this.ShowMessageAsync("Error", string.Format(
                            "No fue posible terminar el Contrato"));
                        }
                    }

                    else
                    {
                        cbkRealized.IsChecked = false;
                        if (UpdateContratoh())
                        {
                            AllInit();
                            await this.ShowMessageAsync("Aviso", string.Format(
                            "Contrato terminado con éxito."));
                        }

                        else
                        {
                            await this.ShowMessageAsync("Error", string.Format(
                            "No fue posible terminar el Contrato"));
                        }
                    }
                }
                catch (Exception zz)
                {
                    await this.ShowMessageAsync("Error", string.Format(
                 "No fue posible terminar el Contrato"));
                }
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnListCl_Click(object sender, RoutedEventArgs e)
        {
            VentanaListadoClientes list = new VentanaListadoClientes(true, true);
            Backup();
            list.Show();
            this.Close();
        }

        private async void BtnBusCl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    Rut = txtRutCliente.Text
                };

                if (cli.Read())
                {
                    txtRutCliente.Text = cli.Rut;
                    lbRazon.Content = cli.RazonSocial;

                }

                else
                {
                    AllInit();
                    await this.ShowMessageAsync("¡Ups!", string.Format(
                    "No se ha encontrado el Cliente {0}", txtRutCliente.Text));
                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                AllInit();
            }
        }

        private void CmbTipoEv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbTipoEv.SelectedIndex)
            {
                case 0:
                    HideAll();
                    grbCoffeeBreak.Visibility = Visibility.Visible;
                    break;

                case 1:
                    HideAll();
                    grbCocktail.Visibility = Visibility.Visible;
                    break;

                case 2:
                    HideAll();
                    grbCena.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void HideAll()
        {
            grbCoffeeBreak.Visibility = Visibility.Hidden;
            grbCocktail.Visibility = Visibility.Hidden;
            grbCena.Visibility = Visibility.Hidden;
            grbBuscar.Visibility = Visibility.Hidden;
            txtUf.Visibility = Visibility.Hidden;
            lbvalArr.Visibility = Visibility.Hidden;
            txtUf.Text = "0";
            dpkCreacionContrato.Visibility = Visibility.Hidden;
            dpkTerminarContrato.Visibility = Visibility.Hidden;
            cbkRealized.Visibility = Visibility.Hidden;
        }

        private void HideAmb()
        {
            lbTipoAmbCk.Visibility = Visibility.Hidden;
            cmbAmbCk.Visibility = Visibility.Hidden;
            cbkCliMusCk.Visibility = Visibility.Hidden;
            cbkAmbMusCk.Visibility = Visibility.Hidden;
        }

        private void ShowAmb()
        {
            lbTipoAmbCk.Visibility = Visibility.Visible;
            cmbAmbCk.Visibility = Visibility.Visible;
            cbkCliMusCk.Visibility = Visibility.Visible;
            cbkAmbMusCk.Visibility = Visibility.Visible;
        }

        private void CbkAmbCk_Checked(object sender, RoutedEventArgs e)
        {
            ShowAmb();
        }

        private void CbkAmbCk_UnChecked(object sender, RoutedEventArgs e)
        {
            HideAmb();
        }

        private void BtnBuscarOn_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            grbBuscar.Visibility = Visibility.Visible;
        }

        private async void BtnCache_Click(object sender, RoutedEventArgs e)
        {
            Backup();
            await this.ShowMessageAsync("Aviso", string.Format(
                    "Se ha guardado el respaldo con éxito.", txtRutCliente.Text));
        }

        private async void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            Restore();
            await this.ShowMessageAsync("Aviso", string.Format(
                    "Se ha recuperado el respaldo con éxito.", txtRutCliente.Text));
        }

        private void HideUF(object sender, RoutedEventArgs e)
        {
            txtUf.Visibility = Visibility.Hidden;
            lbvalArr.Visibility = Visibility.Hidden;
            txtUf.Text = "0";
        }

        private void ShowUF(object sender, RoutedEventArgs e)
        {
            txtUf.Visibility = Visibility.Visible;
            lbvalArr.Visibility = Visibility.Visible;
            txtUf.Text = "";
        }
        private void Backup()
        {
            Save backup = Save.Instance;

            backup.BkRutCl = txtRutCliente.Text;
            backup.BkRzCl = lbRazon.Content.ToString();
            backup.BkStD = (DateTime)dpkStartDte.SelectedDate;
            backup.BkEnD = (DateTime)dpkFTerm.SelectedDate;
            backup.BkAss = txtCAss.Text;
            backup.BkAdd = txtPersonalAdicional.Text;
            backup.BkObs = txtObservacion.Text;
            backup.BkTypeIndex = cmbTipoEv.SelectedIndex;
            backup.BkId = lbNumberContract.Content.ToString();

            backup.BkCBModIndx = cmbCofMod.SelectedIndex;
            backup.BkCBVeg = (bool)cbkVeg.IsChecked;

            backup.BkCKModIndx = cmbCockMod.SelectedIndex;
            backup.BkCKHasAmb = (bool)cbkAmbCk.IsChecked;
            backup.BkCKAmbTipoIndx = cmbAmbCk.SelectedIndex;
            backup.BkCKAmbMus = (bool)cbkAmbMusCk.IsChecked;
            backup.BkCKCLiMus = (bool)cbkCliMusCk.IsChecked;

            backup.BkCeMod = cmbCenaMod.SelectedIndex;
            backup.BkCeAmbTipoIndx = cmbAmbCe.SelectedIndex;
            backup.BkCeAmbMus = (bool)cbkAmbMusCe.IsChecked;
            backup.BkCeCliMus = (bool)cbkCliMusCe.IsChecked;
            backup.BkCeLocOB = (bool)rbtLocalOb.IsChecked;
            backup.BkCeLocOther = (bool)rbtLocalOt.IsChecked;
            backup.BkCeValUf = txtUf.Text;

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Datos.bin";
            Serial.GuardarEnArchivo<Save>(path, backup);
            lb_ASave.Content = "Último Guardado: " + DateTime.Now.ToString();

        }

        private void Restore()
        {
            Save backup = Save.Instance;
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Datos.bin";
            backup = Serial.CargardeArchivo<Save>(path);

            txtRutCliente.Text = backup.BkRutCl;
            lbRazon.Content = backup.BkRzCl;
            dpkStartDte.SelectedDate = backup.BkStD;
            dpkFTerm.SelectedDate = backup.BkEnD;
            txtCAss.Text = backup.BkAss;
            txtPersonalAdicional.Text = backup.BkAdd;
            txtObservacion.Text = backup.BkObs;
            cmbTipoEv.SelectedIndex = backup.BkTypeIndex;
            cmbTipoEv.SelectedIndex = backup.BkTypeIndex;
            lbNumberContract.Content = backup.BkId;

            cmbCofMod.SelectedIndex = backup.BkCBModIndx;
            cbkVeg.IsChecked = backup.BkCBVeg;

            cmbCockMod.SelectedIndex = backup.BkCKModIndx;
            cbkAmbCk.IsChecked = backup.BkCKHasAmb;
            cmbAmbCk.SelectedIndex = backup.BkCKAmbTipoIndx;
            cbkAmbMusCk.IsChecked = backup.BkCKAmbMus;
            cbkCliMusCk.IsChecked = backup.BkCKCLiMus;

            cmbCenaMod.SelectedIndex = backup.BkCeMod;
            cmbAmbCe.SelectedIndex = backup.BkCeAmbTipoIndx;
            cbkAmbMusCe.IsChecked = backup.BkCeAmbMus;
            cbkCliMusCe.IsChecked = backup.BkCeCliMus;
            rbtLocalOb.IsChecked = backup.BkCeLocOB;
            rbtLocalOt.IsChecked = backup.BkCeLocOther;
            txtUf.Text = backup.BkCeValUf;
        }

        private bool CliCheck()
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    Rut = txtRutCliente.Text
                };
                if (cli.Read())
                {
                    return true;
                } else
                { 
                    return false;
                }
            } catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Backup();
            lb_ASave.Content = "Último Autoguardado: " + DateTime.Now.ToString();
        }

        private void BtnBuscarContratoList_Click(object sender, RoutedEventArgs e)
        {
            VentanaListadoContrato list = new VentanaListadoContrato(true);
            list.Show();
            this.Close();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contract con = new Contract()
                {
                    Number = txtBuscar.Text
                };

                con.ReadContract();
                FillContract(con);
                HideUnmod();
            }
            catch
            {
                await this.ShowMessageAsync("Error", string.Format(
                   "No se ha podido encontrar el contrato.", txtBuscar.Text));
            }

        }

        private bool UpdateContratoh()
        {
            try
            {
                switch (cmbTipoEv.SelectedIndex)
                {
                    case 0:
                        CofeeBreak cof = new CofeeBreak()
                        {
                            Number = lbNumberContract.Content.ToString(),
                            Creation = (DateTime)dpkCreacionContrato.SelectedDate,
                            End = (DateTime)dpkTerminarContrato.SelectedDate,
                            Client = txtRutCliente.Text,
                            Mode = (TipoCoff)cmbCofMod.SelectedItem,
                            EvType = (int)((TipoEvento)cmbTipoEv.SelectedItem),
                            Start = (DateTime)dpkStartDte.SelectedDate,
                            Finish = (DateTime)dpkFTerm.SelectedDate,
                            Assist = int.Parse(txtCAss.Text),
                            Additional = int.Parse(txtPersonalAdicional.Text),
                            Realized = (bool)cbkRealized.IsChecked,
                            Observation = txtObservacion.Text,
                            Veg = (bool)cbkVeg.IsChecked
                        };

                        if (cof.Update())
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }
                        break;

                    case 1:
                        Cocktail cock = new Cocktail()
                        {
                            Number = lbNumberContract.Content.ToString(),
                            Creation = (DateTime)dpkCreacionContrato.SelectedDate,
                            End = (DateTime)dpkTerminarContrato.SelectedDate,
                            Client = txtRutCliente.Text,
                            Mode = (TipoCock)cmbCockMod.SelectedItem,
                            EvType = (int)((TipoEvento)cmbTipoEv.SelectedItem),
                            Start = (DateTime)dpkStartDte.SelectedDate,
                            Finish = (DateTime)dpkFTerm.SelectedDate,
                            Assist = int.Parse(txtCAss.Text),
                            Additional = int.Parse(txtPersonalAdicional.Text),
                            Realized = (bool)cbkRealized.IsChecked,
                            Observation = txtObservacion.Text,
                            Ambient = (Ambientacion)cmbAmbCk.SelectedItem,
                            HasAmbient = (bool)cbkAmbCk.IsChecked,
                            AmbientMusic = (bool)cbkAmbMusCk.IsChecked,
                            ClientMusic = (bool)cbkCliMusCk.IsChecked
                        };

                        if (cock.Update())
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                        break;

                    case 2:
                        Cena ce = new Cena()
                        {
                            Number = lbNumberContract.Content.ToString(),
                            Creation = (DateTime)dpkCreacionContrato.SelectedDate,
                            End = (DateTime)dpkTerminarContrato.SelectedDate,
                            Client = txtRutCliente.Text,
                            TipoCena = (TipoCena)cmbCenaMod.SelectedItem,
                            EvType = (int)((TipoEvento)cmbTipoEv.SelectedItem),
                            Start = (DateTime)dpkStartDte.SelectedDate,
                            Finish = (DateTime)dpkFTerm.SelectedDate,
                            Assist = int.Parse(txtCAss.Text),
                            Additional = int.Parse(txtPersonalAdicional.Text),
                            Realized = (bool)cbkRealized.IsChecked,
                            Observation = txtObservacion.Text,
                            IdTipoAmbientacion = (int)((Ambientacion)cmbAmbCe.SelectedItem),
                            MusicaAmbiental = (bool)cbkAmbMusCe.IsChecked,
                            LocalOnBreak = (bool)rbtLocalOb.IsChecked,
                            OtroLocalOnBreak = (bool)rbtLocalOt.IsChecked,
                            ValorArriendo = double.Parse(txtUf.Text)
                        };

                        if (ce.Update())
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                        break;

                    default:
                        return false;
                        break;
                }

            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                AllInit();

                return false;
            }
        }

        private void HideUnmod()
        {
            cmbTipoEv.Visibility = Visibility.Hidden;
            lblTipoEv.Visibility = Visibility.Hidden; 
            dpkStartDte.Visibility = Visibility.Hidden;
            dpkFTerm.Visibility = Visibility.Hidden;
            lblFecIni.Visibility = Visibility.Hidden;
            lblFecTer.Visibility = Visibility.Hidden;
        }

        private void DpkStartDte_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpkStartDte.SelectedDate < DateTime.Today)
            {
                dpkStartDte.SelectedDate = DateTime.Today;
            }

        }

        private void DpkFTerm_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime elapsed = (DateTime)dpkStartDte.SelectedDate;
            if (dpkFTerm.SelectedDate < elapsed.AddDays(1))
            {
                dpkFTerm.SelectedDate = elapsed.AddDays(1);
            }
        }
    }
}
