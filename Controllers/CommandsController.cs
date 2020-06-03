using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Models;
using Commander.Data;
using Commander.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;


namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _reporsitory;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo reporsitory, IMapper mapper)
        {
            _reporsitory = reporsitory;
            _mapper = mapper;
        }

        //private readonly MockCommanderRepo _reporsitory = new MockCommanderRepo();
        //Get api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            
            var commandItems = _reporsitory.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>> (commandItems));
            
        }

        //Get api/command/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _reporsitory.GetCommandById(id);
            if (commandItem != null)
                        return Ok(_mapper.Map<CommandReadDto>(commandItem));
                        else
                        return NotFound();
        }

        //Post api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto objCommandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(objCommandCreateDto);
            _reporsitory.CreateCommand(commandModel);
            _reporsitory.SaveChanges();

            var objcommandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new{id = objcommandReadDto.Id}, objcommandReadDto);
            //return Ok(objcommandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult <CommandReadDto> UpdateCommand(int id, CommandUpdateDto objCommandUpdateDto)
        {
            var objCommandItem = _reporsitory.GetCommandById(id);
            if(objCommandItem == null)  
            {
                return NotFound();
            }
            _mapper.Map(objCommandUpdateDto, objCommandItem);
            _reporsitory.UpdateCommand(objCommandItem);
            _reporsitory.SaveChanges();

            return NoContent(); 
        } 
        
       
       
         //[ {
         //      "op": "Replace",
         //      "path": "/platform",
         //      "value": "Pluralsite"
         //   }]
         //Patch api/commands/{id}
       [HttpPatch("{id}")]
       public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
       {
             var objCommandItem = _reporsitory.GetCommandById(id);
            if(objCommandItem == null)  
            {
                return NotFound();
            }

            var commadToPatch = _mapper.Map<CommandUpdateDto>(objCommandItem);
            patchDoc.ApplyTo(commadToPatch, ModelState);
            if(!TryValidateModel(commadToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
            _mapper.Map(commadToPatch, objCommandItem);
            _reporsitory.UpdateCommand(objCommandItem);
            _reporsitory.SaveChanges();
            return NoContent();
       }

        //Delete api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
       {
            var objCommandItem = _reporsitory.GetCommandById(id);
            if(objCommandItem == null)  
            {
                return NotFound();
            }
            _reporsitory.DeleteCommand(objCommandItem);
            _reporsitory.SaveChanges();
            return NoContent();
       }

    }
}