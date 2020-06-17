using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Lab6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamReader s = new StreamReader("/home/koshka/Desktop/OOP/Labs/Lab6/Lab6/input.txt");
            string problem = s.ReadLine();
            string[] pr = problem.Split(' ');
            int a = Int32.Parse(pr[0]);
            int b = Int32.Parse(pr[2]);
            char op = Char.Parse(pr[1]);
            double res = 0;
            switch (op)
            {
                case '+': res = a + b;
                    break;
                case '-': res = a - b;
                    break;
                case '*': res = a * b;
                    break;
                case '/': res = a / (double) b;
                    break;
                case '%': res = a % b;
                    break;
                case '^': res = Math.Pow(a, b);
                    break;
                default: break;
            }
            StreamWriter o = new StreamWriter("/home/koshka/Desktop/OOP/Labs/Lab6/Lab6/output.txt");
            o.WriteLine("Result is " + res.ToString());
            s.Close();
            o.Close();
        }
    }
}