using IntroduccionAEFCore.Entidad.Seeding;
using IntroduccionAEFCore1.Entidad;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntroduccionAEFCore1
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //aplica las configuraciones

            SeedingInicial.Seed(modelBuilder);
            // modelBuilder.Entity<Genero>().HasKey(g => g.Id);
            // modelBuilder.Entity<Genero>().Property(g => g.Nombre).HasMaxLength(50);  

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150); //para poner por defecto el maxiomo 150 caracteres todo
        }
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Actor> Actores => Set<Actor>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
    }
}
