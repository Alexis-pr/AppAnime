using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAnime.Models
{
    [Table("Anime")]
    public class Anime
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Genero { get; set; }

        public int Episodios { get; set; }
        public string? Imagen { get; set; }
        public string Sinopsis { get; set; }

        [Column("Estado")]
        public string Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}