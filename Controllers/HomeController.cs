﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Login.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
    
    private MyContext _context;
    public HomeController(MyContext context)
    { 
        _context = context;
    }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)

        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(e => e.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email","Email already in use");
                    return View("Index");
                }else{
                    PasswordHasher<User> Hasher =new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser,newUser.Password);
                    _context.Add(newUser);
                    _context.SaveChanges();
                    return RedirectToAction("Success");
                }
            
            } else{
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(User logUser)
        {
            if(ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(u => u.Email == logUser.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invaild login attempt");
                    return View ("Index");
                }
                return RedirectToAction("Success");
            
            }else{
                return View("Index");
        }

        }
        [HttpGet("Success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
        
        
        



       

    
