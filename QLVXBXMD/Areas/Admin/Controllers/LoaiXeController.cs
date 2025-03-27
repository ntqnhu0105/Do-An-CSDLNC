using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.Data;
using QLVXBXMD.Models.System;

namespace QLVXBXMD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Quản lý")]
    public class LoaiXeController : Controller
    {
        private readonly AppDbContext _context;

        public LoaiXeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiXe (Danh sách loại xe)
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiXes.ToListAsync());
        }

        // GET: Admin/LoaiXe/Details/{id} (Xem chi tiết loại xe)
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiXe = await _context.LoaiXes.FirstOrDefaultAsync(lx => lx.MaLoai == id);
            if (loaiXe == null)
            {
                return NotFound();
            }

            return View(loaiXe);
        }

        // GET: Admin/LoaiXe/Create (Hiển thị form tạo mới)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiXe/Create (Tạo mới loại xe)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenLoai,MoTa,SoLuongGhe")] LoaiXe loaiXe)
        {
            ModelState.Remove("MaLoai");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                return View(loaiXe);
            }

            // Sinh MaLoai tự động
            var lastLoaiXe = await _context.LoaiXes.OrderByDescending(lx => lx.MaLoai).FirstOrDefaultAsync();
            int nextId = (lastLoaiXe != null && lastLoaiXe.MaLoai.StartsWith("LX") && int.TryParse(lastLoaiXe.MaLoai.Substring(2), out int parsedId))
                         ? parsedId + 1 : 1;
            loaiXe.MaLoai = $"LX{nextId:D4}";

            try
            {
                _context.Add(loaiXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi lưu dữ liệu: {ex.Message}");
                return View(loaiXe);
            }
        }

        // GET: Admin/LoaiXe/Edit/{id} (Hiển thị form chỉnh sửa)
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiXe = await _context.LoaiXes.FindAsync(id);
            if (loaiXe == null)
            {
                return NotFound();
            }
            return View(loaiXe);
        }

        // POST: Admin/LoaiXe/Edit/{id} (Cập nhật loại xe)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLoai,TenLoai,MoTa,SoLuongGhe")] LoaiXe loaiXe)
        {
            if (id != loaiXe.MaLoai)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                return View(loaiXe);
            }

            try
            {
                _context.Update(loaiXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiXeExists(loaiXe.MaLoai))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                return View(loaiXe);
            }
        }

        // GET: Admin/LoaiXe/Delete/{id} (Hiển thị xác nhận xóa)
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiXe = await _context.LoaiXes.FirstOrDefaultAsync(lx => lx.MaLoai == id);
            if (loaiXe == null)
            {
                return NotFound();
            }

            return View(loaiXe);
        }

        // POST: Admin/LoaiXe/Delete/{id} (Xóa loại xe)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loaiXe = await _context.LoaiXes.FindAsync(id);
            if (loaiXe == null)
            {
                return NotFound();
            }

            try
            {
                _context.LoaiXes.Remove(loaiXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi xóa: {ex.Message}");
                return View(loaiXe);
            }
        }
        private bool LoaiXeExists(string id)
        {
            return _context.LoaiXes.Any(lx => lx.MaLoai == id);
        }
    }
}
