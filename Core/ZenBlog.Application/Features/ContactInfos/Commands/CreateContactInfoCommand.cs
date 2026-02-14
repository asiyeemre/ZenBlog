using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands;

public class CreateContactInfoCommand : IRequest<BaseResult<object>>
{
    public string Adress { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string MapUrl { get; set; }
}
