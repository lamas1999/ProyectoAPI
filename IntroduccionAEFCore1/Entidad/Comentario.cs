﻿namespace IntroduccionAEFCore1.Entidad
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? Contenido { get; set; }
        public bool Recomendar { get; set; }

        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
    }
}
