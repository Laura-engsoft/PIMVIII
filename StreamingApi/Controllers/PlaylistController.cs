using Microsoft.AspNetCore.Mvc;
using StreamingApi.Models;
using StreamingApi.Repository;

namespace StreamingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaylistController : ControllerBase
{
    private readonly IPlaylistRepository _playlistRepository;

    public PlaylistController(IPlaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Playlist>> GetAll()
    {
        var playlists = _playlistRepository.GetAllPlaylists();
        return Ok(playlists);
    }

    [HttpGet("{id:int}", Name = "GetPlaylistById")]
    public ActionResult<Playlist> GetById(int id)
    {
        var playlist = _playlistRepository.GetPlaylistByID(id);
        return playlist is null ? NotFound() : Ok(playlist);
    }

    [HttpPost]
    public ActionResult<Playlist> Create([FromBody] Playlist playlist)
    {
        _playlistRepository.AddPlaylist(playlist);
        return CreatedAtRoute("GetPlaylistById", new { id = playlist.Id }, playlist);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Playlist playlist)
    {
        if (id != playlist.Id)
        {
            return BadRequest("ID do corpo difere do parâmetro.");
        }

        var existingPlaylist = _playlistRepository.GetPlaylistByID(id);
        if (existingPlaylist is null)
        {
            return NotFound();
        }

        _playlistRepository.UpdatePlaylist(playlist);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existingPlaylist = _playlistRepository.GetPlaylistByID(id);
        if (existingPlaylist is null)
        {
            return NotFound();
        }

        _playlistRepository.DeletePlaylist(id);
        return NoContent();
    }
}
