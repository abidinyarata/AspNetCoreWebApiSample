using System;

namespace WebApplication1.Models
{
    public class SongModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }
    }
}
