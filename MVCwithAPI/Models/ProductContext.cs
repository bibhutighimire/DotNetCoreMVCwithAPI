using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCwithAPI.Models
{
    public partial class ProductContext : DbContext
    {
        public ProductContext()
        {

        }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=mvc_product_api", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

               

                entity.HasData(
                     new Product()
                     {
                         ID = -1,
                         Name = "Tomato",
                         Quantity = 49,
                         IsDiscontinued = false
                     },
                     new Product()
                     {
                         ID = -2,
                         Name = "Metal",
                         Quantity = 75,
                         IsDiscontinued = false
                     },
                      new Product()
                      {
                          ID = -3,
                          Name = "Jacket",
                          Quantity = 33,
                          IsDiscontinued = false
                      },
                       new Product()
                       {
                           ID = -4,
                           Name = "Chair",
                           Quantity = 45,
                           IsDiscontinued = true
                       },
                        new Product()
                        {
                            ID = -5,
                            Name = "Pet Food",
                            Quantity = 100,
                            IsDiscontinued = false
                        }
                );
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
