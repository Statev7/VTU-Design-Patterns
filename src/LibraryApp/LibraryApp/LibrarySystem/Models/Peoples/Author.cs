namespace LibraryApp.LibrarySystem.Models.Peoples
{
    public class Author : Adult
    {
        public Author(string firstName, string lastName, int age) 
            : base(firstName, lastName, age)
        {
        }
    }
}
