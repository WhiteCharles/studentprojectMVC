using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.MappingProfiles
{
    public class RecordsMappingProfiles : Profile
    {
        public RecordsMappingProfiles()
        {
            CreateMap<Models.Record, DTOmodels.RecordDTO>();
        }
    }
}
