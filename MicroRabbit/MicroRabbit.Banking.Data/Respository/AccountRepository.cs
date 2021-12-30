using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Data.Respository
{
	public class AccountRepository : IAccountRepository
	{
		private BankDbContext _ctx;

		public AccountRepository(BankDbContext ctx)
		{
			_ctx = ctx;
		}
		public IEnumerable<Account> GetAccounts()
		{
			return _ctx.Accounts;
		}
	}
}
