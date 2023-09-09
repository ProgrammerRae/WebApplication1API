using Microsoft.EntityFrameworkCore;
using WebApplication1API.Models;

namespace WebApplication1API.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) {
        }
        public DbSet<StudentInfo> Students { get; set; }
        
    }
}
