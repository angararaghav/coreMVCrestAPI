
using Commander.Models;
using System.Collections.Generic;
using System.Linq;
namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }
        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == Id);
        }

        public void CreateCommand(Command objCommand)
        {
            if(objCommand == null)
                throw new System.ArgumentNullException(nameof(objCommand));
         
             _context.Commands.Add(objCommand);
            
        } 

        
        public void UpdateCommand(Command objCommand)
        {
            // if(objCommand == null)
            //     throw new System.ArgumentNullException(nameof(objCommand));
         
            //  _context.Commands.Add(objCommand);
            
        } 

        public void DeleteCommand(Command objCommand)
        {
            if(objCommand == null)
                throw new System.ArgumentNullException(nameof(objCommand));
         
             _context.Commands.Remove(objCommand);
            
        } 

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

    }
}