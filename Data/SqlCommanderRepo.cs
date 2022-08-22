using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
  public class SqlCommanderRepo : ICommanderRepo
  {
    private readonly CommanderContext _context;

    public SqlCommanderRepo(CommanderContext context)
    {
      _context = context;
    }



    public void CreateCommand(Command cmd)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }

      _context.CommandsTable.Add(cmd);
    }

    public void DeleteCommand(Command cmd)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }
      _context.CommandsTable.Remove(cmd);
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return _context.CommandsTable.ToList();
    }

    public Command GetCommandById(int id)
    {
      return _context.CommandsTable.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateCommand(Command cmd)
    {
      //Nothing
    }
  }
}