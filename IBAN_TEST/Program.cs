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
            Assert.AreEqual("00120345030000067890142800", resultado);
        }
    }
}
