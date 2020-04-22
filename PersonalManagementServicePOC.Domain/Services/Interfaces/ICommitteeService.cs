using PersonalManagementServicePOC.Domain.DomainModels;
using Repository.PersonalManagementServicePOC.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Domain.Services.Interfaces
{
    public interface ICommitteeService
    {
        CommitteeModel GetCommittee(Guid id);

        Guid Create(CommitteeDto model);
    }
}
