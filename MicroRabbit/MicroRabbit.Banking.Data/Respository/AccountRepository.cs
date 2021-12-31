using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;

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
