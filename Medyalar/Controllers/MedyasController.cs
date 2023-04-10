using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medyalar.Data;
using Medyalar.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Medyalar.Controllers
{
    public class MedyasController : Controller
    {
        private readonly MedyalarContext _context;
        private IRepository _repository;
        private readonly IWebHostEnvironment _whe;

        public MedyasController(MedyalarContext context, IRepository repository, IWebHostEnvironment whe)
        {
            _context = context;
            _repository = repository;
            _whe = whe;
        }

        // GET: Medyas
        public IActionResult Index()
        {
            var medya = _repository.GetMedyas();
            return View(medya);
        }

        // GET: Medyas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medya = await _context.Medya
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medya == null)
            {
                return NotFound();
            }

            return View(medya);
        }

        // GET: Medyas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medyas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medya medya, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                //if (file!=null)
                //{
                    //var extn = Path.GetExtension(file.FileName);
                    //var randomName = ($"{Guid.NewGuid()}{extn}");
                    //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", randomName);
                    //using(var stream=new FileStream(path, FileMode.Create))
                    //{
                    //    await file.CopyToAsync(stream);
                    //}

                //    var local_file_dir = $"wwwroot/uploads/files";
                //    var local_file_path = $"{local_file_dir}/{file.FileName}";  //exception
                //    if (!Directory.Exists(Path.Combine(local_file_dir)))  //dosya yoksa oluştur
                //        Directory.CreateDirectory(Path.Combine(local_file_dir));
                    
                //    using (Stream fileStream = new FileStream(local_file_path, FileMode.Create))  //dosya kaydet
                //    {
                //        file.CopyTo(fileStream);
                //    }
                //medya.DosyaAdi = $"{local_file_dir}{file.FileName}";
                //}
                



                //var files = HttpContext.Request.Form.Files;

                //if (files.Count > 0)
                //{
                //    var fileName = Guid.NewGuid().ToString();

                //    var uploads = Path.Combine(_whe.WebRootPath, @"uploads\files");
                //    var extn = Path.GetExtension(files[0].FileName);

                //    if (medya.DosyaAdi != null)
                //    {
                //        var path = Path.Combine(_whe.WebRootPath, medya.DosyaAdi.TrimStart('\\'));

                //        if (System.IO.File.Exists(path))
                //        {
                //            System.IO.File.Delete(path);
                //        }
                //    }
                //    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extn), FileMode.Create))
                //    {
                //        files[0].CopyTo(filesStreams);
                //    }
                //    medya.DosyaAdi = @"uploads\files\" + fileName + extn;
                //}
                _context.Add(medya);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medya);
        }

        // GET: Medyas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medya = await _context.Medya.FindAsync(id);
            if (medya == null)
            {
                return NotFound();
            }
            return View(medya);
        }

        // POST: Medyas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medya medya)
        {
            _repository.UpdateMedya(medya);
            return RedirectToAction(nameof(Index));

        }

        // GET: Medyas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medya = await _context.Medya
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medya == null)
            {
                return NotFound();
            }

            return View(medya);
        }

        // POST: Medyas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medya = await _context.Medya.FindAsync(id);
            //TempData["Message"] = "Kayıt sistemden tamamen silinecek. Bu işlem geri alınamaz.";

            var path = Path.Combine(_whe.WebRootPath, medya.DosyaAdi.TrimStart('\\'));

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);

            }

            _context.Medya.Remove(medya);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedyaExists(int id)
        {
            return _context.Medya.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ArchiveData(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medya = await _context.Medya
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medya == null)
            {
                return NotFound();
            }

            return View(medya);
        }

        [HttpPost, ActionName("ArchiveData")]
        [ValidateAntiForgeryToken]
        public IActionResult ArchiveData(Medya medya)
        {
            _repository.Arsivle(medya);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Archived()
        {
            //var archived = _repository.Medya.Where(m => m.isArchived == true).ToList();
            var archived = _repository.GetMedyasByArchived(true);
            return View(archived);
        }
    }
}
