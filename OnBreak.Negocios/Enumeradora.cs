using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocios
{
    public enum ActividadEmpresa
    {
        Agropecuaria = 1,
        Minería = 2,
        Manufactura = 3,
        Comercio = 4,
        Hotelería = 5,
        Alimentos = 6,
        Transporte = 7,
        Servicios = 8
    }

    public enum TipoEmpresa
    {
        SPA = 10 ,
        EIRL = 20,
        Limitada = 30,
        Sociedad_Anonima = 40
    }

    public enum TipoEvento
    {
        CoffeeBreak = 10,
        Cocktail = 20,
        Cenas = 30
    }

    public enum Modalidad
    {
        LightBreak = 001,
        JournalBreak = 002,
        DayBreak = 003,
        Ejecutiva = 004,
        Celebracion = 005,
        QuickCocktail = 006,
        AmbientCocktail = 007
    }

    public enum Ambientacion
    {
        Basica = 10,
        Personalizada = 20
    }

    public enum TipoCock
    {
        CO001 = 1,
        CO002 = 2
    }

    public enum TipoCoff
    {
        CB001 = 1,
        CB002 = 2,
        CB003 = 3
    }

    public enum TipoCena
    {
        CE001 = 1,
        CE002 = 2
    }
}
