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
        // Constantes
        const string spainPrefix = "142800";

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
        public static string calcularIban(string cuenta)
        {
            // Variables
            string[] partesCCC = null;
            int iResultado = 0;

            // Calculamos el IBAN
            cuenta = cuenta.Trim();
            if (cuenta.Length != 20)
                return "La CCC debe tener 20 dígitos";

            // Le añadimos el código del pais al cc
            cuenta = cuenta + spainPrefix;

            // Troceamos el ccc en partes (26 digitos)
            partesCCC = new string[5];
            partesCCC[0] = cuenta.Substring(0, 5);
            partesCCC[1] = cuenta.Substring(5, 5);
            partesCCC[2] = cuenta.Substring(10, 5);
            partesCCC[3] = cuenta.Substring(15, 5);
            partesCCC[4] = cuenta.Substring(20, 6);

            for (int i = -1; i < partesCCC.Length - 1; i++)
                iResultado = int.Parse(iResultado + partesCCC[i + 1]) % 97;

            // Le restamos el resultado a 98
            int iRestoIban = 98 - iResultado;
            if (iRestoIban < 10)
                return "ES0" + iRestoIban + cuenta;
           
            return "ES" + iRestoIban + cuenta;


            //int calculoIban;
            //decimal ibanFinal;
            //// Paso preliminar

            //if (cuenta.Length != 20)
            //    throw new CuentaCortaException();

            //// Paso 1
            //// Paso 2
            //string ibanTmp = cuenta + "142800";
            //try
            //{
            //    ibanFinal = decimal.Parse(ibanTmp);
            //}
            //catch
            //{
            //    throw new CaracteresCuentaException();
            //}

            //ibanFinal = ibanFinal % 97;
            //ibanFinal = 98 - ibanFinal;

            //if (ibanFinal > -1 && ibanFinal < 10)
            //    iban = "ES0" + ibanFinal + cuenta;
            //else
            //    iban = "ES" + ibanFinal + cuenta;

            //return iban;
        }

        public bool ComprobarIban(string iban)
        {
            decimal calculo = 0;
            string final = iban.Substring(2, 2);
            string cuenta = iban.Substring(4, 20);

            cuenta = cuenta + "1428" + final;

            calculo = decimal.Parse(cuenta) % 97;

            if (calculo == 1)
                return true;
            else
                return false;
        }

    }
}
