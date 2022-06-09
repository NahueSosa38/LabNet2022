using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.EntityFramework.Data;
using Tp.EntityFramework.Entities;

namespace Tp.EntityFramework.Logic
{
    public class ShippersLogic : BaseLogic
    {
        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }
        public void Add(Shippers newShipper)
        {
            try
            {
                context.Shippers.Add(newShipper);
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

        public void Update(Shippers shippers)
        {
            try
            {
                var shipUpdate = context.Shippers.Single(r => r.ShipperID == ((Shippers)shippers).ShipperID);
                shipUpdate.CompanyName = shippers.CompanyName;
                shipUpdate.Phone = shippers.Phone;
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
                var shipDelete = context.Shippers.Find(id);
                context.Shippers.Remove(shipDelete);
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
