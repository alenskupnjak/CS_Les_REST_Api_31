
using AutoMapper;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
  {
        public CommandsProfile()
        {
            // Source -> Target
            // ovdje se mapiraju podaci
            CreateMap<Models.Command, Dtos.CommandReadDto>();
            CreateMap<Dtos.CommandCreateDto, Models.Command>();
            CreateMap<Dtos.CommandUpdateDto, Models.Command>();
            CreateMap<Models.Command, Dtos.CommandUpdateDto>();
        }

    }
    
}