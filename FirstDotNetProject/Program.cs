using System;
using FirstLib;
using System.Collections;

namespace FirstDotNetProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // char[] charsToTrim = { '*', ' ', '\''};
            // string banner = "*'** 'Much *Ado About Nothing ***";
            // string result = banner.Trim(charsToTrim);
            // string result2 = banner.TrimStart(charsToTrim);
            // string result3 = banner.TrimEnd(charsToTrim);
            // Console.WriteLine("Trimmmed\n   {0}\nto\n   {1}", banner, result);
            // Console.WriteLine("Trimmmed\n   {0}\nto\n   {1}", banner, result2);
            // Console.WriteLine("Trimmmed\n   {0}\nto\n   {1}", banner, result3);
            // System.Console.WriteLine("     hi       ".Trim());
            // System.Console.WriteLine("     hi       ##".Trim('#'));
            Hashtable my_hashtable1 = new Hashtable(); 
  
            // Adding key/value pair  
            // in the hashtable 
            // Using Add() method 
            my_hashtable1.Add("A1", "Welcome"); 
            my_hashtable1.Add("A2", "to"); 
            my_hashtable1.Add("A3", "Publicis Sapient"); 
    
            Console.WriteLine("Key and Value pairs from my_hashtable1:"); 
    
            foreach(DictionaryEntry ele1 in my_hashtable1) 
            { 
                Console.WriteLine("{0} and {1} ", ele1.Key, ele1.Value); 
            } 

            my_hashtable1.Remove("A2"); 
  
            Console.WriteLine("Key and Value pairs :"); 
    
            foreach(DictionaryEntry ele1 in my_hashtable1) 
            { 
                Console.WriteLine("{0} and {1} ", ele1.Key, ele1.Value); 
            } 
            Console.WriteLine(my_hashtable1.Contains("A3")); 
            Console.WriteLine(my_hashtable1.ContainsValue("to"));

            // Create another hashtable 
            // Using Hashtable class 
            // and adding key/value pairs 
            // without using Add method 
            Hashtable my_hashtable2 = new Hashtable() { 
                                        {1, "hello"}, 
                                            {2, 234}, 
                                            {3, 230.45}, 
                                            {4, null}}; 
    
            Console.WriteLine("Key and Value pairs from my_hashtable2:"); 
    
            foreach(var ele2 in my_hashtable2.Keys) 
            { 
                Console.WriteLine("{0} and {1}", ele2, 
                                my_hashtable2[ele2]); 
            } 
        }
    }
}