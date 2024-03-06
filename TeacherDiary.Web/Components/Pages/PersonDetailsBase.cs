using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Components.Pages
{
    public class PersonDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Name { get; set; }

        [Inject]
        public IPersonService PersonService { get; set; }

        public PersonDto Person{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Person = await PersonService.GetPersonByName(Name);
            }
            catch (Exception msg)
            {
                await Console.Out.WriteLineAsync(msg.Message);
                Person = null;
            }
        }
    }
}
