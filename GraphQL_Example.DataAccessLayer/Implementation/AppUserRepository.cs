using GraphQL_Example.DataAccessLayer.HelperClass;
using GraphQL_Example.DataAccessLayer.Repository;
using GraphQL_Example.Database;
using GraphQL_Example.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Example.DataAccessLayer.Implementation
{
    public class AppUserRepository : IAppUserRepository
    {
        public AppUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppDbContext _dbContext { get; }

        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            var userCheck = await _dbContext.ApplicationUsers.FindAsync(user.Id.ToString()).ConfigureAwait(false);
            if (userCheck == null)
            {
                user.DateAcctCreated = DateTime.Now;
                await _dbContext.ApplicationUsers.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return user;

            }
            return null;
        }

        public async Task<ApplicationUser> DeleteUser(string id)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                _dbContext.ApplicationUsers.Remove(user);
                await _dbContext.SaveChangesAsync();
            }

            return user;

        }

        public IEnumerable<ApplicationUser> GetApplicationUsers(AppUserFilter filter)
        {

            var list = _dbContext.ApplicationUsers.ToList();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                list = list.Where(u => u.firstName.ToLower().Contains(filter.Search.ToLower())
                || u.lastName.ToLower().Contains(filter.Search.ToLower())).ToList();
            }

            switch (filter.SortBy)
            {
                case "name":
                    list = list.OrderBy(u => u.firstName).ToList();
                    break;
                case "rank":
                    list = list.OrderByDescending(u => u.rank).ToList();
                    break;
                case "dateCreated":
                    list = list.OrderByDescending(u => u.DateAcctCreated).ToList();
                    break;
                default:
                    break;
            }

            if (list.Count > 0)
            {
                int page = (filter.Page ?? 1);
                
                int pageSize = (filter.PageSize ?? 3);
                if (pageSize == 0)
                {
                    pageSize = 3;
                }
                int maxPage = (list.Count % pageSize == 0) ? list.Count / pageSize : list.Count / pageSize + 1;

                if (page <= maxPage)
                    list = (list.Skip((page - 1) * pageSize).Take(pageSize)).ToList();
                else
                    return null;
            }

                return list;
        }

        public async Task<ApplicationUser> GetByidAsync(string id)
        {
            ApplicationUser user = await _dbContext.ApplicationUsers.FindAsync(id).ConfigureAwait(false);

            return user;
        }
    }
}
