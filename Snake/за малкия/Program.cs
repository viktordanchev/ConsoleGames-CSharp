using System;
using System.Collections.Generic;

namespace за_малкия
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 23 };
            List<int> list2 = list;
            list2[0] = 32;
            Console.WriteLine(string.Join(", ", list)); //1, 23 
            Console.WriteLine(string.Join(", ", list2)); //32, 23 
        }
    }
}
