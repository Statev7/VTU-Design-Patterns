namespace LibraryApp.LibrarySystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LibraryApp.LibrarySystem.Contracts;
    using LibraryApp.LibrarySystem.Infrastructure.Helpers;
    using LibraryApp.LibrarySystem.Models.Books;
    using LibraryApp.LibrarySystem.Models.People;
    using LibraryApp.LibrarySystem.Models.People.Contracts;
    using LibraryApp.Utilities.Constants;
    using LibraryApp.Utilities.Exceptions;
    using LibraryApp.Utilities.Messages;

    public class Library : ILibrary
    {
        private const char SYMBOL = '-';
        private const int SYMBOL_COUNT = 20;
        private const int RENTAL_DAYS = 31;
        private const int NOTICE_DAYS = 5;

        private readonly ICollection<Book> books;
        private readonly ICollection<string> bannedGenresForChilds;
        private readonly ICollection<IPerson> people;
        private readonly IDictionary<IPerson, List<Book>> report;

        public Library()
        {
            this.books = GlobalConstants.Books;
            this.bannedGenresForChilds = GlobalConstants.BannedGenreForChilds;
            this.people = new HashSet<IPerson>();
            this.report = new Dictionary<IPerson, List<Book>>();
        }

        public void RegisterClient(IPerson person)
        {
            bool isPersonAlredyExist = this.people.Any(p => p.FullName == person.FullName);
            if (isPersonAlredyExist)
            {
                string errorMessage = string.Format(ExceptionMessages.USER_ALREADY_REGISTERED, person.FullName);
                throw new EntityAlredyExist(errorMessage);
            }

            this.people.Add(person);
            person.Library = this;
        }

        public Book GetBook(IPerson person, string bookName)
        {
            Book book = this.FindBookByName(bookName);

            bool isBannedGenre = person is Child && this.bannedGenresForChilds.Contains(book.Genre);
            if (isBannedGenre)
            {
                throw new AccessDeniedException(ExceptionMessages.BANNED_GENRE);
            }

            book.DateOfTake = DateTime.UtcNow;
            DateTime returnDate = book.DateOfTake.AddDays(RENTAL_DAYS);
            book.ReturnDate = returnDate;
            book.OnTimeChanged += BookOnTimeChanged;

            if (!this.report.ContainsKey(person))
            {
                this.report.Add(person, new List<Book> { });
            }
            this.report[person].Add(book);
            this.books.Remove(book);

            //book.DateOfTake = DateTime.UtcNow.AddDays(25);

            return book;
        }

        public void ReturnBook(IPerson person, Book book)
        {
            bool isValid = this.report[person].Contains(book);
            if (isValid == false)
            {
                throw new ArgumentException(ExceptionMessages.INVALID_BOOK_TO_RETURN);
            }

            book.DateOfTake = default;

            this.report[person].Remove(book);
            this.books.Add(book);
        }

        public string ShowReportForPerson(string personFullName)
        {
            StringBuilder stringBuilder = new StringBuilder();

            IPerson person = this.FindPersonByFullName(personFullName);

            string reportMessage = 
                this.report[person].Count == 0 ? "Books: none" : "Books:";

            stringBuilder.AppendLine(reportMessage);
            foreach (var book in this.report[person])
            {
                stringBuilder.AppendLine(book.ToString());
                stringBuilder.AppendLine(new string(SYMBOL, SYMBOL_COUNT));
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public IPerson FindPersonByFullName(string personFullName)
        {
           IPerson person = this.people
                .SingleOrDefault(p => p.FullName.ToLower() == personFullName.ToLower());

            bool isNull = CustomValidator.IsNull(person);
            if (isNull)
            {
                string errorMessage = string.Format(ExceptionMessages.PERSON_NOT_REGISTERED, personFullName);
                throw new EntityDoesNotExist(errorMessage);
            }

            return person;
        }

        private Book FindBookByName(string bookName)
        {
            Book book = null;

            bool isBookTaken = false;
            foreach (var person in this.report)
            {
                isBookTaken = person.Value.Any(b => b.Title == bookName);
                if (isBookTaken)
                {
                    book = person.Value.SingleOrDefault(b => b.Title == bookName);

                    string errorMessage = 
                        string.Format(ExceptionMessages.BOOK_IS_ALREADY_TAKEN, 
                        book.Title, 
                        book.ReturnDate.ToString(GlobalConstants.DATE_FORMAT));

                    throw new BookIsAlreadyTaken(errorMessage);
                }
            }

            book = this.books
                .SingleOrDefault(b => b.Title.ToLower() == bookName.ToLower());

            bool isNull = CustomValidator.IsNull(book);
            if (isNull)
            {
                throw new EntityDoesNotExist(ExceptionMessages.INVALID_BOOK);
            }

            return book;
        }

        private void BookOnTimeChanged(object sender, DateTime e)
        {
            Book book = sender as Book;
            TimeSpan result = book.ReturnDate - book.DateOfTake;

            IPerson personToNotify = null;
            foreach (var person in this.report)
            {
                bool isValid = person.Value.Contains(book);
                if (isValid)
                {
                    personToNotify = person.Key;
                    break;
                }
            }

            if (result.Days <= NOTICE_DAYS)
            {
                string message = 
                    string.Format(OutputMessages.NOTIFY_TO_RETURN_BOOK, personToNotify.FullName, book.Title, result.Days);
                Console.WriteLine(message);
            }
        }
    }
}
