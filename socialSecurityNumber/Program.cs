using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Globalization;

namespace socialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Please insert your firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("Please insert your lastname: ");
            string lastName = Console.ReadLine();

            Console.Write("Please insert you social security number (YYMMDD-XXXX) ");
            string socialSecurityNumber = Console.ReadLine();

            string genderNumberString = socialSecurityNumber.Substring(9, 1);
            int gender = int.Parse(genderNumberString);

            bool isFemale = gender % 2 == 0;

            string correctGender = isFemale ? "Female" : "Male";

            string birthDateString = socialSecurityNumber.Substring(0, 6);
            DateTime birthDate = DateTime.ParseExact(birthDateString, "yyMMdd", CultureInfo.InvariantCulture);
            int age = DateTime.Now.Year - birthDate.Year;

            if (birthDate.Month > DateTime.Today.Month
                || birthDate.Month == DateTime.Today.Month && birthDate.Day > DateTime.Now.Day)

                {
                   age = age - 1; 
                    // kan även skrivas som age--; 
                }

            const int silenGenerationStart = 1925;
            const int silentGenerationEnd = 1945;

            const int babyBoomerStart = 1946;
            const int babyBoomerEnd = 1964;

            const int generationXStart = 1965;
            const int generationXEnd = 1979;
            
            const int millenialsStart = 1980;
            const int millenialEnd = 1994;

            const int generationZStart = 1995;
            const int generationZEnd = 2012;

            string generation = "";

            if (birthDate.Year >= silenGenerationStart && birthDate.Year <= silentGenerationEnd)
            {
                generation = "Silent generation";
            }

            else if (birthDate.Year >= babyBoomerStart && birthDate.Year <= babyBoomerEnd)
            {
                generation = "Babyboomer";
            }

            else if (birthDate.Year >= generationXStart && birthDate.Year <= generationXEnd)
            {
                generation = "Generation X";
            }

            else if (birthDate.Year >= millenialsStart && birthDate.Year <= millenialEnd)
            {
                generation = "Millenial";
            }

            else if (birthDate.Year >= generationZStart && birthDate.Year <= generationZEnd)
            {
                generation = "Generation Z";
            }
             
            Console.Clear();


            Console.WriteLine(@"Full name: " + firstName + " " + lastName + Environment.NewLine +
                "Social security number: " + socialSecurityNumber + Environment.NewLine +
                "Age: " + age + Environment.NewLine +
                "Gender: " + correctGender + Environment.NewLine +
                "Generation: " + generation);
                
            





            

        
        }
    }
}
