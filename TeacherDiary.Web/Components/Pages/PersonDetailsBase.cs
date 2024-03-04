using Microsoft.AspNetCore.Components;
using TeacherDiary.WebApi.Interfaces;

namespace TeacherDiary.Web.Components.Pages
{
    public class PersonDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Name { get; set; }

        public IPersonService PersonService { get; set; }
    }
}
