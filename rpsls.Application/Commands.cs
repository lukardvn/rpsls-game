using rpsls.Application.DTOs;
using rpsls.Application.Messaging;

namespace rpsls.Application;

public record PlayCommand(int Player) : ICommand<GameResultDto>;