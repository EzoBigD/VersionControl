using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak7.Entities
{
    class BirthProbability
    {
        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int NbrOfChildren { get; set; }

        public double Probability { get; set; }
    }
}
