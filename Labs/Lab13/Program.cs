using System;

namespace Lab13
{
    class Weight //describes data type
    {
        public int Tone;
        public int Kilo;
        public double Gramm;

        public Weight(int t, int k, double g) //consructor with parameters
        {
            if (t > 0) Tone = t;
            else Tone = 0;
            if (k > 0) Kilo = k;
            else Kilo = 0;
            if (g > 0) Gramm = g;
            else Gramm = 0;
        }

        public static Weight operator +(Weight aw, Weight bw) //overload operator "+"
        {
            double a = aw.Tone * 1000000 + aw.Kilo * 1000 + aw.Gramm;
            double b = bw.Tone * 1000000 + bw.Kilo * 1000 + bw.Gramm;
            double c = a + b;
            return new Weight((int) c/1000000, (int) (c % 1000000) / 1000, c % 1000);
        }
        public static Weight operator -(Weight aw, Weight bw) //overload operator "-"
        {
            double a = aw.Tone * 1000000 + aw.Kilo * 1000 + aw.Gramm;
            double b = bw.Tone * 1000000 + bw.Kilo * 1000 + bw.Gramm;
            double c = a - b;
            return new Weight((int) c/1000000, (int) (c % 1000000) / 1000, c % 1000);
        } 
        public static Weight operator *(Weight aw, Weight bw) //overload operator "*"
        {
            Console.Write("Enter constant: ");
            double b = Double.Parse(Console.ReadLine());
            double a = aw.Tone * 1000000 + aw.Kilo * 1000 + aw.Gramm;
            double c = (int) (a * b);
            return new Weight((int) c/1000000, (int) (c % 1000000) / 1000, c % 1000);
        } 
        public static double operator /(Weight aw, Weight bw) //overload operator "/"
        {
            double a = aw.Tone * 1000000 + aw.Kilo * 1000 + aw.Gramm;
            double b = bw.Tone * 1000000 + bw.Kilo * 1000 + bw.Gramm;
            double c = a / b;
            return c;
        }
        public static bool operator >(Weight aw, Weight bw) //overload operator ">"
        {
            double a = aw.Tone * 1000000 + aw.Kilo * 1000 + aw.Gramm;
            double b = bw.Tone * 1000000 + bw.Kilo * 1000 + bw.Gramm;
            if (a > b) return true;
            else return false;
        } 
        public static bool operator ==(Weight aw, Weight bw) //overload operator "=="
        {
            double a = aw.Tone * 1000000 + aw.Kilo * 1000 + aw.Gramm;
            double b = bw.Tone * 1000000 + bw.Kilo * 1000 + bw.Gramm;
            if (a == b) return true;
            else return false;
        }
        public static bool operator !=(Weight aw, Weight bw) //overload operator "!="
        {
            double a = aw.Tone * 1000000 + aw.Kilo * 1000 + aw.Gramm;
            double b = bw.Tone * 1000000 + bw.Kilo * 1000 + bw.Gramm;
            if (a != b) return true;
            else return false;
        } 
        public static bool operator <(Weight aw, Weight bw) //overload operator "<"
        {
            double a = aw.Tone * 1000000 + aw.Kilo * 1000 + aw.Gramm;
            double b = bw.Tone * 1000000 + bw.Kilo * 1000 + bw.Gramm;
            if (a < b) return true;
            else return false;
        }

        public Weight Round() //rounds weight to the less(only first!) accuracy 1g
        {
            this.Gramm = (int) this.Gramm;
            return (new Weight(this.Tone, this.Kilo, this.Gramm));
        }
        public void Show() //displays result
        {
            Console.WriteLine("Result: {0}t {1}kl {2}g", Tone, Kilo, Gramm);
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            int mode = 1;
            while ( mode != 0)
            {
                //entering weight
                Console.Write("Enter first weight(kilos)(kilo.ggg): ");
                double f = (double.Parse(Console.ReadLine()));
                double a = (f * 1000);
                Console.Write("Enter second weight(kilos)(kilo.ggg): ");
                double s = (double.Parse(Console.ReadLine()));
                double b = (s * 1000);
                //converting to data type format
                Weight ar = new Weight((int) (a/1000000), (int) ((a % 1000000) / 1000), (a % 1000));
                Weight br = new Weight((int) b/1000000, (int) (b % 1000000) / 1000, b % 1000);
                Console.Write("Enter action(| to round): ");
                //defines operation
                string act = Console.ReadLine();
                Weight cr, cr1, cr2;
                double cri;
                bool crb;
                //allow to choose operation
                switch (act)
                {
                    case "+":
                        cr = ar + br;
                        cr.Show();
                        break;
                    case "-":
                        cr = ar - br;
                        cr.Show();
                        break;
                    case "*":
                        cr = ar * br;
                        cr.Show();
                        break;
                    case "/":
                        cri = ar / br;
                        Console.WriteLine("Result: " + cri.ToString());
                        break;
                    case ">":
                        cr1 = ar.Round();
                        cr2 = br.Round();
                        crb = cr1 > cr2;
                        Console.WriteLine("Result: " + crb);
                        break;
                    case "<":
                        cr1 = ar.Round();
                        cr2 = br.Round();
                        crb = cr1 < cr2;
                        Console.WriteLine("Result: " + crb);
                        break;
                    case "==":
                        cr1 = ar.Round();
                        cr2 = br.Round();
                        crb = cr1 == cr2;
                        Console.WriteLine("Result: " + crb);
                        break;
                    case "!=":
                        cr1 = ar.Round();
                        cr2 = br.Round();
                        crb = cr1 != cr2;
                        Console.WriteLine("Result: " + crb);
                        break;
                    case "|":
                        cr = ar.Round();
                        cr.Show();
                        break;
                    default: break;
                }
                //ask for new calculation
                Console.Write("New calculation?: ");
                mode = Int32.Parse(Console.ReadLine());
            }
        }       
    }
}
