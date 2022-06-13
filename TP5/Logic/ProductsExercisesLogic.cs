using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Logic
{
    public class ProductsExercisesLogic : LinqExercisesLogic
    {
        //2
        public List<Products> ProductosSinStock()
        {
            return context.Products.Where(p => p.UnitsInStock == 0).ToList();
            
        }

        //----------------------------------------------------
        //3
        public List<Products> ProductosCostoTres()
        {           
            return context.Products.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3).ToList();

        }
        //----------------------------------------------------
        //5
        public Products PrimeroONulo()
        {

            return context.Products.FirstOrDefault(x => x.ProductID == 789);

        }

        //----------------------------------------------------
        //9
        public List<Products> ProductosPorNombre()
        {

            var query = from products in context.Products
                        orderby products.ProductName
                        select products;

            return query.ToList();
        }

        //----------------------------------------------------
        //10
        public List<Products> ProductosPorUnidadStock()
        {

            var query = from products in context.Products
                        orderby products descending
                        select products;

            return query.ToList();
        }

        //----------------------------------------------------
        //11
        public List<int?> CategoriasProductos()
        {
            var query = context.Products.Select(x => x.CategoryID);

            return query.ToList();
        }

        //-----------------------------------------------------
        //12
        public List<Products> PrimerProducto()
        {
            var query = from products in context.Products
                        select products;

            return query.Take(1).ToList();
        }

    }

}
