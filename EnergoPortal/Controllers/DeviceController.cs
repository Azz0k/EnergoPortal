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
    public class DeviceController : Controller
    {
        IDeviceRepository _deviceRepository;
        public DeviceController(IDeviceRepository deviceRepository) => _deviceRepository = deviceRepository;
        //[Authorize]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "1")]
        [HttpGet]
        public async Task<NetworkDevices<Device>> GetDevices (int id)
        {
            return await _deviceRepository.GetDevices(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "2")]
        [HttpPut]
        public async Task UpdateDevice ([FromBody] Device device)
        {
            await _deviceRepository.UpdateDevice(device);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "4")]
        [HttpPost]
        public async Task AddDevice([FromBody] Device device)
        {
            await _deviceRepository.AddDevice(device);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5")]
        [HttpDelete]
        public async Task DeleteDevice(int id)
        {
            await _deviceRepository.DeleteDevice(id);
        }

    }
}
