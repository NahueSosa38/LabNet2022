using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod]
        public void ExcepcionPunto4Test()
        {
            //arrange
            string expectedMessage = "Lo siento amiguito, ha ocurrido una excepcion. Probando unit test";
            //act
            var newException = new ExcepcionPersonalizada("Probando unit test");
            //Assert
            Assert.AreEqual(expectedMessage, newException.Message);
        }
     
    }
}