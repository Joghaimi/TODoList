using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TODoList.Models;

namespace TODoList.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Note> Note { set; get; }
    }
}
