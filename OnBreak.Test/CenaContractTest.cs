using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnBreak.Negocios;

namespace OnBreak.Test
{
    [TestClass]
    public class CenaTest
    {
        [TestMethod]
        public void CreateCenaTest()
        {
            bool expected = true;
            Cena cen = new Cena()
            {
                Number = "121212120",
                Creation = DateTime.Now,
                End = DateTime.Now,
                Client = "20295782K",
                TipoCena = TipoCena.CE001,
                EvType = 30,
                Start = DateTime.Now,
                Finish = DateTime.Now,
                Assist = 10,
                Additional = 20,
                Realized = true,
                Total = 987654321,
                Observation = "Probanding",
                IdTipoAmbientacion = 10,
                MusicaAmbiental = true,
                LocalOnBreak = true,
                OtroLocalOnBreak = false,
                ValorArriendo = 150000

            };
            bool result = cen.Create();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReadCenaTest()
        {
            // Declarar un string para buscar y una de el valor esperado
            string expected = "20295782K";
            string result = "";
            Cena cen = new Cena()
            {
                Number = "121212120"
            };
            cen.Read();
            result = cen.Client;
            // Preguntar si variables resultado y esperado son iguales
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UpdateCenaTest()
        {
            string expected = "Funco";
            Cena cen = new Cena()
            {
                Number = "121212120",
                Creation = DateTime.Now,
                End = DateTime.Now,
                Client = "20295782K",
                TipoCena = TipoCena.CE001,
                EvType = 30,
                Start = DateTime.Now,
                Finish = DateTime.Now,
                Assist = 10,
                Additional = 20,
                Realized = true,
                Total = 987654321,
                Observation = "Funco",
                IdTipoAmbientacion = 10,
                MusicaAmbiental = true,
                LocalOnBreak = false,
                OtroLocalOnBreak = true,
                ValorArriendo = 120000
            };

            cen.Update();
            string result = cen.Observation;
            //Preguntamos si son iguales
            Assert.AreEqual(expected, result);
        }

    }
}
