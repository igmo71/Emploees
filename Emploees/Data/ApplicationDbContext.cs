using Emploees.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Emploees.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Catalog_Сотрудники_Zup> Catalog_Сотрудники_Zup { get; set; }

        public DbSet<Catalog_Сотрудники_Buh> Catalog_Сотрудники_Buh { get; set; }

        public DbSet<Catalog_Пользователи> Catalog_Пользователиs {  get; set; }
        public DbSet<Catalog_СхемаПредприятия> Catalog_СхемаПредприятия { get; set; } = default!;
        public DbSet<Пользователь_СхемаПредприятия> Пользователь_СхемаПредприятия { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Catalog_Сотрудники_Zup>().HasKey(e => e.Ref_Key);
            builder.Entity<Catalog_Сотрудники_Zup>().Property(e => e.Ref_Key).HasMaxLength(AppSettings.GUID);
            builder.Entity<Catalog_Сотрудники_Zup>().Property(e => e.Code).HasMaxLength(AppSettings.CODE);
            builder.Entity<Catalog_Сотрудники_Zup>().Property(e => e.Description).HasMaxLength(AppSettings.DESCRIPTION);

            builder.Entity<Catalog_Сотрудники_Buh>().HasKey(e => e.Ref_Key);
            builder.Entity<Catalog_Сотрудники_Buh>().Property(e => e.Ref_Key).HasMaxLength(AppSettings.GUID);
            builder.Entity<Catalog_Сотрудники_Buh>().Property(e => e.Code).HasMaxLength(AppSettings.CODE);
            builder.Entity<Catalog_Сотрудники_Buh>().Property(e => e.Description).HasMaxLength(AppSettings.DESCRIPTION);

            builder.Entity<Catalog_Пользователи>().HasKey(e => e.Ref_Key);
            builder.Entity<Catalog_Пользователи>().Property(e => e.Ref_Key).HasMaxLength(AppSettings.GUID);
            builder.Entity<Catalog_Пользователи>().Property(e => e.Description).HasMaxLength(AppSettings.DESCRIPTION);

            builder.Entity<Catalog_СхемаПредприятия>().ToTable("Catalog_СхемаПредприятия").HasKey(e => e.Ref_Key);

            builder.Entity<Catalog_Пользователи>().ToTable("Catalog_Пользователи").HasKey(e => e.Ref_Key);

            builder.Entity<Пользователь_СхемаПредприятия>().ToTable("Пользователь_СхемаПредприятия").HasKey(e => e.Пользователь_Key);
            builder.Entity<Пользователь_СхемаПредприятия>()
                .HasOne(e => e.Пользователь)
                .WithOne()
                .HasForeignKey<Пользователь_СхемаПредприятия>(e => e.Пользователь_Key)
                .HasPrincipalKey<Catalog_Пользователи>(e => e.Ref_Key);
            builder.Entity<Пользователь_СхемаПредприятия>()
                .HasOne(e => e.СхемаПредприятия)
                .WithOne()
                .HasForeignKey<Пользователь_СхемаПредприятия>(e => e.СхемаПредприятия_Key)
                .HasPrincipalKey<Catalog_СхемаПредприятия>(e => e.Ref_Key);

            base.OnModelCreating(builder);
        }
    }
}
