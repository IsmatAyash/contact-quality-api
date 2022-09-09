using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Contact.Center.Api.Models;
using Contact.Center.Api.Dtos;
using Contact.Center.Api.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Contact.Center.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelRepo _repo;
        private readonly IMapper _mapper;

        public ChannelController(IChannelRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChannelDto>>> GetChannels([FromHeader] bool flipSwitch)
        {
            var channels = await _repo.GetChannels();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"--> The flip switch is: {flipSwitch}");
            Console.ResetColor();

            return Ok(_mapper.Map<IEnumerable<ChannelDto>>(channels));
        }

        [HttpGet("{id}", Name = "GetChannelById")]
        public async Task<ActionResult<ChannelDto>> GetChannelById(int id)
        {
            var channel = await _repo.GetChannelById(id);
            if (channel != null)
            {
                return Ok(_mapper.Map<ChannelDto>(channel));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ChannelDto>> AddChannel(CreateChannelDto createChannelDto)
        {
            var channel = _mapper.Map<Channel>(createChannelDto);
            await _repo.AddChannel(channel);
            await _repo.SaveChanges();

            var channelRead = _mapper.Map<ChannelDto>(channel);
            
            Console.WriteLine($"Model State is: {ModelState.IsValid}");

            return CreatedAtRoute(nameof(GetChannelById), new { Id = channelRead.ChannelId}, channelRead);
        }

        //PATCH api/channel/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialChannelUpdate(int id, JsonPatchDocument<UpdateChannelDto> patchDoc)
        {
            var channelFromRepo = await _repo.GetChannelById(id);
            if(channelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<UpdateChannelDto>(channelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, channelFromRepo);

            //await _repo.UpdateChannel(channelFromRepo);

            await _repo.SaveChanges();

            return NoContent();
        }

        //PUT api/channel/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChannel(int id, UpdateChannelDto updateChannelDto)
        {
            var channelFromRepo = await _repo.GetChannelById(id);
            if(channelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(updateChannelDto, channelFromRepo);

            await _repo.SaveChanges();

            return NoContent();
        }

         //DELETE api/channel/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChannel(int id)
        {
            var channelFromRepo = await _repo.GetChannelById(id);
            if(channelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeleteChannel(channelFromRepo);
            await _repo.SaveChanges();

            return NoContent();
        }
    }
}