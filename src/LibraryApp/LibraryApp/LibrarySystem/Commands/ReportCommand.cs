namespace LibraryApp.LibrarySystem.Commands
{
    using System;

    using LibraryApp.LibrarySystem.Commands.Contracts;
    using LibraryApp.LibrarySystem.Contracts;

    public class ReportCommand : ICommand
    {
        public string Execute(ILibrary library, params string[] arguments)
        {
            string personFullName = string.Join(' ', arguments);
            string report = library.ShowReportForPerson(personFullName);

            return report;
        }
    }
}
