namespace LibraryApp.LibrarySystem.Commands
{
    using System.Linq;

    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Contracts;
    using LibraryApp.LibrarySystem.Models.People.Contracts;
    using LibraryApp.Utilities.Messages;

    public class GetItemCommand : ICommand
    {
        public string Execute(ILibrary library, params string[] arguments)
        {
            string personFullName = string.Join(" ", arguments.Take(2));
            string itemName = string.Join(" ", arguments.Skip(2));
            IPerson person = library.FindPersonByFullName(personFullName);

            person.GetLibraryItem(itemName);

            string message = string.Format(OutputMessages.SUCCESSFULY_TAKEN_ITEM, person.FullName, itemName);
            return message;
        }
    }
}
