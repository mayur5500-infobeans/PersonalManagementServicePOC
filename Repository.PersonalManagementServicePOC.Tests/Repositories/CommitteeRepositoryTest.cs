using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using Repository.PersonalManagementServicePOC.Context.Implementation;
using Repository.PersonalManagementServicePOC.DTOs;
using Repository.PersonalManagementServicePOC.Repositories.Implementations;

namespace Repository.PersonalManagementServicePOC.Tests.Repositories
{
    public class CommitteeRepositoryTest
    {
        private readonly CommitteeRepository _committeeRepository;
        private readonly CommitteeContext _committeeContext;

        public CommitteeRepositoryTest()
        {
            _committeeContext = new InMemoryDBContextFactory().GetCommitteeContext();
            _committeeRepository = new CommitteeRepository(_committeeContext);
        }


        [Test]
        public void GetCommittee_Success()
        {
            var id = Guid.NewGuid();
            var expected = new CommitteeDto() {Id = id,Name ="Test" };
            _committeeContext.Committees.Add(expected);
            _committeeContext.SaveChanges();

            var actual = _committeeRepository.GetCommittee(id);
            
            Assert.AreEqual(expected.Id, actual.Id);
        }
    }
}
