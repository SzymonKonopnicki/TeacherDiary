
using TeacherDiary.Web.Interfaces;

namespace TeacherDiary.Web.Services
{
    public class MessageService : IMessageService
    {
        public event Action<string> OnError;

        public void ShowError(string errorMessage)
        {
            OnError?.Invoke(errorMessage);
        }
    }
}
