namespace LibraryApp.LibrarySystem.Models.People.Contracts
{
    public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }

        int Age { get; }

        string FullName { get; }

        public Library Library { get; set; }

        void GetBook(string bookName);

        void ReturnBook(string bookName);
    }
}
