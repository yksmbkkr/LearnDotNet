using System;
using FirstLib;

namespace FirstDotNetProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            System.Console.WriteLine("I am in .net project");

            var ob = new Addition();
            ob.display();
        }
    }
}