using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using PlantItApp.Modules.Users.Data;
using PlantItApp.Modules.Users.Models.DbTable;
using PlantItApp.Modules.Users.Models.Request;
using PlantItApp.Modules.Users.Models.Response;
using PlantItApp.Modules.Users.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PlantItApp.Modules.Users.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly UserDbContext _userDbContext;
        private readonly IConfiguration _configuration;

        public UserRepo(UserDbContext userDbContext, IConfiguration configuration)
        {
            _userDbContext = userDbContext;
            _configuration = configuration;
        }

      
        public LoginResponse Login(LoginReq req)
        {
            var detail = new User();
            var email = new EmailAddressAttribute();




            if (email.IsValid(req.NumberOrEmail))
            {
                detail = _userDbContext.users.Where(x => x.Email == req.NumberOrEmail).FirstOrDefault();
            }
            else
            {
                detail = _userDbContext.users.Where(x => x.PhoneNumber == req.NumberOrEmail).FirstOrDefault();
            }

            var Parts = detail.PasswordHash.Split(":");
            var salt = Parts[0];
            var storedPassord = Parts[1];

            var hashedPassword = HashPassword(req.password, salt);

            if (hashedPassword == storedPassord)
            {
                var token = GenerateJwtToken(detail.UserId);
                if (detail != null)
                {
                    return new LoginResponse
                    {
                        UserId = detail.UserId,
                        Name = detail.FirstName,
                        Number = detail.PhoneNumber,
                        email = detail.Email,
                        address = detail.Address,
                        Token = token
                    };
                }

            }
           
            return new LoginResponse();


        }

        public string Register(RegistrationReq req)
        {
            var hashedPassword = HashPasswordWithSalt(req.password);
            var data = new User
            {
                FirstName = req.firstName,
                LastName = req.lastName,
                Email = req.email,
                PhoneNumber = req.phoneNumber,
                PasswordHash = hashedPassword,
                Role = Role.Customer,

            };
            _userDbContext.users.Add(data);
            _userDbContext.SaveChanges();

            return "Success";


        }

        //JWT Token generation code

        private string GenerateJwtToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(int.Parse(_configuration["Jwt:Expires"])),
                Issuer = _configuration["Jwt:ValidIssuer"],
                Audience = _configuration["Jwt:ValidAudience"],

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        //Password Hashing Code is here

        public string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public string HashPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public string HashPasswordWithSalt(string password)
        {
            var salt = GenerateSalt();
            var hashedPassword = HashPassword(password, salt);
            return $"{salt}:{hashedPassword}";
        }

    }
}
