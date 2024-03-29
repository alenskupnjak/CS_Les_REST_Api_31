using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    // Krairanje zapisa BAZI
    public void CreateCommand(Command cmd)
    {
      Console.WriteLine("Value koju printam u konzoli {0} ", cmd);
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }
      _context.CommandsTable.Add(cmd);
    }


    // DELETE DELETE DELETE
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

    // GET ONE
    public Command GetCommandById(int id)
    {
      var data = _context.CommandsTable.FirstOrDefault(p => p.Id == id);
      //Type t = data?.GetType();
      //if (t is object)
      //{
      //  Console.WriteLine("Type is: {0} Id={1}", t.Name, id);
      //  Console.WriteLine(data);
      //  PropertyInfo[] props = t.GetProperties();
      //  Console.WriteLine("Properties (N = {0}):", props.Length);
      //  foreach (var prop in props)
      //    if (prop.GetIndexParameters().Length == 0)
      //      Console.WriteLine("   {0} ({1}): {2}", prop.Name, prop.PropertyType.Name, prop.GetValue(data));
      //    else
      //      Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name, prop.PropertyType.Name);
      //}
      return data;
    }

    // Snimanje podataka u bazi
    public bool SaveChanges()
    {
      Console.WriteLine("Ja sam u SaveChanges ");
      return (_context.SaveChanges() >= 0);
    }

    // UPDATE
    public void UpdateCommand(Command cmd)
    {
      Console.WriteLine("Ja sam u UpdateCommand");
      // Ne treba nista, ovo je samo da se zadovolji forma jer Intarface mora viti pokriven...
    }
  }
}