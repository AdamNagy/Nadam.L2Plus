using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GraduateNotes.API.Authentication
{
    public class UserService : IUserService
    {
        private IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<BasicIdentity> _users = new List<BasicIdentity>
        {
            new BasicIdentity { Id = "number-sequ-1", Email= "test1@gmail.com", Password = "test1" },
            new BasicIdentity { Id = "number-sequ-1", Email= "test2@gmail.com", Password = "test2" },
        };

        public BasicIdentity Authenticate(string email, string password)
        {
            var user = _users.SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
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
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public BasicIdentity Create(BasicIdentity user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_users.Any(x => x.Email == user.Email))
                throw new Exception("Username \"" + user.Email+ "\" is already taken");

            _users.Add(user);
            return user;
        }

        public IEnumerable<BasicIdentity> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}
