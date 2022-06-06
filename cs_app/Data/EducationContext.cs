using Microsoft.EntityFrameworkCore;
using cs_app.Data.Models;

namespace cs_app.Data
{
    public class EducationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Customer> Customers { get; set; }

        //это метод, вызываемый при инициализации экземпляра класса EducationContext,
        //который отвечает за первичное подключение к БД и ее настройку.
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=education;Username=postgres;Password=root")
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
        }

        //метод определения параметров при работе с сущностями и таблицами в БД
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().HasMany(au => au.Items).WithMany(af => af.Orders);
            modelBuilder.Entity<Customer>().HasMany(ar => ar.Orders);
        }
    }
}