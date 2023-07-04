using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LimousineApi.Models;

using LimousineApi.Services.WalletsServices;

namespace LimousineApi.Controllers
{
    [Route("wallet")]
    public class WalletsController : Controller
    {

        private readonly IWalletsServices _repository;
        private IMapper _mapper;

        public WalletsController(IWalletsServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add-wallet")]
        public async Task<ActionResult> AddWallet([FromForm] Wallet wallet)
        {

            return Ok(await _repository.AddWallet(wallet));

        }


        [HttpGet]
        [Route("get-wallets-by-userId")]
        public async Task<ActionResult> GetWalletsTrip([FromForm] string userId)
        {

            return Ok(await _repository.GetWalletByDriverId(userId));
        }


       
    }
}