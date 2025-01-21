
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Linq;
using PdfSharp.Fonts;
using System.IO;
using System.Reflection;
using PdfSharpCore.Fonts;
using System.IO;
using PdfSharp.Pdf;
namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InvoseController : Controller
    {
        IIInvose iInvose;
        IICompanyInformation iCompanyInformation;
        MasterDbcontext dbcontext;
        public InvoseController(IIInvose iInvose1, IICompanyInformation iCompanyInformation1,MasterDbcontext dbcontext1)
        {
            iInvose = iInvose1;
            iCompanyInformation = iCompanyInformation1;
            dbcontext = dbcontext1;
        }
        public IActionResult MyInvose()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewInvose = iInvose.GetAll();
            // جلب جميع البيانات
            var allInvoices = iInvose.GetAll();

            // استخراج أسماء مدخلي البيانات بدون تكرار
            var uniqueCashers = allInvoices.Select(i => i.DataEntry).Distinct().ToList();

            // تمرير البيانات إلى ViewBag
            ViewBag.CasherName = uniqueCashers;
            //طرق الدفع
            var PymentMoted = allInvoices.Select(i => i.PaymentMethodAr).Distinct().ToList();
            ViewBag.PayMoTh = PymentMoted;


            //تاريخ الفاتورة 
            var distinctDates = allInvoices
            .Select(i => i.DateTimeEntry.Date).Distinct().ToList();
            ViewBag.dateTai = distinctDates;
            return View(vmodel);
        }

    public IActionResult GeneratePdf()
{
    // **1. جلب البيانات من الجداول**
    // هنا يمكنك إضافة منطق جلب البيانات من قاعدة البيانات
    // var products = _context.Products.Select(p => new { p.Name, p.Price }).ToList();
    // var orders = _context.Orders.Select(o => new { o.Id, o.TotalAmount }).ToList();

    // **2. إنشاء ملف PDF**
    var pdfDocument = Document.Create(container =>
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(2, Unit.Centimetre);
            page.DefaultTextStyle(x => x.FontSize(12));

            page.Header()
                .AlignCenter()
                .Text("تقرير النظام")
                .FontSize(20)
                .Bold();

            page.Content().Column(content =>
            {
                // جدول المنتجات
                content.Item().Text("قائمة المنتجات:").FontSize(16).Bold();
                content.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(50);  // رقم الفاتورة
                        columns.RelativeColumn(100);     // اسم المنتج
                        columns.ConstantColumn(50);   // الكمية
                        columns.ConstantColumn(50);   // السعر
                        columns.ConstantColumn(70);   // الإجمالي
                        columns.ConstantColumn(100);  // مدخل البيانات
                        columns.ConstantColumn(80);   // وقت وتاريخ الإدخال
                    });

                    // إضافة عناوين الأعمدة
                    table.Header(header =>
                    {
                        header.Cell().Border(1).Text("رقم الفاتورة").Bold();
                        header.Cell().Border(1).Text("اسم المنتج").Bold();
                        header.Cell().Border(1).Text("الكمية").Bold();
                        header.Cell().Border(1).Text("السعر").Bold();
                        header.Cell().Border(1).Text("الإجمالي").Bold();
                        header.Cell().Border(1).Text("مدخل البيانات").Bold();
                        header.Cell().Border(1).Text("وقت وتاريخ الإدخال").Bold();
                    });

                    // إضافة البيانات
                    ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
                    var products = vmodel.ListViewInvose = iInvose.GetAll();

                    foreach (var product in products)
                    {
                        table.Cell().Border(1).Text(product.InvoiceNumber.ToString());   // رقم الفاتورة
                        table.Cell().Border(1).Text(product.ProductNameAr);               // اسم المنتج
                        table.Cell().Border(1).Text(product.Quantity.ToString());        // الكمية
                        table.Cell().Border(1).Text($"${product.price}");                 // السعر
                        table.Cell().Border(1).Text($"${product.total}");                 // الإجمالي
                        table.Cell().Border(1).Text(product.DataEntry);                   // مدخل البيانات
                        table.Cell().Border(1).Text(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss")); // وقت وتاريخ الإدخال
                                                                                                  // وقت وتاريخ الإدخال
                      
                    }
                  
                    // تطبيق الحدود على جميع الخلايا
                    // إضافة حدود حول الخلايا
                });

                content.Item().PaddingTop(10);

                // جدول الطلبات (إذا كنت بحاجة إلى إضافة طلبات)
                content.Item().Text("قائمة الطلبات:").FontSize(16).Bold();
                content.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(100); // رقم الطلب
                        columns.RelativeColumn();    // المجموع
                        columns.ConstantColumn(100); // تاريخ الطلب
                    });

                    // إضافة عناوين الأعمدة
                    table.Header(header =>
                    {
                        header.Cell().Text("رقم الطلب").Bold();
                        header.Cell().Text("المجموع").Bold();
                        header.Cell().Text("تاريخ الطلب").Bold();
                    });

                    // إضافة البيانات
                    // إضافة بيانات الطلبات حسب الحاجة
                    // foreach (var order in orders)
                    // {
                    //     table.Cell().Text(order.Id.ToString());    // رقم الطلب
                    //     table.Cell().Text($"${order.TotalAmount}"); // المجموع
                    //     table.Cell().Text(order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")); // تاريخ الطلب
                    // }
                });
            });

            page.Footer()
                .AlignRight()
                .Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}")
                .FontSize(10);
        });
    });

    // **3. إعادة الملف كتنزيل**
    var pdfData = pdfDocument.GeneratePdf();
    return File(pdfData, "application/pdf", "Report.pdf");
}









        public IActionResult GeneratePdf1()
        {
            // إنشاء مستند PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "تقرير النظام";

            // إضافة صفحة جديدة
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //// استخدام الخط الافتراضي (مثال: Arial)
            //XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);
            //XFont boldFont = new XFont("Arial", 12, XFontStyleEx.Bold);

            string fontPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fonts", "Roboto-Regular.ttf");
            XFont font = new XFont(fontPath, 12, XFontStyleEx.Regular);
            XFont boldFont = new XFont(fontPath, 12, XFontStyleEx.Bold);

            //XFont font = new XFont("Times New Roman", 12, XFontStyleEx.Regular);
            //XFont boldFont = new XFont("Times New Roman", 12, XFontStyleEx.Bold);
            // رسم العنوان
            gfx.DrawString("تقرير النظام", boldFont, XBrushes.Black, new XPoint(page.Width / 2, 30), XStringFormats.Center);

            // رسم جدول
            double yPosition = 50;
            double xPosition = 30;

            // رأس الجدول
            gfx.DrawString("رقم الفاتورة", boldFont, XBrushes.Black, new XPoint(xPosition, yPosition));
            xPosition += 90;
            gfx.DrawString("اسم المنتج", boldFont, XBrushes.Black, new XPoint(xPosition, yPosition));
            xPosition += 130;
            gfx.DrawString("الكمية", boldFont, XBrushes.Black, new XPoint(xPosition, yPosition));
            xPosition += 60;
            gfx.DrawString("السعر", boldFont, XBrushes.Black, new XPoint(xPosition, yPosition));
            xPosition += 60;
            gfx.DrawString("الإجمالي", boldFont, XBrushes.Black, new XPoint(xPosition, yPosition));
            xPosition += 100;
            gfx.DrawString("مدخل البيانات", boldFont, XBrushes.Black, new XPoint(xPosition, yPosition));
            xPosition += 120;
            gfx.DrawString("وقت وتاريخ الإدخال", boldFont, XBrushes.Black, new XPoint(xPosition, yPosition));

            // تحريك للمرة التالية
            yPosition += 20;
            xPosition = 30;

            // إضافة البيانات
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var products = vmodel.ListViewInvose = iInvose.GetAll();

            foreach (var product in products)
            {
                gfx.DrawString(product.InvoiceNumber.ToString(), font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += 90;
                gfx.DrawString(product.ProductNameAr, font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += 130;
                gfx.DrawString(product.Quantity.ToString(), font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += 60;
                gfx.DrawString($"${product.price}", font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += 60;
                gfx.DrawString($"${product.total}", font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += 100;
                gfx.DrawString(product.DataEntry, font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += 120;
                gfx.DrawString(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"), font, XBrushes.Black, new XPoint(xPosition, yPosition));

                yPosition += 20;
                xPosition = 30;
            }

            // إضافة تذييل الصفحة
            gfx.DrawString($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}", font, XBrushes.Black, new XPoint(page.Width - 150, page.Height - 30), XStringFormats.TopLeft);

            // حفظ الملف وتصديره
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream, false);
                // استخدام FileResult بدلاً من Content أو ActionResult
                return File(stream.ToArray(), "application/pdf", "Report.pdf");
            }
        }

    }
}
