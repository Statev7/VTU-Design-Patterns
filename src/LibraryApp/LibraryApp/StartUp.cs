namespace LibraryApp
{
    using LibraryApp.LibrarySystem.Core;
    using LibraryApp.LibrarySystem.Core.Contracts;
    using LibraryApp.LibrarySystem.IO.Contracts;
    using LibraryApp.LibrarySystem.IO.Readers;
    using LibraryApp.LibrarySystem.IO.Writers;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
