using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
     public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                 new Command{Id=1, HowTo="Boil an Egg", Line="Boil water", Platform="Kettle & Pan"},
                 new Command{Id=2, HowTo="Cut bread", Line="Get a knife", Platform="Knife and Chopping board"},
                 new Command{Id=4, HowTo="Make cup of Tea", Line="Boil water place a teabag", Platform="Kettle & Cup"}
            };

            return commands;
        }

        public  Command GetCommandById(int Id)
        {
             return new Command{Id=1, HowTo="Boil an Egg", Line="Boil water", Platform="Kettle & Pan"};
        }

        public void CreateCommand(Command objCommand)
        {
            throw new System.NotImplementedException();
        }
        public void UpdateCommand(Command objCommand)
        {
            throw new System.NotImplementedException();
        }
        public bool SaveChanges()
        {
            return true;
        }
    }
}