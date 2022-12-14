using FindTheBuilder.Applications.Helper;
using FindTheBuilder.Applications.Services.PaymentAppServices;
using FindTheBuilder.Applications.Services.TransactionAppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;

namespace FindTheBuilder.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentAppService _paymentAppService;
		private readonly ITransactionAppService _transactionAppService;
		public PaymentController(IPaymentAppService paymentAppService, ITransactionAppService transactionAppService)
		{
			_paymentAppService = paymentAppService;
			_transactionAppService = transactionAppService;
		}

		[HttpPost]
		[Authorize(Roles = "Customer")]
		public  async Task<IActionResult> Payment(int idTrans)
		{
			try
			{
				if(idTrans != 0)
				{
					var res = await _paymentAppService.Post();
					if (res == null)
					{
						return await Task.Run(()=>(Requests.Response(this, new ApiStatus(404), null, "Error")));
					}
					var transResult = await _transactionAppService.UpdatePayment(idTrans);
					if(transResult.Id == 0)
					{
						return await Task.Run(() => (Requests.Response(this, new ApiStatus(404), null, "Error")));
					}
					return await Task.Run(()=>(Requests.Response(this, new ApiStatus(200), res, "Success")));
				}
				return await Task.Run(()=>( Requests.Response(this, new ApiStatus(400), null, "Error")));
			}
			catch(DbException de)
			{
				return await Task.Run(()=>(Requests.Response(this, new ApiStatus(500), null, de.Message)));
			}
		}
	}
}
