namespace LibraryApp.Utilities.Exceptions
{
    using System;

    public class EntityAlredyExist : Exception
    {
        public EntityAlredyExist()
            :base()
        {

        }

        public EntityAlredyExist(string errorMessage)
            :base(errorMessage)
        {

        }
    }
}
