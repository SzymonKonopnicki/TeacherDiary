using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.Web.Middlewares.Exceptions;
using TeacherDiary.Web.Services;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Components.BaseClasses
{
    public class PersonsDetailsBase : ComponentBase
    {
        [Parameter]
        public string Mail { get; set; }
        public PersonDto PersonDto { get; set; }

        [Inject]
        public IPersonService ProductService { get; set; }

        [Inject]
        public IMessageService MessageService { get; set; }

        public bool ExceptionSwitch { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                PersonDto = await ProductService.GetPersonByEmail(Mail);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception("bład ogólnny");
            }
        }

    }
}
