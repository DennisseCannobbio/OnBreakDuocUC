using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Negocios
{
    internal class Conexion
    {
        private static OnBreakEntities _onBreakBD;
        public static OnBreakEntities OnBreakBD
        {
            get
            {
                if (_onBreakBD == null)
                {
                    _onBreakBD = new OnBreakEntities();
                }
                _onBreakBD.Configuration.AutoDetectChangesEnabled = false;
                return _onBreakBD;
            }
            set
            {
                _onBreakBD = value; 
            }
        }
    }
}
