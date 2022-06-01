using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Logic
    {
        public static void ExcepcionPunto3()
        {
            throw new Exception();
        }

        public static void ExcepcionPunto4()
        {
            throw new ExcepcionPersonalizada("--God,no?--");
        }
    }
}
