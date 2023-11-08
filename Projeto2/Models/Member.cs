using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace Models
{
    public class Member
    {
        public int Id { get; set; }
        [Display(Name="Nome")]
        public string? Mname { get; set; }
        [Display(Name="Endereço")]
        public string? Maddress { get; set; }
        public int? Mno { get; set; }
    }
}