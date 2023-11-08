
using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace Models
{
    public class Books
    {
        public int Id { get; set; }
        [Display(Name="Nome do Autor")]
        public string? AuthorName { get; set; }
        public int? Noofbooks { get; set; }
        public int LibraryId { get; set; }
        public virtual Library? Library { get; set; }      
    }
}