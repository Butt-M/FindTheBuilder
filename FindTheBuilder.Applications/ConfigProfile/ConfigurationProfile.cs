﻿using AutoMapper;

using FindTheBuilder.Applications.Services.CustomerAppServices.DTO;
using FindTheBuilder.Applications.Services.PriceAppServices.DTO;
using FindTheBuilder.Applications.Services.ProductAppServices.DTO;
using FindTheBuilder.Applications.Services.SkillAppServices.DTO;
using FindTheBuilder.Applications.Services.TransactionAppServices.DTO;
using FindTheBuilder.Applications.Services.TukangAppServices.DTO;
using FindTheBuilder.Applications.Services.AuthAppServices.Dto;
using FindTheBuilder.Databases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FindTheBuilder.Applications.Services.TransactionDetailAppServices.DTO;

namespace FindTheBuilder.Applications.ConfigProfile
{
	public class ConfigurationProfile: Profile
	{
		public ConfigurationProfile()
		{
			// Customers
			CreateMap<Customers, CustomerDTO>();
			CreateMap<CustomerDTO, Customers>();

			CreateMap<Customers, UpdateCustomerDTO>();
			CreateMap<UpdateCustomerDTO, Customers>();


			// Tukang			
			CreateMap<TukangDTO, Tukang>();
			CreateMap<Tukang, TukangDTO>();
			
			CreateMap<Tukang, UpdateTukangDTO>();
			CreateMap<UpdateTukangDTO, Tukang>();

			// Product
			CreateMap<Products, ProductDTO>();
			CreateMap<ProductDTO, Products>();

			CreateMap<Products, UpdateProductDTO>();
			CreateMap<UpdateProductDTO, Products>();

			// Skill
			CreateMap<Skills, SkillDTO>();
			CreateMap<SkillDTO, Skills>();

			CreateMap<UpdateSkillDTO, Skills>();
			CreateMap<Skills, UpdateSkillDTO>();

			// Price
			CreateMap<Prices, PriceDTO>();
			CreateMap<PriceDTO, Prices>();

			CreateMap<Prices, UpdatePriceDTO>();
			CreateMap<UpdatePriceDTO, Prices>();

			//Transaction details
			CreateMap<TransactionDetails, CreateTransactionDetailDTO>();
			CreateMap<CreateTransactionDetailDTO, TransactionDetails>();

			CreateMap<TransactionDetails, TransactionDetailDTO>();
			CreateMap<TransactionDetailDTO, TransactionDetails>();

			// Transaction
			CreateMap<Transactions, TransactionDTO>();
			CreateMap<TransactionDTO, Transactions>();

			CreateMap<Transactions, UpdateTransactionDTO>();
			CreateMap<UpdateTransactionDTO, Transactions>();

			//Auth
			CreateMap<Auth, AuthDto>();
			CreateMap<AuthDto, Auth>();

		}
	}
}
