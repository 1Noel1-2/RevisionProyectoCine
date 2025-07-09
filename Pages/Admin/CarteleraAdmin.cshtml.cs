using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Cine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CarteleraAdminModel : PageModel
{
    private readonly SarmiMovieDbContext _context;

    public CarteleraAdminModel(SarmiMovieDbContext context)
    {
        _context = context;
    }

    public List<Pelicula> Peliculas { get; set; } = new();
    public List<Pelicula> PeliculasInactivas { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    public void OnGet()
    {
        var queryActivas = _context.Peliculas.Where(p => p.Activa == true);
        var queryInactivas = _context.Peliculas.Where(p => p.Activa == false);

        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            queryActivas = queryActivas.Where(p => p.Titulo.Contains(SearchTerm));
            queryInactivas = queryInactivas.Where(p => p.Titulo.Contains(SearchTerm));
        }

        Peliculas = queryActivas.ToList();
        PeliculasInactivas = queryInactivas.ToList();
    }

    // Desactiva una película (Quitar)
    public async Task<IActionResult> OnPostDesactivarAsync(int id)
    {
        var pelicula = await _context.Peliculas.FindAsync(id);
        if (pelicula != null && pelicula.Activa == true)
        {
            pelicula.Activa = false;
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }

    // Activa una película (Volver a cartelera)
    public async Task<IActionResult> OnPostActivarAsync(int id)
    {
        var pelicula = await _context.Peliculas.FindAsync(id);
        if (pelicula != null && pelicula.Activa == false)
        {
            pelicula.Activa = true;
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}
