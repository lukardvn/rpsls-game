using rpsls.Application.DTOs;
using rpsls.Domain.Models;

namespace rpsls.Application.Extensions;

public static class MappingExtensions
{
    public static ResultDto ToResultDto(this GameResult result)
    {
        return new ResultDto(result.PlayerChoice, result.ComputerChoice, result.Outcome);
    }
}