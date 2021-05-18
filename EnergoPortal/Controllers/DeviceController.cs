using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository;
using Models;

namespace EnergoPortal.Controllers
{
    [Route("api/[controller]")]
    [Route("api/[controller]/{id?}")]
    public class DeviceController : Controller
    {
        IDeviceRepository _deviceRepository;
        public DeviceController(IDeviceRepository deviceRepository) => _deviceRepository = deviceRepository;
        [HttpGet]
        public async Task<NetworkDevices<Device>> GetDevices (int id)
        {
            return await _deviceRepository.GetDevices(id);
        }
    }
}
