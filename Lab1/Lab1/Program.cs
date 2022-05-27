using System;
using System.IO;
using System.Text.Json;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Date date1 = new Date();
            date1.get_year();
            date1.get_month();
            date1.get_day();

            Date date2 = new Date();
            date2.get_year();
            date2.get_month();
            date2.get_day();

            Date.days_difference(date1, date2);

            Console.WriteLine("Введіть кількість днів: ");
            int days_amount=int.Parse(Console.ReadLine());
            TimeSpan days = new TimeSpan(days_amount, 0, 0, 0);
            Date.date_lag(date1, days);

            Date.day_of_week(date1);

            Date.serealize(date1);
            Date.deserealize();
            Date.serealize(date2);
            Date.deserealize();

            Console.ReadLine();
        }
    }
}
