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
		//IIdentityService _service;
		IIdentityRepository _service;

		public IdentityController(IIdentityRepository service)
		{
			_service = service;
		}

		[Route("token")]
		[HttpGet]
		[Authorize]
		//public async Task<IActionResult> Token([FromBody] IdentityViewModel model)
		public async Task<IActionResult> Token()
		{
			//var identity = await GetIdentity(model.Username, model.Password);
			var identity = await GetIdentity(HttpContext.User.Identity.Name, "");
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
				access_token = encodedJwt,
				username = identity.Name
			};

			return Ok(response);
		}
		/*
		[Route("rights")]
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Rights()
        {
			
			string[] roles = new string[] { "1", "2", "3", "4", "5" };
			var UserName = HttpContext.User.Identity.Name;
			var user = await _service.GetUser(UserName);
			if (user!= null)
            {
				var AssignedRoles = roles.Select((element, index) => new { element, index }).Where(x => x.index < user.UserAccessLevel).Select(x => x.element).ToArray();
				GenericPrincipal principal = new GenericPrincipal(HttpContext.User.Identity, AssignedRoles);

				var response = new
				{
					UserAccessLevel = user.UserAccessLevel
				};
			return Ok(response);
			}
			else
            {
				return Unauthorized();

			}
        }
		*/

		private async Task<ClaimsIdentity> GetIdentity(string userName, string password)
		{
			string[] roles = new string[] { "1", "2", "3", "4", "5" };
			ClaimsIdentity identity = null;
			var user = await _service.GetUser(userName);
			if (user != null)
			{
				var sha256 = new SHA256Managed();
				var passwordHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
				if (true)//(passwordHash == user.Password)
				{
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
				}
			}
			return identity;
		}
	}
}
