using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorTrackerStatelessService.StorageModel
{
    public class VisitorContext : DbContext
    {
        public VisitorContext(DbContextOptions<VisitorContext> options)
        : base(options)
        {

        }
     
        public DbSet<Visitors> Visitors { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DbContext>();
            builder.UseSqlServer("Server=idtp285\\sqlserver;Database=TrackerDB;Trusted_Connection=True;MultipleActiveResultSets =true");
            return new DbContext(builder.Options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("VisitorDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
   

}
