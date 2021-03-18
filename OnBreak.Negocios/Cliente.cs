using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnBreak.Negocios
{
    public class Cliente
    {
        #region Atributos
        private string _rut;
        private string _razonSocial;
        private string _direccion;
        private string _nombreContacto;
        private string _email;
        private string _telefono;
        private ActividadEmpresa _actEmp;
        private TipoEmpresa _tipoEmp;
        #endregion

        #region Propiedades
        public string Email
        {
            get { return _email; }
            set { if (value.Trim() != string.Empty)
                    _email = value;
                else
                    throw new ArgumentException("Nombre no debe estar vacío");
            }
        }
        public string NombreContacto
        {
            get { return _nombreContacto; }
            set {   if (value.Split(' ').Length >= 2)
                    _nombreContacto = value;
                else
                    throw new ArgumentException("Debe ingresar nombre y apellido");
            }
        }

        public TipoEmpresa TipoEmpresa
        {
            get { return _tipoEmp; }
            set { _tipoEmp = value; }
        }


        public ActividadEmpresa ActividadEmpresa
        {
            get { return _actEmp; }
            set { _actEmp = value; }
        }


        public string Telefono
        {
            get { return _telefono; }
            set
            {
                if (value.Trim() != string.Empty)
                    _telefono = value;
                else
                    throw new ArgumentException("Telefono no debe estar vacío.");
            }
        }


        public string Direccion
        {
            get { return _direccion; }
            set { if(value.Trim() != string.Empty)
                    _direccion = value;
                else
                    throw new ArgumentException("Dirrección no debe estar vacía.");
            }
        }


        public string RazonSocial
        {
            get { return _razonSocial; }
            set { if( value.Trim() != string.Empty)
                _razonSocial = value;
                else
                    throw new ArgumentException("Razón Social no debe estar vacía.");
            }
        }

        public string Rut
        {
            get { return _rut; }
            set
            {
                if (value.Trim() != string.Empty && value.Length >= 9)
                    _rut = value;
                else
                    throw new ArgumentException("El RUT debe tener como mínimo 9 digitos.");
            }
        }
        #endregion

        #region Constructores
        public void Init()
        {

        }

        public Cliente()
        {
            _rut = string.Empty;
            _razonSocial = string.Empty;
            _direccion = string.Empty;
            _nombreContacto = string.Empty;
            _email = string.Empty;
            _telefono = string.Empty;
            _actEmp = ActividadEmpresa.Agropecuaria;
            _tipoEmp = TipoEmpresa.SPA;
        }

        public Cliente(string rut, string razonsocial, string direccion, string nombreContacto, string email, string telefono, int  actEmp, int tipoEmp)
        {
            this.Rut = rut;
            this.RazonSocial = razonsocial;
            this.Direccion = direccion;
            this.NombreContacto = nombreContacto;
            this.Email = email;
            this.Telefono = telefono;
            //MyEnum enum = (MyEnum) myInt;
            ActividadEmpresa act = (ActividadEmpresa)actEmp;
            this.ActividadEmpresa = act;
            TipoEmpresa te = (TipoEmpresa)tipoEmp;
            this.TipoEmpresa = te;
        }
        #endregion

        #region Metodos

        #endregion

        #region CRUD
        public bool Create()
        {
            try
            {
                Datos.Cliente cli = new Datos.Cliente()
                {
                    //Aquí se pone el nombre en que está en la base de datos :3
                    RutCliente = Rut,
                    RazonSocial = RazonSocial,
                    Direccion = Direccion,
                    NombreContacto = NombreContacto,
                    MailContacto = Email,
                    Telefono = Telefono,
                    IdActividadEmpresa = (int)ActividadEmpresa,
                    IdTipoEmpresa = (int)TipoEmpresa
                };

                Conexion.OnBreakBD.Cliente.Add(cli);
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
                Datos.Cliente cli = (from c in Conexion.OnBreakBD.Cliente
                            where c.RutCliente == this.Rut
                            select c).First();
                this.Rut = cli.RutCliente;
                this.RazonSocial = cli.RazonSocial;
                this.Direccion = cli.Direccion;
                this.NombreContacto = cli.NombreContacto;
                this.Email = cli.MailContacto;
                this.Telefono = cli.Telefono;
                ActividadEmpresa act = (ActividadEmpresa)cli.IdActividadEmpresa;
                this.ActividadEmpresa = act;
                TipoEmpresa te = (TipoEmpresa)cli.IdTipoEmpresa;
                this.TipoEmpresa = te;
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
                //Datos.Cliente cli = Conexion.OnBreakBD.Cliente.First(c => c.RutCliente == Rut);
                var cli = (from c in Conexion.OnBreakBD.Cliente
                                 where c.RutCliente == Rut
                                 select c).SingleOrDefault();
                cli.RutCliente = this.Rut;
                cli.RazonSocial = this.RazonSocial;
                cli.Direccion = this.Direccion;
                cli.NombreContacto = this.NombreContacto;
                cli.MailContacto = this.Email;
                cli.Telefono = this.Telefono;
                cli.IdActividadEmpresa = (int)this.ActividadEmpresa;
                cli.IdTipoEmpresa = (int)this.TipoEmpresa;

                Conexion.OnBreakBD.Entry(cli).State = EntityState.Modified;
                Conexion.OnBreakBD.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                Datos.Cliente cli = (from auxpa in Conexion.OnBreakBD.Cliente
                                     where auxpa.RutCliente == this.Rut
                                     select auxpa).First();

                Conexion.OnBreakBD.Cliente.Remove(cli);
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
