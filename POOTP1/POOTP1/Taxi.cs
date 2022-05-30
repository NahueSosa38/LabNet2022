using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOTP1
{
    public class Taxi : Transporte
    {
        public Taxi()
        {
            cantPasajeros = random.Next(1, 4);
        }


        public override string Avanzar()
        {
            return $"Lleva {cantPasajeros} pasajeros";
        }

        public override string Detenerse()
        {
            return $"Los {cantPasajeros} pasajeros llegaron a destino";
        }
    }
}