using Microsoft.EntityFrameworkCore;
using SecondEndPoint.Models;

namespace SecondEndPoint.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UserRegisterInfo> UserSecondEndPoint { get; set; }
    }
}
