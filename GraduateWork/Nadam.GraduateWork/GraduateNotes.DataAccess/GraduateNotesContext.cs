using Microsoft.EntityFrameworkCore;
using GraduateNotes.DataAccess.Models;

namespace GraduateNotes.DataAccess
{
    class GraduateNotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        public GraduateNotesContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=GraduateNotes;Trusted_Connection=True;");
        }
    }
}
