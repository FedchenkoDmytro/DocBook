using DocBook.Core.Contracts;
using DocBook.Core.Models.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace DocBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAuthService authManager, ILogger<AccountController> logger)
        {
            _authManager = authManager;
            _logger = logger;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="apiUserDto">The user data.</param>
        /// <returns>The registration result.</returns>
        // POST: api/Account/register
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO apiUserDto)
        {
            _logger.LogDebug($"Registration Attempt for {apiUserDto.Email}");
            var errors = await _authManager.Register(apiUserDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok();
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        // POST: api/Account/login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDto)
        {
            _logger.LogDebug($"Login Attempt for {loginDto.Email} ");
            var authResponse = await _authManager.Login(loginDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);

        }

        /// <summary>
        /// Refreshes the access token using a refresh token.
        /// </summary>
        /// <param name="request">The refresh token request.</param>
        /// <returns>The refreshed access token.</returns>
        // POST: api/Account/refreshtoken
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDTO request)
        {
            var authResponse = await _authManager.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }
    }
}
