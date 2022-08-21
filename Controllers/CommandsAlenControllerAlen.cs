using System.Collections.Generic;

using Commander.Data;

using Commander.Models;

using Microsoft.AspNetCore.Mvc;



namespace Commander.Controllers
{

  [Route("api/commandsalen")]
  [ApiController]
  public class CommandsAlenController : ControllerBase
  {
    private readonly MockCommanderRepo _repository = new MockCommanderRepo();




    //GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommmands()
    {
      var commandItems = _repository.GetAllCommands();

      return Ok(commandItems);
    }

    //GET api/commands/{id}
    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if (commandItem != null)
      {
        return Ok(commandItem);
      }
      return NotFound();
    }

  }
}