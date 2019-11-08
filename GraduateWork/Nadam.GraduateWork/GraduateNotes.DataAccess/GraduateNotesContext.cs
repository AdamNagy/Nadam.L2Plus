using Microsoft.EntityFrameworkCore;
using GraduateNotes.DataAccess.Contract.Models;

namespace GraduateNotes.DataAccess
{
    public class GraduateNotesContext : DbContext
    {
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NoteSharing> NoteSharing { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<ExceptionType> ExceptionTypes { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventMonitor> MyProperty { get; set; }

        public GraduateNotesContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NoteSharing>()
                .HasKey(table => new
                {
                    table.OwnerId,
                    table.SharedWithId,
                    table.NoteId
                });

            builder.Entity<NoteSharing>().HasOne<UserEntity>(table => table.Owner)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<NoteSharing>().HasOne<UserEntity>(table => table.SharedWith)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<NoteSharing>().HasOne<NoteEntity>(table => table.Note)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Test.GraduateNotes;Trusted_Connection=True;");
        }
    }
}
