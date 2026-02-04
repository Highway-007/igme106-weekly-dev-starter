using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Interfaces
{
    internal class Circle : IPosition, IArea
    {
        //Fields
        private double radius;
        private double area;
        private double perimeter;
        private double x;
        private double y;



        //Properties
        /// <summary>
        /// A get property for the area variable
        /// </summary>
        public double Area 
        { 
            get { return area; }
        }

        /// <summary>
        /// A get property for the perimeter variable
        /// </summary>
        public double Perimeter 
        { 
            get { return perimeter; } 
        }

        /// <summary>
        /// A get/set property for the x variable
        /// </summary>
        public double X 
        { 
            get { return x; } 
            set { x = value; } 
        }

        /// <summary>
        /// A get/set property for the y variable
        /// </summary>
        public double Y 
        { 
            get { return y; }
            set { y = value; }
        }

        //Constructors
        /// <summary>
        /// Defines the base values for x, y, radius, area, and perimeter
        /// </summary>
        /// <param name="x">the user inputted x value</param>
        /// <param name="y">the user inputted y value</param>
        /// <param name="radius">the user inputted radius value</param>
        public Circle(double x, double y, double radius)
        {
            this.radius = radius;
            this.x = x;
            this.y = y;
            area = Math.PI * Math.Pow(radius, 2);
            perimeter = Math.PI * 2 * radius;
        }

        //Methods
        /// <summary>
        /// A method calculating the distance from the current circle to a user given position
        /// </summary>
        /// <param name="position">An interface for a point</param>
        /// <returns></returns>
        public double DistanceTo(IPosition position)
        {
            double dist = Math.Sqrt(Math.Pow(position.X - x, 2) + Math.Pow(position.Y - y, 2));
            return dist;
        }

        /// <summary>
        /// A method changing the x and y positions of the circle to user given positions
        /// </summary>
        /// <param name="x">x position the circle is to be moved to</param>
        /// <param name="y">y position the circle is to be moed to</param>
        public void MoveTo(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// A method adding an offset to the circles current position
        /// </summary>
        /// <param name="xOffset">x offset for the circle</param>
        /// <param name="yOffset">y offset for the circle</param>
        public void MoveBy(double xOffset, double yOffset)
        {
            x += xOffset;
            y += yOffset;
        }

        /// <summary>
        /// A method checking wether a position is contained inside the area of the circle
        /// </summary>
        /// <param name="position">position to check</param>
        /// <returns>true/false</returns>
        public bool ContainsPosition(IPosition position)
        {
            if(DistanceTo(position) > radius)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// A method checking if the area of the current circle is greater than another circle's area
        /// </summary>
        /// <param name="areaToCheck">the area to compare to</param>
        /// <returns>true/false</returns>
        public bool IsLargerThan(IArea areaToCheck)
        {
            if(areaToCheck.Area >= area)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// An override of the ToString Function
        /// </summary>
        /// <returns>a description of the current circle</returns>
        public override string ToString()
        {
            return $"\nThis circle's values are:" +
                $"\n\tCoordinates: ({x:F2}, {y:F2})" +
                $"\n\tArea: {area:F2}" +
                $"\n\tPerimeter: {perimeter:F2}";
        }
    }
}
