using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string site)
        {
            if (!this.ValidateURL(site))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            if (!this.ValidateNumber(number))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
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

        private bool ValidateURL(string urls)
        {
            foreach (char url in urls)
            {
                if (char.IsDigit(url))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
