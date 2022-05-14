namespace LibraryApp.LibrarySystem.Models.LibraryItems
{
    using LibraryApp.LibrarySystem.Models.People;

    public class Comics : LibraryItem
    {
        public Comics(string title, Author author, string genre) 
            : base(title, author, genre)
        {
        }
    }
}
