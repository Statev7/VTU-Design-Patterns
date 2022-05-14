namespace LibraryApp.Utilities.Exceptions
{
    using System;

    public class ItemIsAlreadyTaken : Exception
    {
        public ItemIsAlreadyTaken()
            :base()
        {

        }

        public ItemIsAlreadyTaken(string errorMessage)
            :base(errorMessage)
        {

        }
    }
}
