using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Cine.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Proyecto_Cine.Pages.Admin;

public class ModificarPeliculaAdminModel : PageModel
{
    private readonly SarmiMovieDbContext _context;
    private readonly IWebHostEnvironment _env;

    public ModificarPeliculaAdminModel(SarmiMovieDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    [BindProperty]
    public Pelicula Pelicula { get; set; } = new();

    [BindProperty]
    public List<string> IdiomasSeleccionados { get; set; } = new();

    [BindProperty]
    public IFormFile? ArchivoImagen { get; set; }

    public bool EsNueva => Pelicula.Id == 0;

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            Pelicula = new Pelicula { Activa = true };
        }
        else
        {
            Pelicula = _context.Peliculas.FirstOrDefault(p => p.Id == id);
            if (Pelicula == null)
                return NotFound();

            IdiomasSeleccionados = Pelicula.Idioma?.Split(',').ToList() ?? new List<string>();
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        string? rutaImagenNueva = null;

        // Procesar imagen si fue cargada
        if (ArchivoImagen != null)
        {
            string nombreArchivo = Path.GetFileName(ArchivoImagen.FileName);
            string rutaCarpeta = Path.Combine(_env.WebRootPath, "images", "peliculas");
            string rutaDestino = Path.Combine(rutaCarpeta, nombreArchivo);

            if (!Directory.Exists(rutaCarpeta))
                Directory.CreateDirectory(rutaCarpeta);

            // Sobrescribe si ya existe
            using (var stream = new FileStream(rutaDestino, FileMode.Create))
            {
                ArchivoImagen.CopyTo(stream);
            }

            rutaImagenNueva = $"/images/peliculas/{nombreArchivo}";
        }

        if (Pelicula.Id == 0)
        {
            // Validar imagen obligatoria al crear nueva película
            if (rutaImagenNueva == null)
            {
                ModelState.AddModelError(string.Empty, "Debe subir una imagen para la película.");
                return Page();
            }

            Pelicula.Activa = true;
            Pelicula.Idioma = string.Join(",", IdiomasSeleccionados);
            Pelicula.Imagen = rutaImagenNueva;

            _context.Peliculas.Add(Pelicula);
        }
        else
        {
            var existente = _context.Peliculas.FirstOrDefault(p => p.Id == Pelicula.Id);
            if (existente == null) return NotFound();

            existente.Titulo = Pelicula.Titulo;
            existente.Genero = Pelicula.Genero;
            existente.Duracion = Pelicula.Duracion;
            existente.Clasificacion = Pelicula.Clasificacion;
            existente.Idioma = string.Join(",", IdiomasSeleccionados);
            existente.Sinopsis = Pelicula.Sinopsis;
            existente.Activa = Pelicula.Activa;

            if (rutaImagenNueva != null)
                existente.Imagen = rutaImagenNueva;
        }

        _context.SaveChanges();
        return RedirectToPage("CarteleraAdmin");
    }
}