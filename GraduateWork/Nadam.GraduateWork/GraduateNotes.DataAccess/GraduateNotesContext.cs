using Microsoft.EntityFrameworkCore;
using GraduateNotes.DataAccess.Contracts.Models;

namespace GraduateNotes.DataAccess
{
    public class GraduateNotesContext : DbContext
    {
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public GraduateNotesContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Test.GraduateNotes;Trusted_Connection=True;");
        }
    }
}
