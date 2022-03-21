namespace LibraryApp.LibrarySystem.IO.Writers
{
    using System;

    using LibraryApp.LibrarySystem.IO.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}
