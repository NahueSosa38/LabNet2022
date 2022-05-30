using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOTP1
{
    public abstract class Transporte

    {

        public int cantPasajeros { get; set; }
        protected Random random = new Random(Guid.NewGuid().GetHashCode());


        public Transporte()
        {

        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}