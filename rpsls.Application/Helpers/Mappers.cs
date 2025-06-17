using rpsls.Application.DTOs;
using rpsls.Domain.Models;

namespace rpsls.Application.Helpers;

public static class Mappers
{
    public static ResultDto ToResultDto(this GameResult result)
    {
        return new ResultDto(result.PlayerChoice, result.ComputerChoice, result.Outcome);
    }
}