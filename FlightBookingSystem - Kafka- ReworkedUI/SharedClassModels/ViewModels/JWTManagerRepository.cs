using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedClassModels.CmnModels;
using SharedClassModels.DataModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SharedClassModels.ViewModels
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration configuartion;

        private readonly AirlineDBContext _dbcontext;

        public JWTManagerRepository(IConfiguration iconfiguration, AirlineDBContext Dbcontext)
        {
            configuartion = iconfiguration;
            _dbcontext = Dbcontext;
        }     

        public TokenDetails Authenticate(TblUserdetail users)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email,users.EmailId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenDetails { Token = tokenHandler.WriteToken(token)};
        }

        public int RegisterUser(TblUserdetail users)
        {
            PasswordEncrypt encrypt = new PasswordEncrypt();
            users.Password = encrypt.EncryptPwd(users.Password);
            users.IsActive = 1;
            users.CreatedBy = users.UserName.ToString();
            users.ModifiedBy = users.UserName.ToString();

            _dbcontext.TblUserdetails.Add(users);
            int IsSuccess = _dbcontext.SaveChanges();
            return IsSuccess;
        }

        public List<string> Login(TblUserdetail users)
        {
            PasswordEncrypt encrypt = new PasswordEncrypt();
            users.Password = encrypt.EncryptPwd(users.Password);
            IEnumerable<TblUserdetail> searchResults = _dbcontext.TblUserdetails.ToList()
                .Where(m => m.EmailId == users.EmailId && m.Password == users.Password);

            List<string> lst = new List<string>();
            //Check if the entered credentials are found in the DB
            if (searchResults.ToList().Count != 0)
            {
                lst.Add(searchResults.FirstOrDefault().UserId.ToString());
                lst.Add(searchResults.FirstOrDefault().RoleId.ToString());

            }
            return lst;
        }

    }   

}
