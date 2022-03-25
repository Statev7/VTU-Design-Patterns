namespace LibraryApp.LibrarySystem.Models.People.Contracts
{
    using LibraryApp.LibrarySystem.Contracts;

    public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }

        int Age { get; }

        string FullName { get; }

        public ILibrary Library { get; set; }

        void GetBook(string bookName);

        void ReturnBook(string bookName);
    }
}
