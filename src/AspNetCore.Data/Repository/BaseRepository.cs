using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Data.Context;
using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MyContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                entity.CreateAt = DateTime.UtcNow;
                
                _dbSet.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(s => s.Id.Equals(entity.Id));

                if (result == null)
                {
                    return null;
                }

                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(s => s.Id.Equals(id));

                if (result == null)
                {
                    return false;
                }

                _dbSet.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            try
            {
                return await _dbSet.AnyAsync(s => s.Id.Equals(id));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> SelectAsync(Guid id)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(s => s.Id.Equals(id));
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> SelectAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}