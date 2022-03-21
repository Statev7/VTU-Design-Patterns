namespace LibraryApp.LibrarySystem.Models.Peoples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LibraryApp.LibrarySystem.Infrastructure.Helpers;
    using LibraryApp.LibrarySystem.Models.Book;
    using LibraryApp.LibrarySystem.Models.Peoples.Contracts;
    using LibraryApp.Utilities.Exceptions;
    using LibraryApp.Utilities.Messages;

    public abstract class Person : IPerson
    {
        private const int FIRST_NAME_MIN_LENGHT_VALUE = 3;
        private const int LAST_NAME_MIN_LENGHT_VALUE = 3;

        private string firstName;
        private string lastName;
        private int age;
        private readonly ICollection<Book> books;

        private Person()
        {
            this.books = new List<Book>();
        }

        protected Person(string firstName, string lastName, int age)
            :this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.ValidateName(value, FIRST_NAME_MIN_LENGHT_VALUE, nameof(this.FirstName));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.ValidateName(value, LAST_NAME_MIN_LENGHT_VALUE, nameof(this.LastName));

                this.lastName = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                bool isAgeInvalid = CustomValidator.IsBelowOrEqualToZero(value);
                if (isAgeInvalid)
                {
                    throw new ArgumentException(ExceptionMessages.NEGATIVE_OR_ZERO_AGE);
                }

                this.age = value;
            }
        }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public Library Library { get; set; }

        public void GetBook(string bookName)
        {
            Book book = this.Library.GetBook(this, bookName);
            this.books.Add(book);
        }

        public void ReturnBook(string bookName)
        {
            Book book = this.FindBookByName(bookName);

            bool isNull = CustomValidator.IsNull(book);
            if (isNull)
            {
                throw new EntityDoesNotExist(ExceptionMessages.INVALID_BOOK_TO_RETURN);
            }

            this.books.Remove(book);
            this.Library.ReturnBook(this, book);
        }

        private Book FindBookByName(string bookName)
        {
            return this.books.SingleOrDefault(b => b.Title == bookName);
        }

        private void ValidateName(string nameValue, int minLenght, string nameOf)
        {
            bool isNullOrWhiteSpace = CustomValidator.IsNullOrWhiteSpace(nameValue);
            if (isNullOrWhiteSpace)
            {
                string errorMessage = string.Format(ExceptionMessages.NULL_OR_WHITESPACE_NAME, nameOf);
                throw new ArgumentNullException(errorMessage);
            }

            bool isNameLenghtInvalid = CustomValidator.IsStringLengthLowerTo(nameValue, minLenght);
            if (isNameLenghtInvalid)
            {
                string errorMessage = string.Format(ExceptionMessages.NAME_INVALID_LENGHT, nameOf, minLenght);
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
