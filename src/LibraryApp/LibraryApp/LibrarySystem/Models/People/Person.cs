namespace LibraryApp.LibrarySystem.Models.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LibraryApp.LibrarySystem.Contracts;
    using LibraryApp.LibrarySystem.Infrastructure.Helpers;
    using LibraryApp.LibrarySystem.Models.LibraryItems;
    using LibraryApp.LibrarySystem.Models.People.Contracts;
    using LibraryApp.Utilities.Exceptions;
    using LibraryApp.Utilities.Messages;

    public abstract class Person : IPerson
    {
        private const int FIRST_NAME_MIN_LENGHT_VALUE = 3;
        private const int LAST_NAME_MIN_LENGHT_VALUE = 3;

        private string firstName;
        private string lastName;
        private int age;
        private readonly ICollection<LibraryItem> libraryItems;

        private Person()
        {
            this.libraryItems = new List<LibraryItem>();
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

        public ILibrary Library { get; set; }

        public void GetLibraryItem(string libraryItemName)
        {
            LibraryItem libraryItem = this.Library.GetItem(this, libraryItemName);
            this.libraryItems.Add(libraryItem);
        }

        public void ReturnLibraryItem(string libraryItemName)
        {
            LibraryItem libraryItem = this.FindLibraryItemByName(libraryItemName);

            bool isNull = CustomValidator.IsNull(libraryItem);
            if (isNull)
            {
                throw new EntityDoesNotExist(ExceptionMessages.INVALID_ITEM_TO_RETURN);
            }

            this.libraryItems.Remove(libraryItem);
            this.Library.ReturnItem(this, libraryItem);
        }

        private LibraryItem FindLibraryItemByName(string libraryItemName)
        {
            return this.libraryItems.SingleOrDefault(li => li.Title == libraryItemName);
        }

        private void ValidateName(string nameValue, int minLenght, string nameOf)
        {
            bool isNullOrWhiteSpace = CustomValidator.IsNullOrWhiteSpace(nameValue);
            if (isNullOrWhiteSpace)
            {
                string errorMessage = string.Format(ExceptionMessages.NULL_OR_WHITESPACE_NAME, nameOf);
                throw new ArgumentNullException(null, errorMessage);
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
