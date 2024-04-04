using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Primitives;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Components.BaseClasses
{
    public class TicketsBase : ComponentBase
    {
        [Inject]
        public ITicketService TicketService { get; set; }

        public IEnumerable<TicketDto> Tickets { get; set; }
        public TicketDto Ticket { get; set; } = new TicketDto();
        public bool IsEditMode { get; private set; }

        [SupplyParameterFromForm]
        public string PriceAsString { get; set; }

        [SupplyParameterFromForm]
        public string EntryQuantityAsString { get; set; }

        public void SwitchEditMode(TicketDto ticketDto)
        {
            Ticket = ticketDto;
            IsEditMode = !IsEditMode;
        }

        protected async Task HandleValidTicketDtoSubmit()
        {
            if (Ticket.Price != null)
            {
                if (double.TryParse(PriceAsString, out double parsedPrice))
                {
                    Ticket.Price = parsedPrice;
                }
            }
            if (Ticket.EntryQuantity != null)
            {
                if (int.TryParse(EntryQuantityAsString, out int parsedEntry))
                {
                    Ticket.EntryQuantity = parsedEntry;
                }
            }

            await TicketService.UpdateTicket(Ticket);
        }


        protected override async Task OnInitializedAsync()
        {
            Tickets = await TicketService.GetTickets();
        }

    }
}
