namespace LibraryApp.LibrarySystem.Core
{
    using System;
    using System.Linq;

    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Factories;

    public class CommandInterpreter
    {
        private readonly CommandFactory commandFactory;
        private readonly Library library;

        public CommandInterpreter(Library library)
        {
            this.commandFactory = new CommandFactory();
            this.library = library;
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string commandType = tokens[0];
            string[] arguments = tokens.Skip(1).ToArray();

            ICommand command = this.commandFactory.Create(commandType);
            string commandResult = command.Execute(this.library, arguments);

            return commandResult;
        }
    }
}
