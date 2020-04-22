using PersonalManagementServicePOC.Infrastructure.Services.Interfaces;
using Repository.PersonalManagementServicePOC.DTOs;
using Repository.PersonalManagementServicePOC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Infrastructure.Services.Implementations
{
    public class CommitteeService : ICommitteeService
    {
        private readonly ICommitteeRepository _committeeRepository;

        public CommitteeService(ICommitteeRepository committeeRepository)
        {
            _committeeRepository = committeeRepository;
        }
        public CommitteeDto GetCommittee(Guid id)
        {
            return _committeeRepository.GetCommittee(id);
        }
    }
}
