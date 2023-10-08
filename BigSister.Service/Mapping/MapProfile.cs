using AutoMapper;
using BigSister.Core.DTOs;
using BigSister.Core.Models;

namespace BigSister.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ConstantValue, ConstantValueDto>().ReverseMap();
            CreateMap<PageImage, PageImageDto>().ReverseMap();
            CreateMap<WorkItem, WorkItemDto>().ReverseMap();
        }
    }
}
