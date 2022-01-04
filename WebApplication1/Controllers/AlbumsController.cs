using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private DatabaseContext _db;

        public AlbumsController(DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet("list")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<AlbumModel>))]
        public List<AlbumModel> List()
        {
            List<AlbumModel> albums = _db.Albums.Select(x => new AlbumModel { Id = x.Id, Name = x.Name, Author = x.Author}).ToList();

            return albums;
        }
        
        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AlbumModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        public IActionResult Create([FromBody] AlbumCreateModel model)
        {
            try
            {
                Album album = new Album
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Author = model.Author
                };

                _db.Albums.Add(album);
                int affected = _db.SaveChanges();

                if (affected > 0)
                {
                    AlbumModel result = new AlbumModel
                    {
                        Id = album.Id,
                        Name = album.Name,
                        Author = album.Author
                    };

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Ekleme işlemi yapılamadı");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AlbumModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        public IActionResult GetById([FromRoute] Guid id)
        {
            Album album = _db.Albums.Find(id);

            if (album == null)
            {
                return NotFound(id.ToString());
            }

            AlbumModel model = new AlbumModel
            {
                Id = album.Id,
                Name = album.Name,
                Author = album.Author
            };

            return Ok(model);
        }

        [HttpPut("update/{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AlbumModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        public IActionResult Update([FromRoute] Guid id, [FromBody] AlbumUpdateModel model)
        {
            Album album = _db.Albums.Find(id);

            if (album == null)
            {
                return NotFound(id.ToString());
            }

            album.Name = model.Name;
            album.Author = model.Author;

            _db.SaveChanges();

            AlbumModel data = new AlbumModel
            {
                Id = album.Id,
                Name = album.Name,
                Author = album.Author
            };

            return Ok(data);
        }

        [HttpDelete("remove")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        public IActionResult Delete(Guid id)
        {
            Album album = _db.Albums.Find(id);

            if (album == null)
            {
                return null;
            }

            _db.Albums.Remove(album);
            _db.SaveChanges();

            return Ok();
        }
    }
}
