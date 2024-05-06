using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace testlog.Models
{
    public class database:IdentityDbContext<iuser>
    {
        public database(DbContextOptions<database> op) : base(op)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
    public class iuser : IdentityUser
    {
        
    }
}
