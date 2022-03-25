namespace LibraryApp.LibrarySystem.Contracts
{
    using LibraryApp.LibrarySystem.Models.Books;
    using LibraryApp.LibrarySystem.Models.People.Contracts;

    public interface ILibrary
    {
        void RegisterClient(IPerson person);

        Book GetBook(IPerson person, string bookName);

        void ReturnBook(IPerson person, Book book);

        string ShowReportForPerson(string personFullName);

        IPerson FindPersonByFullName(string personFullName);
    }
}
