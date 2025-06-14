using MediatR;
using rpsls.Application.DTOs;

namespace rpsls.Application.Queries;

public record GetChoicesQuery() : IRequest<IEnumerable<ChoiceDto>>;

public record GetRandomChoiceQuery() : IRequest<ChoiceDto>;