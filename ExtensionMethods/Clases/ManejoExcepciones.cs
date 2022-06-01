using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ManejoExcepciones
    {

        public static int ExcepcionDivisiones(int dividendo, int divisor)
        {
            int division;
            try
            {
                division = dividendo / divisor;

            }
            catch (DivideByZeroException drossito)
            {
                throw drossito;
            }
            
            return division;
        }
    }
}
