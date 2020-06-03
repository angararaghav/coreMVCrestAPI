using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{

    public interface ICommanderRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int Id);
        void CreateCommand(Command objCommand);
        void UpdateCommand(Command objCommand);
    }
}