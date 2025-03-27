using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.Data;
using QLVXBXMD.Models.System;

namespace QLVXBXMD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Quản lý")]
    public class ChuyenXeDiemController : Controller
    {
        private readonly AppDbContext _context;

        public ChuyenXeDiemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChuyenXeDiem (Danh sách chuyến xe - điểm)
        public async Task<IActionResult> Index()
        {
            var chuyenXeDiems = await _context.ChuyenXeDiems
                .Include(cxd => cxd.ChuyenXe)
                .Include(cxd => cxd.Diem)
                .ToListAsync();
            return View(chuyenXeDiems);
        }

        // GET: Admin/ChuyenXeDiem/Details/{maChuyen}/{maDiem} (Xem chi tiết)
        [HttpGet]
        public async Task<IActionResult> Details(string maChuyen, string maDiem)
        {
            if (maChuyen == null || maDiem == null)
            {
                return NotFound();
            }

            var chuyenXeDiem = await _context.ChuyenXeDiems
                .Include(cxd => cxd.ChuyenXe)
                .Include(cxd => cxd.Diem)
                .FirstOrDefaultAsync(cxd => cxd.MaChuyen == maChuyen && cxd.MaDiem == maDiem);
            if (chuyenXeDiem == null)
            {
                return NotFound();
            }

            return View(chuyenXeDiem);
        }

        // GET: Admin/ChuyenXeDiem/Create (Hiển thị form tạo mới)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ChuyenXes = _context.ChuyenXes
                .Include(cx => cx.TuyenXe)
                .Select(cx => new { cx.MaChuyen, Display = $"{cx.MaChuyen} ({cx.TuyenXe.DiemDi} - {cx.TuyenXe.DiemDen})" })
                .ToList();
            ViewBag.Diems = _context.Diems.Select(d => new { d.MaDiem, d.TenDiem }).ToList();
            return View();
        }

        // POST: Admin/ChuyenXeDiem/Create (Tạo mới chuyến xe - điểm)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChuyen,MaDiem,ThoiGianDuKien")] ChuyenXeDiem chuyenXeDiem)
        {
            ModelState.Remove("ChuyenXe");
            ModelState.Remove("Diem");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.ChuyenXes = _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .Select(cx => new { cx.MaChuyen, Display = $"{cx.MaChuyen} ({cx.TuyenXe.DiemDi} - {cx.TuyenXe.DiemDen})" })
                    .ToList();
                ViewBag.Diems = _context.Diems.Select(d => new { d.MaDiem, d.TenDiem }).ToList();
                return View(chuyenXeDiem);
            }

            // Kiểm tra MaChuyen và MaDiem
            if (!await _context.ChuyenXes.AnyAsync(cx => cx.MaChuyen == chuyenXeDiem.MaChuyen))
            {
                ModelState.AddModelError("MaChuyen", "Mã chuyến không tồn tại.");
                ViewBag.ChuyenXes = _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .Select(cx => new { cx.MaChuyen, Display = $"{cx.MaChuyen} ({cx.TuyenXe.DiemDi} - {cx.TuyenXe.DiemDen})" })
                    .ToList();
                ViewBag.Diems = _context.Diems.Select(d => new { d.MaDiem, d.TenDiem }).ToList();
                return View(chuyenXeDiem);
            }

            if (!await _context.Diems.AnyAsync(d => d.MaDiem == chuyenXeDiem.MaDiem))
            {
                ModelState.AddModelError("MaDiem", "Mã điểm không tồn tại.");
                ViewBag.ChuyenXes = _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .Select(cx => new { cx.MaChuyen, Display = $"{cx.MaChuyen} ({cx.TuyenXe.DiemDi} - {cx.TuyenXe.DiemDen})" })
                    .ToList();
                ViewBag.Diems = _context.Diems.Select(d => new { d.MaDiem, d.TenDiem }).ToList();
                return View(chuyenXeDiem);
            }

            // Kiểm tra trùng lặp
            if (await _context.ChuyenXeDiems.AnyAsync(cxd => cxd.MaChuyen == chuyenXeDiem.MaChuyen && cxd.MaDiem == chuyenXeDiem.MaDiem))
            {
                ModelState.AddModelError("", "Chuyến xe này đã được liên kết với điểm này.");
                ViewBag.ChuyenXes = _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .Select(cx => new { cx.MaChuyen, Display = $"{cx.MaChuyen} ({cx.TuyenXe.DiemDi} - {cx.TuyenXe.DiemDen})" })
                    .ToList();
                ViewBag.Diems = _context.Diems.Select(d => new { d.MaDiem, d.TenDiem }).ToList();
                return View(chuyenXeDiem);
            }

            try
            {
                _context.Add(chuyenXeDiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi lưu dữ liệu: {ex.Message}");
                ViewBag.ChuyenXes = _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .Select(cx => new { cx.MaChuyen, Display = $"{cx.MaChuyen} ({cx.TuyenXe.DiemDi} - {cx.TuyenXe.DiemDen})" })
                    .ToList();
                ViewBag.Diems = _context.Diems.Select(d => new { d.MaDiem, d.TenDiem }).ToList();
                return View(chuyenXeDiem);
            }
        }

        // GET: Admin/ChuyenXeDiem/Edit/{maChuyen}/{maDiem} (Hiển thị form chỉnh sửa)
        [HttpGet]
        public async Task<IActionResult> Edit(string maChuyen, string maDiem)
        {
            if (maChuyen == null || maDiem == null)
            {
                return NotFound();
            }

            var chuyenXeDiem = await _context.ChuyenXeDiems
                .FirstOrDefaultAsync(cxd => cxd.MaChuyen == maChuyen && cxd.MaDiem == maDiem);
            if (chuyenXeDiem == null)
            {
                return NotFound();
            }

            // Lấy thông tin hiển thị từ database
            var chuyenXe = await _context.ChuyenXes
                .Include(cx => cx.TuyenXe)
                .FirstOrDefaultAsync(cx => cx.MaChuyen == chuyenXeDiem.MaChuyen);
            ViewBag.SelectedChuyenXeDisplay = chuyenXe != null
                ? $"{chuyenXe.MaChuyen} ({chuyenXe.TuyenXe.DiemDi} - {chuyenXe.TuyenXe.DiemDen})"
                : chuyenXeDiem.MaChuyen;

            var diem = await _context.Diems
                .FirstOrDefaultAsync(d => d.MaDiem == chuyenXeDiem.MaDiem);
            ViewBag.SelectedDiemDisplay = diem != null ? diem.TenDiem : chuyenXeDiem.MaDiem;

            return View(chuyenXeDiem);
        }

        // POST: Admin/ChuyenXeDiem/Edit/{maChuyen}/{maDiem} (Cập nhật chuyến xe - điểm)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string maChuyen, string maDiem, [Bind("MaChuyen,MaDiem,ThoiGianDuKien")] ChuyenXeDiem chuyenXeDiem)
        {
            if (maChuyen != chuyenXeDiem.MaChuyen || maDiem != chuyenXeDiem.MaDiem)
            {
                return NotFound();
            }

            ModelState.Remove("ChuyenXe");
            ModelState.Remove("Diem");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                // Lấy thông tin hiển thị từ database khi validation thất bại
                var chuyenXe = await _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .FirstOrDefaultAsync(cx => cx.MaChuyen == chuyenXeDiem.MaChuyen);
                ViewBag.SelectedChuyenXeDisplay = chuyenXe != null
                    ? $"{chuyenXe.MaChuyen} ({chuyenXe.TuyenXe.DiemDi} - {chuyenXe.TuyenXe.DiemDen})"
                    : chuyenXeDiem.MaChuyen;

                var diem = await _context.Diems
                    .FirstOrDefaultAsync(d => d.MaDiem == chuyenXeDiem.MaDiem);
                ViewBag.SelectedDiemDisplay = diem != null ? diem.TenDiem : chuyenXeDiem.MaDiem;

                return View(chuyenXeDiem);
            }

            if (!await _context.ChuyenXes.AnyAsync(cx => cx.MaChuyen == chuyenXeDiem.MaChuyen))
            {
                ModelState.AddModelError("MaChuyen", "Mã chuyến không tồn tại.");
                var chuyenXe = await _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .FirstOrDefaultAsync(cx => cx.MaChuyen == chuyenXeDiem.MaChuyen);
                ViewBag.SelectedChuyenXeDisplay = chuyenXe != null
                    ? $"{chuyenXe.MaChuyen} ({chuyenXe.TuyenXe.DiemDi} - {chuyenXe.TuyenXe.DiemDen})"
                    : chuyenXeDiem.MaChuyen;

                var diem = await _context.Diems
                    .FirstOrDefaultAsync(d => d.MaDiem == chuyenXeDiem.MaDiem);
                ViewBag.SelectedDiemDisplay = diem != null ? diem.TenDiem : chuyenXeDiem.MaDiem;

                return View(chuyenXeDiem);
            }

            if (!await _context.Diems.AnyAsync(d => d.MaDiem == chuyenXeDiem.MaDiem))
            {
                ModelState.AddModelError("MaDiem", "Mã điểm không tồn tại.");
                var chuyenXe = await _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .FirstOrDefaultAsync(cx => cx.MaChuyen == chuyenXeDiem.MaChuyen);
                ViewBag.SelectedChuyenXeDisplay = chuyenXe != null
                    ? $"{chuyenXe.MaChuyen} ({chuyenXe.TuyenXe.DiemDi} - {chuyenXe.TuyenXe.DiemDen})"
                    : chuyenXeDiem.MaChuyen;

                var diem = await _context.Diems
                    .FirstOrDefaultAsync(d => d.MaDiem == chuyenXeDiem.MaDiem);
                ViewBag.SelectedDiemDisplay = diem != null ? diem.TenDiem : chuyenXeDiem.MaDiem;

                return View(chuyenXeDiem);
            }

            try
            {
                _context.Update(chuyenXeDiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuyenXeDiemExists(chuyenXeDiem.MaChuyen, chuyenXeDiem.MaDiem))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                var chuyenXe = await _context.ChuyenXes
                    .Include(cx => cx.TuyenXe)
                    .FirstOrDefaultAsync(cx => cx.MaChuyen == chuyenXeDiem.MaChuyen);
                ViewBag.SelectedChuyenXeDisplay = chuyenXe != null
                    ? $"{chuyenXe.MaChuyen} ({chuyenXe.TuyenXe.DiemDi} - {chuyenXe.TuyenXe.DiemDen})"
                    : chuyenXeDiem.MaChuyen;

                var diem = await _context.Diems
                    .FirstOrDefaultAsync(d => d.MaDiem == chuyenXeDiem.MaDiem);
                ViewBag.SelectedDiemDisplay = diem != null ? diem.TenDiem : chuyenXeDiem.MaDiem;

                return View(chuyenXeDiem);
            }
        }

        // GET: Admin/ChuyenXeDiem/Delete/{maChuyen}/{maDiem} (Hiển thị xác nhận xóa)
        [HttpGet]
        public async Task<IActionResult> Delete(string maChuyen, string maDiem)
        {
            if (maChuyen == null || maDiem == null)
            {
                return NotFound();
            }

            var chuyenXeDiem = await _context.ChuyenXeDiems
                .Include(cxd => cxd.ChuyenXe)
                .Include(cxd => cxd.Diem)
                .FirstOrDefaultAsync(cxd => cxd.MaChuyen == maChuyen && cxd.MaDiem == maDiem);
            if (chuyenXeDiem == null)
            {
                return NotFound();
            }

            return View(chuyenXeDiem);
        }

        // POST: Admin/ChuyenXeDiem/Delete/{maChuyen}/{maDiem} (Xóa chuyến xe - điểm)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string maChuyen, string maDiem)
        {
            var chuyenXeDiem = await _context.ChuyenXeDiems
                .FirstOrDefaultAsync(cxd => cxd.MaChuyen == maChuyen && cxd.MaDiem == maDiem);
            if (chuyenXeDiem == null)
            {
                return NotFound();
            }

            try
            {
                _context.ChuyenXeDiems.Remove(chuyenXeDiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi xóa: {ex.Message}");
                return View(chuyenXeDiem);
            }
        }
        private bool ChuyenXeDiemExists(string maChuyen, string maDiem)
        {
            return _context.ChuyenXeDiems.Any(cxd => cxd.MaChuyen == maChuyen && cxd.MaDiem == maDiem);
        }
    }
}