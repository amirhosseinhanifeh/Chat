using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mozer.Business.Account.Abstraction;
using Mozer.DataAccess.Common.Abstraction;
using Mozer.Models.Accounts.Entities;
using Mozer.ViewModels.Accounts;
using Mozer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Business.Account.Implementation
{
    public class RegisterService : IRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration configuration;
        public RegisterService(IUnitOfWork unitOfWork,
            IConfiguration _configuration)
        {
            _unitOfWork = unitOfWork;
            configuration = _configuration;
        }

        public async Task<ResultViewModel<(string,Guid)>> RegisterByPass(RegisterByPassDto model, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Get(x => (x.Email == model.UserName && x.Password == model.Password) || (x.UserName == model.UserName && x.Password == model.Password));
            if (user == null)
            {
                user = new UserModel()
                {
                    UserName = model.UserName,
                    RoleId = 3,
                    UserState=Models.Accounts.Enums.UserStateEnum.Registered
                };
                user.Profile = new ProfileModel
                {
                    Name = null,
                    Avatar = null
                };
                _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            string token = GenerateToken(user);

            return new ResultViewModel<(string,Guid)>
            {
                Message = "",
                NotificationType = ViewModels.Common.Enums.NotificationType.Success,
                Object = (token,user.Id)
            };
        }

        public async Task<ResultViewModel<string>> RegisterUser(ResponseRegisterDTO model, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.Get(x => x.Mobile == model.Mobile);
                if (user == null)
                {
                    user = new UserModel()
                    {
                        Mobile = model.Mobile,
                        RoleId = 2,
                        UserState = Models.Accounts.Enums.UserStateEnum.Registered
                    };
                    _unitOfWork.UserRepository.Add(user);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }

                string token = GenerateToken(user);

                return new ResultViewModel<string>
                {
                    Message = "",
                    NotificationType = ViewModels.Common.Enums.NotificationType.Success,
                    Object = token
                };
            }
            catch (Exception e)
            {
                return new ResultViewModel<string>
                {
                    Message = e.Message,
                    NotificationType = ViewModels.Common.Enums.NotificationType.Danger,
                    Object = null
                };
            }

        }

        private string GenerateToken(UserModel model)
        {

            var claims = new List<Claim>
            {
new Claim(JwtRegisteredClaimNames.UniqueName, model.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
