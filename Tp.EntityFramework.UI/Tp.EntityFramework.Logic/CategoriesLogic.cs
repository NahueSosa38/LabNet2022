using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.EntityFramework.Data;
using Tp.EntityFramework.Entities;

namespace Tp.EntityFramework.Logic
{
    public class CategoriesLogic : BaseLogic
    {
        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        } 

        public void Add(Categories newCategorie)
        {
            try
            {
                context.Categories.Add(newCategorie);
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Categories categories)
        {
            try
            {
                var catUpdate = context.Categories.Single(r => r.CategoryID == ((Categories)categories).CategoryID);
                catUpdate.CategoryName = categories.CategoryName;
                catUpdate.Description = categories.Description;
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {

                throw;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var catDelete = context.Categories.Find(id);
                context.Categories.Remove(catDelete);
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
