using AutoMapper;
using CustomBlog.Api.Domain.Models;
using CustomBlog.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginUserViewModel>()
            .ReverseMap();

    }
}
