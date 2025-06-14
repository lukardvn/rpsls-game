using rpsls.Application.DTOs;
using rpsls.Application.Messaging;

namespace rpsls.Application.Commands;

public record PlayCommand(int Player) : ICommand<ResultDto>;