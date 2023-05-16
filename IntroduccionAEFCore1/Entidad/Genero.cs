namespace IntroduccionAEFCore1.Entidad
{
    public class Genero
    {
        public int Id { get; set; }
        // [StringLength(maximumLength:150)]
        public string Nombre { get; set; } = null!;
        //relacion n a n
        public HashSet<Pelicula> Peliculas { get; set; } = new HashSet<Pelicula>();
    }
}
