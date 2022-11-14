using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any())
                .ToArray();

            foreach (var propertyInfo in propertyInfos)
            {
                object value = propertyInfo.GetValue(obj);
                MyValidationAttribute attribute = propertyInfo.GetCustomAttribute<MyValidationAttribute>();

                bool isValid = attribute.IsValid(value);

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
