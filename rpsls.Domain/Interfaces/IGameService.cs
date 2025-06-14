using rpsls.Domain.Models;

namespace rpsls.Domain.Interfaces;

public interface IGameService
{
    Task<Choice> MapNumberToChoice(int number);
    Task<string> DetermineOutcome(Choice player, Choice computer);
}