using rpsls.Application.Interfaces;
using rpsls.Domain.Models;

namespace rpsls.Infrastructure.Repositories;

public class ScoreboardRepository : IScoreboardRepository
{
    public Task AddResult(string username, Choice playerChoice, Choice computerChoice, Outcome outcome, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GameResult>> GetRecentResults(int count = 10, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task ResetScoreboard(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}