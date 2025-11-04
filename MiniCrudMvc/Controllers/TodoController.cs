using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCrudMvc.Models;

namespace MiniCrudMvc.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        //READ
        public async Task<IActionResult> Index()
        {
            var items = await _context.TodoItems.ToListAsync();
            return View(items);
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        //CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItem item)
        {
            if (!ModelState.IsValid) return View(item);

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //UPDATE
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        //UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoItem item)
        {
            if (id != item.Id) return BadRequest();

            if (!ModelState.IsValid) return View(item);

            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        //DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //READ
        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }
    }
}
