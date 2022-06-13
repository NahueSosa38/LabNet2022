using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class LinqExercisesLogic
    {
        public readonly NorthwindContext context;
        public LinqExercisesLogic()
        {
            context = new NorthwindContext();
        }
    }
}
