﻿using System.ComponentModel.DataAnnotations
namespace BookStore.Api.Models
{
    public class BookModel
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
