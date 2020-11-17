using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointsAPI.Domain.Models;
using PointsAPI.Domain.Services;

namespace PointsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPointsService _pointService;
        private readonly IMapper _mapper;

        public PointsController(IUserService userService, IPointsService pointService, IMapper mapper)
        {
            _userService = userService;
            _pointService = pointService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PointResource), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPoints(int id)
        {
            var user = await _userService.GetAsync(id);

            if (user == null)
                return NotFound();

            var points = await _pointService.GetPoints(id);
            var resource = _mapper.Map<IEnumerable<Point>, IEnumerable<UserBalanceResource>>(points);

            return Ok(resource);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddPointsToUser(int id, [FromBody] Point point)
        {
            if (string.IsNullOrEmpty(point.PayerName))
                return BadRequest();

            var user = await _userService.GetAsync(id);

            if (user == null)
                return NotFound();

            await _pointService.AddPointsToUser(id, point);

            return CreatedAtAction(nameof(GetPoints), new { id = user.Id }, user);
        }

        [HttpPut("{id}/deduct/{amount}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeductPointsFromUser(int id, int amount)
        {
            if (amount < 0)
                return BadRequest();

            var user = await _userService.GetAsync(id);

            if (user == null)
                return NotFound();

            if (user.Points.Sum(s => s.Amount) < amount)
                return BadRequest();

            var newPoints = await _pointService.DeductPointsFromUser(id, amount);
            var resource = _mapper.Map<IEnumerable<Point>, IEnumerable<PointResource>>(newPoints);

            return Ok(resource);
        }
    }
}