using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IBAN;


namespace IBAN_TEST
{
    [TestFixture]
    public class IBAN_TEST
    {
        [Test]
        public void CrearIban()
        {
            string cuenta = "00120345030000067890";
            IBANP iban = new IBANP();
            string resultado = iban.CrearIban(cuenta);
            Assert.AreEqual("ES0700120345030000067890", resultado);
        }

        [Test]
        public void ComprobarIbanCorrecto()
        {
            IBANP iban = new IBANP();
            string iban_cuenta = "ES0700120345030000067890";
            bool resultado = iban.ComprobarIban(iban_cuenta);
            Assert.AreEqual(true, resultado);
        }

        [Test]
        public void ComprobarIbanError()
        {
            IBANP iban = new IBANP();
            string iban_cuenta = "ES0200120345030000067890";
            bool resultado = iban.ComprobarIban(iban_cuenta);
            Assert.AreEqual(false, resultado);
        }

        [Test]
        public void LongitudCuentaIncorrecta()
        {
            string cuenta = "0120345030000067890";
            IBANP iban = new IBANP();           
            try
            {
                string resultado = iban.CrearIban(cuenta);
                Assert.Fail("Falla porque no se puede hacer los calculos con ese número");
            }
            catch
            {
                
            }
        }

        [Test]
        public void CaracteresNoValidosEnCuenta()
        {
            string cuenta = "00120345030AB0067890";
            IBANP iban = new IBANP();
            try
            {
                string resultado = iban.CrearIban(cuenta);
                Assert.Fail("Falla porque no todos los caracteres son numericos");
            }
            catch
            {

            }
        }
    }
}
