using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Lab8._2
{
    
class Person
    {
        public string Name;
        public int Age;
        public string Role;
        public Person(string N, string R, int A)
        {
            Name = N;
            Age = A;
            Role = R;
        }
        public string GetName() { return Name; }
    }
    class St_Assesment
    {
        int [] assesment;
        public St_Assesment()
        {
            assesment = new int[10];
        }
        //indexator
        public int this[int index]
        {
            get
            {
                return assesment[index];
            }
            set
            {
                assesment[index] = value;
            }
        }

        public double StRating(Random arand)
        {
            Console.Write("Your marks: ");
            double rating = 0;
            for (int i = 0; i < 10; i++)
            {
                assesment[i] = arand.Next(40, 100);
                rating += assesment[i];
                Console.Write(assesment[i].ToString() + ",");
            }
            Console.WriteLine();
            return rating / 10;
        }
    }
    class Student : Person
    {
        public string Facultet;
        public string Group;
        public int Course;
        public Student(string N, string R, int A, string F, string G, int C)
        : base(N, R, A)
        {
            Name = N;
            Age = A;
            Role = R;
            Facultet = F;
            Group = G;
            Course = C;
        }
       St_Assesment strating = new St_Assesment();
        public void MyRating(Random arand)
        {
            double Rating = strating.StRating(arand);
            Console.WriteLine("Your rating: " + Rating.ToString());
            if (Rating >= 82)
                Console.WriteLine("Good job!");
            else
                if (Rating <= 60)
                Console.WriteLine("Refresher course");
            else
                Console.WriteLine("You can do it better");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student newSt = new Student("Ivanov", "student", 20, "КННІ", "K - 01 ", 3);
            Random arand = new Random();
            newSt.MyRating(arand);
            Console.ReadKey();

        }
    }
}