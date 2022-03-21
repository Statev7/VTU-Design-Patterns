namespace LibraryApp.LibrarySystem.IO.Readers
{
    using System;

    using LibraryApp.LibrarySystem.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
