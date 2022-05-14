namespace LibraryApp.LibrarySystem.Commands
{
    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Contracts;
    using LibraryApp.Utilities.Constants;
    using LibraryApp.Utilities.Messages;

    public class ShutdownCommand : ICommand
    {
        public string Execute(ILibrary library, params string[] arguments)
        {
            GlobalConstants.IsAppRun = false;
            return OutputMessages.APP_SHUTDOWN;
        }
    }
}
