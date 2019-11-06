using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.Contract.Model;
using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Contracts.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GraduateNotes.Service.AccountDomain
{
    public class UserService : IUserService
    {
        private IConfiguration configuration;
        private IUserRepository repository;

        public UserService(IConfiguration _configuration,
            IUserRepository _repository)
        {
            configuration = _configuration;
            repository = _repository;
        }

        public BasicIdentity Authenticate(string email, string password)
        {
            var user = repository.FindUser(email, password);

            // return null if user not found
            if (user == null)
                return null;

            var identity = Map(user);

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            identity.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            identity.Password = null;

            return identity;
        }

        //public BasicIdentity Create(BasicIdentity user, string password)
        //{
        //    // validation
        //    if (string.IsNullOrWhiteSpace(password))
        //        throw new Exception("Password is required");

        //    if (repository.FindUser(user.Email) != null)
        //        throw new Exception("Username \"" + user.Email+ "\" is already taken");

        //    _users.Add(user);
        //    return user;
        //}

        //public IEnumerable<BasicIdentity> GetAll()
        //{
        //    // return users without passwords
        //    return _users.Select(x => {
        //        x.Password = null;
        //        return x;
        //    });
        //}
    
        private BasicIdentity Map(UserEntity entity)
        {
            return new BasicIdentity()
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Id = entity.Id,
                Password = entity.Password,
            };
        }
    }
}
