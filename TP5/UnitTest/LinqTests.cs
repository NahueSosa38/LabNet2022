using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;
using Entities;
using Logic;

namespace UnitTest
{
    [TestClass]
    public class LinqTests
    {
        //UTILICÉ UNIT TEST PARA EVITAR EL USO DE LA CONSOLA
        // Y SEA MAS PRACTICO A LA HORA DE CORREGIR

        public readonly NorthwindContext context = new NorthwindContext();
        CustomersExercisesLogic customersExercises = new CustomersExercisesLogic();
        ProductsExercisesLogic productsExercises = new ProductsExercisesLogic();
        [TestMethod]
        public void Should_ReturnCustomerType()
        {
            //Assert
            Assert.IsInstanceOfType(customersExercises.Clientes(), typeof(Customers));
        }

        [TestMethod]
        public void Should_HaveZeroUnitsInStock()
        {
            //Arrange
            bool flag = true;

            //Act
            foreach (Products products in productsExercises.ProductosSinStock())
            {
                if (products.UnitsInStock != 0)
                {
                    flag = false;
                    break;
                }
            }

            //Assert
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void Should_ObtainNullValue_When_SearchForACheaperProduct()
        {
            //Arrange
            Products cheaperProduct;

            //Act
            cheaperProduct = productsExercises.ProductosCostoTres().Find(product => product.UnitPrice < 3);

            //Assert
            Assert.IsNull(cheaperProduct);
        }

        [TestMethod]
        public void Should_ObtainNullValue_When_SearchForAnInvalidRegion()
        {
            //Arrange
            var nullSearch = customersExercises.ClientesWA().Find(c => c.Region == "**");
            //Assert
            Assert.IsNull(nullSearch);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Should_ReturnProductType()
        {
            //Assert
            Assert.AreEqual(productsExercises.PrimeroONulo().ProductID, 789);
        }

        [TestMethod]
        public void Should_ContainUpperCaseNames()
        {
            //Arrange
            string testUpperCaseName = customersExercises.Clientes().ContactName.ToUpper() ;
            //Act
            bool result = customersExercises.ClientesMayusMinus().Contains(testUpperCaseName);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_ReturnCustomOrdersType()
        {
            //Assert
            Assert.IsInstanceOfType(customersExercises.JoinClientesOrdenes()[0], typeof(CustomerOrders));
        }
    }
}
