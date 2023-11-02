using Shared.Models;

namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public String? CreatorName { get; set; }
    public string? Title { get; set; }
    public string? body { get; set; }
}