namespace LibraryApp.LibrarySystem.Models.Books
{
    using System;
    using System.Text;

    using LibraryApp.LibrarySystem.Models.People;
    using LibraryApp.Utilities.Constants;

    public class Book
    {
        private DateTime dateOfTake;

        public Book(string title, Author author, string genre)
        {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
        }

        public string Title { get; private set; }

        public Author Author { get; private set; }

        public string Genre { get; private set; }

        public DateTime DateOfTake
        {
            get => this.dateOfTake;
            set
            {
                this.dateOfTake = value;
                OnTimeChanged?.Invoke(this, this.dateOfTake);
            }
        }

        public DateTime ReturnDate { get; set; }

        public event EventHandler<DateTime> OnTimeChanged;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Author: {this.Author.FirstName}");
            sb.AppendLine($"Genre: {this.Genre}");
            sb.AppendLine($"Date of take: {this.DateOfTake.ToString(GlobalConstants.DATE_FORMAT)}");
            sb.AppendLine($"Return date: {this.ReturnDate.ToString(GlobalConstants.DATE_FORMAT)}");

            return sb.ToString().TrimEnd();
        }
    }
}
