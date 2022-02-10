using AutoMapper;
using BaseApi.Common.DTO.Request;
using BaseApi.Common.DTO.Response;
using BaseApi.Core.Entities;

namespace BaseApi.Services.Utils
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
