using Contact.Center.Api.Models;

namespace Contact.Center.Api.Data
{
    public interface IChannelRepo
    {
        Task SaveChanges();
        Task<IEnumerable<Channel>> GetChannels();
        Task<Channel?> GetChannelById(int id);
        Task AddChannel(Channel channel);
        Task UpdateChannel(int id, Channel channel);
        void DeleteChannel(Channel channel);
    }
}