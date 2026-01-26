using Emploees.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Emploees.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Catalog_Сотрудники_Zup> Catalog_Сотрудники_Zup { get; set; }

        public DbSet<Catalog_Сотрудники_Buh> Catalog_Сотрудники_Buh { get; set; }

        public DbSet<Catalog_Пользователи> Catalog_Пользователи { get; set; }
        public DbSet<Catalog_СхемаПредприятия> Catalog_СхемаПредприятия { get; set; } = default!;
        public DbSet<Пользователь_СхемаПредприятия> Пользователь_СхемаПредприятия { get; set; }

        public DbSet<AdUser> AdUsers { get; set; }

        public DbSet<CostItem> CostItems { get; set; }
        public DbSet<JobTitle> JobTitles => Set<JobTitle>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Location> Locations => Set<Location>();

        public DbSet<Emploee> Emploees => Set<Emploee>();

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

            builder.Entity<AdUser>().HasKey(e => e.Sid);

            builder.Entity<CostItem>().HasKey(e => e.Id);

            builder.Entity<JobTitle>().HasKey(e => e.Id);

            builder.Entity<City>().HasKey(e => e.Id);

            builder.Entity<Location>().HasKey(e => e.Id);


            builder.Entity<Emploee>().HasKey(e => e.Id);
            builder.Entity<Emploee>().HasOne(e => e.JobTitle).WithMany().HasForeignKey(e => e.JobTitleId).HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.CostItem).WithMany().HasForeignKey(e => e.CostItemId).HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.Department).WithMany().HasForeignKey(e => e.DepartmentId).HasPrincipalKey(e => e.Ref_Key).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.City).WithMany().HasForeignKey(e => e.CityId).HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.Location).WithMany().HasForeignKey(e => e.LocationId).HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.UserUt).WithMany().HasForeignKey(e => e.UserUtId).HasPrincipalKey(e => e.Ref_Key).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.UserAd).WithMany().HasForeignKey(e => e.UserAdId).HasPrincipalKey(e => e.Sid).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.EmploeeBuh).WithMany().HasForeignKey(e => e.EmploeeBuhId).HasPrincipalKey(e => e.Ref_Key).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.EmploeeZup).WithMany().HasForeignKey(e => e.EmploeeZupId).HasPrincipalKey(e => e.Ref_Key).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.OperationManager).WithMany().HasForeignKey(e => e.OperationManagerId).HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Emploee>().HasOne(e => e.LocationManager).WithMany().HasForeignKey(e => e.LocationManagerId).HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
