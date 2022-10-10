
namespace Commander.Profiles
{
    public class CommandsProfile : AutoMapper.Profile
  {
        public CommandsProfile()
        {
            //Source -> Target
            // ovdije se mapiraju podaci
            CreateMap<Models.Command, Dtos.CommandReadDto>();
            CreateMap<Dtos.CommandCreateDto, Models.Command>();
            CreateMap<Dtos.CommandUpdateDto, Models.Command>();
            CreateMap<Models.Command, Dtos.CommandUpdateDto>();
        }

    }
    
}