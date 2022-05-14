namespace LibraryApp.Utilities.Constants
{
    using System.Collections.Generic;

    using LibraryApp.LibrarySystem.Models.LibraryItems;
    using LibraryApp.LibrarySystem.Models.People;
    using LibraryApp.LibrarySystem.Models.People.Contracts;

    public static class GlobalConstants
    {
        public static List<IPerson> Authors = new List<IPerson>()
        {
           new Author("Joan", "Rowling", 56),
           new Author("Sarah", "Maas", 36),
           new Author("Stephen", "King", 74),
           new Author("Joe", "Kelly", 51),
           new Author("Dan", "Slott", 54),
        };

        public static List<LibraryItem> Books = new List<LibraryItem>()
        {
            new Book("Harry Potter and the Philosopher's Stone", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Chamber of Secrets", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Prisoner of Azkaban", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Goblet of Fire", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Order of the Phoenix", (Author)Authors[0], "Novel"),
            new Book("Harry Potter and the Half-Blood Prince", (Author)Authors[0], "Novel"),
            new Book("Shine", (Author)Authors[2], "Horror"),
            new Book("Pet cemetery", (Author)Authors[2], "Horror"),
            new Comics("Savage Spider-Man", (Author)Authors[3], "Superhero"),
            new Comics("Fantastic Four: Reckoning War Alpha", (Author)Authors[4], "Superhero"),
            new Comics("Ms. Marvel: Metamorphosis", (Author)Authors[4], "Superhero"),
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
