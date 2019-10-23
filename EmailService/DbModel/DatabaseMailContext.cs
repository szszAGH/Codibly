using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MailsService.DbModel
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

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Types> Types { get; set; }

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
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("Address");

                entity.HasOne(d => d.IdMailNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.IdMail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Mail");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Types");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.IdMailNavigation)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.IdMail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attachment_Mail");
            });

            modelBuilder.Entity<Mail>(entity =>
            {
                entity.HasKey(e => e.IdMail)
                    .HasName("PK__Mail__4E65A0770519C6AF");

                entity.Property(e => e.Body).HasColumnType("text");

                entity.HasOne(d => d.IdPriorityNavigation)
                    .WithMany(p => p.Mail)
                    .HasForeignKey(d => d.IdPriority)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mail_Priority");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.HasKey(e => e.IdPriority)
                    .HasName("PK__Priority__20A1DC1A08EA5793");

                entity.Property(e => e.IdPriority).ValueGeneratedNever();

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdMail);

                entity.Property(e => e.IdMail).ValueGeneratedNever();

                entity.Property(e => e.Status1).HasColumnName("Status");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.IdType);

                entity.Property(e => e.IdType).ValueGeneratedNever();

                entity.Property(e => e.Desc).IsRequired();
            });
        }
    }
}
