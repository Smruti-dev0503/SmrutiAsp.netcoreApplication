using SmrutiAsp.netcoreApplication.Interface;
using SmrutiAsp.netcoreApplication.Models;
using SmrutiAsp.netcoreApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.Repository
{
    
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeContext context;

        public UserRepository(EmployeeContext context)
        {
            this.context = context;
        }

        public bool GetUser(LoginViewModel loginViewModel)
        {
            var Islogin = context.User.Where(x => x.EmailId == loginViewModel.EmailId && x.Password == loginViewModel.Password).FirstOrDefault(); 

            if(Islogin !=null)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }

        
    }
}
