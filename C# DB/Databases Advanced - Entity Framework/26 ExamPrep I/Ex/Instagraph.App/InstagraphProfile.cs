using AutoMapper;
using Instagraph.DataProcessor.DtoModels;
using Instagraph.Models;

namespace Instagraph.App
{
    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(u => u.ProfilePicture, pp => pp.UseValue<Picture>(null));

            CreateMap<Post, UncommentedPostsDto>()
                .ForMember(p => p.Picture, pp => pp.MapFrom(x => x.Picture.Path))
                .ForMember(u => u.User, uu => uu.MapFrom(x => x.User.Username));

            CreateMap<User, PopularUserDto>()
                .ForMember(u => u.Username, uu => uu.MapFrom(x => x.Username))
                .ForMember(f => f.Followers, ff => ff.MapFrom(x => x.Followers.Count));
        }
    }
}
