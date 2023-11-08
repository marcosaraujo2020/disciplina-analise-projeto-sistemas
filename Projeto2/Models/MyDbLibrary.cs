using Microsoft.EntityFrameworkCore;
using Models;

namespace Models
{
    public class MyDbLibrary : DbContext
    {
               public MyDbLibrary(DbContextOptions<MyDbLibrary> options) : base(options)
        {
        } 
    public DbSet<Models.Student> Student { get; set; } = default!;
    public DbSet<Models.Library> Library { get; set; } = default!;
    public DbSet<Models.Books> Books { get; set; } = default!;
    public DbSet<Models.FacultyMember> FacultyMember { get; set; } = default!;
    public DbSet<Models.GeneralBook> GeneralBook { get; set; } = default!;
    public DbSet<Models.ReferenceBook> ReferenceBook { get; set; } = default!;
    }
}


