using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Models;
using LimousineApi.Services.NotificationsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LimousineApi.Controllers
{
    [Route("notification")]
    public class NotificationsController : Controller
    {
           private readonly INotificationsService _repository;
        private IMapper _mapper;

        public NotificationsController(INotificationsService repository, IMapper mapper)
        {
             _repository = repository;
            _mapper = mapper;
        }

      
        [HttpPost]
        [Route("add-notiy")]
        public async Task<ActionResult> AddNotification([FromForm] Notification notification)
        {
            if (notification == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(notification);

            

            return Ok(notification);
        }

         [HttpGet]
        [Route("get-notifications")]
        public async Task<ActionResult> GetNotifications([FromQuery] string UserId)
        {

            return Ok(await _repository.GetItems(UserId));
        }


    }
}