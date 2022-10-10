using System.Collections.Generic;

namespace Commander
{
  public interface ICommanderRepo
  {
    bool SaveChanges();
    IEnumerable<Models.Command> GetAllCommands();
    Models.Command GetCommandById(int id);
    void CreateCommand(Models.Command cmd);
    void UpdateCommand(Models.Command cmd);
    void DeleteCommand(Models.Command cmd);
  }
}