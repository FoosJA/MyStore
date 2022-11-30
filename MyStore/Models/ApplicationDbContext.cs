using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using System.Xml.Linq;


namespace MyStore.Models

{
    public class ApplicationDbContext : DbContext//определяет контекст данных, используемый для взаимодействия с базой данных
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ProductClass> Products { get; set; }//представляет набор объектов, которые хранятся в базе данных

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//устанавливает параметры подключения
         {
             optionsBuilder.UseSqlite("Data Source=helloapp.db");
         }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Entity<ProductClass>().Property(e => e.ProductID).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductClass>().HasData(
                new ProductClass
                {
                    ProductID = 1,
                    Name = "Kayak",
                    Description = "А boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new ProductClass
                {
                    ProductID = 2,
                    Name = "Lifejacket",
                    Description = "Protective and fashionable",
                    Category = "Watersports",
                    Price = 48.95m
                },
                new ProductClass
                {
                    ProductID = 3,
                    Name = "Soccer Ball",
                    Description = "FIFA-approved size and weight",
                    Category = "Soccer",
                    Price = 19.50m
                },
                new ProductClass
                {
                    ProductID = 4,
                    Name = "Corner Flags",
                    Description = "Give your playing field а professional touch",
                    Category = "Soccer",
                    Price = 34.95m
                },
                new ProductClass
                {
                    ProductID = 5,
                    Name = "Stadium",
                    Description = "Flat-packed 35, 000-seat stadium",
                    Category = "Soccer",
                    Price = 79500
                },
                new ProductClass
                {
                    ProductID = 6,
                    Name = "Thinking Сар",
                    Description = "Improve brain efficiency Ьу 75i",
                    Category = "Chess",
                    Price = 16
                },
                new ProductClass
                {
                    ProductID = 7,
                    Name = "Unsteady Chair",
                    Description = "Secretly give your opponent а disadvantage",
                    Category = "Chess",
                    Price = 29.95m
                },
                new ProductClass
                {
                    ProductID = 8,
                    Name = "Human Chess Board",
                    Description = "А fun game for the family",
                    Category = "Chess",
                    Price = 75
                },
                new ProductClass
                {
                    ProductID = 9,
                    Name = "Bling-Bling King",
                    Description = "Gold-plated, diamond-studded King",
                    Category = "Chess",
                    Price = 1200
                }
            );
        }
    }

}
