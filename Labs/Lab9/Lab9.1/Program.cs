using System;

namespace Lab9._1
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double  Money { get; set; }
        public Person(string n, string sur, int a, double m)
        {
            Name = n;
            Surname = sur;
            Age = a;
            Money = m;
        }

    }
    class Employee : Person
    {
       
        public int Salary { get; set; }
        public int YearApply { get; set; }

        public Employee(string n, string sur, int a, int s, int y, double m) : base(n, sur, a, m)
        {
            
            Salary = s;
            YearApply = y;
        }

        public virtual void Job()
        {
            Console.WriteLine(this.Name + " has a job");
        }
        
        public virtual void RecieveSalary()
        {
            this.Money += this.Salary;
            Console.WriteLine("You received " + this.Salary.ToString());
            
        }
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
            Employee sandy = new Employee("Sandy", "Green", 24, 2000, 2018, 200);
            Government judy = new Government("Ministry of Youth and Sports", "Judy", "Brooks", 30, 2500, 2010, 2000);
            Worker tom = new Worker("Oriflame", "Tom", "Cat", 20, 1200, 2019, 100);
            Console.WriteLine("Employee: ");
            sandy.Job();
            sandy.RecieveSalary();
            Console.WriteLine();
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