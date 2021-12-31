using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Respository
{
	public class TransferRepository : ITransferRepository
	{
		private TransferDbContext _ctx;

		public TransferRepository(TransferDbContext ctx)
		{
			_ctx = ctx;
		}
		public IEnumerable<TransferLog> GetTransferLogs()
		{
			return _ctx.TransferLogs;
		}

		public void Add(TransferLog transferLog)
		{
			_ctx.TransferLogs.Add(transferLog);
			_ctx.SaveChanges();
		}

	}
}
