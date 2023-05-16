using IntroduccionAEFCore1.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionAEFCore.Entidad.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            var terror = new Genero { Id = 4, Nombre = "Terror" };
            var animamcion = new Genero { Id = 5, Nombre = "Animacion" };
            builder.HasData(terror, animamcion);

            builder.HasIndex(p => p.Nombre).IsUnique();
        }
    }
}
