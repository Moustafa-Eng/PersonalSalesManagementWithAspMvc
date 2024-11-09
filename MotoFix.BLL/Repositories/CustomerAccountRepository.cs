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
	public class CustomerAccountRepository : GenericRepository<CustomerAccount> , ICustomerAccountRepository
	{
		public CustomerAccountRepository(ApplicationDbContext dbContext) : base(dbContext)
		{

		}
	}
}
