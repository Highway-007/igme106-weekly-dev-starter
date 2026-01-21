using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet___DBG_DS
{
    internal class Pet
    {
        private string name;
        private double weight;

        // Default constructor
        public Pet()
        {
        }

        // Parameterized constructor
        public Pet(string name, double weight)
        {
            this.name = name;
            this.weight = weight;
        }
    }
}
