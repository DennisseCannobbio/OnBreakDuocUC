using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnBreak.Negocios;

namespace OnBreak.Test
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void CreateClientTest()
        {
            bool expected = true;
            Cliente cli = new Cliente()
            {
                Rut = "20295782K",
                RazonSocial = "Tengo Frío",
                Direccion = "Parque Agustinas 5517",
                NombreContacto = "Dennisse Cannobbio",
                Email = "dennissecannobbio@gmail.com",
                Telefono = "964162216",
                ActividadEmpresa = (ActividadEmpresa)1,
                TipoEmpresa = (TipoEmpresa)10
            };
            bool result = cli.Create();

            //Preguntamos si son iguales
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReadClientTest()
        {
            // Declarar un string para buscar y una de el valor esperado
            string expected = "Dennisse Cannobbio";
            string result = "";
            Cliente cli = new Cliente()
            {
                Rut = "20295782K"
            };
            cli.Read();
            result = cli.NombreContacto;
            // Preguntar si variables resultado y esperado son iguales
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UpdateClientTest()
        {
            string expected = "Tengo Rabia";
            Cliente cli = new Cliente()
            {
                Rut = "20295782K",
                RazonSocial = "Tengo Rabia",
                Direccion = "Parque Agustinas 5517",
                NombreContacto = "Dennisse Cannobbio",
                Email = "dennissecannobbio@gmail.com",
                Telefono = "964162216",
                ActividadEmpresa = (ActividadEmpresa)1,
                TipoEmpresa = (TipoEmpresa)10
            };

            cli.Update();
            string result = cli.RazonSocial;
            //Preguntamos si son iguales
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void DeleteClientTest()
        {
            // Declarar un string para buscar y una de el valor esperado
            bool expected = true;
            Cliente cli = new Cliente()
            {
                Rut = "20295782K"
            };
            bool result = cli.Delete();
            // Preguntar si variables resultado y esperado son iguales
            Assert.AreEqual(expected, result);
        }
    }


}
