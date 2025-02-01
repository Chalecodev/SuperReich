﻿using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;

namespace SuperReich.Domain.Entities.Clients
{
    public class Client: Audit
    {
        [Key]
        public int ClientId { get; set; }
        public string Rut { get; set; } = string.Empty;
        public string Names { get; set; } = string.Empty;
        public string Surnames { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
