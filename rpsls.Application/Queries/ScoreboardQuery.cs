using MediatR;
using rpsls.Domain.Models;

namespace rpsls.Application.Queries;

public record ScoreboardQuery(int Count = 10) : IRequest<IEnumerable<GameResult>>;