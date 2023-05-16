using ApiCQRS.Core.UserContext;
using Microsoft.EntityFrameworkCore;

namespace ApiCQRS.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}