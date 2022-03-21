namespace LibraryApp
{
    using LibraryApp.LibrarySystem.Core;
    using LibraryApp.LibrarySystem.Core.Contracts;
    using LibraryApp.LibrarySystem.IO.Readers;
    using LibraryApp.LibrarySystem.IO.Writers;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}
