﻿using Microsoft.AspNetCore.Mvc;
using Auction_Marketplace.Services.Interface;
using Auction_Marketplace.Data.Models.Auction;

namespace Auction_Marketplace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionsService _auctionsService;

		public AuctionController(IAuctionsService auctionsService)
		{
            _auctionsService = auctionsService;
		}

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllAuctions()
        {
            try
            {
                var response = await _auctionsService.GetAllAuctions();
                return response.Succeed == true ? Ok(response.Data) : BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuctionById([FromRoute]int id)
        {
            try
            {
                var response = await _auctionsService.GetAuctionById(id);
                if (response == null)
                {
                    return NotFound();
                }

                return response.Succeed == true ? Ok(response.Data) : BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction(AuctionViewModel auction)
        {  
            try
            {
                var response = await _auctionsService.CreateAuction(auction);
                return response.Succeed == true ? Ok(response.Data) : BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuction([FromRoute]int id, AuctionViewModel updatedAuction)
        {
            try
            {
                var response = await _auctionsService.UpdateAuction(id, updatedAuction);
                return response.Succeed == true ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction([FromRoute]int id)
        {
            try
            {
                var response = await _auctionsService.DeleteAuction(id);
                return response.Succeed == true ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}
