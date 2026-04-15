namespace PE___Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            //First List all vertices
            graph.ListAllVertices();

            //Then conduct 2 Breadth First searched
            graph.BreadthFirst("hall");
            Console.WriteLine();
            graph.BreadthFirst("hall");
        }
    }
}
