using GraphQL_Example.DataAccessLayer.HelperClass;
using GraphQL_Example.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Example.DataAccessLayer.Repository
{
   public interface IAppUserRepository
    {
        IEnumerable<ApplicationUser> GetApplicationUsers(AppUserFilter filter);
        Task<ApplicationUser> GetByidAsync(string id);
        Task<ApplicationUser> AddUser(ApplicationUser user);
        Task<ApplicationUser> DeleteUser(string id);
       
    }
}
