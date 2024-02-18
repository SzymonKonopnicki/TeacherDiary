using Microsoft.AspNetCore.Mvc;
using TeacherDiary.WebApi.Database;

#pragma warning disable VSSpell001 // Spell Check
namespace TeacherDiary.WebApi.Controllers
#pragma warning restore VSSpell001 // Spell Check
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly DiaryContext _diaryContext;
        public TicketController(DiaryContext diaryContext)
        {
            _diaryContext = diaryContext;
        }


    }
}
