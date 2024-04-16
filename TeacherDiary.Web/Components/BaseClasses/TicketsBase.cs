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
        public TicketDto TicketCreate { get; set; } = new TicketDto();
        public bool IsEditMode { get; private set; }

        protected internal bool IsAddedMode = false;


        [SupplyParameterFromForm]
        public string PriceAsString { get; set; }

        [SupplyParameterFromForm]
        public string EntryQuantityAsString { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Tickets = await TicketService.GetTickets();
        }
        protected void SwitchAddedMode()
        {
            IsAddedMode = !IsAddedMode;
        }

        public void SwitchEditMode(TicketDto ticketDto)
        {
            Ticket = ticketDto;
            IsEditMode = !IsEditMode;
        }
        protected async Task RemoveTicket(string ticketName)
        {
            await TicketService.RemoveTicket(ticketName);
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
        protected async Task HandleValidAddTicketDtoSubmit()
        {
            TicketCreate.EntryQuantity = Int32.Parse(EntryQuantityAsString);
            TicketCreate.Price = Double.Parse(PriceAsString);
            await TicketService.AddTicket(TicketCreate);                                                                                                    
        }
    }
}
