﻿using FindTheBuilder.Applications.Services.PriceAppServices;
using FindTheBuilder.Applications.Services.PriceAppServices.DTO;
using FindTheBuilder.Applications.Services.SkillAppServices;
using FindTheBuilder.Applications.Services.SkillAppServices.DTO;
using FindTheBuilder.Applications.Services.TukangAppServices;
using FindTheBuilder.Applications.Services.TukangAppServices.DTO;
using FindTheBuilder.Databases.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindTheBuilder.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize(Roles ="Tukang")]
	public class TukangController : ControllerBase
	{
		private readonly ITukangAppService _tukangAppService;
		private readonly ISkillAppService _skillAppService;
		private readonly IPriceAppService _priceAppService;

		public TukangController(ITukangAppService tukangAppService, 
			ISkillAppService skillAppService, 
			IPriceAppService priceAppService)
		{
			_tukangAppService = tukangAppService;
			_skillAppService = skillAppService;
			_priceAppService = priceAppService;
		}

		// Tukang

		[HttpPost("CreateTukang")]
		[Authorize(Roles = "Tukang")]
		public Tukang CreateTukang([FromBody] TukangDTO model)		
		{			
			return _tukangAppService.Create(model);
		}
		
		[HttpPatch("EditTukang")]
		[Authorize(Roles = "Tukang")]
		public Tukang EditTukang([FromBody] UpdateTukangDTO model)		
		{			
			return _tukangAppService.Update(model);
		}
		
		// Skill Tukang
		[HttpPost("CreateSkill")]
		[Authorize(Roles = "Tukang")]
		public Skills CreateSkill([FromBody] SkillDTO model)		
		{			
			return _skillAppService.Create(model);
		}
		
		[HttpPatch("EditSkill")]
		[Authorize(Roles = "Tukang")]
		public Skills EditSkill([FromBody] UpdateSkillDTO model)		
		{			
			return _skillAppService.Update(model);
		}
		
		[HttpDelete("DeleteSkill")]
		[Authorize(Roles = "Tukang")]
		public Skills DeleteSkill(int id)		
		{			
			return _skillAppService.Delete(id);
		}	
		
	}
}
