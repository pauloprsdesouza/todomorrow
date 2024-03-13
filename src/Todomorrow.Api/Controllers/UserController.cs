using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Api.Authorization;
using Todomorrow.Contracts.Organizations;
using Todomorrow.Contracts.Users;
using Todomorrow.Domain.Users;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/users")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IOptions<JwtOptions> jwtOptions, IMapper mapper)
        {
            _userService = userService;
            _jwtOptions = jwtOptions;
            _mapper = mapper;
        }

        /// <summary>
        /// Signin
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("signin"), AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrganizationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            User user = _mapper.Map<User>(request);
            UserRole userRole = await _userService.SignIn(user, request.Token);

            if (userRole is null)
            {
                return Unauthorized();
            }

            ApiToken apiToken = new(_jwtOptions, userRole);

            UserResponse response = _mapper.Map<UserResponse>(userRole.User);
            response.Token = apiToken.ToString();

            return Ok(response);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("signup"), AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrganizationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            User user = _mapper.Map<User>(request);
            user = await _userService.SignUp(user);

            UserResponse response = _mapper.Map<UserResponse>(user);

            return Ok(response);
        }

        /// <summary>
        /// Follow a user
        /// </summary>
        /// <returns></returns>
        [HttpPatch, Route("follow/{userId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrganizationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Follow([FromRoute] Guid userId)
        {
            User response = await _userService.Follow(User.GetEmail(), userId);

            return Ok(response is not null ? _mapper.Map<UserResponse>(response) : null);
        }

        /// <summary>
        /// Unfollow a user
        /// </summary>
        /// <returns></returns>
        [HttpPatch, Route("unfollow/{userId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrganizationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Unfollow([FromRoute] Guid userId)
        {
            User response = await _userService.Unfollow(User.GetEmail(), userId);

            return Ok(response is not null ? _mapper.Map<UserResponse>(response) : null);
        }
    }
}
