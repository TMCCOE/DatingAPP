using DatingAPP.Domain.Entities;
using DationgAppServices.Infrastrcuture;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DationgAppServices.Services.UserService
{
    public class UserService : IUserService
    {
        private IRepostioryWrapper _repostioryWrapper;
        public UserService(IRepostioryWrapper repostioryWrapper)
        {
            _repostioryWrapper = repostioryWrapper;
        }
        public async Task<(HttpStatusCode, IEnumerable<AppUser>)> GetAllUsersAsync()
        {
            try
            {
                var users = await _repostioryWrapper.User.FindAll().ToListAsync();

                return (HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {

                return (HttpStatusCode.InternalServerError, null);

            }
        }

        public async Task<(HttpStatusCode, AppUser)> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _repostioryWrapper.User.FindByCondition(user => user.Id == id).SingleOrDefaultAsync();
                return (HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return (HttpStatusCode.InternalServerError, null);
            }
        }
    }
}
