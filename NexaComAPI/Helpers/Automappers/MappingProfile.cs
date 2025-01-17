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
            CreateMap<Brand, BrandDTO>().ReverseMap(); 
            CreateMap<Category, CategoryDTO>().ReverseMap().ForMember(dest => dest.CategoryImage, opt => opt.MapFrom(src => src.CategoryImage)).ForMember(x=>x.CategoryIcon,y=>y.MapFrom(z=>z.CategoryIcon)).ForMember(a=>a.CategoryMetaImage,b=>b.MapFrom(c=>c.CategoryMetaImage));
            CreateMap<Product, ProductModel>().ReverseMap(); 
            CreateMap<Attachment, AttachmentDTO>().ReverseMap();
        }       
    }
}
