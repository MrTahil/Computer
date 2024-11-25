namespace ComputerApi.Models
{
    public record CreateOsDto(string name);
    public record UpdateOsDto(string name);
    public record CreateCompDto(string? Brand, string? Type,double? Display, int? Memory, string? OsId);
}
