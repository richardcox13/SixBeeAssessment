
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixBeeHealthTech.Data;
using SixBeeHealthTech.Models;

[Authorize]
public class AppointmentController : Controller {
    private readonly ApplicationDbContext _context;

    public AppointmentController(ApplicationDbContext context) {
        _context = context;
    }

    // GET: APPOINTMENTEDITMODELS
    public async Task<IActionResult> Index() {
        return View(await _context.Appointments.Select(a => new AppointmentEditModel(a)).ToListAsync());
    }

    // GET: APPOINTMENTEDITMODELS/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id is null) {
            return NotFound();
        }

        var appt = await _context.Appointments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (appt is null) {
            return NotFound();
        }

        return View(new AppointmentEditModel(appt));
    }

    // GET: APPOINTMENTEDITMODELS/Create
    [AllowAnonymous]
    public IActionResult Create() {
        return View();
    }

    // POST: APPOINTMENTEDITMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Create(AppointmentEditModel model) {
        if (ModelState.IsValid) {
            var appt = model.UpdateAppointment(new Appointment());

            _context.Add(appt);
            await _context.SaveChangesAsync();
            // Anon-users can't access appointment listing...
            return RedirectToAction(nameof(Index), "Home");
        }

        return View(model);
    }

    // GET: APPOINTMENTEDITMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id) {
        if (id == null) {
            return NotFound();
        }

        var appt = await _context.Appointments.FindAsync(id);
        if (appt == null) {
            return NotFound();
        }
        return View(new AppointmentEditModel(appt));
    }

    // POST: APPOINTMENTEDITMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, AppointmentEditModel model) {
        if (id != model.Id) {
            return NotFound();
        }

        if (ModelState.IsValid) {
            try {
                // We're not round tripping all the fields, so can't use DbSet<T>.Update!
                var appt = await _context.Appointments.SingleAsync(a => a.Id == id);
                model.UpdateAppointment(appt);

                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!AppointmentEditModelExists(model.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    // GET: APPOINTMENTEDITMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id) {
        if (id == null) {
            return NotFound();
        }

        var appointmenteditmodel = await _context.Appointments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (appointmenteditmodel == null) {
            return NotFound();
        }

        return View(appointmenteditmodel);
    }

    // POST: APPOINTMENTEDITMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id) {
        var appt = await _context.Appointments.FindAsync(id);
        if (appt != null) {
            _context.Appointments.Remove(appt);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AppointmentEditModelExists(int? id) {
        return _context.Appointments.Any(e => e.Id == id);
    }
}
