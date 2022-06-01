using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ExcepcionPersonalizada : Exception
    {

        public override string Message => "Lo siento amiguito, ha ocurrido una excepcion. "+base.Message;
        public ExcepcionPersonalizada(string mensajeError) : base (mensajeError)
        {

        }
    }
}
