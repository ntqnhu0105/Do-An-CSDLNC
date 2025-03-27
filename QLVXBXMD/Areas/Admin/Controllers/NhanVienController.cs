using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.Data;
using QLVXBXMD.Models.System;

namespace QLVXBXMD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Quản lý")]
    public class NhanVienController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public NhanVienController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var nhanViens = await _context.NhanViens.ToListAsync();
            return View(nhanViens);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(nv => nv.NhaXe)
                .FirstOrDefaultAsync(nv => nv.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.NhaXes = _context.NhaXes
                .Select(nx => new { nx.MaNhaXe, nx.TenNhaXe })
                .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NhanVien model)
        {
            // Loại bỏ MaNV và NhaXe khỏi validation
            ModelState.Remove("MaNV");
            ModelState.Remove("NhaXe");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(model);
            }

            // Kiểm tra MaNhaXe
            if (!await _context.NhaXes.AnyAsync(nx => nx.MaNhaXe == model.MaNhaXe))
            {
                ModelState.AddModelError("MaNhaXe", "Mã nhà xe không tồn tại.");
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(model);
            }

            // Tạo nhân viên
            var nhanVien = new NhanVien
            {
                MaNV = Guid.NewGuid().ToString(),
                HovaTen = model.HovaTen,
                CCCD = model.CCCD,
                SDT = model.SDT,
                Email = model.Email,
                DiaChi = model.DiaChi,
                NgaySinh = model.NgaySinh,
                MaNhaXe = model.MaNhaXe,
                ChucVu = model.ChucVu
            };

            try
            {
                _context.NhanViens.Add(nhanVien);
                await _context.SaveChangesAsync();

                // Tạo tài khoản Identity
                if (!string.IsNullOrEmpty(model.Email))
                {
                    var user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FullName = model.HovaTen,
                        CCCD = model.CCCD,
                        SDT = model.SDT,
                        EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(user, "NhanVien@123");
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", $"Lỗi tạo tài khoản: {error.Description}");
                        }
                        ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                        return View(model);
                    }

                    await _userManager.AddToRoleAsync(user, "Nhân viên");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi lưu dữ liệu: {ex.Message}");
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            ViewBag.NhaXes = _context.NhaXes
                .Select(nx => new { nx.MaNhaXe, nx.TenNhaXe })
                .ToList();
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Edit/{id} (Cập nhật nhân viên)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,HovaTen,CCCD,SDT,Email,DiaChi,NgaySinh,MaNhaXe,ChucVu")] NhanVien model)
        {
            if (id != model.MaNV)
            {
                return NotFound();
            }

            ModelState.Remove("NhaXe");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", $"Lỗi: {error.ErrorMessage}");
                }
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(model);
            }

            if (!await _context.NhaXes.AnyAsync(nx => nx.MaNhaXe == model.MaNhaXe))
            {
                ModelState.AddModelError("MaNhaXe", "Mã nhà xe không tồn tại.");
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(model);
            }

            try
            {
                var nhanVien = await _context.NhanViens.FindAsync(id);
                if (nhanVien == null)
                {
                    return NotFound();
                }

                nhanVien.HovaTen = model.HovaTen;
                nhanVien.CCCD = model.CCCD;
                nhanVien.SDT = model.SDT;
                nhanVien.Email = model.Email;
                nhanVien.DiaChi = model.DiaChi;
                nhanVien.NgaySinh = model.NgaySinh;
                nhanVien.MaNhaXe = model.MaNhaXe;
                nhanVien.ChucVu = model.ChucVu;

                _context.Update(nhanVien);
                await _context.SaveChangesAsync();

                // Cập nhật tài khoản Identity nếu email thay đổi
                if (!string.IsNullOrEmpty(model.Email))
                {
                    var user = await _userManager.FindByEmailAsync(nhanVien.Email);
                    if (user != null)
                    {
                        user.FullName = model.HovaTen;
                        user.CCCD = model.CCCD;
                        user.SDT = model.SDT;
                        await _userManager.UpdateAsync(user);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(model.MaNV))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                ViewBag.NhaXes = _context.NhaXes.Select(nx => new { nx.MaNhaXe, nx.TenNhaXe }).ToList();
                return View(model);
            }
        }

        // GET: Admin/NhanVien/Delete/{id} (Hiển thị xác nhận xóa)
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(nv => nv.NhaXe)
                .FirstOrDefaultAsync(nv => nv.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Delete/{id} (Xóa nhân viên)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            try
            {
                _context.NhanViens.Remove(nhanVien);
                await _context.SaveChangesAsync();

                // Xóa tài khoản Identity nếu có
                if (!string.IsNullOrEmpty(nhanVien.Email))
                {
                    var user = await _userManager.FindByEmailAsync(nhanVien.Email);
                    if (user != null)
                    {
                        await _userManager.DeleteAsync(user);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi xóa: {ex.Message}");
                return View(nhanVien);
            }
        }

        private bool NhanVienExists(string id)
        {
            return _context.NhanViens.Any(nv => nv.MaNV == id);
        }
    }
}
