using System;

namespace Lab1
{
    class Student
    {
        private string Name; 
        private string LastName;  
        private string Adress; 
        private string Passport;
        private int Age;
        private string Phone;
        private int Rating;
        public Student()
        {
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string lastname
        {
            get { return LastName; }
            set { LastName = value;}
        }

        public string adress
        {
            get { return Adress;}
            set { Adress = value; }
        }

        public string passport
        {
            get { return Passport; }
            set { Passport = value; }
        }

        public int age
        {
            get { return Age; }
            set { Age = value; }
        }

        public string phone
        {
            get { return Phone; }
            set { Phone = value; }
        }

        public int rating
        {
            get { return Rating; }
            set { Rating = value; }
        }
        public void StudentRating(int R)
        {
            Rating = R;
            if (Rating >= 80)
                Console.WriteLine("Привіт відмінникам");
            else
            if (Rating <= 30)
                Console.WriteLine("Треба вчитися краще!");
            else
                Console.WriteLine("Можна вчитися ще краще!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            //дані рейтингу
            //ініціалізація полів класу виконується в конструкторі з параметрами
            Student newStudent = new Student();
            Console.Write("Введіть своє ім'я: ");
            newStudent.name = Console.ReadLine();
            Console.Write("Введіть своє прізвище: ");
            newStudent.lastname = Console.ReadLine();            
            Console.Write("Введіть адресу: ");
            newStudent.adress = Console.ReadLine();
            Console.Write("Введіть номер паспорта: ");
            newStudent.passport = Console.ReadLine();
            Console.Write("Введіть вік: ");
            newStudent.age = int.Parse(Console.ReadLine());
            Console.Write("Введіть номер телефону: ");
            newStudent.phone = Console.ReadLine();
            Console.WriteLine("Ім'я = " + newStudent.name);
            Console.WriteLine("Прізвище = " + newStudent.lastname);
            Console.WriteLine("Адреса = " + newStudent.adress);
            Console.WriteLine("Паспорт = " + newStudent.passport);
            Console.WriteLine("Вік = " + newStudent.age);
            Console.WriteLine("Телефон = " + newStudent.phone);
            Console.Write("Ваш рейтинг? ");
            string r = Console.ReadLine();
            newStudent.rating = int.Parse(r);
            newStudent.StudentRating(newStudent.rating);
            Console.ReadLine();
        }
    }
}