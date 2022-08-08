using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using MeetupManager.Application.Meetups.Commands.CreateMeetup;
using MeetupManager.Application.Meetups.Commands.DeleteMeetup;
using MeetupManager.Application.Meetups.Commands.UpdateMeetup;
using MeetupManager.Application.Meetups.Queries.GetMeetupDetails;
using MeetupManager.Application.Meetups.Queries.GetMeetupList;
using MeetupManager.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MeetupManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MeetupController : BaseController
    {
        private readonly IMapper _mapper;

        public MeetupController(IMapper mapper) 
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Get the list of meetups
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /meetup
        /// </remarks>
        /// <returns>Returns MeetupListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">UnAuth User</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MeetupListVm>> GetAll()
        {
            var query = new GetMeetupListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets meetup by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /meetup/D3930CC5-0A6B-47C9-BBFB-804D2E5C82A9
        /// </remarks>
        /// <param name="id">Meetup id (guid)</param>
        /// <returns>Returns MeetupDetailVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">UnAuth User</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MeetupDetailVm>> Get(Guid id)
        {
            var query = new GetMeetupDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the meetup
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /meetup
        /// {
        ///     "title": "string",
        ///     "description": "string",
        ///     "organizer": "string",
        ///     "startDate": "2022-08-08T12:55:58.795Z",
        ///     "place": "string"
        /// }
        /// </remarks>
        /// <param name="createMeetupDto">CreateMeetupDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">UnAuth User</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMeetupDto createMeetupDto)
        {
            var command = _mapper.Map<CreateMeetupCommand>(createMeetupDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        /// <summary>
        /// Updates the meetup
        /// </summary>
        /// <param name="updateMeetupDto">UpdateMeetupDto object</param>
        /// <returns>Return NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">UnAuth User</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateMeetupDto updateMeetupDto)
        {
            var command = _mapper.Map<UpdateMeetupCommand>(updateMeetupDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the meetup
        /// </summary>
        /// <param name="id">Id of the meetup</param>
        /// <returns>Returns NoContent</returns>
        ///
        /// <response code="401">UnAuth User</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMeetupCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
