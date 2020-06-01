using AutoMapper;
using Commander.Models;
using Commander.Dtos;
namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command,CommandReadDto> ();
        }

    }
}