using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pm.Api.Dal;
using Pm.Api.helpers;
using Pm.Api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pm.Api.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
       

        private readonly AppSettings _appSettings;
        private readonly ErasmusContext _context;

        public UserService(IOptions<AppSettings> appSettings, ErasmusContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            var user = _context.Profiles.Where(p => p.Email == model.Username)
                .Select(p => new User()
                {
                    FirstName = p.Name,
                    LastName = p.LastName,
                    Id = p.ProfileId.ToString(),
                    Username = p.Email
                }).FirstOrDefault();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Profiles.Select(p => new User()
            {
                FirstName = p.Name,
                LastName = p.LastName,
                Id = p.ProfileId.ToString(),
                Username = p.Email
            }).ToList();
        }

        public User GetById(Guid id)
        {
            //return _users.FirstOrDefault(x => x.Id == id);

            var perfil = _context.Profiles.Find(id);

            return new User()
            {
                Id = perfil.ProfileId.ToString(),
                FirstName = perfil.Name,
                LastName = perfil.LastName,
                Username = perfil.Email
            };
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
