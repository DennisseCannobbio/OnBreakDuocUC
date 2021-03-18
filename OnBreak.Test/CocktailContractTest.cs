using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnBreak.Negocios;

namespace OnBreak.Test
{
    [TestClass]
    public class CocktailContractTest
    {
        [TestMethod]
        public void CreateCocktailTest()
        {
            bool expected = true;
            Cocktail cock = new Cocktail()
            {
                Number = "123456788",
                Creation = DateTime.Now,
                End = DateTime.Now,
                Client = "20295782K",
                Mode = TipoCock.CO001,
                EvType = 20,
                Start = DateTime.Now,
                Finish = DateTime.Now,
                Assist = 10,
                Additional = 20,
                Realized = false,
                Total = 987654321,
                Observation = "Probanding",
                Ambient = Ambientacion.Basica,
                HasAmbient = true,
                AmbientMusic = true,
                ClientMusic = false
            };
            bool result = cock.Create();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReadCocktailTest()
        {
            // Declarar un string para buscar y una de el valor esperado
            string expected = "20295782K";
            string result = "";
            Cocktail cock = new Cocktail()
            {
                Number = "123456780"
            };
            cock.Read();
            result = cock.Client;
            // Preguntar si variables resultado y esperado son iguales
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UpdateCocktailTest()
        {
            bool expected = true;
            Cocktail cock = new Cocktail()
            {
                Number = "123456780",
                Creation = DateTime.Now,
                End = DateTime.Now,
                Client = "20295782K",
                Mode = TipoCock.CO001,
                EvType = 20,
                Start = DateTime.Now,
                Finish = DateTime.Now,
                Assist = 10,
                Additional = 20,
                Realized = true,
                Total = 987654321,
                Observation = "Se cambiooo",
                Ambient = Ambientacion.Basica,
                HasAmbient = true,
                AmbientMusic = false,
                ClientMusic = true
            };

            cock.Update();
            bool result = cock.ClientMusic;
            //Preguntamos si son iguales
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void DeleteCocktailTest()
        {
            // Declarar un string para buscar y una de el valor esperado
            bool expected = true;
            Cocktail cock = new Cocktail()
            {
                Number = "123456780"
            };
            bool result = cock.Delete();
            // Preguntar si variables resultado y esperado son iguales
            Assert.AreEqual(expected, result);
        }

        /*
        [TestMethod]
        public void CreateCoffeeTest()
        {
            bool expected = true;
            CofeeBreak cli = new CofeeBreak()
            {
                Num = "123456780",
                Veg = false
            };
            bool result = cli.Create();

            //Preguntamos si son iguales
            Assert.AreEqual(expected, result);
        }
        */
    }

}
