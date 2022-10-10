
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
  public class CommanderContext : DbContext
  {
    public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
    {
    }
    public DbSet<Models.Command> CommandsTable { get; set; }
  }
}