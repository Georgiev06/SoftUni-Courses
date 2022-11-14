using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("John");
            stack.Push("Betty");
            stack.Push("Simeon");

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(stack.IsEmpty());
        }
    }
}
