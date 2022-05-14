namespace LibraryApp.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string INVALID_TYPE = "The {0} is not a valid type!";

        public const string USER_ALREADY_REGISTERED = "{0} is already registered!";

        public const string INVALID_ITEM_TO_RETURN = "Invalid item to return!";

        public const string PERSON_NOT_REGISTERED = "{0} is not registered!";

        public const string INVALID_ITEM = "Such a item does not exist!";

        public const string ITEM_IS_ALREADY_TAKEN = "{0} is taken. Will be available at the latest: {1}";

        public const string NULL_OR_WHITESPACE_NAME = "{0} cannot be null or whitespace";

        public const string NAME_INVALID_LENGHT = "The {0} cannot contain less than {1} characters";

        public const string NEGATIVE_OR_ZERO_AGE = "Age cannot be zero or negative!";

        public const string ADULT_INVALID_AGE = "The age of an adult client cannot be less than {0} years";

        public const string CHILD_INVALID_AGE = "The age of the client child may not be more than or equal to {0} years";

        public const string BANNED_GENRE = "Genre: {0} is forbidden for children!";

        public const string INVALID_AGE_FORMAT = "{0} is not a number!";  

        public const string INVALID_COUNT_OF_ARGUMENTS = "Expected count of arguments is {0}, you pass {1}!";
    }
}
