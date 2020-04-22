using AutoMapper;
using DomainModel = PersonalManagementServicePOC.Domain.DomainModels;
using Model = PersonalManagementServicePOC.Application.Models;

namespace PersonalManagementServicePOC.Application.Mapping
{
    public class ModelToDomainModelMapping : Profile
    {
        public ModelToDomainModelMapping()
        {
            CreateMap<Model.CommitteeModel, DomainModel.CommitteeModel>().ReverseMap();
        }
    }
}
