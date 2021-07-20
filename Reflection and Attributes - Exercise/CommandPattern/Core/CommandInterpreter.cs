namespace CommandPattern.Core
{
    using CommandPattern.Core.Commands;
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandArgs = args
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string commandType = commandArgs[0].ToLower();
            string[] commandTokens = commandArgs.Skip(1).ToArray();

            string result = string.Empty;
            
            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == $"{commandType}Command".ToLower());

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            result = instance.Execute(commandTokens);

            return result;
        }
    }
}
