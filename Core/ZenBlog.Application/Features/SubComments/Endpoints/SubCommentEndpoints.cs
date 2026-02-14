using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Queries;

namespace ZenBlog.Application.Features.SubComments.Endpoints;

public static class SubCommentEndpoints
{
    public static void RegisterSubCommentEndpoints(this IEndpointRouteBuilder app)
    {
        var subComments = app.MapGroup("/subComments").WithTags("SubComments");

        subComments.MapPost("",
            async(CreateSubCommentCommand command , IMediator mediator)=>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess?Results.Ok(response): Results.BadRequest(response);
            });
        subComments.MapGet("",
            async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetSubCommentsQuery());
               return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        subComments.MapGet("{id}",
            async (Guid id,IMediator mediator) =>
            {
                var response = await mediator.Send(new GetSubCommentByIdQuery(id));
               return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        subComments.MapPut("",
            async (UpdateSubCommentCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
               return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

        subComments.MapDelete("{id}",
            async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new RemoveSubCommentCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
    }
}
        