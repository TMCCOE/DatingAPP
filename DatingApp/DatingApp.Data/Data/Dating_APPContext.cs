using DatingAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Data
{
    public partial class Dating_APPContext : DbContext
    {
        public Dating_APPContext()
        {

        }

        public Dating_APPContext(DbContextOptions<Dating_APPContext> options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("users", "dbo");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserName)
                     .HasColumnName("UserName")
                     .HasMaxLength(100)
                     .IsUnicode(false);


            });

        }
    }
}
