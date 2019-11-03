using Microsoft.EntityFrameworkCore;

namespace TodoList.Models
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
