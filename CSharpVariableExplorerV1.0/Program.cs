// using declarations make namespaces easily available, so instead of typing System.Console.WriteLine("text"), you can
// just type Console.WriteLine("text") as the System namespace has alreasy been referenced by the using statement.
using System;
using System.Globalization;

namespace CSharpVariableExplorer
{
    internal class Program
    {
        private static int noOfTests = 0;
        private static void Main(string[] args)
        {
            // Deal with any args passed in
            if (args.Length == 0)
            {
                Console.WriteLine("You started this program with no parameters.");
            }
            else
            {
                /* Instead of just looping through the arguments passed and showing what they were and their types, now pass them to a method to handle them.
                 * 
                for (var x = 0; x == args.Length; x++)
                {
                    Console.WriteLine("Argument " + x + " is " + args[x]);
                }
                */

                HandleArgs(args);
            }
            // Set console size
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            Console.SetWindowPosition(0, 0);
            // Input various type of data
            // Text
            Console.Write("Please enter some text: ");
            string text = ""; // instantiate string text as null so it can be used within the try..catch loop
            try
            {
                text = Console.ReadLine();
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            // By rights you should use a null check here but the error handling would catch a null anyway
            // Also you do not need the .ToString() method to convert the GetType() result to a string but it is there for educational purposes
            Console.WriteLine("You entered: " + text + ", using a " + text.GetType().ToString() + " variable type.");
            Console.WriteLine();
            // 32 bit Integer
            Console.Write("Please enter a whole number in digit(s) below which holds negative (between 2,147,483,647 and -2,147,483,648: ");
            int number = 0;
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            Console.WriteLine("You entered: " + number + ", using a " + number.GetType() + " variable type.");
            Console.WriteLine();
            // Boolean
            Console.WriteLine("Please enter true or false (boolean): ");
            bool yesNo = false;
            try
            {
                yesNo = Convert.ToBoolean(Console.ReadLine());
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            Console.WriteLine("You entered: " + yesNo + ", using a " + yesNo.GetType() + " variable type.");
            Console.WriteLine();
            // Byte
            Console.WriteLine("Please enter a positive whole number in digit(s) (between 0 and 255: ");
            byte byteSize = 0;
            try
            {
                byteSize = Convert.ToByte(Console.ReadLine());
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            Console.WriteLine("You entered: " + byteSize + ", using a " + byteSize.GetType() + " variable type.");
            Console.WriteLine();
            // 32 bit unsigned integer
            Console.WriteLine("Please enter a positive number in digit(s) (between 0 and 4,294,967,295: ");
            UInt32 unsignedInt = 0;
            try
            {
                unsignedInt = Convert.ToUInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            Console.WriteLine("You entered: " + unsignedInt + ", using a " + unsignedInt.GetType() + " variable type.");
            Console.WriteLine();
            // Char
            Console.WriteLine("Please press a key: ");
            char character = 'a';
            try
            {
                character = Convert.ToChar(Console.ReadKey().KeyChar);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            Console.WriteLine("You entered: " + character + ", using a " + character.GetType() + " variable type.");
            Console.WriteLine();
            // DateTime
            Console.WriteLine("Please enter a date (in the format YYYY MM DD so - 2001 01 01 for example): ");
            DateTime thisThen = new DateTime(2001, 01, 01);
            try
            {
                thisThen = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            Console.WriteLine("You entered: " + thisThen.ToShortDateString() + ", using a " + thisThen.GetType() + " variable type, shortened to remove the time component.");
            Console.WriteLine();
            // TimeSpan
            Console.WriteLine("Please enter a time (in the format HH MM SS so - 12 30 00 for example) with each section (hour, minute, second) on a new line: ");
            TimeSpan thisNow = new TimeSpan(00, 00, 00);
            try
            {
                // Use var for private scope variables rather than explicit types (e.g. int, string, etc.)
                var hour = Convert.ToInt32(Console.ReadLine());
                var minute = Convert.ToInt32(Console.ReadLine());
                var second = Convert.ToInt32(Console.ReadLine());
                thisNow = new TimeSpan(hour, minute, second);
                if (thisNow.Ticks > TimeSpan.TicksPerDay)
                {
                    Console.WriteLine("You entered an hour greater than 24, this would lead to a result in days.");
                    Console.WriteLine("Whoops.");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            Console.WriteLine("You entered: " + thisNow + ", using a " + thisNow.GetType() + " variable type.");
            Console.WriteLine();
            // Decimal
            Console.WriteLine("Please enter pi to 10 decimal places (type help if you don't know): ");
            const decimal pi = 3.1415926536M;   // Use of var here would be counter productive as compiler would 
            // set pi as a double not a decimal also the value is never altered so it makes sense to make it a constant
            // the CultureInfo.InvariantCulture uses the settings defined in Windows' settings, so language, alphabet, calendar format, etc.
            try
            {
                var input = Console.ReadLine();
                if (input == "help")
                {
                    Console.WriteLine("Pi to 10 decimal places is " + pi.ToString(CultureInfo.InvariantCulture) + ". I have entered it for you.");
                }
                else
                {
                    if (Convert.ToDecimal(input) == pi)
                    {
                        Console.WriteLine("Nicely done!");
                    }
                    else if (input == "help")
                    {
                        Console.WriteLine("The answer is 3.1415926536.");
                    }
                    else
                    {
                        Console.WriteLine("Whoops, I am sure you were close, it is actually " + pi.ToString(CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler(ex.Message);
            }
            Console.WriteLine("You entered: " + pi.ToString(CultureInfo.InvariantCulture) + ", using a " + pi.GetType() + " variable type.");
            Console.WriteLine();
            // Full list
            Console.WriteLine("OK, so now you have a flavour of the data types C# can work with.");
            Console.WriteLine("For completeness sake, here is a list:");
            Console.WriteLine("Boolean, Byte, Char, DateTime, Decimal, Double, Float, Integer, Long, Object, SByte, Short, String, UInteger, ULong, UShort");
            Console.WriteLine("Not to mention user defined types. Yep, you can make your own should you need it!");
            Console.WriteLine("Then there are other data constructs like TimeSpan, Array, List, Constant, Enum, Class, Struct, Nullables, Interface, RegEx...");
            Console.WriteLine("That's a lot, no?");
            Console.WriteLine();
            // Exit code
            Console.WriteLine("Please press enter to exit.");
            Console.ReadLine();
        }

        private static void HandleArgs(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Only one switch is allowed, ignoring subsequent switches.");
            }
            switch (args[0])
            {
                case "1":
                    Console.WriteLine("You are choosing one test.");
                    noOfTests = 1;
                    break;
                case "2":
                    Console.WriteLine("You are choosing two test.");
                    noOfTests = 2;
                    break;
                case "3":
                    Console.WriteLine("You are choosing three tests.");
                    noOfTests = 3;
                    break;
                case "4":
                    Console.WriteLine("You are choosing four tests.");
                    noOfTests = 4;
                    break;
                case "5":
                    Console.WriteLine("You are choosing five tests.");
                    noOfTests = 5;
                    break;
                case "6":
                    Console.WriteLine("You are choosing six tests.");
                    noOfTests = 6;
                    break;
                case "7":
                    Console.WriteLine("You are choosing seven tests.");
                    noOfTests = 7;
                    break;
                case "8":
                    Console.WriteLine("You are choosing eight tests.");
                    noOfTests = 8;
                    break;
                case "help":
                    HelpUser();
                    break;
                default:
                    Console.WriteLine("You have entered an invalid switch. Displaying help.");
                    HelpUser();
                    break;
            }
        }

        private static void HelpUser()
        {
            throw new NotImplementedException();
        }

        protected static void ErrorHandler(string err)
        {
            Console.WriteLine("You have an error: " + err);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(1);
        }

    }
}

