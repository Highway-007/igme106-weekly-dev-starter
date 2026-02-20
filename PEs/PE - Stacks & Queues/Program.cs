
using System;

namespace PE___Stacks___Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> intStack = new MyStack<int>();
            MyStack<string> stringStack = new MyStack<string>();
            MyQueue<int> intQueue = new MyQueue<int>();
            MyQueue<string> stringQueue = new MyQueue<string>();

            //Stack Testing
            Console.WriteLine("Adding ints 33, 44, 55, and 66 to a stack from least to greatest");
            intStack.Push(33);
            intStack.Push(44);
            intStack.Push(55);
            intStack.Push(66);

            Console.WriteLine($"Lets look at whats at the top: {intStack.Peek()}");
            Console.WriteLine("Printing the stack of ints:");
            for(int i = intStack.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"\n\t- {intStack.Pop()}");
            }

            Console.WriteLine("\nAdding strings a, b, c, and d to a stack in alphabetical order");
            stringStack.Push("a");
            stringStack.Push("b");
            stringStack.Push("c");
            stringStack.Push("d");

            Console.WriteLine($"Lets look at whats at the top: {stringStack.Peek()}");
            Console.WriteLine("Printing the stack of strings:");
            for (int i = stringStack.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"\n\t- {stringStack.Pop()}");
            }


            //Queue Testing
            Console.WriteLine("\nAdding ints 11, 77, 88, and 99 to a Queue from least to greatest");
            intQueue.Enqueue(11);
            intQueue.Enqueue(77);
            intQueue.Enqueue(88);
            intQueue.Enqueue(99);

            Console.WriteLine($"Lets look at whats at the front: {intQueue.Peek()}");
            Console.WriteLine("Printing the queue of ints:");
            for (int i = intQueue.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"\n\t- {intQueue.Dequeue()}");
            }

            Console.WriteLine("\nAdding strings e, f, g, and h to a queue in alphabetical order");
            stringQueue.Enqueue("e");
            stringQueue.Enqueue("f");
            stringQueue.Enqueue("g");
            stringQueue.Enqueue("h");

            Console.WriteLine($"Lets look at whats at the front: {stringQueue.Peek()}");
            Console.WriteLine("Printing the queue of strings:");
            for (int i = stringQueue.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"\n\t- {stringQueue.Dequeue()}");
            }
        }
    }
}
