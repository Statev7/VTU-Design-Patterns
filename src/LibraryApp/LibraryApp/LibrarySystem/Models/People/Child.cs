namespace LibraryApp.LibrarySystem.Models.People
{
    using System;

    using LibraryApp.Utilities.Messages;

    public class Child : Person
    {
        private const int AGE_MAX_VALUE = 18;

        public Child(string firstName, string lastName, int age)
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
                bool isInvalid = value >= AGE_MAX_VALUE;
                if (isInvalid)
                {
                    string errorMessage = string.Format(ExceptionMessages.CHILD_INVALID_AGE, AGE_MAX_VALUE);
                    throw new ArgumentException(errorMessage);
                }

                base.Age = value;
            }
        }
    }
}
