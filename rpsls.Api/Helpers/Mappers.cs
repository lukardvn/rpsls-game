using rpsls.Api.DTOs;
using rpsls.Application.Commands;

namespace rpsls.Api.Helpers;

public static class Mappers
{
    public static PlayCommand ToPlayCommand(this PlayRequest request) =>
        new(request.Player);
    
    public static UserPlayCommand ToPlayCommand(this UserPlayRequest request) =>
        new(request.Choice, request.Username);
}