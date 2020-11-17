using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointsAPI.Domain.Models;
using PointsAPI.Domain.Repositories;
using PointsAPI.Domain.Services;
using PointsAPI.Resources;

namespace PointsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserResource), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await _userService.GetAsync(id);

            if (user == null)
                return NotFound();

            var resource = _mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            var userExists = await _userService.UserExists(user.Id);
            if (!userExists)
            {
                await _userService.CreateUser(user);
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            else
            {
                return UnprocessableEntity();
            }
        }
    }
}