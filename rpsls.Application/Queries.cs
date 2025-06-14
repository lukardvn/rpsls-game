using MediatR;
using rpsls.Application.DTOs;

namespace rpsls.Application;

public record GetChoicesQuery() : IRequest<IEnumerable<ChoiceDto>>;

public record GetRandomChoiceQuery() : IRequest<ChoiceDto>;