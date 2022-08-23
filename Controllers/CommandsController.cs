using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// MS SQL Login name: CommanderAPI
// password: 1234
namespace Commander.Controllers
{

  [Route("api/commands")]
  // [Route("api/[controller]")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    //
    //GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommmands()
    {
      var commandItems = _repository.GetAllCommands();
      return Ok(commandItems);
    }

    //GET api/commands/obicni
    [HttpGet("obicni")]
    public ActionResult<IEnumerable<Command>> GetAllCommmandsObicni()
    {
      var commandItems = _repository.GetAllCommandsObicni();
      return Ok(commandItems);
    }

    //
    //GET api/commands/{id}
    // Name mora biti isto kao i naziv funkcije!
    [HttpGet("{id}", Name = "GetCommandById")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if (commandItem != null)
      {
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
      }
      return NotFound("Nisam nista nasao!");
    }

    //
    //GET api/commands/obicni/{id}
    [HttpGet("obicni/{id}", Name = "GetCommandByIdObicni")]
    public ActionResult<CommandReadDto> GetCommandByIdObicni(int id)
    {
      var commandItem = _repository.GetCommandByIdObicni(id);
      if (commandItem != null)
      {
        return Ok(commandItem);
      }
      return NotFound("Nisam nista nasao!");
    }

    //
    //POST api/commands
    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto data)
    {
      var model = _mapper.Map<Command>(data);
      _repository.CreateCommand(model);
      _repository.SaveChanges();
      var dataReadDto = _mapper.Map<CommandReadDto>(model);
      return CreatedAtRoute(nameof(GetCommandById), new { Id = dataReadDto.Id }, dataReadDto);
    }

    //
    //PUT api/commands/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDto data)
    {
      var modelFromRepo = _repository.GetCommandById(id);
      if (modelFromRepo == null)
      {
        return NotFound("Nisam napravio update, nisam naso podatak!");
      }
      _mapper.Map(data, modelFromRepo);
      _repository.UpdateCommand(modelFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

    // //PATCH api/commands/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
      patchDoc.ApplyTo(commandToPatch, ModelState);
      if (!TryValidateModel(commandToPatch))
      {
        return ValidationProblem(ModelState);
      }
      _mapper.Map(commandToPatch, commandModelFromRepo);
      _repository.UpdateCommand(commandModelFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

    //
    //DELETE api/commands/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
      var data = _repository.GetCommandById(id);
      if (data == null)
      {
        return NotFound("Nema tog zapisa nisam mogao obrisati.");
      }
      _repository.DeleteCommand(data);
      _repository.SaveChanges();
      return NoContent();
    }

  }
}