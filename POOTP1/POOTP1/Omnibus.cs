using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOTP1
{
    public class Omnibus : Transporte
    {
        public Omnibus()
        {   /// se asigna una cantidad aleatoria de pasajeros original
            cantPasajeros = random.Next(15, 80);
        }

        public override string Avanzar()
        {
            return $"La cantidad de pasajeros es: {cantPasajeros}";


        }
        ///Se calcula una nueva cantidad de pasajeros para simular subida y bajada
        private int Calculo()
        {
            int aux = cantPasajeros;

            int aux2 = random.Next(0, aux + 10);

            int nuevacantPasajeros = aux2 - aux;

            return nuevacantPasajeros;
        }
        public override string Detenerse()
        {
            /// Dependiendo del calculo anterios con los if se determina el mensaje que aparecerá en pantalla
            int ayuda = Calculo();
            if (ayuda == 0)
            {
                return $"No se han subido ni bajado pasajeros";
            }
            if (ayuda < 0)
            {
                return $" Se han SUBIDO {-ayuda} pasajeros y el total es de {-ayuda + cantPasajeros} pasajeros";
            }
            else
            {
                return $"Se han BAJADO {ayuda} pasajeros y el total es de {cantPasajeros - ayuda} pasajeros";
            }
        }

    }
}