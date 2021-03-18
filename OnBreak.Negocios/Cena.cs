using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnBreak.Negocios
{
    public class Cena : Contract
    {

        #region Atributos
        private int _idTipoAmbientacion;
        private bool _musicaAmbiental;
        private bool _localOnBreak;
        private bool _otroLocalOnBreak;
        private double _valorArriendo;
        private TipoCena _tipoCena;
        private double _valor;
        private double _valorTotal;
        #endregion

        #region Propiedades

        public double ValorTotal
        {
            get { return _valorTotal; }
            set { _valorTotal = value; }
        }


        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public TipoCena TipoCena
        {
            get { return _tipoCena; }
            set { _tipoCena = value; }
        }

        public double ValorArriendo
        {
            get { return _valorArriendo; }
            set { _valorArriendo = value; }
        }

        public bool OtroLocalOnBreak
        {
            get { return _otroLocalOnBreak; }
            set { _otroLocalOnBreak = value; }
        }


        public bool LocalOnBreak
        {
            get { return _localOnBreak; }
            set { _localOnBreak = value; }
        }


        public bool MusicaAmbiental
        {
            get { return _musicaAmbiental; }
            set { _musicaAmbiental = value; }
        }


        public int IdTipoAmbientacion
        {
            get { return _idTipoAmbientacion; }
            set { _idTipoAmbientacion = value; }
        }

        #endregion

        #region Constructor
        public void CeInit()
        {
            this.Init();
        }

        public Cena()
        {
            Number = "";
            Creation = DateTime.Now;
            End = DateTime.Now.AddDays(3);
            Client = "";
            Start = DateTime.Now.AddDays(1);
            Finish = DateTime.Now.AddDays(2);
            Assist = 1;
            Additional = 2;
            Realized = false;
            Total = 0.0;
            Observation = "-";
            EvType = 0;
            _idTipoAmbientacion = 0;
            _musicaAmbiental = false;
            _localOnBreak = false;
            _otroLocalOnBreak = false;
            _valorArriendo = 0;
            _tipoCena = TipoCena.CE001;
            Mod = "CE001";
            this.EvType = 30;
            this.Realized = false;
        }

        public Cena(DateTime creation, DateTime end, string client, DateTime start, DateTime finish, int assist,
                    int additional, string obs, int idTipoAmbientacion, bool musicaAmbiental,
                    bool localOnBreak, bool otroLocalOnBreak, int valorArriendo, string tipoCena)
        {
            //this.Number = this.SetID();
            this.Creation = creation;
            this.End = end;
            this.Client = client;
            this.Start = start;
            this.Finish = finish;
            this.Assist = assist;
            this.Additional = additional;
            this.Observation = obs;
            this.EvType = 30;
            this.IdTipoAmbientacion = idTipoAmbientacion;
            this.MusicaAmbiental = musicaAmbiental;
            this.LocalOnBreak = localOnBreak;
            this.OtroLocalOnBreak = otroLocalOnBreak;
            if (otroLocalOnBreak)
            {
                this.ValorArriendo = valorArriendo;
            }
            else
            {
                this.ValorArriendo = 0;
            }
            Enum.TryParse(tipoCena, out TipoCena modo);
            this.TipoCena = modo;
            this.Mod = tipoCena;
            this.EvType = 30;
            this.Realized = false;
            this.Total = this.CalcMonto();

        }
        #endregion

        #region Metodos
        public double SetMonto()
        {
            switch (this.TipoCena)
            {
                case TipoCena.CE001:
                    return 25.0;
                    break;

                case TipoCena.CE002:
                    return 35.0;
                    break;

                default:
                    return 0;
                    break;
            }
        }

        public double CalcMonto()
        {
            double mon = SetMonto();

            if (Assist >= 1 && Assist <= 20)
            {
                mon = mon + 4;
            }
            else if (Assist >= 21 && Assist <= 50)
            {
                mon = mon + 6;
            }
            else if (Assist > 50)
            {
                int add = Assist - 50;
                add = (add / 20) * 2;
                mon = mon + 5 + add;
            }

            if (Additional == 2)
            {
                mon = mon + 2;
            }
            else if (Additional == 3)
            {
                mon = mon + 3;
            }
            else if (Additional == 4)
            {
                mon = mon + 3.5;
            }
            else if (Additional > 4)
            {
                double extr = (Additional - 4) * 0.5;
                mon = mon + 3.5 + extr;
            }
            return mon;
        }
        #endregion

        #region CRUD
        public bool Create()
        {
            try
            {
                this.Number = SetID();
                CreateContract();

                Datos.Cenas cena = new Datos.Cenas()
                {
                    Numero = this.Number,
                    IdTipoAmbientacion = this.IdTipoAmbientacion,
                    MusicaAmbiental = this.MusicaAmbiental,
                    LocalOnBreak = this.LocalOnBreak,
                    OtroLocalOnBreak = this.OtroLocalOnBreak,
                    ValorArriendo = this.ValorArriendo
                };

                Conexion.OnBreakBD.Entry(cena).State = EntityState.Added;
                Conexion.OnBreakBD.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                ReadContract();
                Datos.Cenas cen = (from auxpaa in Conexion.OnBreakBD.Cenas
                                   where auxpaa.Numero == this.Number
                                   select auxpaa).First();

                this.IdTipoAmbientacion = cen.IdTipoAmbientacion;
                this.MusicaAmbiental = cen.MusicaAmbiental;
                this.LocalOnBreak = cen.LocalOnBreak;
                this.OtroLocalOnBreak = cen.OtroLocalOnBreak;
                this.ValorArriendo = cen.ValorArriendo;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                this.Total = CalcMonto();
                UpdateContract();
                var cen = (from c in Conexion.OnBreakBD.Cenas
                           where c.Numero == Number
                           select c).SingleOrDefault();
                cen.Numero = this.Number;
                cen.IdTipoAmbientacion = this.IdTipoAmbientacion;
                cen.MusicaAmbiental = this.MusicaAmbiental;
                cen.LocalOnBreak = this.LocalOnBreak;
                cen.OtroLocalOnBreak = this.OtroLocalOnBreak;
                cen.ValorArriendo = this.ValorArriendo;

                Conexion.OnBreakBD.Entry(cen).State = EntityState.Modified;
                Conexion.OnBreakBD.SaveChanges();
                return true;

            }
            catch 
            {
                return false;
            }
        }
        #endregion
    }
}
