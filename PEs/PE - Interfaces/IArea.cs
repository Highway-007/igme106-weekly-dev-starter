using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Interfaces
{
    internal interface IArea
    {
        // Properties
        double Area { get; }    // PI * radius * radius
        double Perimeter { get; }   // PI * 2 * radius

        // Methods
        bool ContainsPosition(IPosition position);
        bool IsLargerThan(IArea areaToCheck);
    }
}
