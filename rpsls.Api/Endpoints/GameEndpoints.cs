using MediatR;
using Microsoft.AspNetCore.Mvc;
using rpsls.Api.DTOs;
using rpsls.Api.Mappers;
using rpsls.Application.DTOs;
using rpsls.Application.Queries;

namespace rpsls.Api.Endpoints;

public static class GameEndpoints
{
    public static void RegisterGameEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/game").WithTags("Game");
        
        group.MapGet("/choices", async (ISender mediator, CancellationToken ct = default) =>
        {
            var result = await mediator.Send(new ChoicesQuery(), ct);
            return Results.Ok(result);
        })
        .WithDescription("Get all the choices that are usable for the UI.")
        .WithName("GetGameChoices")
        .Produces<IEnumerable<ChoiceDto>>();
        
        group.MapGet("/choice", async (ISender mediator, CancellationToken ct = default) =>
        {
            var result = await mediator.Send(new RandomChoiceQuery(), ct);
            return Results.Ok(result);
        })
        .WithDescription("Get a randomly generated choice.")
        .WithName("GetRandomChoice")
        .Produces<ChoiceDto>();
        
        group.MapPost("/play", async (PlayRequest request, ISender mediator, CancellationToken ct) =>
        {
            var result = await mediator.Send(request.ToPlayCommand(), ct);
            return Results.Ok(result);
        })
        .WithDescription("Play a round against a computer opponent.")
        .WithName("PlayGame")
        .Accepts<PlayRequest>("application/json")
        .Produces<ResultDto>()
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
    }
}