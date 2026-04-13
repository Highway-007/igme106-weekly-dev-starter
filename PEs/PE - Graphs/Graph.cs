using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Graphs
{
    internal class Graph
    {
        //FIELDS
        private List<Vertex> rooms;
        private Dictionary<string, List<Vertex>> adjacencyList;

        //CONSTRUCTOR
        public Graph()
        {
            //helper variables for reading rooms.txt
            StreamReader input = new StreamReader("rooms.txt");
            string line;
            string[] lineToAdd = new string[10];

            rooms = new List<Vertex>();
            adjacencyList = new Dictionary<string, List<Vertex>>();

            //Move Past Title lines in file
            for (int i = 0; i < 3; i++)
            {
                input.ReadLine();
            }

            //Enter list info
            while ((line = input.ReadLine()) != "-----------------------------")
            {
                lineToAdd = line.Split('|');
                rooms.Add(new Vertex(lineToAdd[0], lineToAdd[1]));
            }
            input.ReadLine();

            /* Attempted to make the dictionary use rooms.txt but I currently do not have time.
            //Enter dictionary/adjacency info
            while((line = input.ReadLine()) != null)
            {
                lineToAdd = line.Split('|');
                adjacencyList.Add(lineToAdd[0], new List<Vertex>());

                //Save the current dictionary index
                line = lineToAdd[0];
                lineToAdd = lineToAdd[1].Split(',');

                while (true)
                {
                    adjacencyList[line] = lineToAdd.ToList;
                }
            }
            */

            //Enter Dictionary info
            adjacencyList.Add("hall", new List<Vertex>
            {
                rooms[1],
                rooms[3],
                rooms[5]
            });
            adjacencyList.Add("library", new List<Vertex>
            {
                rooms[0],
                rooms[3]
            });
            adjacencyList.Add("dining", new List<Vertex>
            {
                rooms[0],
                rooms[4]
            });
            adjacencyList.Add("kitchen", new List<Vertex>
            {
                rooms[1],
                rooms[2]
            });
            adjacencyList.Add("conservatory", new List<Vertex>
            {
                rooms[2],
                rooms[5],
                rooms[4]
            });
            adjacencyList.Add("deck", new List<Vertex>
            {
                rooms[4],
                rooms[3],
                rooms[6]
            });
            adjacencyList.Add("exit", new List<Vertex>
            {
                rooms[5]
            });
        }

        //METHODS
        /// <summary>
        /// Iterates through the rooms list to print every rom
        /// </summary>
        public void ListAllVertices()
        {
            foreach (Vertex v in rooms)
            {
                Console.WriteLine(v.ToString());
            }
        }

        /// <summary>
        /// A method checking the adjacency Dictionary to see if a room exists
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public bool MapContainsRoom(string room)
        {
            return adjacencyList.TryGetValue(room, out List<Vertex> value);
        }

        /// <summary>
        /// Searches through the adjacency dictionary to check if 2 rooms are adjacent
        /// </summary>
        /// <param name="firstRoom">name of the first room</param>
        /// <param name="secondRoom">name of the second room</param>
        /// <returns></returns>
        public bool AdjacentArea(string firstRoom, string secondRoom)
        {
            foreach(Vertex v in adjacencyList[firstRoom])
            {
                if (v.Name == secondRoom)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// A method returning a list of rooms adjacent to a given room
        /// </summary>
        /// <param name="room">room name</param>
        /// <returns></returns>
        public List<Vertex> GetAdjacentList(string room)
        {
            return adjacencyList[room];
        }
    }
}
