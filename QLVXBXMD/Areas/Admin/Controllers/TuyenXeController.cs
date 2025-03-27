using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.Data;
using QLVXBXMD.Models.System;

namespace QLVXBXMD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Quản lý")]
    public class TuyenXeController : Controller
    {
        private readonly AppDbContext _context;

        public TuyenXeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TuyenXe
        public async Task<IActionResult> Index()
        {
            return View(await _context.TuyenXes.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuyenXe = await _context.TuyenXes
                .FirstOrDefaultAsync(tx => tx.MaTuyen == id);
            if (tuyenXe == null)
            {
                return NotFound();
            }

            return View(tuyenXe);
        }
        // GET: Admin/TuyenXe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TuyenXe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiemDi,DiemDen,KhoangCach,ThoiGianDuKien,MoTa,GiaThamKhao")] TuyenXe tuyenXe)
        {
            ModelState.Remove("MaTuyen");

            if (!ModelState.IsValid)
            {
                return View(tuyenXe);
            }

            // Tự động sinh mã tuyến xe
            var lastTuyen = await _context.TuyenXes.OrderByDescending(t => t.MaTuyen).FirstOrDefaultAsync();
            int nextId = (lastTuyen != null && lastTuyen.MaTuyen.StartsWith("TX") && int.TryParse(lastTuyen.MaTuyen.Substring(2), out int parsedId))
                         ? parsedId + 1 : 1;

            tuyenXe.MaTuyen = $"TX{nextId:D4}";

            try
            {
                _context.Add(tuyenXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi lưu dữ liệu: {ex.Message}");
                return View(tuyenXe);
            }
        }

        // GET: Admin/TuyenXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuyenXe = await _context.TuyenXes.FindAsync(id);
            if (tuyenXe == null)
            {
                return NotFound();
            }
            return View(tuyenXe);
        }

        // POST: Admin/TuyenXe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTuyen,DiemDi,DiemDen,KhoangCach,ThoiGianDuKien,MoTa,GiaThamKhao")] TuyenXe tuyenXe)
        {
            if (id != tuyenXe.MaTuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuyenXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuyenXeExists(tuyenXe.MaTuyen))
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
            return View(tuyenXe);
        }

        // GET: Admin/TuyenXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuyenXe = await _context.TuyenXes.FirstOrDefaultAsync(m => m.MaTuyen == id);
            if (tuyenXe == null)
            {
                return NotFound();
            }

            return View(tuyenXe);
        }

        // POST: Admin/TuyenXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tuyenXe = await _context.TuyenXes.FindAsync(id);
            if (tuyenXe != null)
            {
                _context.TuyenXes.Remove(tuyenXe);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TuyenXeExists(string id)
        {
            return _context.TuyenXes.Any(e => e.MaTuyen == id);
        }
    }
}
