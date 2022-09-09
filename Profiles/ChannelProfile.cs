using AutoMapper;
using Contact.Center.Api.Dtos;
using Contact.Center.Api.Models;

namespace Contact.Center.Api.Profiles
{
    public class ChannelProfile : Profile
    {
    public ChannelProfile()
    {
        // Source => Target
        CreateMap<Channel, ChannelDto>();
        CreateMap<CreateChannelDto, Channel>();
        CreateMap<UpdateChannelDto, Channel>();
    }
    }
}