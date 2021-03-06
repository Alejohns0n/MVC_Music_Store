﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCMusicStore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMusicStore.Controllers
{
    [Authorize]
    [Route("Manager")]
    public class StoreManagerController : Controller
    {
        private readonly MusicStoreEntities _context;

        public StoreManagerController(MusicStoreEntities context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var musicStoreEntities = _context.Tab_Album.Include(a => a.Artist).Include(a => a.Genre);
            return View(await musicStoreEntities.ToListAsync());
        }

        // GET: StoreManager/Details/5
        [Route("Detalhes/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Tab_Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: StoreManager/Create
        [Route("Adicionar")]
        public IActionResult Create()
        {
            ViewData["ArtistName"] = new SelectList(_context.Tab_Artist, "ArtistId", "Name");
            ViewData["GenreName"] = new SelectList(_context.Tab_Genre, "GenreId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Adicionar")]
        public async Task<IActionResult> Create([Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Tab_Artist, "ArtistId", "ArtistId", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Tab_Genre, "GenreId", "GenreId", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        [Route("Editar/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Tab_Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Tab_Artist, "ArtistId", "ArtistId", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Tab_Genre, "GenreId", "GenreId", album.GenreId);
            return View(album);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Tab_Artist, "ArtistId", "ArtistId", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Tab_Genre, "GenreId", "GenreId", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Delete/5
        [Route("Deletar/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Tab_Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Tab_Album.FindAsync(id);
            _context.Tab_Album.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Route("CriarArtista")]
        public IActionResult CreateArtist()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CriarArtista")]
        public IActionResult CreateArtist([Bind("Name")] Artist artist)
        {
            if (!ModelState.IsValid)
                return View();

            _context.Add(artist);
            _context.SaveChangesAsync();
            return  RedirectToAction(nameof(Index));
        }

        [Route("CriarGenero")]
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        [Route("CriarGenero")]
        public IActionResult CreateGenre([Bind("Name, Description")] Genre genre)
        {
            if (!ModelState.IsValid)
                return View();
            genre.Name = genre.Name.ToUpper();
            _context.AddAsync(genre);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool AlbumExists(int id)
        {
            return _context.Tab_Album.Any(e => e.AlbumId == id);
        }
    }
}
