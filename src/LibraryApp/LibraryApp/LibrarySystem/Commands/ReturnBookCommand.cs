namespace LibraryApp.LibrarySystem.Commands
{
    using System.Linq;

    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Models.Peoples.Contracts;
    using LibraryApp.Utilities.Messages;

    public class ReturnBookCommand : ICommand
    {
        public string Execute(Library library, params string[] arguments)
        {
            string personFullName = string.Join(" ", arguments.Take(2));
            string bookName = string.Join(" ", arguments.Skip(2));
            IPerson person = library.FindPersonByFullName(personFullName);

            person.ReturnBook(bookName);

            string message = string.Format(OutputMessages.SUCCESSFULLY_RETURNED_BOOK, bookName);
            return message;
        }
    }
}
