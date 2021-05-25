using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using Models;
using TestWebApp.Helpers;
using DBRepository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace TestWebApp.Controllers
{
	
	public class IdentityViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

	[Route("api/[controller]")]
	public class IdentityController : Controller
	{
		IIdentityRepository _service;

		public IdentityController(IIdentityRepository service)
		{
			_service = service;
		}

		[Route("token")]
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Token()
		{
			var identity = await GetIdentity(HttpContext.User.Identity.Name);
			if (identity == null)
			{
				return Unauthorized();
			}

			var now = DateTime.UtcNow;
			// создаем JWT-токен
			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					notBefore: now,
					claims: identity.Claims,
					expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

			var response = new
			{
				accessToken = encodedJwt,
				userName = identity.Name,
				role = Int32.Parse(identity.Label),
			};

			return Ok(response);
		}
		//windows authentification
		private async Task<ClaimsIdentity> GetIdentity(string userName)
		{
			ClaimsIdentity identity = null;
			var user = await _service.GetUser(userName);
			if (user != null)
			{
				string[] roles = new string[] { "1", "2", "3", "4", "5" };
				var AssignedRoles = roles.Select((element, index) => new { element, index }).Where(x => x.index < user.UserAccessLevel).Select(x => x.element).ToArray();
				var claims = new List<Claim>
				{
					new Claim(ClaimsIdentity.DefaultNameClaimType, user.LoginName),
				};
				foreach (var i in AssignedRoles)
                {
					claims.Add(new Claim(ClaimTypes.Role, i));
				}
				identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
				identity.Label = user.UserAccessLevel.ToString();
			}
			return identity;
		}
	}
}
