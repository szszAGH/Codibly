using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SenderService.DbModel
{
    public partial class DatabaseMailContext : DbContext
    {
        public DatabaseMailContext()
        {
        }

        public DatabaseMailContext(DbContextOptions<DatabaseMailContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=avp07;Database=DatabaseMail;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdMail);

                entity.Property(e => e.IdMail).ValueGeneratedNever();

                entity.Property(e => e.Status1).HasColumnName("Status");
            });
        }
    }
}
