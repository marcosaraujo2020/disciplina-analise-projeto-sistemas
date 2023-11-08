using Models;

namespace Models
{
    public class FacultyMember : Member
    {
        public string? Fname { get; set; }        
        public string? facultycoll { get; set; }   
        public int LibraryId { get; set; }
        public virtual Library? Library { get; set; }      
    }
}