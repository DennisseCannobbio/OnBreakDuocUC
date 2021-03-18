using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace OnBreak.Negocios
{
    public class Contract
    {
        #region atr
        private string _number;
        private DateTime _creation;
        private DateTime _end;
        private string _client;
        private DateTime _start;
        private DateTime _finish;
        private int _assist;
        private int _additional;
        private bool _realized;
        private double _total;
        private string _observation;
        private int _evType;
        private string _mod;

        public string Mod
        {
            get { return _mod; }
            set { _mod = value; }
        }

        #endregion

        #region prop

        public int EvType
        {
            get { return _evType; }
            set { _evType = value; }
        }

        public string Observation
        {
            get { return _observation; }
            set { if(value.Trim() != string.Empty)
                    if (value.Length <= 250)
                    {
                        _observation = value;
                    }
                    else
                    {
                        throw new ArgumentException("Este campo no debe tener más de 250 carácteres");
                    }
                   
                else
                {
                    throw new ArgumentException("No debe estar vacío este campo");
                }
            }
        }


        public double Total
        {
            get { return _total; }
            set { _total = value; }
        }


        public bool Realized
        {
            get { return _realized; }
            set { _realized = value; }
        }


        public int Additional
        {
            get { return _additional; }
            set { if(value != 0)
                    if (value >= 2)
                    {
                        _additional = value;
                    }
                    else
                    {
                        throw new ArgumentException("El mínimo que puede ingresar de personal es 2");
                    }
               
                else
                {
                    throw new ArgumentException("Debe ingresar número de personal adicional");
                }
            }
        }


        public int Assist
        {
            get { return _assist; }
            set { if(value > 0)
                {
                    _assist = value;
                }
                else
                {
                    throw new ArgumentException("Debe ingresar asistentes");
                }
                }
        }

        public DateTime Finish
        {
            get { return _finish; }
            set { _finish = value; }
        }


        public DateTime Start
        {
            get { return _start; }
            set { _start = value;}
        }

        public string Client
        {
            get { return _client; }
            set { _client = value; }
        }


        public DateTime End
        {
            get { return _end; }
            set { _end = value; }
        }


        public DateTime Creation
        {
            get { return _creation; }
            set { _creation = value; }
        }


        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }


        #endregion

        #region cons
        public void Init()
        {

        }

        public Contract()
        {
            _number = "";
            _creation = DateTime.Now;
            _end = DateTime.Now.AddDays(3);
            _client = "";
            _start = DateTime.Now.AddDays(1);
            _finish = DateTime.Now.AddDays(2);
            _assist = 1;
            _additional = 2;
            //_realized = false;
            _total = 0.0;
            _observation = "-";
            _evType = 0;
        }

        public Contract(string num, DateTime cre, DateTime en, string cli,
                        DateTime st, DateTime fin, int ass, int add, string obs, int et,
                        double total, string mod, bool real)
        {
            this.Number = num;
            this.Creation = cre;
            this.End = en;
            this.Client = cli;
            this.Start = st;
            this.Finish = fin;
            this.Assist = ass;
            this.Additional = add;
            this.Total = total;
            this.Observation = obs;
            this.EvType = et;
            this.Mod = mod;
            this.Realized = real;
        }
        #endregion

        #region methods
        public string SetID()
        {
            string yr = DateTime.Now.Year.ToString();
            string mo = DateTime.Now.Month.ToString("D2");
            string da = DateTime.Now.Day.ToString("D2");
            string ho = DateTime.Now.Hour.ToString("D2");
            string mi = DateTime.Now.Minute.ToString("D2");
            return yr + mo + da + ho + mi;
            /*if ((int)DateTime.Now.Month < 10)
            {
                return yr + "0" + mo + da + ho + mi;
            }
            else
            {
                return yr + mo + da + ho + mi;
            }*/
        }
        #endregion

        #region CRUD
        public bool CreateContract()
        {
            try
            {
                Datos.Contrato con = new Datos.Contrato()
                {
                    Numero = this.Number,
                    Creacion = this.Creation,
                    Termino = this.End,
                    RutCliente = this.Client,
                    IdModalidad = this.Mod,
                    IdTipoEvento = this.EvType,
                    FechaHoraInicio = this.Start,
                    FechaHoraTermino = this.Finish,
                    Asistentes = this.Assist,
                    PersonalAdicional = this.Additional,
                    Realizado = this.Realized,
                    ValorTotalContrato = this.Total,
                    Observaciones = this.Observation
                };

                Conexion.OnBreakBD.Contrato.Add(con);
                Conexion.OnBreakBD.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ReadContract()
        {
            try
            {
                Datos.Contrato con = (from auxpaa in Conexion.OnBreakBD.Contrato
                                      where auxpaa.Numero == this.Number
                                      select auxpaa).First();
                this.Number = con.Numero;
                this.Creation = con.Creacion;
                this.End = con.Termino;
                this.Client = con.RutCliente;
                this.Start = con.FechaHoraInicio;
                this.Finish = con.FechaHoraTermino;
                this.Assist = con.Asistentes;
                this.Additional = con.PersonalAdicional;
                this.Total = con.ValorTotalContrato;
                this.Observation = con.Observaciones;
                this.EvType = con.IdTipoEvento;
                this.Mod = con.IdModalidad;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateContract()
        {
            try
            {
                var con = (from c in Conexion.OnBreakBD.Contrato
                           where c.Numero == Number
                           select c).SingleOrDefault();
                con.Numero = this.Number;
                con.Creacion = this.Creation;
                con.Termino = this.End;
                con.RutCliente = this.Client;
                con.FechaHoraInicio = this.Start;
                con.FechaHoraTermino = this.Finish;
                con.Asistentes = this.Assist;
                con.PersonalAdicional = this.Additional;
                con.ValorTotalContrato = this.Total;
                con.Observaciones = this.Observation;
                con.IdTipoEvento = this.EvType;
                con.IdModalidad = this.Mod;
                con.Realizado = this.Realized;

                Conexion.OnBreakBD.Entry(con).State = EntityState.Modified;
                Conexion.OnBreakBD.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //No accesible desde interfaz, solo para testeo
        public bool DeleteContract()
        {
            try
            {
                Datos.Contrato con = (from auxpa in Conexion.OnBreakBD.Contrato
                                      where auxpa.Numero == this.Number
                                      select auxpa).First();
                Conexion.OnBreakBD.Contrato.Remove(con);
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

