using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class Program
    {
        const string Notebook = "Сотрудники.txt";
        public static void Reading()
        {
            if (!File.Exists(Notebook))
            {
                Console.WriteLine(Notebook);
                return;
            }
            using (StreamReader sr = new StreamReader("Сотрудники.txt", Encoding.Unicode))
            {


                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] people = line.Split('#');
                    Console.WriteLine($"Номер: {people[0]} Время: {people[1]} ФИО: {people[2]}" +
                    $" Дата рождения: {people[3]}  Возраст:{people[4]} Рост: {people[5]}  Место рождения:{people[6]}");
                }
                Console.ReadKey();

            }
        }
        static int Birthday(int day, int month, int year)
        {
            DateTime now = DateTime.Today;
            DateTime bday = new DateTime(year, month, day);
            int age = now.Year - bday.Year;
            if (bday > now.AddYears(-age)) age--;

            return age;
        }


        static void Print()
        {


            int ID = 1;
            if (!File.Exists(Notebook))
            {
                File.Create(Notebook).Close();
                Console.WriteLine("Файл создан");
            }
            else
            {
                ID = File.ReadAllLines(Notebook).Length + 1;
            }

            string people = string.Empty;
            Console.WriteLine($"ID {ID}");
            people += ($"{ID++}#");
            string now = DateTime.Now.ToString();
            Console.WriteLine($"Дата и время заметки {now}");
            people += $"{now}#";
            Console.WriteLine("Введите Ф.И.О сотрудника: ");
            people += $"{Console.ReadLine()}#";
            Console.WriteLine("Дата рождения: ");
            Console.WriteLine("День");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Месяц");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Год");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine($"Дата рождения: {day}.{month}.{year}");
            people += $"{day}.{month}.{year}#";
            Console.WriteLine($"Возраст {Birthday(day, month, year)}");
            people += $"{Birthday(day, month, year)}#";
            Console.WriteLine("Рост: ");
            people += $"{Console.ReadLine()}#";
            Console.WriteLine("Место рождения: ");
            people += $"{Console.ReadLine()}#";
            using (StreamWriter list = new StreamWriter("Сотрудники.txt", true, Encoding.Unicode))
            {
                list.WriteLine(people.ToString());
            }
        }

        static void Main(string[] args)
        {

            bool Exit = true;
            do
            {

                Console.WriteLine("Для просмотра справочника нажмите 1");
                Console.WriteLine("Для ввода новых данных нажмите 2");
                Console.WriteLine("Для выхода с приложения намжите Y");
                string value = Console.ReadLine();
                if (value == "1")
                {
                    Reading();
                }
                else if (value == "2")
                {
                    Print();
                }
                else if (value == "Y")
                {
                    Exit = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода, попробуйте еще раз");
                }
                Console.WriteLine();
            } while (Exit);

        }

    }
}

