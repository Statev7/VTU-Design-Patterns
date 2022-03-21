namespace LibraryApp.LibrarySystem.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Infrastructure.Helpers;
    using LibraryApp.Utilities.Constants;
    using LibraryApp.Utilities.Messages;

    public class CommandFactory
    {
        public ICommand Create(string commandType)
        {
            string typeAsString = commandType.ToLower() + GlobalConstants.CommandSuffix;

            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .SingleOrDefault(t => t.Name.ToLower() == typeAsString);

            bool isNull = CustomValidator.IsNull(type);
            if (isNull)
            {
                string errorMessage = string.Format(ExceptionMessages.INVALID_TYPE, typeAsString);
                throw new ArgumentException(errorMessage);
            }

            ICommand command = (ICommand)Activator.CreateInstance(type);
            return command;
        }
    }
}
