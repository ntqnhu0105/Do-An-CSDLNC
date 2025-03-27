using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.Data;
using QLVXBXMD.Models.System;

namespace QLVXBXMD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Quản lý")]
    public class DiemController : Controller
    {
        private readonly AppDbContext _context;

        public DiemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Diem (Danh sách điểm)
        public async Task<IActionResult> Index()
        {
            var diems = await _context.Diems
                .Include(d => d.TuyenXe)
                .ToListAsync();
            return View(diems);
        }

        // GET: Admin/Diem/Details/{id} (Xem chi tiết điểm)
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diems
                .Include(d => d.TuyenXe)
                .FirstOrDefaultAsync(d => d.MaDiem == id);
            if (diem == null)
            {
                return NotFound();
            }

            return View(diem);
        }

        // GET: Admin/Diem/Create (Hiển thị form tạo mới)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
            return View();
        }

        // POST: Admin/Diem/Create (Tạo mới điểm)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenDiem,DiaChi,MaTuyen,LoaiDiem,ToaDoGPS")] Diem diem)
        {
            ModelState.Remove("MaDiem");
            ModelState.Remove("TuyenXe");
            ModelState.Remove("ChuyenXeDiems"); // Loại bỏ validation cho ChuyenXeDiems

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                return View(diem);
            }

            // Kiểm tra MaTuyen
            if (!await _context.TuyenXes.AnyAsync(tx => tx.MaTuyen == diem.MaTuyen))
            {
                ModelState.AddModelError("MaTuyen", "Mã tuyến không tồn tại.");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                return View(diem);
            }

            // Sinh MaDiem tự động
            var lastDiem = await _context.Diems.OrderByDescending(d => d.MaDiem).FirstOrDefaultAsync();
            int nextId = (lastDiem != null && lastDiem.MaDiem.StartsWith("D") && int.TryParse(lastDiem.MaDiem.Substring(1), out int parsedId))
                         ? parsedId + 1 : 1;
            diem.MaDiem = $"D{nextId:D4}";

            try
            {
                _context.Add(diem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi lưu dữ liệu: {ex.Message}");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                return View(diem);
            }
        }

        // GET: Admin/Diem/Edit/{id} (Hiển thị form chỉnh sửa)
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diems.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }

            ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
            return View(diem);
        }

        // POST: Admin/Diem/Edit/{id} (Cập nhật điểm)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDiem,TenDiem,DiaChi,MaTuyen,LoaiDiem,ToaDoGPS")] Diem diem)
        {
            if (id != diem.MaDiem)
            {
                return NotFound();
            }

            ModelState.Remove("TuyenXe");
            ModelState.Remove("ChuyenXeDiems"); // Loại bỏ validation cho ChuyenXeDiems

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                return View(diem);
            }

            if (!await _context.TuyenXes.AnyAsync(tx => tx.MaTuyen == diem.MaTuyen))
            {
                ModelState.AddModelError("MaTuyen", "Mã tuyến không tồn tại.");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                return View(diem);
            }

            try
            {
                _context.Update(diem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiemExists(diem.MaDiem))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                return View(diem);
            }
        }

        // GET: Admin/Diem/Delete/{id} (Hiển thị xác nhận xóa)
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diems
                .Include(d => d.TuyenXe)
                .FirstOrDefaultAsync(d => d.MaDiem == id);
            if (diem == null)
            {
                return NotFound();
            }

            return View(diem);
        }

        // POST: Admin/Diem/Delete/{id} (Xóa điểm)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diem = await _context.Diems.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }

            try
            {
                _context.Diems.Remove(diem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi xóa: {ex.Message}");
                return View(diem);
            }
        }

        private bool DiemExists(string id)
        {
            return _context.Diems.Any(d => d.MaDiem == id);
        }
    }
}