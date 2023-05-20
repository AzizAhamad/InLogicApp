using System;
using InLogicApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace InLogicApp.API.Helper
{
	public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("InLogicAppConnString"));
        }

        public DbSet<User> Users { get; set; }
    }
}

