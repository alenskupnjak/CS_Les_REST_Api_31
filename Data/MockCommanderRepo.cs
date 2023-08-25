using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    // CREATE CREATE CREATE
    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    // DELETE DELETE
    public void DeleteCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    // GET GET GET
    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command>
          {
            new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
            new Command{Id=1, HowTo="Cut bread", Line="Get a knife", Platform="knife & chopping board"},
            new Command{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle & cup"}
          };
      return commands;
    }

    // GET ONE
    public Command GetCommandById(int id)
    {
      return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
    }
    
    // SAVE SAVE 
    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }

    // UPDATE UPDATE UPDATE UPDATE UPDATE
    public void UpdateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }
  }
}