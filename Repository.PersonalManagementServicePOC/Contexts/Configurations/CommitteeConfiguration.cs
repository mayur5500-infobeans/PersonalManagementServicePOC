using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.PersonalManagementServicePOC.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.Entity.ModelConfiguration;

namespace Repository.PersonalManagementServicePOC.Contexts.Configurations
{
    public class CommitteeConfiguration //: EntityTypeConfiguration<CommitteeDto>
    {
        public void Configure(EntityTypeBuilder<CommitteeDto> builder)
        {
            throw new NotImplementedException();
        }
    }
}
