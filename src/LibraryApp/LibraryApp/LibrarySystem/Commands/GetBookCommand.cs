namespace LibraryApp.LibrarySystem.Commands
{
    using System.Linq;

    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Models.People.Contracts;
    using LibraryApp.Utilities.Messages;

    public class GetBookCommand : ICommand
    {
        public string Execute(Library library, params string[] arguments)
        {
            string personFullName = string.Join(" ", arguments.Take(2));
            string bookName = string.Join(" ", arguments.Skip(2));
            IPerson person = library.FindPersonByFullName(personFullName);

            person.GetBook(bookName);

            string message = string.Format(OutputMessages.SUCCESSFULY_TAKEN_BOOK, person.FullName, bookName);
            return message;
        }
    }
}
