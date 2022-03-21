namespace LibraryApp.LibrarySystem.Models.People
{
    public class Author : Adult
    {
        public Author(string firstName, string lastName, int age) 
            : base(firstName, lastName, age)
        {
        }
    }
}
