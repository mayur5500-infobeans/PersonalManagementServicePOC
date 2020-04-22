using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Moq;
using PersonalManagementServicePOC.Domain.Services.Interfaces;
using Repository.PersonalManagementServicePOC.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using PersonalManagementServicePOC.Application.Controllers;
using NUnit.Framework;
using Repository.PersonalManagementServicePOC.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PersonalManagementServicePOC.Application.Tests.Controllers
{
    public class CommitteeControllerTests
    {
        private readonly Mock<ICommitteeService> _committeeService;
        private readonly Mock<ICommitteeRepository> _committeeRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IConfiguration> _configuration;
        CommitteeController _committeeController;

        public CommitteeControllerTests()
        {
            _committeeService = new Mock<ICommitteeService>();
            _committeeRepository = new Mock<ICommitteeRepository>();
            _committeeController = new CommitteeController(_committeeService.Object, _committeeRepository.Object, null, null);
                //_mapper.Object, _configuration.Object);
        }

        [Test]
        public void Get_Success()
        {
            var id = Guid.NewGuid();
            var dto = new CommitteeDto() { Id = id, Name = "Test" };

            _committeeRepository.Setup(m => m.GetCommittee(id)).Returns(dto);
            var output = _committeeController.Get(id);

            //Assert
            Assert.AreEqual(dto.Id, ((CommitteeDto)((ObjectResult)output).Value).Id);
        }
    }
}
