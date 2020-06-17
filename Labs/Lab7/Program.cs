using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Lab7
{
    interface IComparable
    {
        int CompareTo(object o);
    }

    interface IComparer
    {
        int Compare(object o1, object o2);
    }
    class OS
    {
        public int Price { get; set; }
        public int Year { get; set; }
        Random rand = new Random();

        public OS(int p, int y)
        {
            Price = p;
            Year = y;
        }
    }

    class Group : IComparable<OS>
    {
        List<OS> systems = new List<OS>();

        public Group(OS first, OS second)
        {
            systems.Add(first);
            systems.Add(second);
            
        }

        public int CompareTo(OS a)
        {
            return systems[1].Price.CompareTo(a.Price);
        }
    }
    internal class Program
    {
        public static void CompareResult(int res)
        {
            switch (res)
            {
                case 1:
                    Console.WriteLine("Given OS is more expensive than test example");
                    break;
                case -1:
                    Console.WriteLine("Given OS is cheaper than test example");
                    break;
                case 0:
                    Console.WriteLine("Prices are equal");
                    break;
                default:
                    Console.WriteLine("Something wrong.");
                    break;
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter price and year of ... for test example: ");
            int pr = Int32.Parse(Console.ReadLine());
            int yr = Int32.Parse(Console.ReadLine());
            OS test = new OS(pr, yr);
            Console.Write("Enter price and year of ... for example to compare: ");
            pr = Int32.Parse(Console.ReadLine());
            yr = Int32.Parse(Console.ReadLine());
            OS toComp = new OS(pr, yr);
            Group one = new Group(test, toComp);
            int res = one.CompareTo(test);
            CompareResult(res);
            
        }
    }
}