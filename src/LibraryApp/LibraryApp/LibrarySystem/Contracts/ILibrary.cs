namespace LibraryApp.LibrarySystem.Contracts
{
    using LibraryApp.LibrarySystem.Models.LibraryItems;
    using LibraryApp.LibrarySystem.Models.People.Contracts;

    public interface ILibrary
    {
        string RegisterClient(IPerson person);

        LibraryItem GetItem(IPerson person, string bookName);

        void ReturnItem(IPerson person, LibraryItem book);

        string ShowReportForPerson(string personFullName);

        IPerson FindPersonByFullName(string personFullName);
    }
}
