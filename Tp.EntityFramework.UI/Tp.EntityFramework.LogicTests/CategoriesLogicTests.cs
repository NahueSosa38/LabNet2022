using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tp.EntityFramework.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.EntityFramework.Entities;
using Tp.EntityFramework.Data;

namespace Tp.EntityFramework.Logic.Tests
{
    [TestClass()]
    public class CategoriesLogicTests
    {
        [TestMethod()]
        public void DeleteTest()
        {
            //arrange
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            var testCategory = new Categories("Unit Test", "Categoria para Unit Test");

            //act
            categoriesLogic.Add(testCategory);
            var id = testCategory.CategoryID;
            categoriesLogic.Delete(id);
            var idBorrado = categoriesLogic.GetAll().FirstOrDefault(x => x.CategoryID == id);

            //assert
            Assert.IsNull(idBorrado);


        }

    }
}