using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;
using DBRepository.Interfaces;

namespace DBRepository
{
    public class NetworkDevices<T>
    {
        public List<T> Records { get; set; }
        public int TotalDevices { get; set; }
        public int CurrentDeviceId { get; set; }
    }
    public interface IDeviceRepository
    {
        public Task<NetworkDevices<Device>> GetDevices(int id = 0);
    }
    public class DeviceRepository : BaseRepository, IDeviceRepository
    { 
        public DeviceRepository(string connectionString, IRepositoryContextFactory contextFactory):base(connectionString, contextFactory)
        {
        }
        public async Task <NetworkDevices<Device>> GetDevices(int id = 0)
        {
            var result = new NetworkDevices<Device>() { CurrentDeviceId = id };
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Devices.AsQueryable();
                if (id > 0)
                {
                    query = query.Where(d => d.DeviceId == id);
                }
                else 
                {
                    query = query.Select(d => new Device { DeviceId = d.DeviceId, Color = d.Color, PosX=d.PosX, PosY=d.PosY, LevelId=d.LevelId, IsEnabled=d.IsEnabled, IsInUse=d.IsInUse });
                }
                result.TotalDevices = await query.CountAsync();
                result.Records = await query.ToListAsync();
            }
            return result;
            
        }
    }
}
