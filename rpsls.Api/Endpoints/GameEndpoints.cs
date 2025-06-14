using MediatR;
using rpsls.Api.DTOs;
using rpsls.Application;
using rpsls.Application.Commands;
using rpsls.Application.DTOs;
using rpsls.Application.Queries;

namespace rpsls.Api.Endpoints;

public static class GameEndpoints
{
    public static void RegisterGameEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/game").WithTags("Game");
        
        group.MapGet("/choices", async (ISender mediator, CancellationToken ct = default) =>
        {
            var result = await mediator.Send(new ChoicesQuery(), ct);
            return Results.Ok(result);
        })
        .WithDescription("Get all possible choices.")
        .WithName("GetGameChoices")
        .WithTags("Game")
        .Produces<IEnumerable<ChoiceDto>>();
        
        group.MapGet("/choice", async (ISender mediator, CancellationToken ct = default) =>
        {
            var result = await mediator.Send(new RandomChoiceQuery(), ct);
            return Results.Ok(result);
        })
        .WithDescription("Get randomly generated choice.")
        .WithName("GetRandomChoice")
        .WithTags("Game")
        .Produces<ChoiceDto>();
        
        group.MapPost("/play", async (PlayRequest request, ISender mediator, CancellationToken ct) =>
        {
            var result = await mediator.Send(new PlayCommand(request.Player), ct);
            return Results.Ok(result);
        })
        .WithDescription("Play a game round against the computer.")
        .WithName("PlayGame")
        .WithTags("Game")
        .Accepts<PlayRequest>("application/json")
        .Produces<ResultDto>();
    }
}