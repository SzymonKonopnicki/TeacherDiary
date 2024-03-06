using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Components.Pages
{
    public class PersonsBase : ComponentBase
    {
        [Inject]
        public IPersonService ProductService { get; set; }

        public IEnumerable<PersonDto> Persons { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Persons = await ProductService.GetPersons();
        }
    }
}
