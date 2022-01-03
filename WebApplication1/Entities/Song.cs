using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Songs")]
    public class Song
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int? Duration { get; set; }
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
