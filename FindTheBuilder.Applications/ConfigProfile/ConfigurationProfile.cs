﻿using AutoMapper;
using FindTheBuilder.Applications.Services.CustomerAppServices.DTO;
using FindTheBuilder.Applications.Services.TukangAppServices.DTO;
using FindTheBuilder.Databases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FindTheBuilder.Applications.ConfigProfile
{
	public class ConfigurationProfile: Profile
	{
		public ConfigurationProfile()
		{
			// Customers
			CreateMap<Customers, CustomerDTO>();
			CreateMap<CustomerDTO ,Customers>();

			CreateMap<Customers, UpdateCustomerDTO>();
			CreateMap<UpdateCustomerDTO, Customers>();

			// Tukang
			CreateMap<Tukang, TukangDTO>();
			CreateMap<TukangDTO, Tukang>();
			
			CreateMap<Tukang, UpdateTukangDTO>();
			CreateMap<UpdateTukangDTO, Tukang>();
		}
	}
}
