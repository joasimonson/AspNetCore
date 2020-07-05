using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Data.Context;
using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dbSet;

        public UserRepository(MyContext context) : base(context)
        {
            this._dbSet = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string login)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email.Equals(login));
        }
    }
}