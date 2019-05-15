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
            int calculoIban;
            // Paso preliminar
            // Paso 1
            // Paso 2
            string ibanTmp = cuenta + "142800";
            calculoIban = int.Parse(ibanTmp);
            calculoIban = calculoIban % 97;
            calculoIban = 98 - calculoIban;

            if (calculoIban > -1 && calculoIban < 10)
                iban = "ES0" + calculoIban + cuenta;
            else
                iban = "ES" + calculoIban + cuenta;

            return iban;
        }

        public bool ComprobarIban()
        {



        }

    }
}
