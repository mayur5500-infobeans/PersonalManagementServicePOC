using AutoMapper;
using PersonalManagementServicePOC.Application.Models;
using PersonalManagementServicePOC.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Application.Mapping
{
    public class ModelToDomainModel : Profile
    {
        public ModelToDomainModel()
        {
            CreateMap<Committee, CommitteeModel>().ReverseMap();
        }
    }
}
