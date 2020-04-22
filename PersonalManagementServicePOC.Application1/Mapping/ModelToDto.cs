using AutoMapper;
using PersonalManagementServicePOC.Application.Models;
using Repository.PersonalManagementServicePOC.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Application.Mapping
{
    public class ModelToDto : Profile
    {
        public ModelToDto()
        {
            CreateMap<Committee, CommitteeDto>().ReverseMap();
        }
    }
}
