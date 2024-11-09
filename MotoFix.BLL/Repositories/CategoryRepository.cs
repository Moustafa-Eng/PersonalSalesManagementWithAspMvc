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
	public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
	{
        public CategoryRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
