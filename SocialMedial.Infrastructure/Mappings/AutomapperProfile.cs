using AutoMapper;
using SocialMedia.Core.DOTs;
using SocialMedial.Core.Etities;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>(); //las propiedades deben tener el mismo nombre
            CreateMap<PostDto, Post>();
        }
    }
}
