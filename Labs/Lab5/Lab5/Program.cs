using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Lab5
{
   class Person
    {
        public string Name;
        public int Age;
        public string Role;
        public Person(string N, int A, string R)
        {
            Name = N;
            Age = A;
            Role = R;
        }
    }

   class St_Assement
   {
       private double[] assesment = new double[7];

       public double StRating(Random rand)
       {
           double rating = 0;
           for (int i = 0; i < 7; ++i)
           {
               assesment[i] = rand.Next(60, 100);
               rating += assesment[i];
               Console.Write(assesment[i].ToString() + ",");
           }
           Console.WriteLine();
           return rating / 7;
       }
   }
    class Student : Person
    {
        public string Faculty;
        public string Group;
        public int Course;
        public Student(string N, int A, string R, string F, string G, int C) : base(N, A, R)
        {
            Name = N;
            Age = A;
            Role = R;
            Faculty = F;
            Group= G;
            Course = C;
        }
        St_Assement r1 = new St_Assement();
        St_Assement r2 = new St_Assement();

        public void MyRating(Random rand)
        {
            double R1 = r1.StRating(rand);
            double R2 = r2.StRating(rand);
            double R = (R1 + R2) / 2;
            Console.WriteLine("Student Rating is " + R.ToString());
            if (R >= 82) Console.WriteLine("Good job!");
            else if (R < 60) Console.WriteLine("Refresher course!");
            else Console.WriteLine("You can do it better");
        }
    }

    public class Faculty
    {
        public string FacN;

        public partial class Department
        {
            public string DepN;
            public int Teachers;
           

            public string GetDepN()
            {
                return DepN;
            }
            public int NTeach()
            {
                return Teachers;
            }
        }

        public partial class Department
        {
            public string[] disc;
            public void Disc()
            {
                foreach (var d in disc)
                {
                    Console.Write(d + ", ");
                }
            }
        }
        public Department d1 = new Department();
        public Department d2 = new Department();

        public string FacultN()
        {
            return FacN;
        }
    }
     static class Op
    {
        public static void MaxMin(double[] list)
        {
            double max = 0;
            double min = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (i == (list.Length - 1))
                {
                    if (max < list[list.Length - 1])
                    {
                        max = list[list.Length - 1];
                    }
                    if (min > list[list.Length - 1])
                    {
                        min = list[list.Length - 1];
                    }
                }
                else if (max > list[i])
                {
                    max = Math.Max(list[i], list[i + 1]);
                }
                else if (min < list[i])
                {
                    min = Math.Min(list[i], list[i + 1]);
                }
            }
            Console.WriteLine("Max: " + max.ToString());
            Console.WriteLine("Min: " + min.ToString());
        }
        
        public static void Unique(int[] list)
        {
            int count = 0;
            for(int i = 0; i < list.Length-1; ++i)
            {
                for(int j = i + 1; j < list.Length; ++j)
                {
                    if (list[i] == list[j] && list[j] != 0)
                    {
                        list[j] = 0;
                    }
                }
            }
            for (int i = 0; i < list.Length; ++i)
            {
                if(list[i] != 0) count++;
            }
            Console.WriteLine("Amount of different numbers: " + count.ToString());
        }
        
        public static void Linear(int[] list)
        {
            int temp;
            for (int i = 0; i < list.Length - 1; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[i] > list[j])
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            int max = list[list.Length - 1];
            int min = list[0];
            Console.WriteLine("Max: " + max.ToString());
            Console.WriteLine("Min: " + min.ToString());
        }
    }

internal class Program
    {
        public static void Task1()
        {
            string N, R, F, G;
            int A, C;
            Random rand = new Random();
            Console.Write("Enter Name: ");
            N = Console.ReadLine();
            Console.Write("Enter Role: ");
            R = Console.ReadLine();
            Console.Write("Enter Age: ");
            A = Int32.Parse(Console.ReadLine());
            Console.Write("Enter Faculty: ");
            F = Console.ReadLine();
            Console.Write("Enter Group: ");
            G = Console.ReadLine();
            Console.Write("Enter Course: ");
            C = Int32.Parse(Console.ReadLine());
            Student St = new Student(N, A, R, F, G, C);
            St.MyRating(rand);

        }
    public static void Task2()
        {
            Faculty f1 = new Faculty();
            f1.FacN = "Faculty of Informational Technologies";
            f1.d1.DepN = "Program System and Technologies";
            f1.d1.Teachers = 10;
            f1.d1.disc = new[] {"OOP", "ASD", "BPI", "CNT"};
            Console.WriteLine("Faculty: " + f1.FacultN());
            Console.WriteLine();
            Console.WriteLine("First Department: " + f1.d1.GetDepN());
            Console.Write("Disciplines: ");
            f1.d1.Disc();
            Console.WriteLine();
            Console.WriteLine("Number of Teachers: " + f1.d1.NTeach().ToString());
            Console.WriteLine();
            f1.d2.DepN = "Cybersecurity";
            f1.d2.Teachers = 8;
            f1.d2.disc = new[] {"Physic", "Cryptography", "Programming", "Cyber Law"};
            Console.WriteLine("Second Department: " + f1.d2.GetDepN());
            Console.Write("Disciplines: ");
            f1.d2.Disc();
            Console.WriteLine();
            Console.WriteLine("Number of Teachers: " + f1.d2.NTeach().ToString());
            Console.WriteLine();
            
        }
    public static void Task3()
        {
            Console.WriteLine("Class Department contains two partial classes");
        }

    public static void Task4()
        {
            double[] arr1 = new double[4] { 2, 8.3, 6.3, 7.2 };
            int[] arr2 = new int[9] { 1, 2, 5, 3, 7, 5, 1, 3, 4 };
            int[] arr3 = new int[8] { 4, 5, 2, 3, 8, 7, 6, 1 };

            Op.MaxMin(arr1);
            Console.WriteLine();
            Op.Unique(arr2);
            Console.WriteLine();
            Op.Linear(arr3);
            
        }

    public static void Main(string[] args)
        {
            int t = 1;
            while (t != 0)
            {
                Console.WriteLine("Choose task: ");
                t = Int32.Parse(Console.ReadLine());
                switch (t)
                {
                    case 1: Task1();
                        break;
                    case 2: Task2();
                        break;
                    case 3: Task3();
                        break;
                    case 4: Task4();
                        break;
                }
            }
        }
    }
}