using rpsls.Application.DTOs;
using rpsls.Application.Messaging;

namespace rpsls.Application.Commands;

public record UserPlayCommand(int Choice, string? Username) : ICommand<ResultDto>;