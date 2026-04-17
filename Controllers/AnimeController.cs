using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppAnime.Data;
using AppAnime.Models;

namespace AppAnime.Controllers
{
    public class AnimeController : Controller
    {
        private readonly AppDbContext _context;

        public AnimeController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            var anime = await _context.Anime.ToListAsync();
            return View(anime);
        }

        // CREAR
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Anime anime)
        {
            if (ModelState.IsValid)
            {
                anime.FechaCreacion = DateTime.Now;

                _context.Add(anime);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(anime);
        }

        // EDITAR
        public async Task<IActionResult> Edit(int id)
        {
            var anime = await _context.Anime.FindAsync(id);

            if (anime == null)
                return NotFound();

            return View(anime);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Anime anime)
        {
            if (ModelState.IsValid)
            {
                _context.Update(anime);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(anime);
        }

        // ELIMINAR
        public async Task<IActionResult> Delete(int id)
        {
            var anime = await _context.Anime.FindAsync(id);

            if (anime == null)
                return NotFound();

            return View(anime);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var anime = await _context.Anime.FindAsync(id);

            _context.Anime.Remove(anime);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // DETALLES
        public async Task<IActionResult> Details(int id)
        {
            var anime = await _context.Anime.FirstOrDefaultAsync(x => x.Id == id);

            if (anime == null)
                return NotFound();

            return View(anime);
        }
    }
}