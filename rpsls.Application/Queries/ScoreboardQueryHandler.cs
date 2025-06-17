using MediatR;
using rpsls.Application.DTOs;
using rpsls.Application.Helpers;
using rpsls.Application.Interfaces;

namespace rpsls.Application.Queries;

public class ScoreboardQueryHandler(IScoreboardRepository scoreboardRepo)
    : IRequestHandler<ScoreboardQuery, IEnumerable<ResultDto>>
{
    public async Task<IEnumerable<ResultDto>> Handle(ScoreboardQuery request, CancellationToken ct)
    {
        var dbResults=  await scoreboardRepo.GetRecentResults(request.Count, ct);

        return dbResults.Select(r => r.ToResultDto());
    }
}