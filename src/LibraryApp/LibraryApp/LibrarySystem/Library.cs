namespace LibraryApp.LibrarySystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LibraryApp.LibrarySystem.Infrastructure.Helpers;
    using LibraryApp.LibrarySystem.Models.Book;
    using LibraryApp.LibrarySystem.Models.Peoples;
    using LibraryApp.LibrarySystem.Models.Peoples.Contracts;
    using LibraryApp.Utilities.Constants;
    using LibraryApp.Utilities.Exceptions;
    using LibraryApp.Utilities.Messages;

    public class Library
    {
        private readonly ICollection<Book> books;
        private readonly ICollection<string> bannedGenresForChilds;
        private readonly ICollection<IPerson> people;
        private readonly IDictionary<IPerson, List<Book>> report;
        private readonly StringBuilder stringBuilder;

        public Library()
        {
            this.books = GlobalConstants.Books;
            this.bannedGenresForChilds = GlobalConstants.BannedGenreForChilds;
            this.people = new HashSet<IPerson>();
            this.report = new Dictionary<IPerson, List<Book>>();
            this.stringBuilder = new StringBuilder();
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
                //TODO: Create custom exception!
                throw new Exception(ExceptionMessages.BANNED_GENRE);
            }

            book.DateOfTake = DateTime.UtcNow;
            if (!this.report.ContainsKey(person))
            {
                this.report.Add(person, new List<Book> { });
            }
            this.report[person].Add(book);
            this.books.Remove(book);

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
            IPerson person = this.FindPersonByFullName(personFullName);

            stringBuilder.Clear();
            stringBuilder.AppendLine("Books:");
            foreach (var book in this.report[person])
            {
                stringBuilder.AppendLine(book.ToString());
                stringBuilder.AppendLine(new string('-', 20));
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
                        string.Format(ExceptionMessages.BOOK_IS_ALREADY_TAKEN, book.Title, book.ReturnDate.ToString("MM/dd/yyyy"));

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
    }
}
