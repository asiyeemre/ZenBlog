using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Users.Queries;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class GetLoginQueryHandler(UserManager<AppUser> _userManager, IJwtService _jwtService, IMapper _mapper) : IRequestHandler<GetLoginQuery, BaseResult<GetLoginQueryResult>>
    {
        public async Task<BaseResult<GetLoginQueryResult>> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return BaseResult<GetLoginQueryResult>.NotFound("Kullanıcı Bulunamadı");
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                return BaseResult<GetLoginQueryResult>.Fail("Email veya Şifre Geçersiz.");
            }

            var userResult = _mapper.Map<GetUsersQueryResult>(user);

            var response = await _jwtService.GenerateTokenAsync(userResult);
            if (response is null)
            {
                return BaseResult<GetLoginQueryResult>.Fail("Token oluşturulamadı.");
            }
            return BaseResult<GetLoginQueryResult>.Success(response);
        }
    }
}