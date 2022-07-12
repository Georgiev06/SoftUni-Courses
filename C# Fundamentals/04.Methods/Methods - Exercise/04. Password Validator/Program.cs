using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MinPassLenght = 6;
            const int MaxPassLenght = 10;
            const int passDigitMinCount = 2;

            //Read password from the console
            string password = Console.ReadLine();

            bool isPasswordvalid = ValidatePassword(password, MinPassLenght, MaxPassLenght, passDigitMinCount);

            if (isPasswordvalid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool ValidatePassword(string password, int MinPassLenght, int MaxPassLenght, int passDigitMinCount)
        {
            bool isPassValid = true;

            if (!ValidatePasswordLenght(password, MinPassLenght, MaxPassLenght))
            {
                Console.WriteLine($"Password must be between {MinPassLenght} and {MaxPassLenght} characters");
                isPassValid = false;
            }
            if (!ValidatePasswordIsDigitOrWords(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isPassValid = false;
            }
            if (!ValidatePasswordCount(password, passDigitMinCount))
            {
                Console.WriteLine($"Password must have at least {passDigitMinCount} digits");
                isPassValid = false;
            }
            return isPassValid;
        }

        static bool ValidatePasswordLenght(string password, int minLenght, int maxLenght)
        {
            if (password.Length >= minLenght && password.Length <= maxLenght)
            {
                return true;
            }
            return false;
        }

        static bool ValidatePasswordIsDigitOrWords(string password)
        {
            foreach (char ch in password)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        static bool ValidatePasswordCount(string password, int minDigitCount)
        {
            int digitsCount = 0;
            foreach (char ch in password)
            {
                if (Char.IsDigit(ch))
                {
                    digitsCount++;
                }
            }
            return digitsCount >= minDigitCount;
        }
    }
}

