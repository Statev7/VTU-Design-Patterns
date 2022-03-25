namespace LibraryApp.LibrarySystem.Commands
{
    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Contracts;
    using LibraryApp.LibrarySystem.Factories;
    using LibraryApp.LibrarySystem.Factories.Contracts;
    using LibraryApp.LibrarySystem.Models.People.Contracts;
    using LibraryApp.Utilities.Messages;

    public class RegisterClientCommand : ICommand
    {
        private readonly IFactory<IPerson> personFactory;

        public RegisterClientCommand()
        {
            this.personFactory = new PersonFactory();
        }

        public string Execute(ILibrary library, params string[] arguments)
        {
            IPerson clien = this.personFactory.Create(arguments);

            library.RegisterClient(clien);
            return OutputMessages.SUCCESFFULY_REGISTRATION;    
        }
    }
}
