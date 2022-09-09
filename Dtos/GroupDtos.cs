namespace Contact.Center.Api.Dtos
{
    public record GroupDto(int GroupId, string GroupName, string GroupInitials);
    public record CreateGroupDto(string GroupName, string GroupInitials, DateTime CreatedAt);
    public record UpdateGroupDto(string GroupName, string GroupInitials, DateTime UpdatedAt);
    public record DeleteGroupDto(int GroupId);

}