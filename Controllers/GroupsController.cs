using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Models;
using LimousineApi.Services.GroupsServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LimousineApi.Controllers
{
    [Route("group")]
    public class GroupsController : ControllerBase
    {


        private readonly IGroupsServices _repository;
        private IMapper _mapper;
        public GroupsController(IGroupsServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("add-group")]
        public async Task<ActionResult> AddGroup([FromForm] Group Group)
        {
            if (Group == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(Group);

            return Ok(Group);
        }


        [HttpGet]
        [Route("get-groups")]
        public async Task<ActionResult> GetGroups()
        {

            return Ok(await _repository.GetItems("UserId"));
        }

        [HttpGet]
        [Route("get-group-by-id")]
        public async Task<ActionResult> GetGroupById([FromQuery] int groupId)
        {

            return Ok(await _repository.GitById(groupId));
        }


        [HttpPost]
        [Route("accept-group")]
        public async Task<ActionResult> AcceptGroup([FromForm] int driverId, [FromForm] int status, [FromForm] int groupId)
        {

            return Ok(await _repository.AcceptGroup(driverId, status, groupId));
        }


        [HttpGet]
        [Route("get-group-Details")]
        public async Task<ActionResult> GetGroupDetails([FromQuery] int groupId)
        {

            return Ok(await _repository.GetGroupDetails(groupId));
        }
    }
}