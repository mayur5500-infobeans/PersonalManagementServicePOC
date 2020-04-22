using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PersonalManagementServicePOC.Application.Models;
using PersonalManagementServicePOC.Domain.Services.Interfaces;
using Repository.PersonalManagementServicePOC.DTOs;
using Repository.PersonalManagementServicePOC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Application.Controllers
{
    [Route("api/committee")]
    [ApiController]
    public class CommitteeController : ControllerBase
    {
        private readonly ICommitteeService _committeeService;
        private readonly ICommitteeRepository _committeeRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CommitteeController(ICommitteeService committeeService, ICommitteeRepository committeeRepository, 
            IMapper mapper, IConfiguration configuration) 
        {
            _committeeService = committeeService;
            _committeeRepository = committeeRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        // GET: api/Committee
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Committee/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            //var value = _configuration.GetSection("ConnectionStrings").Value;
            var model = _committeeRepository.GetCommittee(id);
            return Ok(model);
        }

        // POST: api/Committee
        [HttpPost]
        public IActionResult Post([FromBody] Committee model)
        {
            var dto = _mapper.Map<CommitteeDto>(model);
            _committeeService.Create(dto);
            return Ok();
        }

        // PUT: api/Committee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
