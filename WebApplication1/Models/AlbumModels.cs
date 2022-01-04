using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AlbumModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }

    public class AlbumCreateModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
    }

    public class AlbumUpdateModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
    }
}
