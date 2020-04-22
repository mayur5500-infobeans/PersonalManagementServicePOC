using Repository.PersonalManagementServicePOC.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.PersonalManagementServicePOC.Repositories.Interfaces
{
    public interface ICommitteeRepository : IDisposable
    {
        CommitteeDto GetCommittee(Guid id);

        void Create(CommitteeDto model);
    }
}
