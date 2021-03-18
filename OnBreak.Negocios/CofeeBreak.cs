using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace OnBreak.Negocios
{
    public class CofeeBreak : Contract
    {
        private bool _veg;
        private TipoCoff _mode;
        private double _monto;
        private double _montoTotal;

        public double MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }


        public double Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }


        public TipoCoff Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }


        public bool Veg
        {
            get { return _veg; }
            set { _veg = value; }
        }

        public void CBInit()
        {

        }

        public CofeeBreak()
        {
            this.Number = string.Empty;
            this.Creation = DateTime.Now;
            this.End = DateTime.Now.AddDays(3);
            this.Client = "";
            this.Start = DateTime.Now.AddDays(1);
            this.Finish = DateTime.Now.AddDays(2);
            this.Assist = 1;
            this.Additional = 2;
            //this.Realized = false;
            this.Total = 0.0;
            this.Observation = "-";
            this._veg = true;
            this._mode = TipoCoff.CB001;
            this.Mod = "CB001";
            this.EvType = 10;
            //this.Realized = false;
        }

        public CofeeBreak( DateTime cre, DateTime en, string cli,
                        DateTime st, DateTime fin, int ass, int add, string obs, bool veg,
                        string mod)
        {
            //this.Number = this.SetID();
            this.Creation = cre;
            this.End = en;
            this.Client = cli;
            this.Start = st;
            this.Finish = fin;
            this.Assist = ass;
            this.Additional = add;
            this.Observation = obs;
            this.Veg = veg;
            Enum.TryParse(mod, out TipoCoff modo);
            this.Mode = modo;
            this.Mod = mod;
            this.EvType = 10;
            //this.Realized = false;
            this.Total = this.CalcMonto();
        }
        

        public double SetMonto()
        {
            switch (this.Mode)
            {
                case TipoCoff.CB001:
                    return 3.0;
                break;

                case TipoCoff.CB002:
                    return 8.0;
                break;

                case TipoCoff.CB003:
                    return 12.0;
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
                mon = mon + 3;
            }
            else if (Assist >= 21 && Assist <= 50)
            {
                mon = mon + 5;
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

        public bool Create()
        {
            try
            {
                this.Number = SetID();
                CreateContract();

                Datos.CoffeeBreak cof = new Datos.CoffeeBreak()
                {
                    Numero = SetID(),
                    Vegetariana = this.Veg
                };

                Conexion.OnBreakBD.Entry(cof).State = EntityState.Added;
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

                Datos.CoffeeBreak coff = (from auxpaa in Conexion.OnBreakBD.CoffeeBreak
                                          where auxpaa.Numero == this.Number
                                          select auxpaa).First();
                this.Veg = coff.Vegetariana;
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
                var coff = (from c in Conexion.OnBreakBD.CoffeeBreak
                            where c.Numero == Number
                            select c).SingleOrDefault();
                coff.Numero = this.Number;
                coff.Vegetariana = this.Veg;

                Conexion.OnBreakBD.Entry(coff).State = EntityState.Modified;
                Conexion.OnBreakBD.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //No accesible desde interfaz, solo para testeo
        public bool Delete()
        {
            try
            {
                DeleteContract();
                Datos.CoffeeBreak coff = (from auxpa in Conexion.OnBreakBD.CoffeeBreak
                                          where auxpa.Numero == this.Number
                                          select auxpa).First();

                Conexion.OnBreakBD.CoffeeBreak.Remove(coff);
                Conexion.OnBreakBD.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

