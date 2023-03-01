using Microsoft.EntityFrameworkCore;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Infrastructure
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions option):base(option)
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}