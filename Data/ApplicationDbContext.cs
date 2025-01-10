using Microsoft.EntityFrameworkCore;
using CsvDatabase.Models;
using CsvDatabase.Data;



namespace CsvDatabase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Record>? Record { get; set; }


    }





}