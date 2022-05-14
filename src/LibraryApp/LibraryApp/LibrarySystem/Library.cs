namespace LibraryApp.LibrarySystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LibraryApp.LibrarySystem.Contracts;
    using LibraryApp.LibrarySystem.Infrastructure.Helpers;
    using LibraryApp.LibrarySystem.Models.LibraryItems;
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
        //private const int RENTAL_DAYS = 1;

        private readonly ICollection<LibraryItem> items;
        private readonly ICollection<string> bannedGenresForChilds;
        private readonly ICollection<IPerson> people;
        private readonly IDictionary<IPerson, List<LibraryItem>> report;

        public Library()
        {
            this.items = GlobalConstants.Books;
            this.bannedGenresForChilds = GlobalConstants.BannedGenreForChilds;
            this.people = new HashSet<IPerson>();
            this.report = new Dictionary<IPerson, List<LibraryItem>>();
        }

        public string RegisterClient(IPerson person)
        {
            bool isPersonAlredyExist = this.people.Any(p => p.FullName == person.FullName);
            if (isPersonAlredyExist)
            {
                string errorMessage = string.Format(ExceptionMessages.USER_ALREADY_REGISTERED, person.FullName);
                throw new EntityAlredyExist(errorMessage);
            }

            this.people.Add(person);
            this.report.Add(person, new List<LibraryItem> { });
            person.Library = this;

            string message = string.Format(OutputMessages.SUCCESFFULY_REGISTRATION, person.FullName);

            return message;
        }

        public LibraryItem GetItem(IPerson person, string itemName)
        {
            LibraryItem libraryItem = this.FindItemByName(itemName);

            bool isBannedGenre = person is Child && this.bannedGenresForChilds.Contains(libraryItem.Genre);
            if (isBannedGenre)
            {
                string message = 
                    string.Format(ExceptionMessages.BANNED_GENRE, libraryItem.Genre);
                throw new AccessDeniedException(message);
            }

            libraryItem.DateOfTake = DateTime.UtcNow;
            DateTime returnDate = libraryItem.DateOfTake.AddDays(RENTAL_DAYS);
            libraryItem.ReturnDate = returnDate;
            libraryItem.IsReturned = false;

            libraryItem.SetTimer();

            this.report[person].Add(libraryItem);
            this.items.Remove(libraryItem);

            return libraryItem;
        }

        public void ReturnItem(IPerson person, LibraryItem item)
        {
            bool isValid = this.report[person].Contains(item);
            if (isValid == false)
            {
                throw new ArgumentException(ExceptionMessages.INVALID_ITEM_TO_RETURN);
            }

            item.DateOfTake = default;
            item.IsReturned = true;

            this.report[person].Remove(item);
            this.items.Add(item);
        }

        public string ShowReportForPerson(string personFullName)
        {
            StringBuilder stringBuilder = new StringBuilder();

            IPerson person = this.FindPersonByFullName(personFullName);

            string reportMessage = 
                this.report[person].Count == 0 ? "Items to return: none" : "Items to return:";

            stringBuilder.AppendLine(reportMessage);
            foreach (var item in this.report[person].OrderBy(x => x.GetType().Name))
            {
                stringBuilder.AppendLine(item.ToString());
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

        private LibraryItem FindItemByName(string itemName)
        {
            LibraryItem item = null;

            bool isItemTaken = false;
            foreach (var person in this.report)
            {
                isItemTaken = person.Value.Any(li => li.Title == itemName);
                if (isItemTaken)
                {
                    item = person.Value.SingleOrDefault(li => li.Title == itemName);

                    string errorMessage = 
                        string.Format(ExceptionMessages.ITEM_IS_ALREADY_TAKEN, 
                        item.Title, 
                        item.ReturnDate.ToString(GlobalConstants.DATE_FORMAT));

                    throw new ItemIsAlreadyTaken(errorMessage);
                }
            }

            item = this.items
                .SingleOrDefault(b => b.Title.ToLower() == itemName.ToLower());

            bool isNull = CustomValidator.IsNull(item);
            if (isNull)
            {
                throw new EntityDoesNotExist(ExceptionMessages.INVALID_ITEM);
            }

            return item;
        }
    }
}
