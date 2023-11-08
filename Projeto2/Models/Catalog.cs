using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;


namespace Models
{
    public class Catalog
    {
        public int Id { get; set; }
        [Display(Name="Título da Obra")]
        public string? TitleName { get; set; }
        [Display(Name="Nº de Cópias")]
        public int? noofcopies { get; set; }
        public Books? Books { get; set; }
    }
}