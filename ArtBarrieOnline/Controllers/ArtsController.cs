using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtBarrieOnline.Data;
using ArtBarrieOnline.Models;

namespace ArtBarrieOnline.Controllers
{
    public class ArtsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Arts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Art.ToListAsync());
        }

        // GET: Arts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Art == null)
            {
                return NotFound();
            }

            var art = await _context.Art
                .FirstOrDefaultAsync(m => m.Id == id);
            if (art == null)
            {
                return NotFound();
            }

            return View(art);
        }

        // GET: Arts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Date_Added,CategoryId,OrganizationId")] Art art, IFormFile Pic)
        {
            if (ModelState.IsValid)
            {
                if (Pic != null)
                {
                    art.Pic = UpPic(Pic);
                }
                _context.Add(art);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(art);
        }

        // GET: Arts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Art == null)
            {
                return NotFound();
            }

            var art = await _context.Art.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }
            return View(art);
        }

        // POST: Arts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date_Added,CategoryId,OrganizationId")] Art art, IFormFile Pic)
        {
            if (id != art.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if(Pic!= null)
                {
                    art.Pic = UpPic(Pic);
                }
                try
                {
                    _context.Update(art);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtExists(art.Id))
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
            return View(art);
        }

        // GET: Arts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Art == null)
            {
                return NotFound();
            }

            var art = await _context.Art
                .FirstOrDefaultAsync(m => m.Id == id);
            if (art == null)
            {
                return NotFound();
            }

            return View(art);
        }

        // POST: Arts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Art == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Art'  is null.");
            }
            var art = await _context.Art.FindAsync(id);
            if (art != null)
            {
                _context.Art.Remove(art);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtExists(int id)
        {
          return _context.Art.Any(e => e.Id == id);
        }
        //for pictures
        //referenc is your week 5 class video 2/3
        private static string UpPic(IFormFile Pic)
        {

            

            var file_name = Guid.NewGuid().ToString();

            var up_path = Directory.GetCurrentDirectory() + "\\wwwroot\\img\\Arts\\" + file_name;

            using (var strm = new FileStream(up_path, FileMode.Create))
            {
                Pic.CopyTo(strm);
            }
            return file_name;
        }
    }
}
