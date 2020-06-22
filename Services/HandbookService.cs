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
using Microsoft.EntityFrameworkCore;
using static WebApi.Services.BaseService;

namespace WebApi.Services
{

    public class HandbookService : IHandbookService
    {

        private readonly AppSettings _appSettings;
        private readonly WeatherGardenContext _context;
        private readonly IMapper _mapper;

        public HandbookService(IOptions<AppSettings> appSettings, WeatherGardenContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// ��Ų
        /// </summary>
        /// <returns></returns>
        public ServiceResult UserHandbook(int userId)
        {

            var user = _context.User.SingleOrDefault(x => x.Id == userId);

            if (user == null)
                return ServiceResult.Fail("�L�ϥΪ�");

            var userHandbooks = _context.UserHandbook.Where(x => x.UserId == userId).AsNoTracking();
            var SalarTermsForYear = new SalarTermsForYear().Init();

            var handbooks = _context.Handbook.Include(n => n.Product).ToList()
                .Select(x => new HandbookModel()
                {
                    PlantCount = _getHandBookPlanCount(userHandbooks.FirstOrDefault(y => y.HandbookId == x.Id)),
                    Id = x.Id,
                    Image = x.Image,
                    Description = x.Descripiton,
                    Name = x.Name,
                    Notice = x.Notice,
                    SolarTerms = x.Product.SolarTerms,
                    SolarTermsDate = SalarTermsForYear.FirstOrDefault(z => z.Name == x.Product.SolarTerms).DayDescription
                });

            return ServiceResult.Success("���\", handbooks);
        }

        /// <summary>
        /// ���o�ϥΪ֦̾���Ų���ƶq
        /// For Select�ϥΡA�קK���Ƽ���Ʈw
        /// </summary>
        /// <param name="userHandbook"></param>
        /// <returns></returns>
        private int _getHandBookPlanCount(UserHandbook userHandbook)
        {
            return userHandbook == null ? 0 : userHandbook.PlantCount;
        }


    }
}