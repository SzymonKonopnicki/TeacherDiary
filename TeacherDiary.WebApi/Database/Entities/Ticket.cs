﻿using System.ComponentModel.DataAnnotations;

namespace TeacherDiary.WebApi.Database.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required int EntryQuantity { get; set; }

    }
}
