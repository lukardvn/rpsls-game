using MediatR;
using rpsls.Application.Interfaces;
using rpsls.Domain.Models;

namespace rpsls.Application.Queries;

public class ScoreboardQueryHandler(IScoreboardRepository scoreboardRepository)
    : IRequestHandler<ScoreboardQuery, IEnumerable<GameResult>>
{
    public async Task<IEnumerable<GameResult>> Handle(ScoreboardQuery request, CancellationToken ct)
    {
        return await scoreboardRepository.GetRecentResults(request.Count, ct);
    }
}