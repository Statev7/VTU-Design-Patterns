namespace LibraryApp.Utilities.Exceptions
{
    using System;

    public class EntityDoesNotExist : Exception
    {
        public EntityDoesNotExist()
            :base()
        {

        }

        public EntityDoesNotExist(string errorMessage)
            :base(errorMessage)
        {

        }
    }
}
