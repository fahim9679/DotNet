﻿using DotNet.Entities;
using DotNet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repositories.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetUserInfo(string username, string password)
        {
            var user=await _context.UserInfo.FirstOrDefaultAsync(x=>x.UserName.ToLower()==username.ToLower() && x.Password==password);
            return user;
        }

        public async Task RegisterUser(UserInfo userInfo)
        {
            if (!Exists(userInfo))
            {
                await _context.UserInfo.AddAsync(userInfo);
                await _context.SaveChangesAsync();
            }
            
        }

        private bool Exists(UserInfo userInfo)
        {
            return _context.UserInfo.Any(x=>x.UserName.ToLower()==userInfo.UserName.ToLower());
        }
    }
}
