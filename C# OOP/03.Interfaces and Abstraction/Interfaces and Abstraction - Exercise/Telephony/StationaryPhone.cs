using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!this.ValidateNumber(number))
            {
                return "Invalid number!";
            }

            return $"Dialing... {number}";
        }

        private bool ValidateNumber(string numbers)
        {
            foreach (char number in numbers)
            {
                if (!char.IsDigit(number))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
