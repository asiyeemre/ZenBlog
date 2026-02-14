using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;

namespace ZenBlog.Application.Features.Messages.Endpoints;

public static class MessageEndpoints
{
    public static void RegisterMessageEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var messages = endpoints.MapGroup("/messages").WithTags("Messages");
        messages.MapPost("", async (IMediator mediator, CreateMessageCommand command) =>
        {
            var result = await mediator.Send(command);
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.BadRequest(result);
        });
        messages.MapGet("", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetMessagesQuery());
            return result.IsSuccess
                ? Results.Ok( result)
                : Results.BadRequest( result); 

        });
        messages.MapGet("{id}", async (IMediator mediator, Guid id) =>
        {
            var result = await mediator.Send(new GetMessageByIdQuery(id));
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.BadRequest(result); 
        });
        messages.MapPut("", async (IMediator mediator, UpdateMessageCommand command) =>
        {       
            var result = await mediator.Send(command);
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.BadRequest(result); 
        });
        messages.MapDelete("", async (IMediator mediator, Guid id) =>
        {
            var result = await mediator.Send(new RemoveMessageCommand(id));
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.BadRequest(result); 
        });

    }
}
