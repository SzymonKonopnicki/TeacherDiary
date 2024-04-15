namespace TeacherDiary.WebApi.Interfaces
{
    public interface IAssignment
    {
        public void AssignTicketToPerson(string personMail, string ticketName);
        public void RemoveTicketFromPerson(string personMail);
    }
}
