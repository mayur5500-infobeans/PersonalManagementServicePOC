using PersonalManagementServicePOC.Domain.DomainModels;
using PersonalManagementServicePOC.Domain.Services.Interfaces;
using Repository.PersonalManagementServicePOC.DTOs;
using Repository.PersonalManagementServicePOC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Domain.Services.Implementations
{
    public class CommitteeService : ICommitteeService
    {
        private readonly ICommitteeRepository _committeeRepository;

        public CommitteeService(ICommitteeRepository committeeRepository)
        {
            _committeeRepository = committeeRepository;
        }

        public Guid Create(CommitteeDto model)
        {
            model.Id = new Guid();
            _committeeRepository.Create(model);
            return model.Id;
        }

        public CommitteeModel GetCommittee(Guid id)
        {
            var result = _committeeRepository.GetCommittee(id);            
            var model = new CommitteeModel() { Id = result.Id, Name = result.Name };
            return model;
        }
    }
}
