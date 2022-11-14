using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            Type typeClass = Type.GetType(className);
            MethodInfo[] methods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var sb = new StringBuilder();

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
        public string RevealPrivateMethods(string className)
        {
            Type typeClass = Type.GetType(className);
            MethodInfo[] methods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {typeClass.BaseType.Name}");

            foreach (MethodInfo method in methods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type typeClass = Type.GetType(className);
            FieldInfo[] fields = typeClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            //PropertyInfo[] properties = typeClass.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            MethodInfo[] publicMethods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var sb = new StringBuilder();

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
             Type typeClass = Type.GetType(classToInvestigate);
             FieldInfo[] fields = typeClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
             var sb = new StringBuilder();

             Object classInstance = Activator.CreateInstance(typeClass, new object[] { });

             sb.AppendLine($"Class under investigation: {classToInvestigate}");

             foreach (FieldInfo field in fields)
             {
                 sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
             }

             return sb.ToString().Trim();
        }
    }
}
