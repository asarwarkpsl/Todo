using API.DTO;
using AutoMapper;
using Core.Model;
using Task = Core.Model.Task;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<List, ListToReturn>();
            CreateMap<Task, TaskToReturn>()
                .ForMember(d=>d.FileURL,o=>o.MapFrom<FileUrlResolver>());
        }
    }
}
