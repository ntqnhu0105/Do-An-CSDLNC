using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.Data;
using QLVXBXMD.Models.System;

namespace QLVXBXMD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Quản lý")]
    public class NhaXeController : Controller
    {
        private readonly AppDbContext _context;

        public NhaXeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/NhaXes
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhaXes.ToListAsync());
        }

        // GET: Admin/NhaXes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaXes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenNhaXe,DiaChi,Email,SDT")] NhaXe nhaXe)
        {
            // Loại bỏ MaNhaXe khỏi validation vì nó sẽ được sinh tự động
            ModelState.Remove("MaNhaXe");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                return View(nhaXe);
            }

            // Sinh mã nhà xe tự động
            var lastNhaXe = await _context.NhaXes.OrderByDescending(n => n.MaNhaXe).FirstOrDefaultAsync();
            int nextId;
            if (lastNhaXe != null && lastNhaXe.MaNhaXe.StartsWith("NX") && int.TryParse(lastNhaXe.MaNhaXe.Substring(2), out int parsedId))
            {
                nextId = parsedId + 1;
            }
            else
            {
                nextId = 1;
            }
            nhaXe.MaNhaXe = $"NX{nextId:D4}";

            try
            {
                _context.Add(nhaXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi lưu dữ liệu: {ex.Message}");
                return View(nhaXe);
            }
        }
        // GET: Admin/NhaXes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaXe = await _context.NhaXes.FindAsync(id);
            if (nhaXe == null)
            {
                return NotFound();
            }
            return View(nhaXe);
        }

        // POST: Admin/NhaXes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhaXe,TenNhaXe,DiaChi,Email,SDT")] NhaXe nhaXe)
        {
            if (id != nhaXe.MaNhaXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaXeExists(nhaXe.MaNhaXe))
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
            return View(nhaXe);
        }

        // GET: Admin/NhaXes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaXe = await _context.NhaXes
                .FirstOrDefaultAsync(m => m.MaNhaXe == id);
            if (nhaXe == null)
            {
                return NotFound();
            }

            return View(nhaXe);
        }

        // POST: Admin/NhaXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhaXe = await _context.NhaXes.FindAsync(id);
            if (nhaXe != null)
            {
                _context.NhaXes.Remove(nhaXe);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NhaXeExists(string id)
        {
            return _context.NhaXes.Any(e => e.MaNhaXe == id);
        }
    }
}
