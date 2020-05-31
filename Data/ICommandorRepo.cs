using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{

    public interface ICommandRepo
    {
        IEnumerable<command> GetAppCommands();
    }
}