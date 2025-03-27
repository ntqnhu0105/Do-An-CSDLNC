using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.Data;
using QLVXBXMD.Models.System;

namespace QLVXBXMD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Quản lý")]
    public class XeController : Controller
    {
        private readonly AppDbContext _context;

        public XeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Xe (Danh sách xe)
        public async Task<IActionResult> Index()
        {
            var xes = await _context.Xes
                .Include(x => x.LoaiXe)
                .Include(x => x.NhaXe)
                .ToListAsync();
            return View(xes);
        }

        // GET: Admin/Xe/Details/{id} (Xem chi tiết xe)
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xe = await _context.Xes
                .Include(x => x.LoaiXe)
                .Include(x => x.NhaXe)
                .FirstOrDefaultAsync(x => x.MaXe == id);
            if (xe == null)
            {
                return NotFound();
            }

            return View(xe);
        }

        // GET: Admin/Xe/Create (Hiển thị form tạo mới)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
            ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
            return View();
        }

        // POST: Admin/Xe/Create (Tạo mới xe)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BienSoXe,MaLoai,MaNhaXe")] Xe xe)
        {
            ModelState.Remove("MaXe");
            ModelState.Remove("LoaiXe");
            ModelState.Remove("NhaXe");
            ModelState.Remove("SoGheSoGiuongs"); // Loại bỏ validation cho SoGheSoGiuongs

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(xe);
            }

            // Kiểm tra MaLoai và MaNhaXe
            if (!await _context.LoaiXes.AnyAsync(lx => lx.MaLoai == xe.MaLoai))
            {
                ModelState.AddModelError("MaLoai", "Mã loại xe không tồn tại.");
                ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(xe);
            }

            if (!await _context.NhaXes.AnyAsync(nx => nx.MaNhaXe == xe.MaNhaXe))
            {
                ModelState.AddModelError("MaNhaXe", "Mã nhà xe không tồn tại.");
                ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(xe);
            }

            // Sinh MaXe tự động
            var lastXe = await _context.Xes.OrderByDescending(x => x.MaXe).FirstOrDefaultAsync();
            int nextId = (lastXe != null && lastXe.MaXe.StartsWith("XE") && int.TryParse(lastXe.MaXe.Substring(2), out int parsedId))
                         ? parsedId + 1 : 1;
            xe.MaXe = $"XE{nextId:D4}";

            try
            {
                _context.Add(xe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi lưu dữ liệu: {ex.Message}");
                ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(xe);
            }
        }

        // GET: Admin/Xe/Edit/{id} (Hiển thị form chỉnh sửa)
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xe = await _context.Xes.FindAsync(id);
            if (xe == null)
            {
                return NotFound();
            }

            ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
            ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
            return View(xe);
        }

        // POST: Admin/Xe/Edit/{id} (Cập nhật xe)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaXe,BienSoXe,MaLoai,MaNhaXe")] Xe xe)
        {
            if (id != xe.MaXe)
            {
                return NotFound();
            }

            ModelState.Remove("LoaiXe");
            ModelState.Remove("NhaXe");
            ModelState.Remove("SoGheSoGiuongs"); // Loại bỏ validation cho SoGheSoGiuongs

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(xe);
            }

            if (!await _context.LoaiXes.AnyAsync(lx => lx.MaLoai == xe.MaLoai))
            {
                ModelState.AddModelError("MaLoai", "Mã loại xe không tồn tại.");
                ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(xe);
            }

            if (!await _context.NhaXes.AnyAsync(nx => nx.MaNhaXe == xe.MaNhaXe))
            {
                ModelState.AddModelError("MaNhaXe", "Mã nhà xe không tồn tại.");
                ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(xe);
            }

            try
            {
                _context.Update(xe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XeExists(xe.MaXe))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                ViewBag.LoaiXes = _context.LoaiXes.Select(lx => new { lx.MaLoai, lx.TenLoai }).ToList();
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(xe);
            }
        }

        // GET: Admin/Xe/Delete/{id} (Hiển thị xác nhận xóa)
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xe = await _context.Xes
                .Include(x => x.LoaiXe)
                .Include(x => x.NhaXe)
                .FirstOrDefaultAsync(x => x.MaXe == id);
            if (xe == null)
            {
                return NotFound();
            }

            return View(xe);
        }

        // POST: Admin/Xe/Delete/{id} (Xóa xe)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var xe = await _context.Xes.FindAsync(id);
            if (xe == null)
            {
                return NotFound();
            }

            try
            {
                _context.Xes.Remove(xe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi xóa: {ex.Message}");
                return View(xe);
            }
        }

        private bool XeExists(string id)
        {
            return _context.Xes.Any(x => x.MaXe == id);
        }
    }
}