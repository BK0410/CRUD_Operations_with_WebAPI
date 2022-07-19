using Microsoft.EntityFrameworkCore;
using SampleWebAPIproject.Data.Entities;

namespace SampleWebAPIproject.Data
{
    public class WebAPIusersDBContext:DbContext
    {
        public WebAPIusersDBContext(DbContextOptions<WebAPIusersDBContext> options):base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
