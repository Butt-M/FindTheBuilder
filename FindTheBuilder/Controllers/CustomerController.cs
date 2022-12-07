﻿using FindTheBuilder.Applications.Helper;
using FindTheBuilder.Applications.Services.CustomerAppServices;
using FindTheBuilder.Applications.Services.CustomerAppServices.DTO;
using FindTheBuilder.Applications.Services.PriceAppServices;
using FindTheBuilder.Applications.Services.PriceAppServices.DTO;
using FindTheBuilder.Applications.Services.TransactionAppServices;
using FindTheBuilder.Applications.Services.TransactionAppServices.DTO;
using FindTheBuilder.Applications.Services.TransactionDetailAppServices;
using FindTheBuilder.Applications.Services.TransactionDetailAppServices.DTO;
using FindTheBuilder.Databases.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace FindTheBuilder.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerAppService _customerAppService;
		private readonly ITransactionAppService _transactionAppService;
		private readonly ITransactionDetailAppService _transactionDetailAppService;
		private readonly IPriceAppService _priceAppService;

		public CustomerController(ICustomerAppService customerAppService, 
			ITransactionAppService transactionAppService, 
			ITransactionDetailAppService transactionDetailAppService, 
			IPriceAppService priceAppService)
		{
			_customerAppService = customerAppService;
			_transactionAppService = transactionAppService;
			_transactionDetailAppService = transactionDetailAppService;
			_priceAppService = priceAppService;
		}

		// Customer
		[HttpPost("CreateCustomer")]
		//[Authorize(Roles = "Customer")]
		public IActionResult CreateCustomer([FromBody] CustomerDTO model)
		{
			try
			{
				if(model.Name != null)
				{
					_customerAppService.Create(model);
					return Requests.Response(this, new ApiStatus(200), null, "Success");
				}
				return Requests.Response(this, new ApiStatus(400), null, "Error");
			}
			catch(DbException de)
			{
				return Requests.Response(this, new ApiStatus(500), null, de.Message);
			}
			
		}
		
		[HttpPatch("UpdateCustomer")]
		//[Authorize(Roles = "Customer")]
		public IActionResult UpdateCustomer([FromBody] UpdateCustomerDTO model)
		{
			try
			{
				if (model.Name != null)
				{
					var res = _customerAppService.Update(model);
					if(res.Name != null)
					{
						return Requests.Response(this, new ApiStatus(200), null, "Success");
					}
					return Requests.Response(this, new ApiStatus(404), null, "Error");
				}
				return Requests.Response(this, new ApiStatus(400), null, "Error");
			}
			catch (DbException de)
			{
				return Requests.Response(this, new ApiStatus(500), null, de.Message);
			}
		}

		// Transaction
		[HttpPost("CreateTransaction")]
		//[Authorize(Roles = "Customer")]
		public IActionResult CreateTransaction([FromBody] TransactionDTO model)
		{
			try
			{
				if (model != null)
				{
					var res = _transactionAppService.Create(model);
					if(res != null)
					{
						return Requests.Response(this, new ApiStatus(200), null, "Success");
					}
					return Requests.Response(this, new ApiStatus(400), null, "Error");
				}
				return Requests.Response(this, new ApiStatus(400), null, "Error");
			}
			catch (DbException de)
			{
				return Requests.Response(this, new ApiStatus(500), null, de.Message);
			}
		}

		[HttpPatch("UpdateTransaction")]
		//[Authorize(Roles = "Customer")]
		public IActionResult UpdateTransaction([FromBody] UpdateTransactionDTO model)
		{
			try
			{
				if (model != null)
				{
					var res = _transactionAppService.Update(model);
					if (res != null)
					{
						return Requests.Response(this, new ApiStatus(200), null, "Success");
					}
					return Requests.Response(this, new ApiStatus(404), null, "Error");
				}
				return Requests.Response(this, new ApiStatus(400), null, "Error");
			}
			catch (DbException de)
			{
				return Requests.Response(this, new ApiStatus(500), null, de.Message);
			}
		}

		// Transaction Detail
		[HttpGet("GetAllTransactionDetails")]
		//Authorize(Roles = "Customer")]
		public IActionResult GetAllTransaction([FromQuery] PageInfo pageInfo)
		{
			try
			{
				var data = _transactionDetailAppService.GetAllTransactions(pageInfo);
				if(data.Data.Count() == 0)
				{
					return Requests.Response(this, new ApiStatus(404), null, "No Transaction");
				}
				return Requests.Response(this, new ApiStatus(200), data, "Success");
			}
			catch(DbException de)
			{
				return Requests.Response(this, new ApiStatus(500), null, de.Message);
			}
		}

		// Prices
		[HttpGet("GetAllPrice")]
		[AllowAnonymous]
		public IActionResult GetAllPrice([FromQuery] PageInfo pageInfo)
		{
			try
			{
				var data = _priceAppService.GetPriceByProduct(pageInfo);
				if (data.Data.Count() == 0)
				{
					return Requests.Response(this, new ApiStatus(404), null, "No Price List");
				}
				return Requests.Response(this, new ApiStatus(200), data, "Success");
			}
			catch (DbException de)
			{
				return Requests.Response(this, new ApiStatus(500), null, de.Message);
			}			 
		}
	}
}
