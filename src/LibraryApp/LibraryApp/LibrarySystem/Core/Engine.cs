namespace LibraryApp.LibrarySystem.Core
{
    using System;

    using LibraryApp.LibrarySystem.Contracts;
    using LibraryApp.LibrarySystem.Core.Contracts;
    using LibraryApp.LibrarySystem.IO.Contracts;
    using LibraryApp.Utilities.Constants;

    public class Engine : IEngine
    {
        private readonly CommandInterpreter commandInterpreter;
        private readonly ILibrary library;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.library = new Library();
            this.commandInterpreter = new CommandInterpreter(this.library);
        }

        public void Run()
        {
            while (GlobalConstants.IsAppRun)
            {
                try
                {
                    string input = this.reader.ReadLine();
                    string message = this.commandInterpreter.ProcessCommand(input);
                    this.writer.WriteLine(message);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
    }
}
