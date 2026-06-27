using DairyManagement.Data.Context;
using DairyManagement.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DairyManagement.UI.Controllers
{
    public class CustomerOrderController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerOrderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.CustomerOrders.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerOrder customerOrder)
        {
            _context.CustomerOrders.Add(customerOrder);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _context.CustomerOrders.Find(id);
            _context.CustomerOrders.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _context.CustomerOrders.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(CustomerOrder customerOrder)
        {
            _context.CustomerOrders.Update(customerOrder);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}