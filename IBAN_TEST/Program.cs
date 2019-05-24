﻿using System;
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
        IBANP iban = new IBANP();
        string cuenta = "00120345030000067890";
        string cuenta_Iban = "ES0700120345030000067890";
        [Test]
        public void CrearIban()
        {
            string resultado = iban.calcularIban(cuenta);
            Assert.AreEqual(cuenta_Iban, resultado);
        }

        [Test]
        public void ComprobarIbanCorrecto()
        {
            bool resultado = iban.ComprobarIban(cuenta_Iban);
            Assert.AreEqual(true, resultado);
        }

        [Test]
        public void ComprobarIbanError()
        {
            string iban_cuenta_Erronea = "ES0200120345030000067890";
            bool resultado = iban.ComprobarIban(iban_cuenta_Erronea);
            Assert.AreEqual(false, resultado);
        }

        [Test]
        public void LongitudCuentaIncorrecta()
        {
            string cuenta_Erronea = "0120345030000067890";
            try
            {
                string resultado = iban.calcularIban(cuenta);
                Assert.Fail("Falla porque no se puede hacer los calculos con ese número");
            }
            catch
            {

            }
        }

        [Test]
        public void CaracteresNoValidosEnCuenta()
        {
            try
            {
                string cuenta_Caracteres = "0120345030abn067890";
                string resultado = iban.calcularIban(cuenta_Caracteres);
                Assert.Fail("Falla porque no todos los caracteres son numericos");
            }
            catch
            {

            }
        }
    }
}
