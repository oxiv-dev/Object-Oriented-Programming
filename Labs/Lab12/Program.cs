using System;
using System.Collections.Generic;

namespace Lab12
{
    class Passenger //describes passenger
    {
        public string Name;
        public string Surname;
        public string DateOfBirth;
        public bool Animals;
        public Passenger() //constructor without parameters
        {
            Console.Write("Enter your name: ");
            Name = Console.ReadLine();
            Console.Write("Enter your surname: ");
            Surname = Console.ReadLine();
            Console.Write("Enter your date of birth(dd.mm.yyyy): ");
            DateOfBirth = Console.ReadLine();
            Console.Write("Do you have animals?(1 - yes, 0 - no): ");
            int mode = Int32.Parse(Console.ReadLine());
            if (mode == 1) Animals = true;
            else Animals = false;
        }
    }

    class Coach
    {
        public bool[] Places = new bool[54]; //demonstrate availability of place in coach
        public Passenger[] Passengers = new Passenger[54];
        public Coach()// constructor without parameters
        {
            for (int i = 0; i < 54; ++i)//sets all elements to default value
            {
                Places[i] = false;
                Passengers[i] = null;
            }
        }

        public int CountFree()//counts free places in each coach
        {
            int c = 0;
            for (int i = 0; i < 54; ++i)
                if (Places[i] == false)
                    c++;
            return c;
        }

