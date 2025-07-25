﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public List<Purchase> Purchases { get; set; } = new();
    }
}
