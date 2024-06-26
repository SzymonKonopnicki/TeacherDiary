﻿using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
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

        public bool ExceptionSwitch { get; set; }
        protected override async Task OnInitializedAsync()
        {
            PersonDto = await ProductService.GetPersonByEmail(Mail);
        }

    }
}
