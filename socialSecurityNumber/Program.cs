using System;
using System.Globalization;

namespace socialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your social security number (YYMMDD-XXXX): ");

            string socialSecurityNumber = Console.ReadLine();

            string genderNumberString = socialSecurityNumber.Substring(9, 1);

            int gender = int.Parse(genderNumberString);

            bool isFemale = gender % 2 == 0;
            
            if (isFemale) 
            {
                Console.WriteLine("Female");
            }
            else
            {
                Console.WriteLine("Male");
            }

            string birthDateString = socialSecurityNumber.Substring(0, 6);

            DateTime birthDate = DateTime.ParseExact(birthDateString, "yyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if (birthDate.Month > DateTime.Today.Month
                || birthDate.Month == DateTime.Today.Month && birthDate.Day > DateTime.Now.Day)
            {
                age = age - 1; 
                // kan även skrivas som age--; 
            }

            Console.WriteLine($" {gender}, {age}");



            

        
        }
    }
}
