namespace LibraryApp.LibrarySystem.Commands
{
    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Factories;
    using LibraryApp.LibrarySystem.Models.People.Contracts;
    using LibraryApp.Utilities.Messages;

    public class RegisterClientCommand : ICommand
    {
        private readonly PersonFactory personFactory;

        public RegisterClientCommand()
        {
            this.personFactory = new PersonFactory();
        }

        public string Execute(Library library, params string[] arguments)
        {
            IPerson clien = this.personFactory.Create(arguments);

            library.RegisterClient(clien);
            return OutputMessages.SUCCESFFULY_REGISTRATION;    
        }
    }
}
