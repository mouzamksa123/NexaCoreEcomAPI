using App.CommonLayer.DTOModels;
using App.DataAccessLayer.Entities;
using AutoMapper;

namespace NexaComAPI.Helpers.Automappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserRegistrationModel>().ReverseMap(); 
            CreateMap<Role, RoleModel>().ReverseMap(); 
            CreateMap<Brand, BrandModel>().ReverseMap(); 
            CreateMap<Category, CateogryModel>().ReverseMap(); 
            CreateMap<Product, ProductModel>().ReverseMap(); 
        }       
    }
}
