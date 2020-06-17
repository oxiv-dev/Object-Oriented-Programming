using System;
using System.Collections.Generic;

namespace Lab11
{
    class Product //describes fridge content
    {
        public string Name;
        public int Temperature = 0;

        public Product()//constructor
        {
            Console.Write("Enter name of product: ");
            Name = Console.ReadLine();
            Console.Write("Enter required temperature: ");
            Temperature = Int32.Parse(Console.ReadLine());
        }
    }

    class Fridge
    {
        List <Product> fridge = new List<Product>(); //containers for products
        List <Product> freezer = new List<Product>();
        public int FTemperature;

        public Fridge()//constructor
        {
            fridge.Add(new Product());
            FTemperature = 4;

        }

        public void AddProduct()//add product into fridge or freezer according to their required temperature
        {
            fridge.Add(new Product());
            if (fridge[fridge.Count - 1].Temperature < 0)
            {
                freezer.Add(fridge[fridge.Count - 1]);
                fridge.Remove(fridge[fridge.Count - 1]);
            }
            Console.WriteLine("Added");
        }

        public void ChangeTemperature() //change temperature in fridge
        {
            Console.Write("Enter new temperature: ");
            this.FTemperature = Int32.Parse(Console.ReadLine());
        }

        public void ShowFreezer() //show products in freezer
        {
            Console.WriteLine("Freezer content: ");
            foreach (Product a in freezer) Console.WriteLine(a.Name);
        }
        public void ShowFridge() //show products in fridge
        {
            Console.WriteLine("Fridge content: ");
            foreach (Product a in fridge) Console.WriteLine(a.Name);
        }

        public void Defrost() //increases fridge temperature up to 12 degrees
        {
            this.FTemperature = 12;
            Console.WriteLine("Defrosting started");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Fridge f1 = new Fridge();
            f1.AddProduct();
            f1.AddProduct();
            f1.AddProduct();
            f1.ChangeTemperature();
            f1.ShowFreezer();
            f1.ShowFridge();
            f1.Defrost();
        }
    }
}