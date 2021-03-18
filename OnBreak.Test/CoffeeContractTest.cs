using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnBreak.Negocios;

namespace OnBreak.Test
{
    [TestClass]
    public class CoffeeContractTest
    {
        [TestMethod]
        public void CreateCoffeeTest()
        {
            bool expected = true;
            CofeeBreak cof = new CofeeBreak()
            {
                Number = "201906300848",
                Creation = DateTime.Now,
                End = DateTime.Now,
                Client = "20295782K",
                Mode = TipoCoff.CB001,
                EvType = 10,
                Start = DateTime.Now,
                Finish = DateTime.Now,
                Assist = 10,
                Additional = 20,
                Realized = false,
                Total = 987654321,
                Observation = "Algo Esta mal con el constr",
                Veg = false
            };
            bool result = cof.Create();

            //Preguntamos si son iguales
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReadCoffeeTest()
        {
            // Declarar un string para buscar y una de el valor esperado
            string expected = "20295782K";
            string result = "";
            CofeeBreak coff = new CofeeBreak()
            {
                Number = "897654321"
            };
            coff.Read();
            result = coff.Client;
            // Preguntar si variables resultado y esperado son iguales
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UpdateCoffeeTest()
        {
            bool expected = true;
            CofeeBreak coff = new CofeeBreak()
            {
                Number = "897654321",
                Creation = DateTime.Now,
                End = DateTime.Now,
                Client = "20295782K",
                Mode = TipoCoff.CB001,
                EvType = 10,
                Start = DateTime.Now,
                Finish = DateTime.Now,
                Assist = 100,
                Additional = 20,
                Realized = true,
                Total = 987654321,
                Observation = "Tengo mucho sueño",
                Veg = true
            };

            coff.Update();
            bool result = coff.Veg;
            //Preguntamos si son iguales
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void DeleteCoffeeTest()
        {
            // Declarar un string para buscar y una de el valor esperado
            bool expected = true;
            CofeeBreak coff = new CofeeBreak()
            {
                Number = "897645321"
            };
            bool result = coff.Delete();
            // Preguntar si variables resultado y esperado son iguales
            Assert.AreEqual(expected, result);
        }
    }
}
