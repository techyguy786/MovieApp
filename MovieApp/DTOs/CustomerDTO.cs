using MovieApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public DateTime? Birthdate { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}