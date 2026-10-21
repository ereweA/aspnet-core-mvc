
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;

public class JokeClassController : Controller
{
    private readonly ApplicationDbContext _context;

    public JokeClassController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: JOKECLASSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.JokeClass.ToListAsync());
    }

    // GET: JOKECLASSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var jokeclass = await _context.JokeClass
            .FirstOrDefaultAsync(m => m.Id == id);
        if (jokeclass == null)
        {
            return NotFound();
        }

        return View(jokeclass);
    }

    // GET: JOKECLASSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: JOKECLASSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,JokeQuestion,JokeAnswer")] JokeClass jokeclass)
    {
        if (ModelState.IsValid)
        {
            _context.Add(jokeclass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(jokeclass);
    }

    // GET: JOKECLASSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var jokeclass = await _context.JokeClass.FindAsync(id);
        if (jokeclass == null)
        {
            return NotFound();
        }
        return View(jokeclass);
    }

    // POST: JOKECLASSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,JokeQuestion,JokeAnswer")] JokeClass jokeclass)
    {
        if (id != jokeclass.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(jokeclass);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokeClassExists(jokeclass.Id))
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
        return View(jokeclass);
    }

    // GET: JOKECLASSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var jokeclass = await _context.JokeClass
            .FirstOrDefaultAsync(m => m.Id == id);
        if (jokeclass == null)
        {
            return NotFound();
        }

        return View(jokeclass);
    }

    // POST: JOKECLASSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var jokeclass = await _context.JokeClass.FindAsync(id);
        if (jokeclass != null)
        {
            _context.JokeClass.Remove(jokeclass);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool JokeClassExists(int? id)
    {
        return _context.JokeClass.Any(e => e.Id == id);
    }
}
