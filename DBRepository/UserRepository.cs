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
    public interface IUserRepository 
    {
    }
    public class UserRepository:BaseRepository,IUserRepository
    {
        public UserRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        {
        }

    }
}
