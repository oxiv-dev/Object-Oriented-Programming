using System;
using System.Collections.Generic;

namespace L7._2
{
    interface IComparer
    {
        int Compare(object o1, object o2);
    }

    class OS
    {
        public int Price { get; set; }
        public int Year { get; set; }

        public OS()
        {
            Price = 2000;
            Year = 2020;
        }

        public OS(int p, int y)
        {
            Price = p;
            Year = y;
        }
    }
    class ToCompare: IComparer<OS>
    {
        public List<OS> pair = new List<OS>();

        public ToCompare(OS first, OS second)
        {
            pair.Add(first);
            pair.Add(second);
        }
        
        public int Compare(OS first, OS second)
        {
            if (first.Year == second.Year)
            {
                if (first.Price < second.Price)
                    return -1;
                else if (first.Price > second.Price)
                    return 1;
                else return 0;
            }
            else if (first.Year < second.Year)
            {
                if (first.Price < second.Price)
                    return -2;
                else if (first.Price > second.Price)
                    return 2;
                else return 8;
            }
            else
            {
                if (first.Price < second.Price)
                    return -3;
                else if (first.Price > second.Price)
                    return 3;
                else return 5;
            }
        }
    }

    internal class Program
    {
        public static void CompareResult(int res)
        {
            switch (res)
            {
                case -1: Console.WriteLine("First OS is cheaper then second. Both are the same age.");
                    break;
                case 1: Console.WriteLine("First OS is more expensive then second. Both are the same age.");
                    break;
                case 0: Console.WriteLine("Prices are equal. Both are the same age.");
                    break;
                case -2: Console.WriteLine("First OS is cheaper then second. First OS is older than second.");
                    break;
                case 2: Console.WriteLine("First OS is more expensive then second. First OS is older than second.");
                    break;
                case 8: Console.WriteLine("Prices are equal. First OS is older than second.");
                    break;
                case -3: Console.WriteLine("First OS is cheaper then second. Second OS is older than first.");
                    break;
                case 3: Console.WriteLine("First OS is more expensive then second. Second OS is older than first.");
                    break;
                case 5: Console.WriteLine("Prices are equal. Second OS is older than first.");
                    break;
                default: Console.WriteLine("Something wrong.");
                    break;
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter price and year of production of first OS: ");
            int pr = Int32.Parse(Console.ReadLine());
            int yr = Int32.Parse(Console.ReadLine());
            OS first = new OS(pr, yr);
            Console.WriteLine("Enter price and year of production of second OS: ");
            pr = Int32.Parse(Console.ReadLine());
            yr = Int32.Parse(Console.ReadLine());
            OS second = new OS(pr, yr);
            ToCompare b = new ToCompare(first, second);
            int res = b.Compare(first, second);
            CompareResult(res);

        }
    }
}