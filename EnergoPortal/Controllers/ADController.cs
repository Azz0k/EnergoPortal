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
using Microsoft.AspNetCore.Authentication.Negotiate;
using System.DirectoryServices;
using System.Runtime.Versioning;

namespace EnergoPortal.Controllers
{
    public class ADUser
    {
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    [Route("api/[controller]")]
    public class ADController:Controller
    {

        [HttpGet]
        [Authorize]
        [Route("search")]
        [SupportedOSPlatform("windows")]
        public async Task<IActionResult> GetADUsers(string SearchString)
        {
            List<ADUser> list = new List<ADUser>();
            await Task.Run(() => {
                var accountName = HttpContext.User.Identity.Name;
                using (var entry = new DirectoryEntry($"LDAP://energo.local"))
                {
                    using (var searcher = new DirectorySearcher(entry))
                    {

                        var searchString = SearchString == null | SearchString == "" ? " " : SearchString;
                        searcher.Filter = $"(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(|(samaccountname=*{searchString}*)(displayname=*{searchString}*)))";
                        searcher.PropertiesToLoad.Add("samaccountname");
                        searcher.PropertiesToLoad.Add("mail");
                        searcher.PropertiesToLoad.Add("usergroup");
                        searcher.PropertiesToLoad.Add("displayname");
                        searcher.PropertiesToLoad.Add("telephoneNumber");
                        searcher.PropertiesToLoad.Add("canonicalName");
                        searcher.PropertiesToLoad.Add("whencreated");
                        searcher.PropertiesToLoad.Add("department");
                        searcher.Asynchronous = true;
                        var searchResult = searcher.FindAll();
                        if (searchResult != null)
                        {
                            if (searchResult.Count>0)
                            {
                                foreach (SearchResult element in searchResult)
                                {
                                    list.Add(new ADUser()
                                    {
                                        DisplayName = element.Properties.Contains("displayName") ? element.Properties["displayName"][0].ToString() : "",
                                        Email = element.Properties.Contains("mail") ? element.Properties["mail"][0].ToString() : "",
                                        PhoneNumber = element.Properties.Contains("telephoneNumber") ? element.Properties["telephoneNumber"][0].ToString() : ""
                                    });
                                }
                            }
                            
                        }
                    }
                }
            });
            return Ok(list);
        }
    }
}
