using rpsls.Api.DTOs;
using rpsls.Application.Commands;

namespace rpsls.Api.Mappers;

public static class PlayRequestMapper
{
    public static PlayCommand ToPlayCommand(this PlayRequest request) =>
        new(request.Player);
}