using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.Contract.Models;
using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Contract.Models;

namespace GraduateNotes.Service.AccountDomain
{
    public class UserService : IUserService
    {
        private IConfiguration configuration;
        private IUserRepository repository;

        public UserService(
            IConfiguration _configuration,
            IUserRepository _repository)
        {
            configuration = _configuration;
            repository = _repository;
        }

        public BasicIdentity Authenticate(string email, string password)
        {
            var user = repository.Read(email, password);

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
                    new Claim(ClaimTypes.Name, user.Id.ToString())
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

        public BasicIdentity Register(BasicIdentity user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (repository.Read(user.Email) != null)
                throw new Exception("Username \"" + user.Email + "\" is already taken");

            repository.Add(Map(user));
            return user;
        }

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
                Id = entity.Id.ToString(),
                Password = entity.Password,
            };
        }

        private UserEntity Map(BasicIdentity from)
        {
            return new UserEntity()
            {
                Email = from.Email,
                FirstName = from.FirstName,
                LastName = from.LastName,
                Password = from.Password
            };
        }
    }
}
