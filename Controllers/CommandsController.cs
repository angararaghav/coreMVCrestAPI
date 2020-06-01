using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Models;
using Commander.Data;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _reporsitory;
        public CommandsController(ICommanderRepo reporsitory)
        {
            _reporsitory = reporsitory;
        }

        //private readonly MockCommanderRepo _reporsitory = new MockCommanderRepo();
        //Get api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            
            var commandItems = _reporsitory.GetAllCommands();
            System.Console.WriteLine("Command" + commandItems);
            return Ok(commandItems);
            
        }

        //Get api/command/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _reporsitory.GetCommandById(id);
            if (commandItem != null)
                        return Ok(commandItem);
                        else
                        return NotFound();
        }
    }
}