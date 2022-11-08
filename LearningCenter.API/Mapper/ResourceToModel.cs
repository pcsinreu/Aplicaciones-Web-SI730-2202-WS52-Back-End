using AutoMapper;
using LearningCenter.API.Resources;
using LearningCenter.Infraestructure;

namespace LearningCenter.API.Mapper;

public class ResourceToModel : Profile
{
    public ResourceToModel()
    {
        CreateMap<CategoryResource, Category>();
        CreateMap<UserResource, User>();
    }
}