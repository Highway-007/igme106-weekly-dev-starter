using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Graphs
{
    internal class Vertex
    {
        //FIELDS
        private string name;
        private string description;

        //PROPERTIES
        /// <summary>
        /// A get only property for the room name
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        //CONSTRUCTOR
        /// <summary>
        /// A constructor class for a room vertex
        /// </summary>
        /// <param name="name">name of the room</param>
        /// <param name="description">description of the room</param>
        public Vertex(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        //METHODS
        public override string ToString()
        {
            return $"{name.ToUpper()}: {description}.";
        }
    }
}
