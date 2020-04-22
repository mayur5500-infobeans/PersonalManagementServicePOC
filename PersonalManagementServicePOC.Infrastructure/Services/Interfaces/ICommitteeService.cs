using Repository.PersonalManagementServicePOC.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Infrastructure.Services.Interfaces
{
    public interface ICommitteeService
    {
        CommitteeDto GetCommittee(Guid id);
    }
}
