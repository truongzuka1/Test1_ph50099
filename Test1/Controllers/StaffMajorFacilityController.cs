using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test1.Models;
using Test1.ViewModel;

namespace Test1.Controllers
{
    public class StaffMajorFacilityController : Controller
    {
        private readonly AppDbContext _context;

        public StaffMajorFacilityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StaffMajorFacility
        public async Task<IActionResult> Index()
        {
            var data = await _context.StaffMajorFacilities
                .Include(smf => smf.IdStaffNavigation)
                .Include(smf => smf.IdMajorFacilityNavigation)
                    .ThenInclude(mf => mf.IdMajorNavigation)
                .Include(smf => smf.IdMajorFacilityNavigation)
                    .ThenInclude(mf => mf.IdDepartmentFacilityNavigation)
                        .ThenInclude(df => df.IdFacilityNavigation)
                .Select(smf => new StaffMajorFacilityViewModel
                {
                    Id = smf.Id,
                    StaffName = smf.IdStaffNavigation != null ? smf.IdStaffNavigation.Name : "N/A",
                    MajorName = smf.IdMajorFacilityNavigation != null && smf.IdMajorFacilityNavigation.IdMajorNavigation != null
                        ? smf.IdMajorFacilityNavigation.IdMajorNavigation.Name
                        : "N/A",
                    FacilityName = smf.IdMajorFacilityNavigation != null &&
                                   smf.IdMajorFacilityNavigation.IdDepartmentFacilityNavigation != null &&
                                   smf.IdMajorFacilityNavigation.IdDepartmentFacilityNavigation.IdFacilityNavigation != null
                        ? smf.IdMajorFacilityNavigation.IdDepartmentFacilityNavigation.IdFacilityNavigation.Name
                        : "N/A"
                })
                .ToListAsync();

            // ⚠️ THÊM ĐỦ 2 ViewBag để view dùng
            ViewBag.Staffs = await _context.Staff.ToListAsync();
            ViewBag.MajorFacilities = await _context.MajorFacilities
                .Include(mf => mf.IdMajorNavigation)
                .Include(mf => mf.IdDepartmentFacilityNavigation)
                    .ThenInclude(df => df.IdFacilityNavigation)
                .ToListAsync();

            return View(data);
        }



        // GET: StaffMajorFacility/Create
        public IActionResult Create()
        {
            ViewBag.Staffs = _context.Staff.ToList();
            ViewBag.MajorFacilities = _context.MajorFacilities
                .Include(mf => mf.IdMajorNavigation)
                .Include(mf => mf.IdDepartmentFacilityNavigation)
                    .ThenInclude(df => df.IdFacilityNavigation)
                .ToList();

            return View();
        }

        // POST: StaffMajorFacility/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid idStaff, Guid idMajorFacility)
        {
            var staffMajorFacility = new StaffMajorFacility
            {
                Id = Guid.NewGuid(),
                IdStaff = idStaff,
                IdMajorFacility = idMajorFacility,
                CreatedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Status = 1
            };

            _context.Add(staffMajorFacility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: StaffMajorFacility/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var smf = await _context.StaffMajorFacilities
                .Include(s => s.IdStaffNavigation)
                .Include(s => s.IdMajorFacilityNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (smf == null) return NotFound();

            return View(smf);
        }

        // POST: StaffMajorFacility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var smf = await _context.StaffMajorFacilities.FindAsync(id);
            if (smf != null)
            {
                _context.StaffMajorFacilities.Remove(smf);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
