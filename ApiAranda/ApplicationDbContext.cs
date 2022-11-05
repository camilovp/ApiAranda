using ApiAranda.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiAranda
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
