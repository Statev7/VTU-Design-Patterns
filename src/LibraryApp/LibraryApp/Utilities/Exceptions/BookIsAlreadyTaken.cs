namespace LibraryApp.Utilities.Exceptions
{
    using System;

    public class BookIsAlreadyTaken : Exception
    {
        public BookIsAlreadyTaken()
            :base()
        {

        }

        public BookIsAlreadyTaken(string errorMessage)
            :base(errorMessage)
        {

        }
    }
}