        public string Tr(bool m, int pos) //transform output to required format
        {
            if (m == false) return (pos + 1).ToString();
            else return "  ";
        }
        public void Show() //show coach to choose place
        {
            
            Console.WriteLine(" ------------------------------------------------------------------------------- ");
            Console.WriteLine(String.Format("|{0,3}|", Tr(Places[1], 1)) + 
                String.Format("{0, 3}|", Tr(Places[3], 3)) + String.Format("|{0,3}|", Tr(Places[5], 5)) + 
                String.Format("{0, 3}|", Tr(Places[7], 7)) + String.Format("|{0,3}|", Tr(Places[9], 9)) + 
                String.Format("{0, 3}|", Tr(Places[11], 11)) + String.Format("|{0,3}|", Tr(Places[13], 13)) + 
                String.Format("{0, 3}|", Tr(Places[15], 15)) + String.Format("|{0,3}|", Tr(Places[17], 17)) + 
                String.Format("{0, 3}|", Tr(Places[19], 19)) + String.Format("|{0,3}|", Tr(Places[21], 21)) + 
                String.Format("{0, 3}|", Tr(Places[23], 23)) + String.Format("|{0,3}|", Tr(Places[25], 25)) + 
                String.Format("{0, 3}|", Tr(Places[27], 27)) + String.Format("|{0,3}|", Tr(Places[29], 29)) + 
                String.Format("{0, 3}|", Tr(Places[31], 31)) + String.Format("|{0,3}|", Tr(Places[33], 33)) + 
                String.Format("{0, 3}|", Tr(Places[35], 35)));
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("|{0,3}|", Tr(Places[0], 0)) + 
                  String.Format("{0, 3}|", Tr(Places[2], 2)) + String.Format("|{0,3}|", Tr(Places[4], 4)) + 
                  String.Format("{0, 3}|", Tr(Places[6], 6)) + String.Format("|{0,3}|", Tr(Places[8], 8)) + 
                  String.Format("{0, 3}|", Tr(Places[10], 10)) + String.Format("|{0,3}|", Tr(Places[12], 12)) + 
                  String.Format("{0, 3}|", Tr(Places[14], 14)) + String.Format("|{0,3}|", Tr(Places[16], 16)) + 
                  String.Format("{0, 3}|", Tr(Places[18], 18)) + String.Format("|{0,3}|", Tr(Places[20], 20)) + 
                  String.Format("{0, 3}|", Tr(Places[22], 22)) + String.Format("|{0,3}|", Tr(Places[24], 24)) + 
                  String.Format("{0, 3}|", Tr(Places[26], 26)) + String.Format("|{0,3}|", Tr(Places[28], 28)) + 
                  String.Format("{0, 3}|", Tr(Places[30], 30)) + String.Format("|{0,3}|", Tr(Places[32], 32)) + 
                  String.Format("{0, 3}|", Tr(Places[34], 34)));
            Console.WriteLine("=================================================================================");
            Console.WriteLine(String.Format("|{0,3}|", Tr(Places[36], 36)) + 
                  String.Format("{0, 3}|", Tr(Places[37], 37)) + String.Format("|{0,3}|", Tr(Places[38], 38)) + 
                  String.Format("{0, 3}|", Tr(Places[39], 39)) + String.Format("|{0,3}|", Tr(Places[40], 40)) + 
                  String.Format("{0, 3}|", Tr(Places[41], 41)) + String.Format("|{0,3}|", Tr(Places[42], 42)) + 
                  String.Format("{0, 3}|", Tr(Places[43], 43)) + String.Format("|{0,3}|", Tr(Places[44], 44)) + 
                  String.Format("{0, 3}|", Tr(Places[45], 45)) + String.Format("|{0,3}|", Tr(Places[46], 46)) + 
                  String.Format("{0, 3}|", Tr(Places[47], 47)) + String.Format("|{0,3}|", Tr(Places[48], 48)) + 
                  String.Format("{0, 3}|", Tr(Places[49], 49)) + String.Format("|{0,3}|", Tr(Places[50], 50)) + 
                  String.Format("{0, 3}|", Tr(Places[51], 51)) + String.Format("|{0,3}|", Tr(Places[52], 52)) + 
                  String.Format("{0, 3}|", Tr(Places[53], 53)));
            Console.WriteLine("---------------------------------------------------------------------------------");
         
        }
    }

    class Train //describes train
    {
        public string From;
        public string To;
        List<Coach> Coaches = new List<Coach>();
        List<int> Free = new List<int>();
        public Train() //constructor without parameters
        {
            Console.Write("From: ");
            From = Console.ReadLine();
            Console.Write("To: ");
            To = Console.ReadLine();
            for (int i = 0; i < 3; ++i)
            {
                Coaches.Add(new Coach());
                Free.Add(Coaches[i].CountFree());
            }
        }
        //TODO: show ticket +
        public void ShowTicket() //shows ticket after name & surname input
        {
            Console.WriteLine("Search ticket:");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your surname: ");
            string surname = Console.ReadLine();
            int[] place = Find(name, surname);
            if (place[0] == -1)
            {
                Console.WriteLine("You don't have ticket on this train!");
                return;
            }
            Console.WriteLine("Name: " + name + " " + surname);
            Console.WriteLine("Date of Birth: " + Coaches[place[0]].Passengers[place[1]].DateOfBirth);
            Console.WriteLine("Route: " + From + " - " + To + String.Format("Coach: {0,2}  ", (place[0] + 1)) + 
                              String.Format("Place: {0,2}", (place[1] + 1)));
            string res = (Coaches[place[0]].Passengers[place[1]].Animals) ? "+" : "-";
            Console.WriteLine("Animals: " + res);
        }
        //show coaches and free places in eaach one
        public void ShowCoaches()
        {
            Console.WriteLine("All coaches: ");
            for (int i = 0; i < Coaches.Count; ++i)
            {
                Console.Write(String.Format("( {0, 2} |", (i + 1)) + String.Format(" {0, 2} )", Free[i]));
            }
            Console.WriteLine();
        }

        public void AddCoach() //add coach)))0)
        {
            Console.WriteLine("Coach was added");
            Coaches.Add(new Coach());
            Free.Add(Coaches[Coaches.Count - 1].CountFree());
        }
        public void ReturnTicket() //makes ordered before place available again and delete ticket
        {
            Console.WriteLine("Ticket returning: ");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your surname: ");
            string surname = Console.ReadLine();
            int[] place = Find(name, surname); //in array order
            if (place[0] == -1)
            {
                Console.WriteLine("You don't have ticket on this train!");
                return;
            }
            Coaches[place[0]].Places[place[1]] = false;
            Coaches[place[0]].Passengers[place[1]] = null;
            Free[place[0]]++;
            Console.WriteLine("Ticket was returned");
        }
        public void BuyTicket()//make choose place not available and create a ticket
        {
            Console.WriteLine("Ticket registration");
            for (int i = 0; i < Coaches.Count; ++i)
            {
                if(Free[i] > 0) 
                {
                    Console.Write(String.Format("( {0, 2} |", (i + 1)) + String.Format(" {0, 2} )", Free[i]));
                }
            }
            Console.WriteLine();
            Console.Write("Enter coach number: ");
            int num = Int32.Parse(Console.ReadLine());
            Coaches[num - 1].Show();
            Console.Write("Choose place: ");
            int place = Int32.Parse(Console.ReadLine()); //in usual order
            if (!Coaches[num - 1].Places[place - 1])
            {
                Coaches[num - 1].Places[place - 1] = true; 
                Coaches[num - 1].Passengers[place - 1] = new Passenger();
                Free[num - 1]--;
            }
        }
        private int[] Find(string name, string surname) //searching for passenger with given name & surname and returns
        //passenger's place
        {
            int[] coord = new int[2]{-1, -1};
            for (int i = 0; i < Coaches.Count; ++i)
            {
                for (int j = 0; j < 54; ++j)
                {
                    if (Coaches[i].Places[j] && Coaches[i].Passengers[j].Name == name &&
                        Coaches[i].Passengers[j].Surname == surname)
                    {
                        coord[0] = i;
                        coord[1] = j;
                        return coord;
                    };
                }
            }
            return coord;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Train t1 = new Train();
            t1.BuyTicket();
            t1.BuyTicket();
            t1.BuyTicket();
            t1.ShowTicket();
            t1.ReturnTicket();
            t1.ShowCoaches();
            t1.AddCoach();
            t1.ShowCoaches();
            Console.ReadKey();
        }
    }
}