using  System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ConsoleApplication1
{
    public abstract class Home
    {
        private int _people = 1;//default value
        public int People
        {
            get { return _people; }
            set
            {
                if (value > 0) _people = value;
            }
        }
        
        protected int Calc(string c, string n) // calculates price to pay for used goods
        {
            int before, now, tariff, amount;
            do
            {
                Console.Write("Enter current " + c + " meter in " + n + ": ");
                now = Int32.Parse(Console.ReadLine());
                Console.Write("Enter previous meter: ");
                before = Int32.Parse(Console.ReadLine());
                if (now < before) Console.WriteLine("Current meter cannot be less than previous!");
            } while (now < before);
            Console.Write("Enter tariff: ");
            tariff = Int32.Parse(Console.ReadLine());
            amount = (now - before) * tariff;
            return amount;
        }
        protected int AskMonth() //asks month for calculate/pay
        {
            Console.Write("Enter month(1 - 12): ");
            int m = Int32.Parse(Console.ReadLine()) - 1;
            return m;
        }
    }
    public class Single : Home
    {
        public int[] gasAccount = new int[12]; //"int" arrays collect sum
        public bool[] gasPayments = new bool[12]; //"bool" arrays collect payment status
        public int[] waterAccount = new int[12];
        public bool[] waterPayments = new bool[12];
        public int[] electricityAccount = new int[12];
        public bool[] electricityPayments= new bool[12];
        private bool _type = false;
        public bool Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Name;
        public Single() //contructor without parameters
        {
            Console.Write("Enter name of house: ");
            Name = Console.ReadLine();
            Console.Write("Enter number of people which registered in the house: ");
            People = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < 12; ++i) //sets all parameters to default value
            {
                gasAccount[i] = 0;
                waterAccount[i] = 0;
                electricityAccount[i] = 0;
                gasPayments[i] = false;
                waterPayments[i] = false;
                electricityPayments[i] = false;
            };
        }
        public Single (string n, int p) //constructor with parameters
        {
            Name = n;
            People = p;
            for (int i = 0; i < 12; ++i) //sets all parameters to default value
            {
                gasAccount[i] = 0;
                waterAccount[i] = 0;
                electricityAccount[i] = 0;
                gasPayments[i] = false;
                waterPayments[i] = false;
                electricityPayments[i] = false;
            };
        }

        public void CalculateGas() //calculates price of used gas
        {
            string com = "gas";
            string n = this.Name;
            gasAccount[AskMonth()] = Calc(com, n);
        }
        public void CalculateWater() //calculates price of used water
        {
            string com = "water";
              string n = this.Name;
            this.waterAccount[AskMonth()] = Calc(com, n);
        }
        public void CalculateElectricity() //calculates price of used electricity
        {
            string com = "electricity";
              string n = this.Name;
            this.electricityAccount[AskMonth()] = Calc(com, n);
        }
        //           Paying bills      //
        public void PayForGas()
        {
            gasPayments[AskMonth()] = true;
            Console.WriteLine("Payed");
        }
        public void PayForWater()
        {
            waterPayments[AskMonth()] = true;
            Console.WriteLine("Payed");
        }
        public void PayForElectricity()
        {
            electricityPayments[AskMonth()] = true;
            Console.WriteLine("Payed");
        }
        //////////////////////////////////////
    }
    public class Multiple : Home
    {
        public List<Single> house = new List<Single>(); //multiple house type as group of single type
        public string Name;
        private int size = 1;

        public int Size
        {
            get { return size; }
            set
            {
                if (value > 1) size = value;
            }
        }
        private int _total = 1; //number of people in house
        public int Total
        {
            get { return _total; }
            set
            {
                if (value > 0) _total = value;
            }
        }
        public Multiple(int size)//constructor with parameters
        {
            Console.Write("Enter multiple house name: ");
            Name = Console.ReadLine();
            int all = 0;
            for (int i = 0; i < size; ++i)
            {
                house.Add(new Single());
                house[i].Type = true; //defines house type as part of multiple
                all += house[i].People;
            }
            Total = all;
        }
        public void CalculateGas()//calculates price of consumed gas
        {
            int mn = AskMonth();
            string com = "gas";
              string n = this.Name;
            int sum = Calc(com, n);
            foreach (Single flat in house)
            {
                flat.gasAccount[mn] = (int) (sum * ((double)flat.People / Total)) + 1;
            }
        }
        public void CalculateWater() //same
        {
         int mn = AskMonth();
         string com = "water";
           string n = this.Name;
         int sum = Calc(com, n);
            foreach (Single flat in house)
            {
                flat.waterAccount[mn] = (int) (sum * ((double)flat.People / Total)) + 1;
            }
        }
        public void CalculateElectricity() //same
        {
         int mn = AskMonth();
         string com = "electricity";
           string n = this.Name;
         int sum = Calc(com, n);
            foreach (Single flat in house)
            {
                flat.electricityAccount[mn] = (int) (sum * ((double)flat.People / Total)) + 1;
            }
        }

        private int AskName() //asks name of house owner
        {
            Console.Write("Enter name of your house: ");
            string name = Console.ReadLine();
            int num = Find(name);
            return num;
        }
        //also paying bills with check of registration in house//
        public void PayForGas()
        {
            int num = AskName();
            if(num > -1)
            {
                house[num].gasPayments[AskMonth()] = true;
                Console.WriteLine("Payed");
            }
        }
        public void PayForWater()
        {
            int num = AskName();
            if(num > -1)
            {
                house[num].waterPayments[AskMonth()] = true;
                Console.WriteLine("Payed");
            }
        }
        public void PayForElectricity()
        {
            int num = AskName();
            if(num > -1)
            {
                house[num].electricityPayments[AskMonth()] = true;
                Console.WriteLine("Payed");
            }
        }
        /////////////////////////////////////////////////////////
        private int Find(string name)
        {
            for (int i = 0; i < size; ++i)
                if (house[i].Name == name) return i;
            Console.WriteLine("You aren't live here!");
            return -1;
        }
    }
    public class Consumers //class-container
    {
       public List<Single> consumers = new List<Single>(); //using default constructor
       public void Add(Single a) //add a single type houses to the list
       {
           consumers.Add(a);
       }
       public void Add(Multiple a) //overload method for adding multiple type houses to the list
       {
           foreach (Single item in a.house)
           {
               consumers.Add(item);
           }
       }
       public void Show() //show report about consumed goods and payment status in chosen month
       {
           Console.Write("Enter month(1-12): ");
           int m = Int32.Parse(Console.ReadLine()) - 1;
           List<string> mon = new List<string>{"January", "February", "March", "April", "May", "June", "July", "August",
               "September", "October", "November", "December"};
           Console.WriteLine($"Chosen month: {mon[m]}");
           Console.WriteLine("|      |            |          |                   Goods                    |");
           Console.WriteLine("----------------------------------------------------------------------------|");
           Console.WriteLine("|Number|    Name    |   Type   |      Gas     |    Water     | Electricity  |");
           Console.WriteLine("----------------------------------------------------------------------------|");
           Console.WriteLine("|      |            |          |   Sum  |Payed|   Sum  |Payed|   Sum  |Payed|");
           Console.WriteLine("----------------------------------------------------------------------------|");
           //Things for formatting
           string TypeH, G, W, E; 
           int c = 1;
           //////////////
           foreach (Single build in consumers) //formatted output
           {
               TypeH = (build.Type)?"Multiple":"Single";
               G = (build.gasPayments[m]) ? "+" : "-";
               W = (build.waterPayments[m]) ? "+" : "-";
               E = (build.electricityPayments[m]) ? "+" : "-";
               Console.WriteLine(String.Format("|{0, 4}  |", c) + String.Format("{0, 12}|", build.Name) + 
                                 String.Format("{0, 10}|", TypeH) + String.Format("{0,6}  |", build.gasAccount[m]) + 
                                 String.Format("{0, 3}  |", G) + String.Format("{0,6}  |", build.waterAccount[m]) + 
                                 String.Format("{0, 3}  |", W) + String.Format("{0, 6}  |", build.electricityAccount[m]) + 
                                 String.Format("{0, 3}  |", E));
               c++;
           }
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            int mode = 1;
            Single s1 = new Single("Tower", 10);
            Single s2 = new Single();
            Multiple m1 = new Multiple(2);
            s1.CalculateGas();
            s1.CalculateWater();
            s1.CalculateElectricity();
            s2.CalculateGas();
            s2.CalculateWater();
            s2.PayForGas();
            s2.CalculateElectricity();
            s1.PayForElectricity();
            m1.CalculateGas();
            m1.CalculateWater();
            m1.CalculateElectricity();
            Consumers c = new Consumers();
            c.Add(s1);
            c.Add(m1);
            c.Add(s2);
            while (mode != 0)
            {
                c.Show();
                Console.Write("If you want to look at report again, press 1(0 to quit): ");
                mode = Int32.Parse(Console.ReadLine());
            }
        }
    }
}