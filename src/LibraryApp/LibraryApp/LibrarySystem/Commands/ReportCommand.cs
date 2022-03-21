namespace LibraryApp.LibrarySystem.Commands
{
    using System;

    using LibraryApp.LibrarySystem.Commands.Contracts;

    public class ReportCommand : ICommand
    {
        public string Execute(Library library, params string[] arguments)
        {
            string personFullName = string.Join(' ', arguments);
            string report = library.ShowReportForPerson(personFullName);

            return report;
        }
    }
}
