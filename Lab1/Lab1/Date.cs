using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab1
{
    class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public static Date date_lag(Date date, TimeSpan days)
        {
            DateTime _date = new DateTime(date.Year, date.Month, date.Day);
            DateTime new_date = _date + days;

            date = new Date();
            date.Year = new_date.Year;
            date.Month = new_date.Month;
            date.Day = new_date.Day;

            Console.WriteLine("Дата, яка відстоїть від "+_date+" на " + days + " днів: " +date.Year+"."+date.Month+"."+date.Day);
            return date;
        }

        public static TimeSpan days_difference(Date date1, Date date2)
        {
            DateTime date_1 = new DateTime(date1.Year, date1.Month, date1.Day);
            DateTime date_2 = new DateTime(date2.Year, date2.Month, date2.Day);
            TimeSpan difference;

            if (date_1 > date_2)
                difference = date_1.Date - date_2.Date;
            else
                difference = date_2.Date - date_1.Date;

            Console.WriteLine("Різниця в днях: " + difference);
            return difference;
        }

        public static void day_of_week(Date date)
        {
            DateTime _date = new DateTime(date.Year, date.Month, date.Day);
           
            switch (_date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    Console.WriteLine("День тижня " + _date + " Неділя");
                    break;
                case DayOfWeek.Monday:
                    Console.WriteLine("День тижня " + _date + " Понеділок");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("День тижня " + _date + " Вівторок");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("День тижня " + _date + " Середа");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("День тижня " + _date + " Четвер");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("День тижня " + _date + " П'ятниця");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("День тижня " + _date + " Субота");
                    break;
                default:
                    break;
            }
        }

        public void get_year()
        {
            Console.WriteLine("Введіть рік дати: ");
            Year = int.Parse(Console.ReadLine());
        }

        public void get_month()
        {
            Console.WriteLine("Введіть місяць дати: ");
            Month = int.Parse(Console.ReadLine());
        }

        public void get_day()
        {
            Console.WriteLine("Введіть день дати: ");
            Day = int.Parse(Console.ReadLine());
        }

        public static void serealize(Date date)
        {
            string fileName = "date.json";
            string jsonString = JsonSerializer.Serialize(date);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine("Інформація записана у файл");
            Console.WriteLine(File.ReadAllText(fileName));
        }

        public static void deserealize()
        {
            string fileName = "date.json";
            string jsonString = File.ReadAllText(fileName);
            Date date = JsonSerializer.Deserialize<Date>(jsonString)!;

            Console.WriteLine("Об'єкт з JSON файлу створений");
        }
    }
}
