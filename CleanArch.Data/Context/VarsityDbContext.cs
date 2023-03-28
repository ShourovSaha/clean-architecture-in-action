using Microsoft.EntityFrameworkCore;
using CleanArch.Domain.Models;

namespace CleanArch.Data.Context
{
    public class VarsityDbContext : DbContext
    {
        public VarsityDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
    }
}