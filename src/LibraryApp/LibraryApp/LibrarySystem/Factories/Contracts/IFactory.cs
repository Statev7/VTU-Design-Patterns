namespace LibraryApp.LibrarySystem.Factories.Contracts
{
    public interface IFactory<TEntity>
        where TEntity : class
    {
        TEntity Create(params string[] arguments);
    }
}
