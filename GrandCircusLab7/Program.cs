using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab7
{
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            /*  this program has methods to validate:
             *  names (alphabetical,start w/capital,max 30)
             *  emails (5-30 alphanumeric,@,5-10 alphanumeric,.,2-3 alphanumeric)
             *  phone numbers (xxx-xxx-xxxx)
             *  date (dd/mm/yyyy)
             */

            Console.WriteLine("Hello! Are you ready to enter your data?");

            //each portion of the program is broken up into a method which is called by Main
            CheckName();
            CheckEmail();
            CheckNumber();
            CheckDate();
            
            Console.WriteLine("\nThank you for the information! \n" +
                "Your data will be sold to big business for loads of money.\n" +
                "Have a nice day :)");
            Console.ReadKey();

        }

        
            //these four methods validate name, email, phone number, and date, respectively
        static void CheckName() //the method validating user's first name
        {
            bool continueName = true; //initializes a boolean to loop CheckName if user desires
            
            do //this code chunk runs the name validation portion
            {
                Console.Write("\nPlease enter your first name: ");
                string name = Console.ReadLine();
                if (Regex.IsMatch(name, @"^[A-Z][a-z]{1,29}$"))//this checks for proper name formatting 
                                                               //(see top of program for allowed formats)
                {
                    Console.WriteLine("Congratulations! Your name follows the rules.");
                }
                else Console.WriteLine("I'm sorry, your name doesn't seem to be valid.\n" +
                    "Please make sure your name begins with a capital letter, is all alphabetical,\n" +
                    "and not longer than 30 letters.");

                Console.Write("Would you like to try another name? (y/n) ");
                string response = Console.ReadLine();
                if (response.ToLower() == "n" || response.ToLower() == "no")
                {
                    continueName = false;
                }
                
            } while (continueName == true);
            

        }
        static void CheckEmail() //method validating user's email address
        {
            bool continueEmail = true;

            do
            {
                Console.Write("\nPlease enter your email address: ");
                string email = Console.ReadLine();
                if (Regex.IsMatch(email, @"^\w{5,30}[@]\w{5,10}[.]\w{2,3}$"))//checks email address is written like an email
                {
                    Console.WriteLine("Hooray! You have a valid email address.");
                }
                else Console.WriteLine("It appears you entered an invalid email address.\n" +
                    "An email address has 5-30 alphanumeric characters, the @ symbol, \n" +
                    "followed by another 5-10 alphanumeric characters, then . and \n" +
                    "2-3 more alphanumeric characters. Sorry I said \"alphanumeric\" so many times.");
                
                Console.Write("Would you like to try a different email? (y/n) ");
                string response = Console.ReadLine();
                if (response.ToLower() == "n" || response.ToLower() == "no")
                {
                    continueEmail = false;
                }
                
            } while (continueEmail == true);

            
        }
        static void CheckNumber()
        {
            bool continuePhoneNumber = true;
            do
            {
                Console.Write("\nPlease enter your phone number, in xxx-xxx-xxx format: ");
                string phoneNumber = Console.ReadLine();
                if (Regex.IsMatch(phoneNumber, @"^[1-9]\d{2}[-]\d{3}[-]\d{4}$"))//looks for phone number in xxx-xxx-xxxx format
                                                                                //(also checks against area code starting with 0)
                {
                    Console.WriteLine("Great! This is a real phone number in the US.");
                }
                else Console.WriteLine("You entered your phone number incorrectly.\n" +
                    "Your number should be 10 digits long and entered in xxx-xxx-xxxx format.");

                Console.Write("Would you like to try a different number? (y/n) ");
                string response = Console.ReadLine();
                if (response.ToLower() == "n" || response.ToLower() == "no")
                {
                    continuePhoneNumber = false;
                }
                
            } while (continuePhoneNumber == true);

        }
        static void CheckDate()
        {
            bool continueDate = true;

            do
            {
                Console.Write("\nPlease enter a date, in dd/mm/yyyy format: ");
                string date = Console.ReadLine();
                if (Regex.IsMatch(date, @"^\d{2}[/]\d{2}[/]\d{4}$"))//checks date is dd/mm/yyyy form
                                                                    //(but doesn't check if it's an actual date)
                {
                    
                    string[] splitDate = date.Split('/');//splits and parses the string into seperate ints
                   
                    if (int.Parse(splitDate[0]) > 0 && int.Parse(splitDate[0]) <= 31)
                    {
                        if (int.Parse(splitDate[1]) > 0 && int.Parse(splitDate[1]) <= 12)
                        {
                            if (int.Parse(splitDate[2]) > 0)
                            {
                                Console.WriteLine("Nice! This is probably a date.");
                            }
                            else Console.WriteLine("I don't think this date exists. I think you made it up.\n" +
                                "Remember, this is in dd/mm/yyyy format.");
                        }
                        else Console.WriteLine("I don't think this date exists. I think you made it up.\n" +
                                "Remember, this is in dd/mm/yyyy format.");
                    }
                    else Console.WriteLine("I don't think this date exists. I think you made it up.\n" +
                                "Remember, this is in dd/mm/yyyy format.");

                }
                else Console.WriteLine("This doesn't look like a date. \n" +
                    "I mean, like a day-month-year date, not a candlelit dinner.\n" +
                    "Please enter the date in dd/mm/yyyy format (not American-style)");
                Console.Write("Would you like to try a different date? (y/n) ");
                string response = Console.ReadLine();
                if (response.ToLower() == "n" || response.ToLower() == "no")
                {
                    continueDate = false;
                }
                
            } while (continueDate == true);

        }
    }

}
