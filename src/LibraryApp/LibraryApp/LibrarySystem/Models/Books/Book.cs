namespace LibraryApp.LibrarySystem.Models.Books
{
    using System;
    using System.Text;
    using System.Timers;

    using LibraryApp.LibrarySystem.Models.People;
    using LibraryApp.Utilities.Constants;
    using LibraryApp.Utilities.Messages;

    public class Book
    {
        private const int NOTICE_DAYS = 5;
        private const int TIMER_DALAY = 86400000;
        private Timer timer;

        public Book(string title, Author author, string genre)
        {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.IsReturned = true;
        }

        public string Title { get; private set; }

        public Author Author { get; private set; }

        public string Genre { get; private set; }

        public bool IsReturned { get; set; }

        public DateTime DateOfTake { get; set; }

        public DateTime ReturnDate { get; set; }

        public void SetTimer()
        {
            this.timer = new Timer(TIMER_DALAY);
            this.timer.Elapsed += OnTimedEvent;
            this.timer.AutoReset = true;
            this.timer.Enabled = true;
        }

        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (this.IsReturned == false)
            {
                TimeSpan result = this.ReturnDate - this.DateOfTake;

                if (result.Days <= NOTICE_DAYS)
                {
                    string message =
                        string.Format(OutputMessages.NOTIFY_TO_RETURN_BOOK, this.Title, result.Days);
                    Console.WriteLine(message);
                }
            }
        }

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
