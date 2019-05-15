using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBAN
{
    // EXEPCIONES
    public class CuentaCortaException : Exception { }
    public class CaracteresCuentaException : Exception { }

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

            if (cuenta.Length != 20)
                throw new CuentaCortaException();

            // Paso 1
            // Paso 2
            string ibanTmp = cuenta + "142800";
            try
            {
                calculoIban = int.Parse(ibanTmp);
            }
            catch
            {
                throw new CaracteresCuentaException();
            }
            
            calculoIban = calculoIban % 97;
            calculoIban = 98 - calculoIban;

            if (calculoIban > -1 && calculoIban < 10)
                iban = "ES0" + calculoIban + cuenta;
            else
                iban = "ES" + calculoIban + cuenta;

            return iban;
        }

        public bool ComprobarIban(string iban)
        {
            int calculo = 0;
            string final = iban.Substring(2, 2);
            string cuenta = iban.Substring(4, 20);

            cuenta = cuenta + "1428" + final;

            calculo = 97 % int.Parse(cuenta);

            if (calculo == 1)
                return true;
            else
                return false;
        }

    }
}
