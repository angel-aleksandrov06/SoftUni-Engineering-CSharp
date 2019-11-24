namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = (inputArgs[0] + "Command").ToLower();
            var commandArgs = inputArgs.Skip(1).ToArray();

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes().FirstOrDefault(n => n.Name.ToLower() == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand instanceType = Activator.CreateInstance(commandType) as ICommand;

            if (instanceType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            return instanceType.Execute(commandArgs);
        }
    }
}
