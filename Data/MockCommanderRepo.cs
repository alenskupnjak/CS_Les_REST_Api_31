using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmd"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmd"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void DeleteCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
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

    public Command GetCommandById(int id)
    {
      return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Command GetCommandByIdObicni(int id)
    {
      return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmd"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void UpdateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }
  }
}