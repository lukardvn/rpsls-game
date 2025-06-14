using MediatR;
using rpsls.Application.DTOs;
using rpsls.Application.Interfaces;
using rpsls.Domain.Interfaces;
using rpsls.Domain.Models;

namespace rpsls.Application.Commands;

public class PlayGameCommandHandler(IGameService gameService, IRandomNumberProvider randomNumberProvider)
    : IRequestHandler<PlayGameCommand, GameResultDto>
{
    public async Task<GameResultDto> Handle(PlayGameCommand request, CancellationToken cancellationToken)
    {
        var computerNumber = await randomNumberProvider.GetRandomNumber(cancellationToken);
        var computerChoice = await gameService.MapNumberToChoice(computerNumber);
        
        var playerChoice = (Choice)request.Player;

        var result = await gameService.DetermineOutcome(playerChoice, computerChoice);

        return new GameResultDto(
            (int)playerChoice,
            (int)computerChoice,
            result
        );
    }
}