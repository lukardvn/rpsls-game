using MediatR;
using rpsls.Application.DTOs;
using rpsls.Application.Exceptions;
using rpsls.Application.Interfaces;
using rpsls.Domain.Interfaces;
using rpsls.Domain.Models;

namespace rpsls.Application;

public class GetChoicesQueryHandler : IRequestHandler<GetChoicesQuery, IEnumerable<ChoiceDto>>
{
    public Task<IEnumerable<ChoiceDto>> Handle(GetChoicesQuery request, CancellationToken cancellationToken)
    {
        var choices = Enum.GetValues<Choice>()
            .Select(c => new ChoiceDto((int)c, c.ToString()));

        return Task.FromResult(choices);
    }
}

public class GetRandomChoiceQueryHandler(IGameService gameService, IRandomNumberProvider rnProvider) : IRequestHandler<GetRandomChoiceQuery, ChoiceDto>
{
    public async Task<ChoiceDto> Handle(GetRandomChoiceQuery request, CancellationToken ct)
    {
        var randomNumber = await rnProvider.GetRandomNumber(ct);
        var choice = await gameService.MapNumberToChoice(randomNumber);
        
        return new ChoiceDto((int)choice, choice.ToString());
    }
}

public class PlayCommandHandler(IGameService gameService, IRandomNumberProvider rnProvider)
    : IRequestHandler<PlayCommand, GameResultDto>
{
    public async Task<GameResultDto> Handle(PlayCommand request, CancellationToken ct)
    {
        var playerChoice = (Choice)request.Player;

        var computerNumber = await rnProvider.GetRandomNumber(ct);
        var computerChoice = await gameService.MapNumberToChoice(computerNumber);

        var result = await gameService.DetermineOutcome(playerChoice, computerChoice);

        return new GameResultDto(
            (int)playerChoice,
            (int)computerChoice,
            result
        );
    }
}