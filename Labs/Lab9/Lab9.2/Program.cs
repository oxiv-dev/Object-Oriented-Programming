using System;
namespace Lab9._2
{
    abstract class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Money { get; set; }
        public int Salary { get; set; }
        public int YearApply { get; set; }

        public Employee(string n, string sur, int a, int s, int y, double m)
        {
            Name = n;
            Surname = sur;
            Age = a;
            Money = m;
            Salary = s;
            YearApply = y;
        }

        public abstract void Job();

        public abstract void RecieveSalary();
    }

    class Government : Employee
    {
        public string Department { get; set; }

        public Government(string d, string n, string sur, int a, int s, int y, double m) : base(n, sur, a,  s,  y, m)
        {
            Department = d;
        }

        public override void Job()
        {
            Console.Write(this.Name + " works as government worker in ");
            Console.WriteLine(this.Department);
        }
        public override void RecieveSalary()
        {
            this.Money += (this.Salary * 0.9);
            Console.WriteLine("You received " + this.Salary.ToString() + ", 10% tax has been withdrawed automatically");
        }

        public void Scedule()
        {
            Console.WriteLine("Your work starts at 9:00 and ends at 17:00");
        }
        
    }

    class Worker : Employee
    {
        public string Company { get; set; }

        public Worker(string c, string n, string sur, int a, int s, int y, double m) : base(n, sur, a, s, y, m)
        {
            Company = c;
        }
        
        public override void Job()
        {
            Console.Write(this.Name + " works as company worker in ");
            Console.WriteLine(this.Company);
        }
        public override void RecieveSalary()
        {
            this.Money += (this.Salary * 0.8);
            Console.WriteLine("You received " + this.Salary.ToString() + ", 20% tax has been withdrawed automatically");
        }

        public void Experience()
        {
            Console.WriteLine("Your work experience is " + (2020 - this.YearApply).ToString() + " years");
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Government judy = new Government("Ministry of Youth and Sports", "Judy", "Brooks", 30, 2500, 2010, 2000);
            Worker tom = new Worker("Oriflame", "Tom", "Cat", 20, 1200, 2019, 100);
            Console.WriteLine("Government worker: ");
            judy.Job();
            judy.RecieveSalary();
            judy.Scedule();
            Console.WriteLine();
            Console.WriteLine("Company worker: ");
            tom.Job();
            tom.RecieveSalary();
            tom.Experience();
        }
    }
}