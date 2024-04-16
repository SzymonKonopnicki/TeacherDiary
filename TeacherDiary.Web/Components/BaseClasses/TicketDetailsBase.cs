using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.Web.Services;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Components.BaseClasses
{
    public class TicketDetailsBase : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }

        [Inject]
        public ITicketService TicketService { get; set; }

        public TicketDto Ticket { get; set; }
        public bool IsEditMode { get; private set; }


        protected override async Task OnInitializedAsync()
        {
            Ticket = await TicketService.GetTicketByName(Name);
        }
        //public void SwitchEditMode(TicketDto ticketDto)
        //{
        //    Ticket = ticketDto;
        //    IsEditMode = !IsEditMode;
        //}
        protected async Task RemoveTicket(string ticketName)
        {
            await TicketService.RemoveTicket(ticketName);
        }

    }
}
