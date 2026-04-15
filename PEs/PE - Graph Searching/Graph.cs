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
        private int[,] adjacencyMatrix;

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

            //Set up adjacency Matrix
            adjacencyMatrix = new int[rooms.Count, rooms.Count];

            for (int i = 0; i < rooms.Count; i++)
            {
                for (int j = 0; j < rooms.Count; j++)
                {
                    if (AdjacentArea(rooms[i].Name, rooms[j].Name))
                    {
                        adjacencyMatrix[i, j] = 1;
                    }
                }
            }
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

        /// <summary>
        /// A method to reset visited nodes after a search
        /// </summary>
        public void Reset()
        {
            foreach(Vertex v in rooms)
            {
                v.IsVisited = false;
            }
        }

        /// <summary>
        /// Checks to see if a room has an adjacent and unvisited room
        /// </summary>
        /// <param name="roomName">name of the current room</param>
        /// <returns></returns>
        public Vertex GetAdjacentUnvisited(string roomName)
        {
            int roomIndex = 0;

            foreach (Vertex v in rooms) 
            {
                if(v.Name == roomName)
                {
                    roomIndex = rooms.IndexOf(v);
                }
            } 

            for(int y = 0; y < adjacencyMatrix.GetLength(0); y++)
            {
                if (adjacencyMatrix[roomIndex, y] == 1 && !rooms[y].IsVisited )
                {
                    return rooms[y];
                }
            }

            return null;
        }

        /// <summary>
        /// Conducts a Breadth first search starting from roomName and ending at Exit
        /// </summary>
        /// <param name="roomName">the starting room for the search</param>
        public void BreadthFirst(string roomName)
        {
            //Entering an incorrect roomName ends the search early
            if (adjacencyList[roomName] == null)
            {
                Console.WriteLine($"The room <{roomName}> is not a valid room");
                return;
            }


            //Begin search
            Queue<Vertex> queue = new Queue<Vertex>();
            Vertex currentVertex = null;


            for(int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Name == roomName)
                {
                    currentVertex = rooms[i];
                }
            }

            Reset();

            Console.WriteLine(" - " + roomName);
            queue.Enqueue(currentVertex);
            currentVertex.IsVisited = true;

            //Start iterative search
            do
            {
                //currentVertex is now the current front queue room
                currentVertex = queue.Peek();

                //If there is an adjacent unvisited room, queue it
                if (GetAdjacentUnvisited(currentVertex.Name) != null)
                {
                    queue.Enqueue(GetAdjacentUnvisited(currentVertex.Name));
                    Console.WriteLine($" - {queue.Last().Name}");
                    queue.Last().IsVisited = true;


                    //currentVertex is now the current front queue room
                    currentVertex = queue.Peek();
                }

                //No more adjacent unvisited rooms? dequeue this room
                else
                {
                    queue.Dequeue();
                }
            } while (queue.Count > 0);
        }
    }
}
