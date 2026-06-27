using ClosedXML.Excel;
using DairyManagement.Data.Context;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace DairyManagement.UI.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.CategoryCount = _context.Categories.Count();
            ViewBag.ProductCount = _context.Products.Count();
            ViewBag.SupplierCount = _context.Suppliers.Count();
            ViewBag.OrderCount = _context.CustomerOrders.Count();

            ViewBag.TotalStock = _context.Products.Sum(x => x.Stock);
            ViewBag.TotalRevenue = _context.CustomerOrders.Sum(x => x.TotalPrice);

            ViewBag.MostExpensiveProduct = _context.Products
                .OrderByDescending(x => x.Price)
                .Select(x => x.ProductName)
                .FirstOrDefault();

            ViewBag.CheapestProduct = _context.Products
                .OrderBy(x => x.Price)
                .Select(x => x.ProductName)
                .FirstOrDefault();

            ViewBag.AveragePrice = _context.Products.Any()
                ? _context.Products.Average(x => x.Price)
                : 0;

            ViewBag.TopStockProduct = _context.Products
                .OrderByDescending(x => x.Stock)
                .Select(x => x.ProductName)
                .FirstOrDefault();

            ViewBag.TopCustomer = _context.CustomerOrders
                .GroupBy(x => x.CustomerName)
                .OrderByDescending(x => x.Sum(y => y.TotalPrice))
                .Select(x => x.Key)
                .FirstOrDefault();

            ViewBag.SupplierCityReport = _context.Suppliers
                .GroupBy(x => x.City)
                .Select(x => new
                {
                    City = x.Key,
                    Count = x.Count()
                })
                .ToList();

            return View();
        }

        public IActionResult ExportProductsToExcel()
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Products");

            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Ürün Adı";
            worksheet.Cell(1, 3).Value = "Fiyat";
            worksheet.Cell(1, 4).Value = "Stok";

            var products = _context.Products.ToList();

            int row = 2;

            foreach (var item in products)
            {
                worksheet.Cell(row, 1).Value = item.ProductId;
                worksheet.Cell(row, 2).Value = item.ProductName;
                worksheet.Cell(row, 3).Value = item.Price;
                worksheet.Cell(row, 4).Value = item.Stock;
                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return File(
                stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "ProductList.xlsx"
            );
        }

        public IActionResult ExportProductsToPdf()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var products = _context.Products.ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .Text("Süt Ürünleri Ürün Raporu")
                        .SemiBold()
                        .FontSize(20)
                        .FontColor(Colors.Blue.Medium);

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(40);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("ID").SemiBold();
                            header.Cell().Text("Ürün Adı").SemiBold();
                            header.Cell().Text("Fiyat").SemiBold();
                            header.Cell().Text("Stok").SemiBold();
                        });

                        foreach (var item in products)
                        {
                            table.Cell().Text(item.ProductId.ToString());
                            table.Cell().Text(item.ProductName);
                            table.Cell().Text(item.Price.ToString());
                            table.Cell().Text(item.Stock.ToString());
                        }
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text("Dairy Management System");
                });
            }).GeneratePdf();

            return File(pdf, "application/pdf", "ProductList.pdf");
        }
    }
}