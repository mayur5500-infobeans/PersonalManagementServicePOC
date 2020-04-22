using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalManagementServicePOC.Application.Results;
using PersonalManagementServicePOC.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using DomainModel = PersonalManagementServicePOC.Domain.DomainModels;
using Model = PersonalManagementServicePOC.Application.Models;

namespace PersonalManagementServicePOC.Application.Controllers
{
    [Route("api/committee")]
    [ApiController]
    public class CommitteeController : ControllerBase
    {
        private readonly ICommitteeService _committeeService;
        //private readonly IMapper _mapper;

        public CommitteeController(ICommitteeService committeeService) //, IMapper mapper)
        {
            _committeeService = committeeService;
            //_mapper = mapper;
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
            var test = new Model.CommitteeModel() { Id = id, Name = "Test" };            
            //var mapping = _mapper.Map<DomainModel.CommitteeModel>(test);    
            
            var model =_committeeService.GetCommittee(id);
            //var result = _mapper.Map<CommitteeResult>(model);
            return Ok(model);
        }

        // POST: api/Committee
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
