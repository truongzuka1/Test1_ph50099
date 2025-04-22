using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Test1.Models;
using Test1.ViewModel;

namespace Test1.Controllers
{
    public class StaffController : Controller
    {
        private readonly AppDbContext _context;

        public StaffController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            var data = await _context.Staff
                .ToListAsync();

            var staffList = data.Select(staff => new StaffViewModel
            {
                Id = staff.Id,
                Name = staff.Name,
                StaffCode = staff.StaffCode,
                AccountFe = staff.AccountFe,
                AccountFpt = staff.AccountFpt,
                Status = staff.Status
            }).ToList();

            return View(staffList);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return PartialView("_CreateStaffModal", new StaffViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffViewModel model)
        {
            if (ModelState.IsValid)
            {
                var staff = new Staff
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    StaffCode = model.StaffCode,
                    AccountFe = model.AccountFe,
                    AccountFpt = model.AccountFpt,
                    CreatedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    LastModifiedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    Status = 1
                };

                _context.Staff.Add(staff);
                await _context.SaveChangesAsync();

                // Trả về JSON với thông báo thành công
                return Json(new { success = true, message = "Thêm nhân viên thành công!" });
            }

            // Trả về lỗi nếu ModelState không hợp lệ
            return Json(new { success = false, errors = GetModelStateErrors() });
        }


        // GET: Staff/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null) return NotFound();

            var model = new StaffViewModel
            {
                Id = staff.Id,
                Name = staff.Name,
                StaffCode = staff.StaffCode,
                AccountFe = staff.AccountFe,
                AccountFpt = staff.AccountFpt,
                Status = staff.Status
            };

            return Json(model); // Trả về dữ liệu dưới dạng JSON cho Ajax
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StaffViewModel model)
        {
            if (ModelState.IsValid)
            {
                var staff = await _context.Staff.FindAsync(model.Id);
                if (staff == null)
                {
                    return NotFound();
                }

                // Cập nhật thông tin nhân viên
                staff.Name = model.Name;
                staff.StaffCode = model.StaffCode;
                staff.AccountFe = model.AccountFe;
                staff.AccountFpt = model.AccountFpt;
                staff.Status = model.Status;
                staff.LastModifiedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                _context.Staff.Update(staff);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Cập nhật nhân viên thành công!" });
            }

            return Json(new { success = false, message = "Có lỗi khi cập nhật thông tin!" });
        }


        // POST: Staff/UpdateStatus
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(Guid id, byte status)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null) return NotFound();

            staff.Status = status;
            staff.LastModifiedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Staff/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null) return NotFound();

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // Phương thức để lấy lỗi từ ModelState
        private Dictionary<string, string> GetModelStateErrors()
        {
            var errors = new Dictionary<string, string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    // Nếu trường này đã có lỗi, sẽ ghi lỗi vào dictionary
                    if (!errors.ContainsKey(state.Key))
                    {
                        errors[state.Key] = error.ErrorMessage;
                    }
                }
            }
            return errors;
        }

    }
}
