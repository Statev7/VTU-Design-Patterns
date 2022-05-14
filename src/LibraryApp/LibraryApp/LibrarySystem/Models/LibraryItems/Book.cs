namespace LibraryApp.LibrarySystem.Models.LibraryItems
{
    using LibraryApp.LibrarySystem.Models.People;

    public class Book : LibraryItem
    {
        public Book(string title, Author author, string genre)
            :base(title, author, genre)
        {
        }
    }
}
