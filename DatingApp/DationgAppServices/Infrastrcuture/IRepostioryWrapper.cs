using DatingApp.Data.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DationgAppServices.Infrastrcuture
{
    public interface IRepostioryWrapper
    {
        IUserRepository User {  get; }
    }
}
