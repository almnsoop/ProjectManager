
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;
using ProjectManager.Data;

public class TeamMembersController : Controller
{
    private readonly AppDbContext _context;

    public TeamMembersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: TEAMMEMBERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.TeamMembers.ToListAsync());
    }

    // GET: TEAMMEMBERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teammember = await _context.TeamMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (teammember == null)
        {
            return NotFound();
        }

        return View(teammember);
    }

    // GET: TEAMMEMBERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TEAMMEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Role,Tasks")] TeamMember teammember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(teammember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(teammember);
    }

    // GET: TEAMMEMBERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teammember = await _context.TeamMembers.FindAsync(id);
        if (teammember == null)
        {
            return NotFound();
        }
        return View(teammember);
    }

    // POST: TEAMMEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Role,Tasks")] TeamMember teammember)
    {
        if (id != teammember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(teammember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(teammember.Id))
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
        return View(teammember);
    }

    // GET: TEAMMEMBERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teammember = await _context.TeamMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (teammember == null)
        {
            return NotFound();
        }

        return View(teammember);
    }

    // POST: TEAMMEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var teammember = await _context.TeamMembers.FindAsync(id);
        if (teammember != null)
        {
            _context.TeamMembers.Remove(teammember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TeamMemberExists(int? id)
    {
        return _context.TeamMembers.Any(e => e.Id == id);
    }
}
