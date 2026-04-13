namespace PE___Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            string currentRoom = "hall";
            List<Vertex> nearbyRooms;
            string userResponse;

            //First list all rooms
            graph.ListAllVertices();

            //Then show a menu of adjacent rooms
            while(currentRoom != "exit")
            {
                Console.WriteLine();
                nearbyRooms = graph.GetAdjacentList(currentRoom);
                Console.WriteLine($"You are currently in the {currentRoom}" +
                    $"\n   Nearby are:   ");
                foreach(Vertex vertex in nearbyRooms)
                {
                    Console.Write($"- {vertex.Name}   ");
                }

                //Check where user wants to go
                Console.WriteLine();
                userResponse = SmartConsole.Prompt("Where would you like to go? ").ToLower().Trim();
                if (graph.MapContainsRoom(userResponse))
                {
                    if(graph.AdjacentArea(currentRoom, userResponse))
                    {
                        currentRoom = userResponse;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, {currentRoom} and {userResponse} aren't adjacent.");
                    }
                }
                else
                {
                    Console.WriteLine("That room doesn't exist!");
                }
            }
        }
    }
}
