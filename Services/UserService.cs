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
using System.Net;
using System.IO;
using Jint;

namespace WebApi.Services
{

    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly WeatherGardenContext _context;
        private readonly IMapper _mapper;

        public UserService(IOptions<AppSettings> appSettings, WeatherGardenContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 登入驗證
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public LoginResponse Authenticate(string account, string password)
        {
            LoginResponse lr = new LoginResponse();
            // 先簡單判斷帳號密碼
            var user = _context.User.SingleOrDefault(x => x.Account == account && x.Password == password);

            //return null if user not found
            if (user == null)
                return lr;

            //authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            lr.User = user.WithoutPassword();
            lr.Token = tokenHandler.WriteToken(token);
            return lr;
        }

        /// <summary>
        /// 取得背包列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserBag GetBagList(int userId)
        {
            UserBag userBag = new UserBag();

            var checkUser = _context.User.Where(x => x.Id == userId);
            if (checkUser == null)
                return userBag;

            userBag.userId = userId;

            var userProduct = _context.UserProduct.Include(x => x.Product).Where(x => x.UserId == userId).ToList();
            userBag.BagItem = _mapper.Map<List<UserProduct>,List<BagItem> >(userProduct);

            return userBag;
        }

        public List<User> GetAll()
        {
             return _context.User.ToList();
        }

        public string GetCurrentWeatherJson()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.cwb.gov.tw/Data/js/Observe/Stations/46692.js");
            request.Method = "GET";
            //回傳的字串
            string responseStr = string.Empty;
            //發出Request
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = sr.ReadToEnd();
                }//end using  
            }
            // 執行JS語法
            var engine = new Engine();
            var result = engine
            .Execute(responseStr)
            .Execute("OBS[0]")
            .GetCompletionValue();
            var jsonData = engine.Json.Stringify(result, new[] { result });
            return jsonData.ToString();
        }
    }
}