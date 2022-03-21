namespace LibraryApp.LibrarySystem.Models.People
{
    using System;

    using LibraryApp.Utilities.Messages;

    public class Adult : Person
    {
        public const int MIN_AGE_VALUE = 18;

        public Adult(string firstName, string lastName, int age) 
            : base(firstName, lastName, age)
        {
        }

        public override int Age
        {
            get
            {
                return base.Age;
            }
            protected set
            {
                bool isAgeInvalid = value < MIN_AGE_VALUE;
                if (isAgeInvalid)
                {
                    string errorMessage = string.Format(ExceptionMessages.ADULT_INVALID_AGE, MIN_AGE_VALUE);
                    throw new ArgumentException(errorMessage);
                }

                base.Age = value;
            }
        }
    }
}
