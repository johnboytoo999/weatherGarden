using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class ShopService : BaseService, IShopService
    {

        private readonly AppSettings _appSettings;
        private readonly WeatherGardenContext _context;
        private readonly IMapper _mapper;


        public ShopService(IOptions<AppSettings> appSettings, WeatherGardenContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <returns></returns>
        public ShopInformation GetShopList()
        {
            var shopInformation = new ShopInformation();
            var solarTerms = GetSolarTerms();
            var products = _context.Product.Where(x => x.SolarTerms == solarTerms.Name || x.SolarTerms == "無" ).ToList();

            shopInformation.ShopItems = _mapper.Map<List<Product>, List<ShopItem>>(products);
            shopInformation.SolarTerms = solarTerms.Name;
            shopInformation.Description = solarTerms.Description;
            shopInformation.DayDescription = solarTerms.DayDescription;

            return shopInformation;
        }

        /// <summary>
        /// 購買物品
        /// </summary>
        /// <param name="buyItemRequest"></param>
        /// <returns></returns>
        public ServiceResult BuyItem(BuyItemRequest buyItemRequest)
        { 
            User userInfo = _context.User.SingleOrDefault(x => x.Id == buyItemRequest.UserId);
            Product product = _context.Product.SingleOrDefault(y => y.Id == buyItemRequest.ProductId);

            if(userInfo == null)
            {
                return ServiceResult.Fail("使用者資訊錯誤");
            }
            if (product == null)
            {
                return ServiceResult.Fail("產品錯誤");
            }
            // Data Annoatation已判斷
            //if(buyItemRequest.Quantity <= 0)
            //{
            //    return ServiceResult.Fail("請選擇數量");
            //}
            if (userInfo.Money < product.Price * buyItemRequest.Quantity)
            {
                return ServiceResult.Fail("金幣不足");
            }

            var userProduct = _context.UserProduct.SingleOrDefault(x => x.ProductId == buyItemRequest.ProductId && x.UserId == buyItemRequest.UserId);

            //DB操作
            if (userProduct == null)
            {
                UserProduct insertUserProduct = _mapper.Map<BuyItemRequest, UserProduct>(buyItemRequest);            
                _context.UserProduct.Add(insertUserProduct);
            }
            else
            {
                userInfo.UserProduct.SingleOrDefault(x => x.ProductId == buyItemRequest.ProductId).Quantity += buyItemRequest.Quantity;
            }
            userInfo.Money -= product.Price * buyItemRequest.Quantity;

            _context.SaveChanges();
            return ServiceResult.Success();
           
        }

        private SalarTerms GetSolarTerms()
        {
            var SalarTermsForYear = new SalarTermsForYear();            
            var salaryTerms = SalarTermsForYear.Init().FirstOrDefault(n => DateTime.Now >= n.StartDate && DateTime.Now < n.EndDate);
            return salaryTerms;
        }
    }
}
