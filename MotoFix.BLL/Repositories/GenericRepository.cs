using Microsoft.EntityFrameworkCore;
using MotoFix.BLL.Interfaces;
using MotoFix.DAL.Context;
using MotoFix.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.BLL.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ApplicationDbContext _dbContext;

		public GenericRepository(ApplicationDbContext dbContext)
        {
			_dbContext = dbContext;
		}

        public async Task AddAsync(T item)
		{
			await _dbContext.AddAsync(item);
		}

		public void Delete(T item)
		{
			_dbContext.Remove(item);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			if(typeof(T) == typeof(Sale))
			{
				return (IEnumerable<T>) await _dbContext.Set<Sale>().Include(S => S.Customer).Include(S => S.SaleItems).ToListAsync();
			}
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}

		public void Update(T item)
		{
			_dbContext.Set<T>().Update(item);
		}
	}
}
