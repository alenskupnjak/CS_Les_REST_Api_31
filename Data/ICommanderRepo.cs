using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public interface ICommanderRepo
  {
    bool SaveChanges();
    IEnumerable<Command> GetAllCommands();
    IEnumerable<Command> GetAllCommandsObicni();
    Command GetCommandById(int id);
    Command GetCommandByIdObicni(int id);
    void CreateCommand(Command cmd);
    void UpdateCommand(Command cmd);
    void DeleteCommand(Command cmd);
  }
}