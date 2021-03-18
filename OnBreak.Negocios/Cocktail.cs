using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnBreak.Negocios
{
    public class Cocktail : Contract
    {
        #region atr
        private Ambientacion _ambient;
        private bool _hasAmbient;
        private bool _ambientMusic;
        private bool _clientMusic;
        private TipoCock _mode;
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


        #endregion

        #region prop

        public TipoCock Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public bool ClientMusic
        {
            get { return _clientMusic; }
            set { _clientMusic = value; }
        }


        public bool AmbientMusic
        {
            get { return _ambientMusic; }
            set { _ambientMusic = value; }
        }


        public bool HasAmbient
        {
            get { return _hasAmbient; }
            set { _hasAmbient = value; }
        }


        public Ambientacion Ambient
        {
            get { return _ambient; }
            set { _ambient = value; }
        }
        #endregion

        #region constructor
        public void CInit()
        {
            this.Init();
        }

        public Cocktail()
        {
            this.Number = string.Empty;
            this.Creation = DateTime.Now;
            this.End = DateTime.Now.AddDays(3);
            this.Client = "";
            this.Start = DateTime.Now.AddDays(1);
            this.Finish = DateTime.Now.AddDays(2);
            this.Assist = 1;
            this.Additional = 2;
            this.Realized = false;
            this.Total = 0.0;
            this.Observation = "-";
            this._hasAmbient = false;
            this._ambientMusic = false;
            this._clientMusic = false;
            this._mode = TipoCock.CO001;
            this.Mod = "CO001";
            this.EvType = 20;
            this.Realized = false;
        }

        public Cocktail(DateTime cre, DateTime en, string cli,
                        DateTime st, DateTime fin, int ass, int add, string obs, bool amb,
                        bool mus, bool clim, string mod, int ambId)
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
            this.HasAmbient = amb;
            if (amb)
            {
                this.AmbientMusic = mus;
                this.ClientMusic = clim;
            }
            else
            {
                this.AmbientMusic = false;
                this.ClientMusic = false;
            }
            Ambientacion ambient = (Ambientacion)ambId;
            this.Ambient = ambient;
            Enum.TryParse(mod, out TipoCock modo);
            this.Mode = modo;
            this.Mod = mod;
            this.EvType = 20;
            this.Realized = false;
            this.Total = this.CalcMonto();
        }
        #endregion

        #region Methods
        public double SetMonto()
        {
            switch (this.Mode)
            {
                case TipoCock.CO001:
                    return 6.0;
                    break;

                case TipoCock.CO002:
                    return 10.0;
                    break;

                default:
                    return 0;
                    break;
            }
        }

        public double CalcMonto()
        {
            double mon = SetMonto(); ;

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

            if (HasAmbient)
            {
                if (Ambient == Ambientacion.Basica)
                {
                    mon = mon + 2;
                }
                else
                {
                    mon = mon + 5;
                }
            }

            if (AmbientMusic)
            {
                mon = mon + 1;
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

                Datos.Cocktail coc = new Datos.Cocktail()
                {
                    Numero = this.Number,
                    IdTipoAmbientacion = (int)this.Ambient,
                    Ambientacion = this.HasAmbient,
                    MusicaAmbiental = this.AmbientMusic,
                    MusicaCliente = this.ClientMusic
                };

                Conexion.OnBreakBD.Entry(coc).State = EntityState.Added;
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

                Datos.Cocktail cock = (from auxpaa in Conexion.OnBreakBD.Cocktail
                                       where auxpaa.Numero == this.Number
                                       select auxpaa).First();

                Ambientacion ambient = (Ambientacion)cock.IdTipoAmbientacion;
                this.Ambient = ambient;
                this.HasAmbient = cock.Ambientacion;
                this.AmbientMusic = cock.MusicaAmbiental;
                this.ClientMusic = cock.MusicaCliente;

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
                var cock = (from c in Conexion.OnBreakBD.Cocktail
                            where c.Numero == Number
                            select c).SingleOrDefault();
                cock.Numero = this.Number;
                cock.IdTipoAmbientacion = (int)this.Ambient;
                cock.Ambientacion = this.HasAmbient;
                cock.MusicaAmbiental = this.AmbientMusic;
                cock.MusicaCliente = this.ClientMusic;

                Conexion.OnBreakBD.Entry(cock).State = EntityState.Modified;
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
                Datos.Cocktail cock = (from auxpa in Conexion.OnBreakBD.Cocktail
                                       where auxpa.Numero == this.Number
                                       select auxpa).First();
                Conexion.OnBreakBD.Cocktail.Remove(cock);
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
