namespace LibraryApp.Utilities.Exceptions
{
    using System;

    public class AccessDeniedException : Exception
    {
        public AccessDeniedException()
            :base()
        {

        }

        public AccessDeniedException(string errorMessage)
            :base(errorMessage)
        {

        }
    }
}
