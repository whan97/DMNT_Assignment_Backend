using CSharpFunctionalExtensions;
using Demant_Assignment.Application.DTO;
using Demant_Assignment.Application.Helper;
using Demant_Assignment.Application.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demant_Assignment.Application.Command
{
    internal class UserLoginCommand : IRequest<Result<JwtTokenOutputDTO>>
    {
        public LoginDetailsInputDTO inputDTO;

        public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<JwtTokenOutputDTO>>
        {
            public IConfiguration _configuration;
          

            public UserLoginCommandHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<Result<JwtTokenOutputDTO>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
            {
                var userName = _configuration["Login"];
                var password = _configuration["Password"];

                if (!userName.Equals(request.inputDTO.Username))
                    return Result.Failure<JwtTokenOutputDTO>("Username does not match");

                if(!password.Equals(request.inputDTO.Password))
                    return Result.Failure<JwtTokenOutputDTO>("Password does not match");

                var token = JWTGenerate.GenerateJwtToken("somethingyouwantwhichissecurewillworkk", "https://localhost:5001/", "https://localhost:4200/", request.inputDTO.Username);

                var newToken = new JwtTokenOutputDTO
                {
                    Token = token
                };
                return Result.Success(newToken);
            }

           
        }
    }
}