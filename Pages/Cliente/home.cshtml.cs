using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;

public class HomeModel : PageModel
{
    private readonly SarmiMovieDbContext _context;

    public HomeModel(SarmiMovieDbContext context)
    {
        _context = context;
    }

    public List<Sucursale> ListaSucursales { get; set; }
    public List<string> Ciudades { get; set; }
    public List<Pelicula> Novedades { get; set; }
    public List<Pelicula> Cartelera { get; set; }

    public async Task OnGetAsync()
    {
        // Carga sucursales y ciudades
        ListaSucursales = await _context.Sucursales.ToListAsync();
        Ciudades = ListaSucursales
            .Select(s => s.Ubicacion.Split(',').Last().Trim())
            .Distinct()
            .ToList();

        // Carga novedades
       Novedades = await _context.Peliculas
        .Where(p => p.Activa != null && p.Activa == true)
        .OrderByDescending(p => p.Id)
        .Take(5)
        .ToListAsync();

        // Carga cartelera activa
        Cartelera = await _context.Peliculas
            .Where(p => p.Activa != null && p.Activa == true)
            .ToListAsync();
    }
}
