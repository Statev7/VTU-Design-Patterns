namespace LibraryApp.LibrarySystem.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using LibraryApp.LibrarySystem.Factories.Contracts;
    using LibraryApp.LibrarySystem.Infrastructure.Helpers;
    using LibraryApp.LibrarySystem.Models.People.Contracts;
    using LibraryApp.Utilities.Messages;

    public class PersonFactory : IFactory<IPerson>
    {
        private const int EXPECTED_ARGUMENT_COUNT = 4;

        public IPerson Create(params string[] arguments)
        {
            if (arguments.Length != EXPECTED_ARGUMENT_COUNT)
            {
                string errorMessage = 
                    string.Format(ExceptionMessages.INVALID_COUNT_OF_ARGUMENTS, EXPECTED_ARGUMENT_COUNT, arguments.Length);

                throw new ArgumentOutOfRangeException(errorMessage);
            }

            string typeAsString = arguments[0];
            string firstName = arguments[1];
            string lastName = arguments[2];
            string ageAsString = arguments[3];

            int age;
            bool isNumber = int.TryParse(arguments[3], out age);

            if (isNumber == false)
            {
                string errorMessage = string.Format(ExceptionMessages.INVALID_AGE_FORMAT, age);
                throw new FormatException(errorMessage);
            }

            Type typeToCreate = Assembly.GetCallingAssembly()
                .GetTypes()
                .SingleOrDefault(t => t.Name.ToLower() == typeAsString.ToLower());

            bool isNull = CustomValidator.IsNull(typeToCreate);
            if (isNull)
            {
                string errorMessage = string.Format(ExceptionMessages.INVALID_TYPE, typeAsString);
                throw new ArgumentNullException(errorMessage);
            }

            object[] arg = new object[] { firstName, lastName, age };
            IPerson person = null;
            try
            {
                person = (IPerson)Activator.CreateInstance(typeToCreate, arg);
            }
            catch (TargetInvocationException tie)
            {
                Exception ex = tie.InnerException;
                throw ex;
            }

            return person;
        }
    }
}
