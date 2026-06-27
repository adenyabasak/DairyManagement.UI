using DairyManagement.Data.Context;
using DairyManagement.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DairyManagement.UI.Controllers
{
    public class SupplierController : Controller
    {
        private readonly AppDbContext _context;

        public SupplierController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Suppliers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _context.Suppliers.Find(id);
            _context.Suppliers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _context.Suppliers.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}