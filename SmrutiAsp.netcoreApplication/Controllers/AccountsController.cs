using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmrutiAsp.netcoreApplication.Interface;
using SmrutiAsp.netcoreApplication.Models;
using SmrutiAsp.netcoreApplication.ViewModel;

namespace SmrutiAsp.netcoreApplication.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountsController(IUserRepository userRepository)
        {
           this._userRepository = userRepository;
        }
      
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            User user = new User();

            user.EmailId = loginViewModel.EmailId;
            user.Password = loginViewModel.Password;

            var IsValidLogin = _userRepository.GetUser(loginViewModel);

            if(IsValidLogin)
            {
                return RedirectToAction("GetEmployeeList", "Employee");
            }
            else
            {
                return RedirectToAction("Index", "Employee");
            }

            
        }
    }
}