using Contact.Center.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact.Center.Api.Data
{
    public class ChannelRepo : IChannelRepo
    {
        private readonly AppDbContext _context;

        public ChannelRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddChannel(Channel channel)
        {
            if (channel == null) 
            {
                throw new ArgumentNullException(nameof(channel));
            }
            
            await _context.AddAsync(channel);
        }

        public void DeleteChannel(Channel channel)
        {
            if (channel == null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            _context.Channels.Remove(channel);
        }

        public async Task<Channel?> GetChannelById(int id)
        {
           return await _context.Channels.FindAsync(id);
        }

        public async Task<IEnumerable<Channel>> GetChannels()
        {
            return await _context.Channels.ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
            
        }

        public Task UpdateChannel(int id, Channel channel)
        {
            throw new NotImplementedException();

        }
    }
}