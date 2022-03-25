namespace LibraryApp.Utilities.Constants
{
    using System.Collections.Generic;

    using LibraryApp.LibrarySystem.Models.Books;
    using LibraryApp.LibrarySystem.Models.People;
    using LibraryApp.LibrarySystem.Models.People.Contracts;

    public static class GlobalConstants
    {
        public static List<IPerson> Authors = new List<IPerson>()
        {
           new Author("Joan", "Rowling", 56),
           new Author("Sarah", "Maas", 36),
           new Author("Stephen", "King", 74),
        };

        public static List<Book> Books = new List<Book>()
        {
            new Book("Harry Potter and the Philosopher's Stone", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Chamber of Secrets", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Prisoner of Azkaban", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Goblet of Fire", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Order of the Phoenix", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Half-Blood Prince", (Author)Authors[0], "Novel"),
            new Book("Shine", (Author)Authors[2], "Horror"),
            new Book("Pet cemetery", (Author)Authors[2], "Horror"),
        };

        public static List<string> BannedGenreForChilds = new List<string>()
        {
            "Horror",
            "True Crime"
        };

        public static bool IsAppRun = true;

        public const string CommandSuffix = "command";

        public const string DATE_FORMAT = "MM/dd/yyyy";
    }
}
