using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Components
{
    public class PersonBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<PersonDto> Persons { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Persons = await ProductService.GetPerson();
        }
    }
}
