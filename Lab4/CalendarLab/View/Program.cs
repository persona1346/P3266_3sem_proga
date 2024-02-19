using System;
using CalendarLab.AppContext;
using CalendarLab.Presenter;

class Program
{
    static void Main()
    {
        CalendarSet calendarSet = new CalendarSet(new DatabaseLoader(new CalendarContext()));

        while (true)
        {
            Console.WriteLine("List of commands:");
            Console.WriteLine(" - 'check' to check if a year is a leap year");
            Console.WriteLine(" - 'calc' to calculate interval length");
            Console.WriteLine(" - 'day' to get the name of the day of the week");
            Console.WriteLine(" - 'quit' to exit.");
            Console.Write("Input the command: ");
            string command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "check":
                    CheckLeapYear(calendarSet);
                    break;
                case "calc":
                    CalculateIntervalLength(calendarSet);
                    break;
                case "day":
                    GetWeekDay(calendarSet);
                    break;
                case "showall":
                    calendarSet.ShowAllDates();
                    break;
                case "quit":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid command. Try again.");
                    break;
            }
        }
    }

    static void CheckLeapYear(CalendarSet calendarSet)
    {
        Console.Write("Input the year: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            bool isLeapYear = calendarSet.IsLeapYear(new DateTime(year, 1, 1));
            Console.WriteLine($"{year} {(isLeapYear ? "is" : "is not")} a leap year.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid year.");
        }
    }

    static void CalculateIntervalLength(CalendarSet calendarSet)
    {
        Console.Write("Input the first date (in dd.mm.yyyy format): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date1))
        {
            Console.Write("Input the second date (in dd.mm.yyyy format): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date2))
            {
                int duration = calendarSet.CalculateDays(date1, date2);
                Console.WriteLine($"Interval length: {duration} days.");
            }
            else
            {
                Console.WriteLine("Invalid input for the second date. Please enter a valid date.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for the first date. Please enter a valid date.");
        }
    }

    static void GetWeekDay(CalendarSet calendarSet)
    {
        Console.Write("Input the date (in dd.mm.yyyy format): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            string dayOfWeek = calendarSet.GetWeekDay(date);
            Console.WriteLine($"Day of the week: {dayOfWeek}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid date.");
        }
    }
}