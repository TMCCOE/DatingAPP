using DatingApp.Data;
using DatingApp.Data.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DationgAppServices.Infrastrcuture
{
    public class RepositoryWrapper : IRepostioryWrapper
    {
        private IUserRepository _user;
        private Dating_APPContext _dating_APPContext;

        public RepositoryWrapper(Dating_APPContext dating_APPContext)
        {
            _dating_APPContext = dating_APPContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_dating_APPContext);
                }

                return _user;
            }
        }

    }
}
