using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Transfer.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TransferController : ControllerBase
	{

		private readonly ITransferService _transferService;

		public TransferController(ITransferService transferService)
		{
			_transferService = transferService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<TransferLog>> Get()
		{
			return Ok(_transferService.GetTransferLogs());
		}
		/*
		[HttpPost]
		public IActionResult Post([FromBody] AccountTransfer accountTransfer)
		{
			_transferService.Transfer(accountTransfer);
			return Ok(accountTransfer);
		}
		*/

	}
}