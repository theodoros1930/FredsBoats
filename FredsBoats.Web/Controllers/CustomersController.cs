using Microsoft.AspNetCore.Mvc;
using FredsBoats.Web.Models;
using FredsBoats.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace FredsBoats.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly FredsBoatsContext _context;
        public CustomersController(FredsBoatsContext context) => _context = context;

        // View List
        public async Task<IActionResult> Index() => View(await _context.Customers.ToListAsync());

        // Show Create Form
        public IActionResult Create() => View();

        // Process Create Form
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}