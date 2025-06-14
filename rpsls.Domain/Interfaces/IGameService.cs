using rpsls.Domain.Models;

namespace rpsls.Domain.Interfaces;

public interface IGameService
{
    Task<Choice> MapNumberToChoice(int number);
    Task<Outcome> DetermineOutcome(Choice player, Choice computer);
}