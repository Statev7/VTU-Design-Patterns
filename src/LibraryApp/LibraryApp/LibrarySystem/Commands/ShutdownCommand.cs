namespace LibraryApp.LibrarySystem.Commands
{
    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.Utilities.Constants;

    public class ShutdownCommand : ICommand
    {
        public string Execute(Library library, params string[] arguments)
        {
            GlobalConstants.IsAppRun = false;
            return null;
        }
    }
}
