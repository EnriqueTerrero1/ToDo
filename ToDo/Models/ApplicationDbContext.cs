
using Microsoft.EntityFrameworkCore;
using PracticeASP.NETCOREMVC.Models;


namespace ToDo
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<ToDoItem> items { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {

            }
        
    }
}
