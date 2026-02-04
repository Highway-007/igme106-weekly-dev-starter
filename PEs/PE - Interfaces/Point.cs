using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Interfaces
{
    internal class Point : IPosition
    {
        //Fields
        private double x;
        private double y;

        //Properties
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
        /// Defines the base values for x and y
        /// </summary>
        /// <param name="x">the user inputted x value</param>
        /// <param name="y">the user inputted y value</param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        //Methods
        /// <summary>
        /// A method calculating the distance from the current point to a user given position
        /// </summary>
        /// <param name="position">An interface for a point</param>
        /// <returns></returns>
        public double DistanceTo(IPosition position)
        {
            double dist = Math.Sqrt(Math.Pow(position.X - x, 2) + Math.Pow(position.Y - y, 2));
            return dist;
        }

        /// <summary>
        /// A method changing the x and y positions of the point to user given positions
        /// </summary>
        /// <param name="x">x position the point is to be moved to</param>
        /// <param name="y">y position the point is to be moed to</param>
        public void MoveTo(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// A method adding an offset to the points current position
        /// </summary>
        /// <param name="xOffset">x offset for the point</param>
        /// <param name="yOffset">y offset for the point</param>
        public void MoveBy(double xOffset, double yOffset)
        {
            x += xOffset;
            y += yOffset;
        }

        /// <summary>
        /// An override of the ToString Function
        /// </summary>
        /// <returns>a description of the current point</returns>
        public override string ToString()
        {
            return $"\nThis point's values are:" +
                $"\n\tCoordinates: ({x:F2}, {y:F2})";
        }
    }
}
