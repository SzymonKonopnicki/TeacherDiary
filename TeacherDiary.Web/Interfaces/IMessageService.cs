namespace TeacherDiary.Web.Interfaces
{
    public interface IMessageService
    {
        event Action<string> OnError;
        void ShowError(string errorMessage);

    }
}
