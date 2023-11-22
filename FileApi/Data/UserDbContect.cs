using FileApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileApi.Data
{
    public class UserDbContect:DbContext
    {
        public UserDbContect(DbContextOptions<UserDbContect> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
    }
}
