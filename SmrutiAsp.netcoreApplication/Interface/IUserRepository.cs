using SmrutiAsp.netcoreApplication.Models;
using SmrutiAsp.netcoreApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.Interface
{
    public interface IUserRepository
    {
        public bool GetUser(LoginViewModel loginViewModel);
    }
}
