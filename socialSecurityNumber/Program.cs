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

            //Calculate gender

            string correctGender = GetGender(socialSecurityNumber);

            //Calculate age

            DateTime birthDate;
            int age;
            CalculateAge(socialSecurityNumber, out birthDate, out age);

            //Generation

            string generation = CalculateGender(birthDate);

            Console.Clear();


            Console.WriteLine(@"Full name: " + firstName + " " + lastName + Environment.NewLine +
                "Social security number: " + socialSecurityNumber + Environment.NewLine +
                "Age: " + age + Environment.NewLine +
                "Gender: " + correctGender + Environment.NewLine +
                "Generation: " + generation);










        }

        private static string CalculateGender(DateTime birthDate)
        {
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

            return generation;
        }

        private static void CalculateAge(string socialSecurityNumber, out DateTime birthDate, out int age)
        {
            string birthDateString = socialSecurityNumber.Substring(0, 6);
            birthDate = DateTime.ParseExact(birthDateString, "yyMMdd", CultureInfo.InvariantCulture);
            age = DateTime.Now.Year - birthDate.Year;
            if (birthDate.Month > DateTime.Today.Month
                || birthDate.Month == DateTime.Today.Month && birthDate.Day > DateTime.Now.Day)

            {
                age = age - 1;
                // kan även skrivas som age--; 
            }
        }

        private static string GetGender(string socialSecurityNumber)
        {
            string genderNumberString = socialSecurityNumber.Substring(9, 1);
            int gender = int.Parse(genderNumberString);

            bool isFemale = gender % 2 == 0;

            string correctGender = isFemale ? "Female" : "Male";
            return correctGender;
        }
    }
}
