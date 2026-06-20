using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Data;
using ProjectManager.Models;

public class WebsitesController : Controller
{
    private readonly AppDbContext _context;

    public WebsitesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: WEBSITES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Websites.ToListAsync());
    }

    // GET: WEBSITES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var website = await _context.Websites
            .FirstOrDefaultAsync(m => m.Id == id);
        if (website == null)
        {
            return NotFound();
        }

        return View(website);
    }

    // GET: WEBSITES/Create
    public IActionResult Create()
    {
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name");
        return View();
    }

    // POST: WEBSITES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    // مسحنا الكلمات الزائدة من الـ Bind
    public async Task<IActionResult> Create([Bind("Id,DomainName,IsHostingReady,Status,Deadline,ClientId")] Website website)
    {
        // نخبر النظام أن يتجاهل التحقق من هذه الخانات لأننا لا نرسلها من الشاشة
        ModelState.Remove("Client");
        ModelState.Remove("Tasks");

        if (ModelState.IsValid)
        {
            _context.Add(website);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // السطر السحري: إعادة تعبئة القائمة المنسدلة في حال وجود خطأ حتى لا تختفي!
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", website.ClientId);
        return View(website);
    }
    // POST: WEBSITES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,DomainName,IsHostingReady,Status,Deadline,ClientId,Client,Tasks")] Website website)
    {
        if (id != website.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(website);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteExists(website.Id))
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
        return View(website);
    }

    // GET: WEBSITES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var website = await _context.Websites
            .FirstOrDefaultAsync(m => m.Id == id);
        if (website == null)
        {
            return NotFound();
        }

        return View(website);
    }

    // POST: WEBSITES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var website = await _context.Websites.FindAsync(id);
        if (website != null)
        {
            _context.Websites.Remove(website);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool WebsiteExists(int? id)
    {
        return _context.Websites.Any(e => e.Id == id);
    }
}
