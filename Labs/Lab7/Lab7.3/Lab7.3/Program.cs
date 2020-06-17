using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lab7._3
{
    interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
   public class OS
    {
        public string Name;
        public int Price;
        public int Year;

        public OS()
        {
            Name = "Windows 10";
            Price = 100;
            Year = 2020;
        }

        public OS(string n, int p, int y)
        {
            Name = n;
            Price = p;
            Year = y;
        }
    }

   public class Group : IEnumerable
   {
       public List<OS> systems = new List<OS>();

       public Group()
       {
           systems.Add(new OS());
       }
        //Constructor with parameters and interaction with user
       public Group(int num)
       {
           string nm;
           int pr, yr;
           for (int i = 0; i < num; ++i)
           {
               Console.Write("Enter name of System" + (i+1).ToString() + ": ");
               nm = Console.ReadLine();
               Console.Write("Enter price of System" + (i+1).ToString() + ": ");
               pr = Int32.Parse(Console.ReadLine());
               Console.Write("Enter System year of product" + (i+1).ToString() + ": ");
               yr = Int32.Parse(Console.ReadLine());
               systems.Add(new OS(nm, pr, yr));
           }
       }
        //Implementing an IEnumerator
       public IEnumerator GetEnumerator()
       {
           return systems.GetEnumerator();
       }
       //Sorting by price and age
       public void Sort()
       {
           OS buf;
           for (int i = 0; i < systems.Count - 1; ++i)
           {
               for (int j = 1; j < systems.Count; ++j)
               {
                   if (systems[i].Price > systems[j].Price)
                   {
                       buf = systems[i];
                       systems[i] = systems[j];
                       systems[j] = buf;
                   }
                   else if (systems[i].Price == systems[j].Price)
                   {
                       if (systems[i].Year <= systems[j].Year) continue;
                       buf = systems[i];
                       systems[i] = systems[j];
                       systems[j] = buf;
                   }
               }
           }
       }
   }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter number of systems: ");
            int num = Int32.Parse(Console.ReadLine());
            Group sys = new Group(num);
            sys.Sort();
            Console.WriteLine("Sorted by increasing of price and decreasing of age");
            Console.WriteLine("  Name      Price     Year");
            foreach (OS s in sys)
            {
                Console.WriteLine(s.Name + "  " + s.Price.ToString() + "      " + s.Year.ToString());
            }
        }
    }
}