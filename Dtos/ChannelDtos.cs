namespace Contact.Center.Api.Dtos
{
    public record ChannelDto(int ChannelId, string ChannelName);
    public record CreateChannelDto(string ChannelName, DateTime CreatedAt);
    public record UpdateChannelDto(string ChannelName, DateTime UpdatedAt);
    public record DeleteChannelDto(int ChannelId);

}