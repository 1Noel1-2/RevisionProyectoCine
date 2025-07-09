using Microsoft.AspNetCore.Mvc;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Controllers
{
    [ApiController]
    [Route("api/funciones")]
    public class FuncionesApiController : ControllerBase
    {
        private readonly SarmiMovieDbContext _context;

        public FuncionesApiController(SarmiMovieDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/precios")]
        public IActionResult GetPrecios(int id)
        {
            var precios = _context.PreciosFuncions
                .Where(p => p.FuncionId == id)
                .Select(p => new
                {
                    id = p.TipoBoleto.Id,
                    nombre = p.TipoBoleto.Nombre,
                    precio = p.Precio ?? 0
                })
                .ToList();

            return Ok(precios);
        }
    }
}
