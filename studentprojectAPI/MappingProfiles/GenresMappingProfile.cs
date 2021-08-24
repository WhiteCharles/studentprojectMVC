﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.MappingProfiles
{
    public class GenresMappingProfile : Profile
    {
        public GenresMappingProfile()
        {
            CreateMap<Models.Genre, DTOmodels.GenreDTO>();
            //CreateMap<DTOmodels.GenreForCreationDTO, Models.Genre>();
        }
    }
}
