using DatingAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DationgAppServices.Services.UserService
{
    public interface IUserService
    {
        Task<(HttpStatusCode, IEnumerable<AppUser>)> GetAllUsersAsync();
        Task<(HttpStatusCode,AppUser)> GetUserByIdAsync(int id);
    }
}
