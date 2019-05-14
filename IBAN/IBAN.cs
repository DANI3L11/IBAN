using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBAN
{
    public class IBANP
    {
        // Variables
        private string iban;
        private string E = "14";
        private string S = "28";

        // Propiedades
        public string Iban
        {
            get { return iban; }
            set { iban = value; }
        }

        // Constructores
        public IBANP() { }

        // Métodos
        public string CrearIban(string cuenta)
        {
            // Paso preliminar
            // Paso 1
            string ibanTmp = cuenta + "ES00";
            
            // Paso 2
            ibanTmp = ibanTmp.Substring(19, 2);
            ibanTmp = ibanTmp.Insert(19, E);
            ibanTmp = ibanTmp.Insert(21, S);

            return ibanTmp;
        }

    }
}
