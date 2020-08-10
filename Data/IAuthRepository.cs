﻿using Mxstrong.Dtos;
using Mxstrong.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mxstrong.Data
{
  public interface IAuthRepository
  {
    Task<User> Register(User user, string password);
    Task<ActivationToken> GenerateActivationToken(string UserId);
    Task<User> ActivateUser(string tokenId);
    Task<User> Login(string email, string pasword);
    Task<bool> UserExists(string email);
    Task<User> FindUser(string id);
    Task<List<User>> GetUsers();
    Task<User> UpdateUser(string id, UserProfileDto user);
  }
}
