using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository;
using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EnergoPortal.ViewModels;

namespace EnergoPortal.Controllers
{
    [Route("api/[controller]")]
    [Route("api/[controller]/{id?}")]
    public class VLANController : Controller
    {
        IVLANRepository _vlanRepository;
        public VLANController(IVLANRepository vlanRepository) => _vlanRepository = vlanRepository;
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "1")]
        [HttpGet]
        public async Task<List<VLAN>> GetVLANs()
        {
            return await _vlanRepository.GetVLANs();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "2")]
        [HttpPut]
        public async Task UpdateVLAN([FromBody] VLAN vlan)
        {
            await _vlanRepository.UpdateVLAN(vlan);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "4")]
        [HttpPost]
        public async Task AddVLAN([FromBody] VLAN vlan)
        {
            await _vlanRepository.AddVLAN(vlan);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5")]
        [HttpDelete]
        public async Task DeleteVLAN(int id)
        {
            await _vlanRepository.DeleteVLAN(id);
        }

    }
}
