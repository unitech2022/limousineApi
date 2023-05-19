
using AutoMapper;
using LimousineApi.Models;
using LimousineApi.Services.GroupLocationsServices;
using LimousineApi.Services.GroupsServices;
using Microsoft.AspNetCore.Mvc;


namespace LimousineApi.Controllers
{
    [Route("group")]
    public class GroupsLocationsController : ControllerBase
    {


        private readonly IGroupsLocationServices _repository;
        private IMapper _mapper;
        public GroupsLocationsController(IGroupsLocationServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("add-group-location")]
        public async Task<ActionResult> AddGroupLocation([FromForm] GroupLocation group)
        {
            if (group == null)
            {
                return NotFound();
            }

            await _repository.AddGroupLocation(group);

            return Ok(group);
        }


        [HttpGet]
        [Route("get-groups-locations")]
        public async Task<ActionResult> GetGroupsLocations()
        {

            return Ok(await _repository.GetItems("UserId"));
        }


        [HttpGet]
        [Route("get-groups-locations-by-userId")]
        public async Task<ActionResult> GetGroupsLocationsByUserId([FromQuery] string userId)
        {

            return Ok(await _repository.GetGroupLocationsByUserId(userId));
        }


        [HttpGet]
        [Route("get-groups-locations-by-driverId")]
        public async Task<ActionResult> GetGroupsLocationsByDriverId([FromQuery] int driverId)
        {

            return Ok(await _repository.GetGroupLocationsByDriverId(driverId));
        }

        [HttpGet]
        [Route("get-group-by-id")]
        public async Task<ActionResult> GetGroupLocationById([FromQuery] int groupId)
        {

            return Ok(await _repository.GitById(groupId));
        }

    }
}