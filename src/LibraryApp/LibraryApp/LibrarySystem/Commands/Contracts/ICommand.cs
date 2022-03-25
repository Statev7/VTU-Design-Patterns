namespace LibraryApp.LibrarySystem.Commands.Contracts
{
    using LibraryApp.LibrarySystem.Contracts;

    public interface ICommand
    {
        string Execute(ILibrary library, params string[] arguments);
    }
}
