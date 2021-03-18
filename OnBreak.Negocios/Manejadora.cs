using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Negocios
{
    public class Manejadora
    {
        public List<Cliente> ListarClientes()
        {
            List<Cliente> ListaClientes = new List<Cliente>();
            foreach (Datos.Cliente clie in Conexion.OnBreakBD.Cliente)
            {
                Cliente nuevoCliente = new Cliente(clie.RutCliente, clie.RazonSocial, clie.Direccion, clie.NombreContacto, clie.MailContacto, clie.Telefono, clie.IdActividadEmpresa, clie.IdTipoEmpresa);
                ListaClientes.Add(nuevoCliente);
            }
            return ListaClientes;
        }

        public List<Contract> ListarContratos()
        {
            List<Contract> ListaContratos = new List<Contract>();
            foreach (Datos.Contrato cont in Conexion.OnBreakBD.Contrato)
            {
                Contract nuevoContrato = new Contract( cont.Numero,cont.Creacion, cont.Termino, cont.RutCliente,
                                                        cont.FechaHoraInicio, cont.FechaHoraTermino, cont.Asistentes,
                                                        cont.PersonalAdicional, cont.Observaciones, cont.IdTipoEvento,
                                                        cont.ValorTotalContrato, cont.IdModalidad, cont.Realizado);
                ListaContratos.Add(nuevoContrato);
            }
            return ListaContratos;
        }

        public List<Cocktail> ListarContratosCocktail()
        {
            List<Cocktail> ListaCocktail = new List<Cocktail>();
            foreach (Datos.Cocktail cock in Conexion.OnBreakBD.Cocktail)
            {
                Cocktail nuevoCocktail = new Cocktail(cock.Contrato.Creacion, cock.Contrato.Termino,
                                                        cock.Contrato.RutCliente, cock.Contrato.FechaHoraInicio, cock.Contrato.FechaHoraTermino,
                                                        cock.Contrato.Asistentes, cock.Contrato.PersonalAdicional, cock.Contrato.Observaciones,
                                                        cock.Ambientacion, cock.MusicaAmbiental, cock.MusicaCliente, cock.Contrato.IdModalidad,
                                                        cock.IdTipoAmbientacion);
                ListaCocktail.Add(nuevoCocktail);
            }
            return ListaCocktail;
        }
    }
}
