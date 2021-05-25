
using Microsoft.EntityFrameworkCore;
using Models;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using System.Linq;


namespace DBRepository
{
	public interface IIdentityRepository
    {
		public  Task<User> GetUser(string userName);

	}
	public class IdentityRepository : BaseRepository, IIdentityRepository
	{
		public IdentityRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

		public async Task<User> GetUser(string userName)
		{
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				return await context.Users.FirstOrDefaultAsync(u => u.LoginName.ToLower() == userName.ToLower());
				
			}
		}
	}
}