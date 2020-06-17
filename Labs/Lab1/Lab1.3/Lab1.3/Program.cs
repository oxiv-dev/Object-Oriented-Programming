using System;

namespace Lab1._3
{
    public class Software
    {
        private string Name;
        private int Price;
        private int Size;

        public Software()
        {
            
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public int price
        {
            get { return Price; }
            set { Price = value; }
        }

        public int size
        {
            get { return Size; }
            set { Size = value; }
        }

        public void Network(int size)
        {
            if (size > 50)
            {
                Console.WriteLine("Для завантаження краще використовувати Wi-Fi");
            }
            else
            {
                Console.WriteLine("Можна завантажувати через мобільну мережу");
            }
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Software soft = new Software();
            Console.Write("Введіть назву ПЗ: ");
            soft.name = Console.ReadLine();
            Console.Write("Введіть Ціну: ");
            soft.price = int.Parse(Console.ReadLine());
            Console.Write("Введіть розмір ПЗ: ");
            soft.size = int.Parse(Console.ReadLine());
            soft.Network(soft.size);
            Console.ReadKey();

        }
    }
}