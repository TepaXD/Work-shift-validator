using System;

namespace Work_shift_validator
{
    class Program
    {

        static void Main(string[] args)
        {
            int choice = 0;
            string start;
            string end;
            string result = null;
            DateTime date;
            Shift shift;

            Console.Write("Welcome to work shift validator!\n\n");

            //Menu
            while (true)
            {
                Console.Write("1: Enter work shift\n");
                Console.Write("2: Exit");

                do
                {
                    Console.Write("\nPlease enter your choice of action: ");
                    string inputchoice = Console.ReadLine();
                    try
                    {
                        choice = Convert.ToInt32(inputchoice);
                    }
                    catch (FormatException)
                    {
                        Console.Write("The choice wasn't in correct format, please use a number!\n");
                    }



                } while (!Convert.ToBoolean(choice));

                //Cases, 1 for validating the shift and 2 for exiting the program
                switch (choice)
                {
                    case 1:
                        DateTime today = DateTime.Today;
                        Console.Write("\nToday is " + today.ToString("d") + ".\n");
                        Console.Write("Please enter work shift date (zeroes default to today): ");
                        string inputdate = Console.ReadLine();
                        try
                        {
                            date = Convert.ToDateTime(inputdate);
                        }
                        catch (FormatException)
                        {
                            Console.Write("The format wasn't correct, please try again!\n");
                            break;
                        }

                        Console.Write("Please enter your starting hour in HH:MM format: ");
                        start = Console.ReadLine();
                        Console.Write("Please enter your finishing hour in HH:MM format: ");
                        end = Console.ReadLine();
                        shift = new Shift(date, start, end);

                        try
                        {
                            result = shift.TestShift();
                        }
                        catch (NullReferenceException)
                        {
                            Console.Write("\nYou need to enter a work shift first!\n");
                        }
                        Console.WriteLine("\n" + result + "\n");
                        break;

                    case 2:
                        Console.Write("\nThank you for using the work shift validator!\n");
                        return;

                    default:
                        Console.Write("\nInvalid choice, please choose again.\n\n");
                        break;

                }

            }
        }
    }
}
