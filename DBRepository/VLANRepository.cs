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
    public interface IVLANRepository 
    {
        public Task<List<VLAN>> GetVLANs();
        public Task UpdateVLAN(VLAN vlan);
        public Task AddVLAN(VLAN vlan);
        public Task DeleteVLAN(int id);
    }
    public class VLANRepository : BaseRepository, IVLANRepository
    {
        public VLANRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        {
        }
        public async Task<List<VLAN>> GetVLANs()
        {
            var result = new List<VLAN>();
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                result = await context.VLANs.ToListAsync();
            }
            return result;
        }
        public async Task UpdateVLAN(VLAN vlan)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.VLANs.Update(vlan);
                await context.SaveChangesAsync();
            }
        }
        public async Task AddVLAN(VLAN vlan)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.VLANs.Add(vlan);
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteVLAN(int id)
        {
            VLAN vlan = new VLAN() { VLANId = id };
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.VLANs.Remove(vlan);
                await context.SaveChangesAsync();
            }
        }
    }
}
