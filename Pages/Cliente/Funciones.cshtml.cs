using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Pages.Cliente;

public class FuncionesModel : PageModel
{
    private readonly SarmiMovieDbContext _context;

    public FuncionesModel(SarmiMovieDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public int? Id { get; set; }

    [BindProperty(SupportsGet = true)]
    public DateOnly? Fecha { get; set; }

    public Pelicula? Pelicula { get; set; }

    public List<Funcione> FuncionesEspañol { get; set; } = new();
    public List<Funcione> FuncionesSubtituladas { get; set; } = new();

    public IActionResult OnGet()
    {
        if (Id == null)
        {
            return RedirectToPage("/Cliente/Cartelera");
        }

        Pelicula = _context.Peliculas.FirstOrDefault(p => p.Id == Id);
        if (Pelicula == null)
        {
            return NotFound();
        }

        var query = _context.Funciones
            .Include(f => f.Sala)
            .Where(f => f.PeliculaId == Id && f.Estado == "Activa");

        if (Fecha.HasValue)
        {
            query = query.Where(f => f.Fecha == Fecha.Value);
        }

        FuncionesEspañol = query.Where(f => f.Idioma == "Español").OrderBy(f => f.HoraInicio).ToList();
        FuncionesSubtituladas = query.Where(f => f.Idioma == "Subtitulada").OrderBy(f => f.HoraInicio).ToList();

        return Page();
    }
}
