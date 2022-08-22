using System.Collections.Generic;

using Commander.Data;

using Commander.Models;

using Microsoft.AspNetCore.Mvc;



namespace Commander.Controllers
{

  [Route("api/alen")]
  [ApiController]
  public class CommandsAlenController : ControllerBase
  {
    private readonly ICommanderRepo _repository;

    // private readonly MockCommanderRepo _repository = new MockCommanderRepo();



    public CommandsAlenController(ICommanderRepo repository)
    {
      _repository = repository;
      // _mapper = mapper;
    }

    //GET api/alen
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommmands()
    {
      var commandItems = _repository.GetAllCommands();

      return Ok(commandItems);
    }

    //GET api/alen/{id}
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