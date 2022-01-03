using MFramework.Services.FakeData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {
        private DatabaseContext _db;

        public DevController(DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet("generate-fake-data")]
        public string Get()
        {
            InsertAlbums();
            InsertSongs();

            return "ok";
        }

        private void InsertSongs()
        {
            if (_db.Songs.Any())
                return;

            List<Album> albums = _db.Albums.ToList();

            foreach (Album album in albums)
            {
                for (int i = 0; i < NumberData.GetNumber(3, 15); ++i)
                {
                    _db.Songs.Add(new Song
                    {
                        Id = Guid.NewGuid(),
                        AlbumId = album.Id,
                        Name = PlaceData.GetStreetName(),
                        Duration = NumberData.GetNumber(60, 240)
                    });
                }
            }

            _db.SaveChanges();
        }

        private void InsertAlbums()
        {
            if (_db.Albums.Any())
                return;

            for (int i = 0; i < 10; ++i)
            {
                _db.Albums.Add(new Album
                {
                    Id = Guid.NewGuid(),
                    Name = NameData.GetCompanyName(),
                    Author = NameData.GetFullName()
                });
            }

            _db.SaveChanges();
        }
    }
}
