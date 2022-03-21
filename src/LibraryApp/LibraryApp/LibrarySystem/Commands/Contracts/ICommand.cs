namespace LibraryApp.LibrarySystem.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(Library library, params string[] arguments);
    }
}
