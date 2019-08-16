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
            var user = _dbContext.ApplicationUsers.FirstOrDefault(x => x.Id == id );

            if (user != null)
            {
                _dbContext.ApplicationUsers.Remove(user);
                await _dbContext.SaveChangesAsync();
            }

            return user;

        }

        public IEnumerable<ApplicationUser> GetApplicationUsers()
        {
            var list = _dbContext.ApplicationUsers.ToList();
            return list;
        }

        public async Task<ApplicationUser> GetByidAsync(string id)
        {
            ApplicationUser user = await _dbContext.ApplicationUsers.FindAsync(id).ConfigureAwait(false);

            return user;
        }
    }
}
