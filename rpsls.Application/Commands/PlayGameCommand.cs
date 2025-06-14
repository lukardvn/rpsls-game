using MediatR;
using rpsls.Application.DTOs;

namespace rpsls.Application.Commands;

public record PlayGameCommand(int Player) : IRequest<GameResultDto>;