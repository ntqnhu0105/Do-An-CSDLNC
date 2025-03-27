using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.Data;
using QLVXBXMD.Models.System;

namespace QLVXBXMD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Quản lý")]
    public class ChuyenXeController : Controller
    {
        private readonly AppDbContext _context;
        public ChuyenXeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChuyenXe (Danh sách chuyến xe)
        public async Task<IActionResult> Index()
        {
            var chuyenXes = await _context.ChuyenXes
                .Include(cx => cx.TuyenXe)
                .Include(cx => cx.Xe)
                .ToListAsync();
            return View(chuyenXes);
        }

        // GET: Admin/ChuyenXe/Details/{id} (Xem chi tiết chuyến xe)
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXes
                .Include(cx => cx.TuyenXe)
                .Include(cx => cx.Xe)
                .FirstOrDefaultAsync(cx => cx.MaChuyen == id);
            if (chuyenXe == null)
            {
                return NotFound();
            }

            return View(chuyenXe);
        }

        // GET: Admin/ChuyenXe/Create (Hiển thị form tạo mới)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
            ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
            return View();
        }

        // POST: Admin/ChuyenXe/Create (Tạo mới chuyến xe)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTuyen,MaXe,NgayKhoiHanh,GioKhoiHanh,Gia,TrangThai")] ChuyenXe chuyenXe)
        {
            ModelState.Remove("MaChuyen");
            ModelState.Remove("TuyenXe");
            ModelState.Remove("Xe");
            ModelState.Remove("ChuyenXeDiems"); // Loại bỏ validation cho ChuyenXeDiems
            ModelState.Remove("SoGheSoGiuongs"); // Loại bỏ validation cho SoGheSoGiuongs

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
                return View(chuyenXe);
            }

            // Kiểm tra MaTuyen và MaXe
            if (!await _context.TuyenXes.AnyAsync(tx => tx.MaTuyen == chuyenXe.MaTuyen))
            {
                ModelState.AddModelError("MaTuyen", "Mã tuyến không tồn tại.");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
                return View(chuyenXe);
            }

            if (!await _context.Xes.AnyAsync(x => x.MaXe == chuyenXe.MaXe))
            {
                ModelState.AddModelError("MaXe", "Mã xe không tồn tại.");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
                return View(chuyenXe);
            }

            // Sinh MaChuyen tự động
            var lastChuyen = await _context.ChuyenXes.OrderByDescending(cx => cx.MaChuyen).FirstOrDefaultAsync();
            int nextId = (lastChuyen != null && lastChuyen.MaChuyen.StartsWith("CX") && int.TryParse(lastChuyen.MaChuyen.Substring(2), out int parsedId))
                         ? parsedId + 1 : 1;
            chuyenXe.MaChuyen = $"CX{nextId:D4}";

            try
            {
                _context.Add(chuyenXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi lưu dữ liệu: {ex.Message}");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
                return View(chuyenXe);
            }
        }

        // GET: Admin/ChuyenXe/Edit/{id} (Hiển thị form chỉnh sửa)
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXes.FindAsync(id);
            if (chuyenXe == null)
            {
                return NotFound();
            }

            ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
            ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
            return View(chuyenXe);
        }

        // POST: Admin/ChuyenXe/Edit/{id} (Cập nhật chuyến xe)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChuyen,MaTuyen,MaXe,NgayKhoiHanh,GioKhoiHanh,Gia,TrangThai")] ChuyenXe chuyenXe)
        {
            if (id != chuyenXe.MaChuyen)
            {
                return NotFound();
            }

            ModelState.Remove("TuyenXe");
            ModelState.Remove("Xe");
            ModelState.Remove("ChuyenXeDiems"); // Loại bỏ validation cho ChuyenXeDiems
            ModelState.Remove("SoGheSoGiuongs"); // Loại bỏ validation cho SoGheSoGiuongs

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
                return View(chuyenXe);
            }

            if (!await _context.TuyenXes.AnyAsync(tx => tx.MaTuyen == chuyenXe.MaTuyen))
            {
                ModelState.AddModelError("MaTuyen", "Mã tuyến không tồn tại.");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
                return View(chuyenXe);
            }

            if (!await _context.Xes.AnyAsync(x => x.MaXe == chuyenXe.MaXe))
            {
                ModelState.AddModelError("MaXe", "Mã xe không tồn tại.");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
                return View(chuyenXe);
            }

            try
            {
                _context.Update(chuyenXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuyenXeExists(chuyenXe.MaChuyen))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                ViewBag.TuyenXes = _context.TuyenXes.Select(tx => new { tx.MaTuyen, Display = $"{tx.DiemDi} - {tx.DiemDen}" }).ToList();
                ViewBag.Xes = _context.Xes.Select(x => new { x.MaXe, x.BienSoXe }).ToList();
                return View(chuyenXe);
            }
        }

        // GET: Admin/ChuyenXe/Delete/{id} (Hiển thị xác nhận xóa)
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXes
                .Include(cx => cx.TuyenXe)
                .Include(cx => cx.Xe)
                .FirstOrDefaultAsync(cx => cx.MaChuyen == id);
            if (chuyenXe == null)
            {
                return NotFound();
            }

            return View(chuyenXe);
        }

        // POST: Admin/ChuyenXe/Delete/{id} (Xóa chuyến xe)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chuyenXe = await _context.ChuyenXes.FindAsync(id);
            if (chuyenXe == null)
            {
                return NotFound();
            }

            try
            {
                _context.ChuyenXes.Remove(chuyenXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi xóa: {ex.Message}");
                return View(chuyenXe);
            }
        }

        private bool ChuyenXeExists(string id)
        {
            return _context.ChuyenXes.Any(cx => cx.MaChuyen == id);
        }
    }
}