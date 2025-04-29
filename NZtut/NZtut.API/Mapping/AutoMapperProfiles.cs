using AutoMapper;
using NZtut.API.Models.Domain;
using NZtut.API.Models.DTO;

namespace NZtut.API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Regions
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();

            //Walks
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();

            //Difficulty
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();

        }
    }
}
