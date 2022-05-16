using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUser.DAL.Tables;

namespace WebUser.DAL
{
    public class IESContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public IESContext() { }
        public IESContext(IConfiguration configuration)
        { 
            this.Configuration = configuration; 
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //var connectionString = Configuration.GetConnectionString("Conn_cSharp");
            //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            options.UseMySql("server=localhost; port=3306; database=csharp; user=csharp; password=csharp; Persist Security Info=False; Connect Timeout=300", ServerVersion.AutoDetect("server=localhost; port=3306; database=csharp; user=csharp; password=csharp; Persist Security Info=False; Connect Timeout=300"));
        }
    }
}
