using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOTP1
{
    internal class Program
    {   /// se genera la lista de transportes
        static void Main(string[] args)
        {
            List<Omnibus> omnibus = new List<Omnibus>
                            {
                                    new Omnibus(),
                                    new Omnibus(),
                                    new Omnibus(),
                                    new Omnibus(),
                                    new Omnibus(),
                            };
            List<Taxi> taxis = new List<Taxi>
                            {
                                    new Taxi(),
                                    new Taxi(),
                                    new Taxi(),
                                    new Taxi(),
                                    new Taxi(),
                            };

            int option;
            int submenu;
            do
            {
                Console.Clear();
                /// se reinician los contadores de transportes (taxi y omnibus)
                int conttaxi = 0;
                int contbus = 0;
                /// Menu Principal
                Console.WriteLine("[1] - Lista Completa");
                Console.WriteLine("[2] - Omnibus");
                Console.WriteLine("[3] - Taxis");
                Console.WriteLine("[4] - Salir");

                bool fallo = int.TryParse(Console.ReadLine(), out option);
                /// segun la opcion ingresada se determina si se entra al menú o se deniega
                /// hasta que se ingrese una opcion valida
                if (fallo)
                {
                    switch (option)
                    {
                        case 1:
                            do
                            {   /// se muestra la lista completa
                                conttaxi = 0;
                                contbus = 0;
                                Console.Clear();

                                foreach (var item in omnibus)
                                {
                                    contbus++;
                                    Console.WriteLine($"[[Omnibus {contbus}]]");
                                    Console.WriteLine(item.Avanzar());
                                    Console.WriteLine(item.Detenerse());
                                }

                                Console.WriteLine("");

                                foreach (var item in taxis)
                                {
                                    conttaxi++;
                                    Console.WriteLine($"[[Taxi {conttaxi}]]");
                                    Console.WriteLine(item.Avanzar());
                                    Console.WriteLine(item.Detenerse());
                                }
                                /// sub menú para volver al menu principal o salir de la consola
                                /// funciona igual que el menu principal
                                Console.WriteLine("");
                                Console.Write("[1] - Volver al menú");
                                Console.Write("      ");
                                Console.WriteLine("[2] - Salir");

                                fallo = int.TryParse(Console.ReadLine(), out submenu);
                                /// se deniegan los datos invalidos hasta que se ingrese una opcion correcta
                                if (fallo)
                                {
                                    if (submenu == 2)
                                    {
                                        option = 4;
                                    }
                                }
                            } while (submenu != 1 && submenu != 2);
                            break;
                        case 2:
                            do
                            {   /// se muestra la lista de omnibus
                                conttaxi = 0;
                                contbus = 0;
                                Console.Clear();

                                foreach (var item in omnibus)
                                {
                                    contbus++;
                                    Console.WriteLine($"[[Omnibus {contbus}]]");
                                    Console.WriteLine(item.Avanzar());
                                    Console.WriteLine(item.Detenerse());
                                }
                                /// tambien posee su propio submenu
                                Console.WriteLine("");
                                Console.Write("[1] - Volver al menú");
                                Console.Write("      ");
                                Console.WriteLine("[2] - Salir");

                                fallo = int.TryParse(Console.ReadLine(), out submenu);

                                if (fallo)
                                {
                                    if (submenu == 2)
                                    {
                                        option = 4;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese un valor valido");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese un valor valido");
                                }
                            } while (submenu != 1 && submenu != 2);

                            break;
                        case 3:
                            do
                            { /// se muestra la lista de taxis
                                conttaxi = 0;
                                contbus = 0;
                                Console.Clear();

                                foreach (var item in taxis)
                                {
                                    conttaxi++;
                                    Console.WriteLine($"[[Taxi {conttaxi}]]");
                                    Console.WriteLine(item.Avanzar());
                                    Console.WriteLine(item.Detenerse());
                                }
                                /// al igual que las demas tiene un submenu
                                Console.WriteLine("");
                                Console.Write("[1] - Volver al menú");
                                Console.Write("      ");
                                Console.WriteLine("[2] - Salir");

                                fallo = int.TryParse(Console.ReadLine(), out submenu);

                                if (fallo)
                                {
                                    if (submenu == 2)
                                    {
                                        option = 4;
                                    }

                                }

                            } while (submenu != 1 && submenu != 2);

                            break;

                        case 4: /// al ingresar 4 en el menu principal la consola se cierra 
                            break;


                    }
                }
            } while (option != 4);

        }
    }
}