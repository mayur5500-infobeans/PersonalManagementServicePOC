using NUnit.Framework;
using Moq;
using Repository.PersonalManagementServicePOC.Repositories.Interfaces;
using PersonalManagementServicePOC.Domain.Services.Implementations;
using PersonalManagementServicePOC.Domain.Services.Interfaces;
using System;
using PersonalManagementServicePOC.Domain.DomainModels;
using Repository.PersonalManagementServicePOC.DTOs;

namespace Tests
{
    public class CommitteeServiceTest
    {
        private readonly Mock<ICommitteeRepository> _committeeRepository;
        private CommitteeService _committeeService;

        public CommitteeServiceTest()
        {
            _committeeRepository = new Mock<ICommitteeRepository>();
            _committeeService = new CommitteeService(_committeeRepository.Object);
        }

        [Test]
        public void GetCommittee_Success()
        {
            var id = new Guid();

            var result = new CommitteeModel() { Id = id, Name = "Test" };
            var dto = new CommitteeDto() { Id = id, Name = "Test"};

            _committeeRepository.Setup(m => m.GetCommittee(id)).Returns(dto);

            var model = _committeeService.GetCommittee(id);

            _committeeRepository.Verify(m => m.GetCommittee(id), Times.Once);

            Assert.AreEqual(result.Id, model.Id);           
        }
    }
}