﻿using System.Threading.Tasks;
using BoardGameRentalApp.Core.Dto.BoardGames;
using BoardGameRentalApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameRentalApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        private readonly IBoardGamesService _service;

        public BoardGamesController(IBoardGamesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<GetAllBoardGamesOutput> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<BoardGameDto> Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        public async Task<BoardGameDto> Create([FromBody]
            CreateBoardGameInput boardGameInput)
        {
            return await _service.CreateAsync(boardGameInput);
        }

        [HttpPut]
        public async Task<BoardGameDto> Update([FromBody]
            BoardGameDto boardGameInput)
        {
            return await _service.UpdateAsync(boardGameInput);
        }
    }
}