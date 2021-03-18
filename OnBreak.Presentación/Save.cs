using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace OnBreak.Presentación
{
    [Serializable]
    public sealed class Save
    {
        private static readonly Save instance = new Save();
        private string _bkRutCl;
        private string _bkRzCl;
        private DateTime _bkStD;
        private DateTime _bkEnD;
        private string _bkAss;
        private string _bkAdd;
        private string _bkObs;
        private int _BkTypeIndx;
        private int _BkCBModIndx;
        private bool _BkCbVeg;
        private int _BkCKModIndx;
        private bool _BkCKHasAmb;
        private int _BkCKAmbTipoIndx;
        private bool _BkCkAmbMus;
        private bool _BkCkCliMus;
        private int _BkCeMod;
        private int _BkCeAmbTipoIndx;
        private bool _BkCeAmbMus;
        private bool _BkCeCliMus;
        private bool _BkCeLocOB;
        private bool _BkCeLocOther;
        private string _BkCeValUf;
        private string _BkId;

        public string BkId
        {
            get { return _BkId; }
            set { _BkId = value; }
        }

        public string BkCeValUf
        {
            get { return _BkCeValUf; }
            set { _BkCeValUf = value; }
        }


        public bool BkCeLocOther
        {
            get { return _BkCeLocOther; }
            set { _BkCeLocOther = value; }
        }


        public bool BkCeLocOB
        {
            get { return _BkCeLocOB; }
            set { _BkCeLocOB = value; }
        }


        public bool BkCeCliMus
        {
            get { return _BkCeCliMus; }
            set { _BkCeCliMus = value; }
        }


        public bool BkCeAmbMus
        {
            get { return _BkCeAmbMus; }
            set { _BkCeAmbMus = value; }
        }


        public int BkCeAmbTipoIndx
        {
            get { return _BkCeAmbTipoIndx; }
            set { _BkCeAmbTipoIndx = value; }
        }


        public int BkCeMod
        {
            get { return _BkCeMod; }
            set { _BkCeMod = value; }
        }


        public bool BkCKCLiMus
        {
            get { return _BkCkCliMus; }
            set { _BkCkCliMus = value; }
        }


        public bool BkCKAmbMus
        {
            get { return _BkCkAmbMus; }
            set { _BkCkAmbMus = value; }
        }


        public int BkCKAmbTipoIndx
        {
            get { return _BkCKAmbTipoIndx; }
            set { _BkCKAmbTipoIndx = value; }
        }


        public bool BkCKHasAmb
        {
            get { return _BkCKHasAmb; }
            set { _BkCKHasAmb = value; }
        }


        public int BkCKModIndx
        {
            get { return _BkCKModIndx; }
            set { _BkCKModIndx = value; }
        }


        public bool BkCBVeg
        {
            get { return _BkCbVeg; }
            set { _BkCbVeg = value; }
        }


        public int BkCBModIndx
        {
            get { return _BkCBModIndx; }
            set { _BkCBModIndx = value; }
        }


        public int BkTypeIndex
        {
            get { return _BkTypeIndx; }
            set { _BkTypeIndx = value; }
        }


        public string  BkObs
        {
            get { return _bkObs; }
            set { _bkObs = value; }
        }

        public string BkAdd
        {
            get { return _bkAdd; }
            set { _bkAdd = value; }
        }


        public string BkAss
        {
            get { return _bkAss; }
            set { _bkAss = value; }
        }


        public DateTime BkEnD
        {
            get { return _bkEnD; }
            set { _bkEnD = value; }
        }


        public DateTime BkStD
        {
            get { return _bkStD; }
            set { _bkStD = value; }
        }


        public string BkRzCl
        {
            get { return _bkRzCl; }
            set { _bkRzCl = value; }
        }


        public string BkRutCl
        {
            get { return _bkRutCl; }
            set { _bkRutCl = value; }
        }


        static Save()
        {
        }

        private Save()
        {
        }

        public static Save Instance
        {
            get
            {
                return instance;
            }
        }

        public void AutoSave()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Datos.bin";
            Serial.GuardarEnArchivo<Save>(path, instance);
        }

    }
}
