using System;

namespace Lab8._1
{
    class Software
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        private int price;
        public int Price
        {
            get { return price;}
            set
            {
                if (value >= 0) price = value;
                else price = 0;
            }
        }

        private int size;
        public int Size
        {
            get { return size;}
            set
            {
                if (value > 0) size = value;
                else size = 1;
            }
        }

        public Software()
        {
            Name = "Subway Surf";
            Genre = "Casual";
            Price = 0;
            Size = 90;
        }

        public Software(string n, string g, int p, int s)
        {
            Name = n;
            Genre = g;
            Price = p;
            Size = s;
        }

        public void Network()
        {
            Console.WriteLine("If software size more than 50 Mb," +
                              " it's better to use Wi-Fi");
        }

        public void Network(int sz)
        {
            Console.WriteLine(sz > 50 ? "It's better to use Wi-Fi" : "You can use mobile network");
        }
    }
    
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Example of class with default data:");
            Software s = new Software();
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Genre: " + s.Genre);
            Console.WriteLine("Price: " + s.Price.ToString());
            Console.WriteLine("Size: " + s.Size.ToString());
            s.Network();
            Console.WriteLine("Example with user's data:");
            Console.Write("Enter name of Software: ");
            string n = Console.ReadLine();
            Console.Write("Enter genre of Software: ");
            string g = Console.ReadLine();
            Console.Write("Enter price: ");
            int p = Int32.Parse(Console.ReadLine());
            Console.Write("Enter size(Mb):");
            int sz = Int32.Parse(Console.ReadLine());
            Software sm = new Software(n, g, p, sz);
            sm.Network(sz);
            Console.ReadKey();
        }
    }
}