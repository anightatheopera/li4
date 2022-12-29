﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadUM.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string? DataNascimento { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string? TipoDeConta { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string? Nr_Telemovel { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string? Morada { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string? Pagamento { get; set; }

    }
}