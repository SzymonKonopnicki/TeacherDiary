﻿using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.Web.Models;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Components.BaseClasses
{
    //TODO: Refaktor całej tej klasy ze względu na bałagan.
    //1. SwitchEditMode refaktor, działa tez żle
    public class PersonsBase : ComponentBase
    {
        [Inject]
        public IPersonService ProductService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<PersonDto> Persons { get; set; }

        public PersonDto PersonDto { get; set; }

        public AssigmentModel AssigmentModel { get; set; } = new AssigmentModel();

        public PersonUpdateDto PersonUpdateDto { get; set; } = new PersonUpdateDto();

        public PersonCreateDto PersonCreateDto { get; set; } = new PersonCreateDto();


        protected internal bool IsEditMode = false;

        protected internal bool IsAddedMode = false;

        protected internal bool IsTicketForPerson = false;

        protected void SwitchEditMode(PersonDto personDto)
        {
            PersonDto = personDto;
            IsEditMode = !IsEditMode;
        }

        protected void SwitchAddedMode()
        {
            IsAddedMode = !IsAddedMode;
        }

        protected void TicketForPerson(string email)
        {
            AssigmentModel.PersonMail = email;
            IsTicketForPerson = !IsTicketForPerson;
        }

        protected async Task HandleValidEditPersonSubmit()
        {
            try
            {
                PersonUpdateDto.Email = PersonDto.Email;

                if (string.IsNullOrWhiteSpace(PersonUpdateDto.Name))
                {
                    PersonUpdateDto.Name = PersonDto.Name;
                }

                if (string.IsNullOrWhiteSpace(PersonUpdateDto.Surname))
                {
                    PersonUpdateDto.Surname = PersonDto.Surname;
                }

                if (string.IsNullOrWhiteSpace(PersonUpdateDto.Phone))
                {
                    PersonUpdateDto.Phone = PersonDto.Phone;
                }

                if (PersonUpdateDto.Agreement == null)
                {
                    PersonUpdateDto.Agreement = PersonDto.Agreement;
                }

                if (string.IsNullOrWhiteSpace(PersonDto.Comments))
                {
                    PersonUpdateDto.Comments = PersonDto.Comments;
                }

                await ProductService.EditPersonByMail(PersonUpdateDto);
            }

            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        protected async Task HandleValidAddPersonSubmit()
        {
            try
            {
                ProductService.AddPerson(PersonCreateDto);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        protected async Task HandleValidAssigneTicketToPersonSubmit()
        {
            try
            {
                ProductService.AssignTicketToPerson(AssigmentModel);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }
        protected void RemovePerson(string name)
        {
            ProductService.RemovePersonByName(name);
        }
        protected void RemoveTicketFromPerson(string mail)
        {
            ProductService.RemoveTicket(mail);
        }
        protected override async Task OnInitializedAsync()
        {
            Persons = await ProductService.GetPersons();
        }
    }
}
