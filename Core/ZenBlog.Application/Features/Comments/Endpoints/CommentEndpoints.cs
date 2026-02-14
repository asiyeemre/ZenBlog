using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Application.Features.Comments.Queries;

namespace ZenBlog.Application.Features.Comments.Endpoints;

public static class CommentEndpoints
{
    public static void RegisterCommentEndpoints(this IEndpointRouteBuilder app)
    {
        var comments = app.MapGroup("/comments").WithTags("Comments");

        comments.MapGet(string.Empty, async (IMediator _mediator) =>
        {
            var response = await _mediator.Send(new GetCommentsQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
        comments.MapPost(string.Empty,
           async (CreateCommentCommand command, IMediator mediator) =>
           {
               var response = await mediator.Send(command);
               return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);

           });
        comments.MapGet("{id}", async (Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCommentByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
        comments.MapPut("", async (UpdateCommentCommand command ,IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
        comments.MapDelete("{id}", async (Guid id ,IMediator mediator) =>
        {
            var response = await mediator.Send(new RemoveCommentCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
       
    }
}
