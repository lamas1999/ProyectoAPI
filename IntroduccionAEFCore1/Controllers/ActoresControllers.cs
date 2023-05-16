using AutoMapper;
using AutoMapper.QueryableExtensions;
using IntroduccionAEFCore.DTOs;
using IntroduccionAEFCore1.DTOs;
using IntroduccionAEFCore1.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionAEFCore1.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresControllers: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresControllers(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actores.OrderBy(a => a.FechaNacimiento).ToListAsync();
        }
        //Buscar por Nombre Completo
        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string nombre)
        {
            // version1
            return await context.Actores.Where(a => a.Nombre == nombre)
                 .OrderBy(a => a.Nombre)
                 .ThenByDescending(a => a.FechaNacimiento).ToListAsync();   
        }
        //Buscar por letras

        [HttpGet("nombre/v2")]
        public async Task<ActionResult<IEnumerable<Actor>>> Getv2(string nombre)
        {
            // version2
            return await context.Actores.Where(a => a.Nombre.Contains(nombre)).ToListAsync();
        }

        //Mostrar actor por rango de fecha de nac
        [HttpGet("rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(DateTime inicio, DateTime fin)
        {
            return await context.Actores.Where(a => a.FechaNacimiento >= inicio && a.FechaNacimiento <= fin).ToListAsync();
        }

        //traer actor por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get (int id)
        {
            var actor = await context.Actores.FirstOrDefaultAsync(a => a.Id == id);
            if (actor is null)
            {
                return NotFound();
            }
            return actor;
        }

        [HttpGet("idynombre")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdyNombre()
        {
            //var actores = await context.Actores.Select(a => new {a.Id, a.Nombre}).ToListAsync();
            //return Ok(actores);

            return await context.Actores
                //.Select(a => new ActorDTO { Id = a.Id, Nombre = a.Nombre }).ToListAsync();
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
        }



        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
