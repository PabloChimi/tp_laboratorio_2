using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;


namespace CorreoUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void InicializacionCorreoListPaquetes()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestPaquetesNoRepetidos()
        {
            Correo c = new Correo();

            Paquete p1 = new Paquete("Gerli", "000-000-0000");
            Paquete p2 = new Paquete("Palermo", "000-000-0000");
            
            c = c + p1;
            c = c + p2;
        }
    }
}
