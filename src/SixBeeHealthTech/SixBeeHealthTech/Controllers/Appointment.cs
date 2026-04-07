
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixBeeHealthTech.Models;
using SixBeeHealthTech.Data;

public class Appointment : Controller
{
    private readonly ApplicationDbContext _context;

    public Appointment(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: APPOINTMENTEDITMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.AppointmentEditModel.ToListAsync());
    }

    // GET: APPOINTMENTEDITMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var appointmenteditmodel = await _context.AppointmentEditModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (appointmenteditmodel == null)
        {
            return NotFound();
        }

        return View(appointmenteditmodel);
    }

    // GET: APPOINTMENTEDITMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: APPOINTMENTEDITMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Genre,Price")] AppointmentEditModel appointmenteditmodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(appointmenteditmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(appointmenteditmodel);
    }

    // GET: APPOINTMENTEDITMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var appointmenteditmodel = await _context.AppointmentEditModel.FindAsync(id);
        if (appointmenteditmodel == null)
        {
            return NotFound();
        }
        return View(appointmenteditmodel);
    }

    // POST: APPOINTMENTEDITMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,ReleaseDate,Genre,Price")] AppointmentEditModel appointmenteditmodel)
    {
        if (id != appointmenteditmodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(appointmenteditmodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentEditModelExists(appointmenteditmodel.Id))
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
        return View(appointmenteditmodel);
    }

    // GET: APPOINTMENTEDITMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var appointmenteditmodel = await _context.AppointmentEditModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (appointmenteditmodel == null)
        {
            return NotFound();
        }

        return View(appointmenteditmodel);
    }

    // POST: APPOINTMENTEDITMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var appointmenteditmodel = await _context.AppointmentEditModel.FindAsync(id);
        if (appointmenteditmodel != null)
        {
            _context.AppointmentEditModel.Remove(appointmenteditmodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AppointmentEditModelExists(int? id)
    {
        return _context.AppointmentEditModel.Any(e => e.Id == id);
    }
}
