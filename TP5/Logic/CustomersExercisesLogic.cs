using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Logic
{
    public class CustomersExercisesLogic : LinqExercisesLogic
    {

        //1
        public Customers Clientes()
        {

            var query = from customers in context.Customers
                        select customers;

            return query.First();
        }
        //----------------------------------------------------------------
        //4
        public List<Customers> ClientesWA()
        {
          
            var query = from customers in context.Customers
                        where customers.City == "WA"
                        select customers;
            return query.ToList();
        }
        //-----------------------------------------------------------------
        //6
        public List<string> ClientesMayusMinus()
        {

            var query = from customers in context.Customers
                        select customers.ContactName;

            var upperLowerCaseCustomers = new List<string>();
            foreach (var item in query)
            {
                upperLowerCaseCustomers.Add(item.ToUpper());
                upperLowerCaseCustomers.Add(item.ToLower());
            }
            return upperLowerCaseCustomers;
        }


        //-----------------------------------------------------------------
        //7
        public List<CustomerOrders> JoinClientesOrdenes()
        {
          
            var query = from orders in context.Orders
                        join customers in context.Customers
                        on orders.CustomerID equals customers.CustomerID
                        where orders.OrderDate > new DateTime(1997, 1, 1) && customers.Region == "WA"
                        select new CustomerOrders()
                        {
                            CustomerName = customers.ContactName,
                            CustomerRegion = customers.Region,
                            OrderId = orders.OrderID,
                            OrderDate = orders.OrderDate
                        };
            return query.ToList();
      
        }
        //-----------------------------------------------------------------
        //8 
        public List<Customers> TresClientesWA()
        {
            
            var query = context.Customers.Where(c => c.Region == "WA").OrderBy(c => c.CustomerID);
            return query.Take(3).ToList();

        }
        //-------------------------------------------------------------------
        //13
        public IEnumerable<dynamic> ClientesOrdenes()
        {
            var query = from customers in context.Customers
                        join orders in context.Orders
                        on customers.CustomerID
                            equals orders.CustomerID
                        into count
                        select new
                        {
                            ID = customers.CustomerID,
                            ContactName = customers.ContactName,
                            OrdersCuantity = count.Count()
                        };
            return query.ToList();
        }

    }
}