using AutoMapper;
using PersonalManagementServicePOC.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel = PersonalManagementServicePOC.Domain.DomainModels;

namespace PersonalManagementServicePOC.Application.Mapping
{
    public class DomainModelToModelResultMapping : Profile
    {
        public DomainModelToModelResultMapping()
        {
            CreateMap<DomainModel.CommitteeModel, CommitteeResult>();
        }
    }
}
