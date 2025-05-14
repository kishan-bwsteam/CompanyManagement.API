using AutoMapper;
using Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.Shared
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserBasic, AdminUser>();
            //CreateMap<UserAddress, AdminUser>()
            //     .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src)); 

        }
    }
}
