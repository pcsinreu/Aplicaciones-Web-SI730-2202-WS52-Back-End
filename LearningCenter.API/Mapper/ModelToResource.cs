using AutoMapper;
using LearningCenter.API.Resources;
using LearningCenter.Infraestructure;

namespace LearningCenter.API.Mapper;

public class ModelToResource : Profile
{
    public ModelToResource()
    {
        CreateMap<Category, CategoryResource>();
        CreateMap<User, UserResource>();
    }
}