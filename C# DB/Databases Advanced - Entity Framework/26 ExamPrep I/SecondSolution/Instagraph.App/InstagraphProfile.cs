using AutoMapper;
using Instagraph.DataProcessor.Dto.Export;
using Instagraph.Models;

namespace Instagraph.App
{
    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<User, PopularUserDto>()
                .ForMember(u => u.Username, uu => uu.MapFrom(x => x.Username))
                .ForMember(f => f.Followers, ff => ff.MapFrom(x => x.Followers.Count));
        }
    }
}
