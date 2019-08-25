using System;
using Algorithms_and_Data_Structures.DataStructures;

namespace Algorithms_and_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();
            stack.Push("hello");
            stack.Push("world");
            stack.Push("Isaac was here");
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Push("d");
            stack.Push("e");
            while (stack.HasNext())
            {
                Console.WriteLine(stack.Pop());
            }
            Console.ReadKey();
        }
    }
}
