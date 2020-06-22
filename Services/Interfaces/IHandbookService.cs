using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;
using static WebApi.Services.BaseService;

namespace WebApi.Services.Interfaces
{
    public interface IHandbookService
    {

        ServiceResult UserHandbook(int userId);


       
    }
}
