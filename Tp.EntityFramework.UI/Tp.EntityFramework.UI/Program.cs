using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.EntityFramework.Entities;
using Tp.EntityFramework.Logic;

namespace Tp.EntityFramework.UI
{
    public class Program
    {
        CategoriesLogic categoriesLogic = new CategoriesLogic();
        static void Main(string[] args)
        {
            int option;
            /// Menu Principal
            do
            {
                Console.Clear();
                Console.WriteLine("[1] - Mostrar Categorias");
                Console.WriteLine("[2] - Mostrar Shippers");
                Console.WriteLine("[3] - Añadir un dato");
                Console.WriteLine("[4] - Actualizar un dato");
                Console.WriteLine("[5] - Borrar un dato");
                Console.WriteLine("[6] - Salir");

                bool fallo = int.TryParse(Console.ReadLine(), out option);

                if (fallo)
                {
                    switch (option)
                    {
                        case 1:
                            CategoriesList();
                            break;

                        case 2:
                            ShippersList();
                            break;

                        case 3:
                            AñadirDato();
                            break;

                        case 4:
                            ActualizarDato();
                            break;

                        case 5:
                            BorrarDato();
                            break;

                        case 6:
                            break;
                    }
                }
            } while (option != 6);
        }


        // ---------------METODOS APLICADOS-------------------

        static void CategoriesList()
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            Console.WriteLine($"[ID]    |Categoria|     <Descripcion>");

            foreach (Categories categoria in categoriesLogic.GetAll())
            {
                Console.WriteLine($"[{categoria.CategoryID}] --- {categoria.CategoryName} --- {categoria.Description}");
            }

            SubMenu();
        }

        static void ShippersList()
        {
            ShippersLogic shippersLogic = new ShippersLogic();

            Console.WriteLine($"[ID]    |Compañia|         <Telefono>");

            foreach (var item in shippersLogic.GetAll())
            {
                Console.WriteLine($"[{item.ShipperID}] --- {item.CompanyName} --- {item.Phone}");
            }
            SubMenu();
        }

        static void SubMenu()
        {
            int submenu; 
            do
            {               
                Console.WriteLine("");
                Console.WriteLine("[1] - Volver al menú");

                bool fallo = int.TryParse(Console.ReadLine(), out submenu);
               
            } while (submenu !=1);
        }

        static void AñadirDato()
        {
            int elegirModificacion;
            do
            {
                Console.WriteLine("");
                Console.Write("[1] - Añadir Categoria");
                Console.WriteLine("");
                Console.Write("[2] - Añadir Shipper");
                Console.WriteLine("");
                Console.WriteLine("[3] - Regresar al menu principal");

                bool fallo = int.TryParse(Console.ReadLine(), out elegirModificacion);

                if (fallo)
                {
                    switch (elegirModificacion)
                    {
                        case 1:
                            AñadirCategoria();
                            break;

                        case 2:
                            AñadirShipper();
                            break;

                        case 3:
                            break;

                    }
                }

            } while (elegirModificacion != 3);

            if (elegirModificacion != 3)
            {
                SubMenu();
            }
        }

        static void AñadirCategoria()
        {
            
            Console.WriteLine("Ingrese el nombre de la categoria nueva: ");
            string nombreCat = Console.ReadLine();
            Console.WriteLine("Ingrese la descripcion de la categoria nueva: ");
            string descripCat = Console.ReadLine();

            CategoriesLogic categoriesLogic = new CategoriesLogic();
            try
            {
                categoriesLogic.Add(new Categories(nombreCat, descripCat));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Console.WriteLine($"Excedio la cantidad de caracteres permitidos -- [{ex.Message}]");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex){

                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }

        static void AñadirShipper()
        {
            Console.WriteLine("Ingrese el nombre de la compañia nueva: ");
            string nombreComp = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono de contacto de la compañia: ");
            string telComp = Console.ReadLine();

            ShippersLogic shippersLogic = new ShippersLogic();
            try
            {
                shippersLogic.Add(new Shippers(nombreComp, telComp));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Console.WriteLine($"Excedio la cantidad de caracteres permitidos -- [{ex.Message}]");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        static void ActualizarDato()
        {
            int elegirModificacion;
            do
            {
                Console.WriteLine("");
                Console.Write("[1] - Modificar Categoria");
                Console.WriteLine("");
                Console.Write("[2] - Modificar Shipper");
                Console.WriteLine("");
                Console.WriteLine("[3] - Regresar al menu principal");

                bool fallo = int.TryParse(Console.ReadLine(), out elegirModificacion);

                if (fallo)
                {
                    switch (elegirModificacion)
                    {
                        case 1:
                            ModificarCategoria();
                            elegirModificacion = 3;
                            break;

                        case 2:
                            ModificarShipper();
                            elegirModificacion = 3;
                            break;

                        case 3:
                            break;

                    }
                }

            } while (elegirModificacion != 3);

            if (elegirModificacion!=3)
            {
                SubMenu(); 
            }
        }

        static void ModificarCategoria()
        {
            Console.WriteLine("Ingrese la ID buscada");
            int idCat = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre de la categoria nueva: ");
            string nombreCat = Console.ReadLine();
            Console.WriteLine("Ingrese la descripcion de la categoria nueva: ");
            string descripCat = Console.ReadLine();

            CategoriesLogic categoriesLogic = new CategoriesLogic();
            try
            {
                categoriesLogic.Update(new Categories(idCat, nombreCat, descripCat));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Console.WriteLine($"Excedio la cantidad de caracteres permitidos -- [{ex.Message}]");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        static void ModificarShipper()
        {
            Console.WriteLine("Ingrese la ID buscada");
            int idShip = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre de la compañia nueva: ");
            string nombreComp = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono de contacto de la compañia: ");
            string telComp = Console.ReadLine();

            ShippersLogic shippersLogic = new ShippersLogic();
            try
            {
                shippersLogic.Update(new Shippers(idShip, nombreComp, telComp));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Console.WriteLine($"Excedio la cantidad de caracteres permitidos -- [{ex.Message}]");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        static void BorrarDato()
        {
            int elegirModificacion;
            do
            {
                Console.WriteLine("");
                Console.Write("[1] - Borrar Categoria");
                Console.WriteLine("");
                Console.Write("[2] - Borrar Shipper");
                Console.WriteLine("");
                Console.WriteLine("[3] - Regresar al menu principal");

                bool fallo = int.TryParse(Console.ReadLine(), out elegirModificacion);

                if (fallo)
                {
                    switch (elegirModificacion)
                    {
                        case 1:
                            BorrarCategoria();
                            elegirModificacion = 3;
                            break;

                        case 2:
                            BorrarShipper();
                            elegirModificacion = 3;
                            break;

                        case 3:
                            break;

                    }
                }

            } while (elegirModificacion != 3);

            if (elegirModificacion != 3)
            {
                SubMenu();
            }
        }

        static void BorrarCategoria()
        {
            Console.WriteLine("Ingrese la ID que desea borrar");
            int idCat = int.Parse(Console.ReadLine());
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            try
            {
                categoriesLogic.Delete(idCat);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        static void BorrarShipper()
        {            
            Console.WriteLine("Ingrese la ID que desea borrar");
            int idShip = int.Parse(Console.ReadLine());
            ShippersLogic shippersLogic = new ShippersLogic();
            try
            {
                shippersLogic.Delete(idShip);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

      
    }
}
