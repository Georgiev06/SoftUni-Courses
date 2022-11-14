using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split();
            string commandType = input[0];
            string[] commandValue = input.Skip(1).ToArray();

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandType + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            var command = Activator.CreateInstance(type) as ICommand;
              
            //ICommand command = default;
            
            //if (commandType == "HelloCommand")
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandType == "ExitCommand")
            //{
            //    command = new ExitCommand();
            //}

            string result = command.Execute(commandValue);
            return result;
        }
    }
}
