using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands;

public record CreateMessageCommand:IRequest<BaseResult<object>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string MessageBody { get; set; } //Mesajın içeriği

    [JsonIgnore]
    public bool IsRead { get; set; }=false;

}
