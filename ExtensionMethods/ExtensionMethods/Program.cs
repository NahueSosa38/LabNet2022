using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///Punto numero 1
            Console.WriteLine($"[[[PUNTO N°1]]]\n");
            Console.Write("Ingrese el numero que desea dividir: ");

            try
            {
                int numero = int.Parse(Console.ReadLine());
                ManejoExcepciones.ExcepcionDivisiones(numero, 0);

            }
            catch (DivideByZeroException spooky)
            {
                Console.WriteLine($"\n[[{spooky.Message}]]");
            }
            catch (FormatException wawe)
            {
                Console.WriteLine($"\n [[{wawe.Message}]]");

            }

            finally
            {
                Console.WriteLine("\n---Punto N°1 ha finalizado---");
            }

            ///Punto numero 2
            Console.WriteLine($"\n\n[[[PUNTO N°2]]]\n");

            try
            {
                Console.Write("Ingrese el dividendo: ");
                int dividendo = int.Parse(Console.ReadLine());
                Console.Write("\nIngrese el divisor: ");
                int divisor = int.Parse(Console.ReadLine());
                int resultado;

                resultado = ManejoExcepciones.ExcepcionDivisiones(dividendo, divisor);
                Console.WriteLine($"\nEl resultado de la operacion es {resultado}");
            }
            catch (DivideByZeroException spooky)
            {
                Console.WriteLine($"\nNo podes dividir por 0 maestro, quien te pensas que sos? \n[[{spooky.Message}]]");
            }
            catch (FormatException wawe)
            {
                Console.WriteLine($"\nNo te hagas el chistoso e ingresá un numero \n[[{wawe.Message}]]");

            }
            finally
            {
                Console.WriteLine("\n---Punto N°2 ha finalizado---");
            }

            ///Punto numero 3
            Console.WriteLine($"\n\n[[[PUNTO N°3]]]\n");

            try
            {
                Logic.ExcepcionPunto3();
            }
            catch (Exception panchula)
            {
               Console.WriteLine($"[[{panchula.GetType().ToString()}]]---[[{panchula.Message}]]");
                
            }
            finally
            {
                Console.WriteLine("\n---Punto N°3 ha finalizado---");
            }

            ///Punto numero 4
            Console.WriteLine($"\n\n[[[PUNTO N°4]]]\n");

            try
            {
                Logic.ExcepcionPunto4();
            }
            catch (ExcepcionPersonalizada jasakita)
            {
                Console.WriteLine($"[[{jasakita.GetType().ToString()}]]---[[{jasakita.Message}]]");

            }
            finally
            {
                Console.WriteLine("\n---Punto N°4 ha finalizado---");
            }

            Console.ReadKey();
        }


    }
}
