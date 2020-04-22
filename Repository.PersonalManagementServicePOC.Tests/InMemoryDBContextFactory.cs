using Microsoft.EntityFrameworkCore;
using Repository.PersonalManagementServicePOC.Context.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.PersonalManagementServicePOC.Tests
{
    public class InMemoryDBContextFactory
    {
        public CommitteeContext GetCommitteeContext()
        {
            var options = new DbContextOptionsBuilder<CommitteeContext>()            
                        .UseInMemoryDatabase(databaseName: "InMemoryDatabase")                            
                            .Options;
            var dbContext = new CommitteeContext(options);

            return dbContext;
        }
    }
}
