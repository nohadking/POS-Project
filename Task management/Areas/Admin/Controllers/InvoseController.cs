
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
using Infarstuructre.ViewModel;
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
        [HttpGet]
        public IActionResult GeneratePdf(string selectedDate)
        {
            // **1. جلب البيانات من الجداول**
            // هنا يمكنك إضافة منطق جلب البيانات من قاعدة البيانات
            // var products = _context.Products.Select(p => new { p.Name, p.Price }).ToList();
            // var orders = _context.Orders.Select(o => new { o.Id, o.TotalAmount }).ToList();

            // **2. إنشاء ملف PDF**
            var pdfDocument = Document.Create(container =>
            {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var compny = dbcontext.TBCompanyInformations.FirstOrDefault();

                // **حساب الإجماليات**
                var products = vmodel.ListViewInvose = iInvose.GetAll().Where(a => a.DataEntry == selectedDate).ToList();
                var totalQuantity = products.Sum(p => p.Quantity);
                var totalAmount = products.Sum(p => p.total);

                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                          .Column(header =>
                          {
                              header.Item().Border(1).AlignCenter().Text("تقرير الفواتير العام ").FontSize(20).Bold();
                              if (compny != null)
                              {
                                  header.Item().Border(1).AlignCenter().Text($" {compny.NameCompanyAr}").FontSize(14);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.AddressAr}").FontSize(12);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.Mobile}").FontSize(12);
                              }
                          });

                    page.Content().Column(content =>
                    {
                        content.Item().AlignCenter().Text($"{selectedDate}تقرير الفاواتير الخاص بالموظف  :").FontSize(16).Bold();
                        content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  // رقم الفاتورة
                                columns.RelativeColumn(100); // اسم المنتج
                                columns.ConstantColumn(50);  // الكمية
                                columns.ConstantColumn(50);  // السعر
                                columns.ConstantColumn(50);  // الإجمالي
                                columns.ConstantColumn(100); // مدخل البيانات
                                columns.ConstantColumn(100); // وقت وتاريخ الإدخال
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).AlignCenter().Text("ر.ف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الصنف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الكمية").Bold();
                                header.Cell().Border(1).AlignCenter().Text("السعر").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الإجمالي").Bold();
                                header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
                                header.Cell().Border(1).AlignCenter().Text("وقت وتاريخ").Bold();
                            });

                            foreach (var product in products)
                            {
                                table.Cell().Border(1).AlignCenter().Text(product.InvoiceNumber.ToString());
                                table.Cell().Border(1).AlignCenter().Text(product.ProductNameAr);
                                table.Cell().Border(1).AlignCenter().Text(product.Quantity.ToString());
                                table.Cell().Border(1).AlignCenter().Text($"${product.price}");
                                table.Cell().Border(1).AlignCenter().Text($"${product.total}");
                                table.Cell().Border(1).AlignCenter().Text(product.DataEntry);
                                table.Cell().Border(1).AlignCenter().Text(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        });

                        content.Item().PaddingTop(10);


                        // **إضافة الفوتر في نهاية التقرير**
                        content.Item().PaddingTop(20).Table(table =>
                        {
                            // تعريف الأعمدة
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(); // العمود الأول: مجموع الكمية
                                columns.RelativeColumn(); // العمود الثاني: المجموع العام
                            });

                            // المسميات في السطر الأول
                            table.Header(header =>
                            {
                                header.Cell().AlignCenter().Text("مجموع الكمية").FontSize(12).Bold();
                                header.Cell().AlignCenter().Text("المجموع العام").FontSize(12).Bold();
                            });

                            // القيم في السطر الثاني
                            table.Cell().Border(1).AlignCenter().Text($"{totalQuantity}").FontSize(12);
                            table.Cell().Border(1).AlignCenter().Text($"${totalAmount}").FontSize(12);
                        });

                        // إضافة تاريخ الطباعة أسفل التقرير
                        content.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
                    });


                });
            });

            var pdfData = pdfDocument.GeneratePdf();
            return File(pdfData, "application/pdf", "Report.pdf");
        }



        //// تقرير عام للفواتير
        //[HttpGet("/GeneratePdf")]
        //public IActionResult GeneratePdf()
        //{
        //    var pdfDocument = Document.Create(container =>
        //    {
        //        ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
        //        var compny = dbcontext.TBCompanyInformations.FirstOrDefault();

        //        // **حساب الإجماليات**
        //        var products = vmodel.ListViewInvose = iInvose.GetAll();
        //        var totalQuantity = products.Sum(p => p.Quantity);
        //        var totalAmount = products.Sum(p => p.total);

        //        container.Page(page =>
        //        {
        //            page.Size(PageSizes.A4);
        //            page.Margin(2, Unit.Centimetre);
        //            page.DefaultTextStyle(x => x.FontSize(12));

        //            page.Header()
        //                  .Column(header =>
        //                  {
        //                      header.Item().Border(1).AlignCenter().Text("تقرير الفواتير العام ").FontSize(20).Bold();
        //                      if (compny != null)
        //                      {
        //                          header.Item().Border(1).AlignCenter().Text($" {compny.NameCompanyAr}").FontSize(14);
        //                          header.Item().Border(1).AlignCenter().Text($" {compny.AddressAr}").FontSize(12);
        //                          header.Item().Border(1).AlignCenter().Text($" {compny.Mobile}").FontSize(12);
        //                      }
        //                  });

        //            page.Content().Column(content =>
        //            {
        //                content.Item().AlignCenter().Text("تقرير الفواتير الاجمالي").FontSize(16).Bold();
        //                content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();
        //                content.Item().Table(table =>
        //                {
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        columns.ConstantColumn(40);  // رقم الفاتورة
        //                        columns.RelativeColumn(100); // اسم المنتج
        //                        columns.ConstantColumn(50);  // الكمية
        //                        columns.ConstantColumn(50);  // السعر
        //                        columns.ConstantColumn(50);  // الإجمالي
        //                        columns.ConstantColumn(100); // مدخل البيانات
        //                        columns.ConstantColumn(100); // وقت وتاريخ الإدخال
        //                    });

        //                    table.Header(header =>
        //                    {
        //                        header.Cell().Border(1).AlignCenter().Text("ر.ف").Bold();
        //                        header.Cell().Border(1).AlignCenter().Text("الصنف").Bold();
        //                        header.Cell().Border(1).AlignCenter().Text("الكمية").Bold();
        //                        header.Cell().Border(1).AlignCenter().Text("السعر").Bold();
        //                        header.Cell().Border(1).AlignCenter().Text("الإجمالي").Bold();
        //                        header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
        //                        header.Cell().Border(1).AlignCenter().Text("وقت وتاريخ").Bold();
        //                    });

        //                    foreach (var product in products)
        //                    {
        //                        table.Cell().Border(1).AlignCenter().Text(product.InvoiceNumber.ToString());
        //                        table.Cell().Border(1).AlignCenter().Text(product.ProductNameAr);
        //                        table.Cell().Border(1).AlignCenter().Text(product.Quantity.ToString());
        //                        table.Cell().Border(1).AlignCenter().Text($"${product.price}");
        //                        table.Cell().Border(1).AlignCenter().Text($"${product.total}");
        //                        table.Cell().Border(1).AlignCenter().Text(product.DataEntry);
        //                        table.Cell().Border(1).AlignCenter().Text(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
        //                    }
        //                });

        //                content.Item().PaddingTop(10);

                       
        //                // **إضافة الفوتر في نهاية التقرير**
        //                content.Item().PaddingTop(20).Table(table =>
        //                {
        //                    // تعريف الأعمدة
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        columns.RelativeColumn(); // العمود الأول: مجموع الكمية
        //                        columns.RelativeColumn(); // العمود الثاني: المجموع العام
        //                    });

        //                    // المسميات في السطر الأول
        //                    table.Header(header =>
        //                    {
        //                        header.Cell().AlignCenter().Text("مجموع الكمية").FontSize(12).Bold();
        //                        header.Cell().AlignCenter().Text("المجموع العام").FontSize(12).Bold();
        //                    });

        //                    // القيم في السطر الثاني
        //                    table.Cell().Border(1).AlignCenter().Text($"{totalQuantity}").FontSize(12);
        //                    table.Cell().Border(1).AlignCenter().Text($"${totalAmount}").FontSize(12);
        //                });

        //                // إضافة تاريخ الطباعة أسفل التقرير
        //                content.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
        //            });

                   
        //        });
        //    });

        //    var pdfData = pdfDocument.GeneratePdf();
        //    return File(pdfData, "application/pdf", "Report.pdf");
        //}

        // حسب تاريخ محدد يوم واحد
        [HttpGet("/GeneratePdfByOneDate/{date}")]
        public IActionResult GeneratePdfByOneDate(DateTime date)
        {
            var pdfDocument = Document.Create(container =>
            {
                ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
                var compny = dbcontext.TBCompanyInformations.FirstOrDefault();

                // **حساب الإجماليات**
                var products = vmodel.ListViewInvose = iInvose.GetByDateTimeEntry(date);
                var totalQuantity = products.Sum(p => p.Quantity);
                var totalAmount = products.Sum(p => p.total);

                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                          .Column(header =>
                          {
                              header.Item().Border(1).AlignCenter().Text("تقرير الفواتير العام ").FontSize(20).Bold();
                              if (compny != null)
                              {
                                  header.Item().Border(1).AlignCenter().Text($" {compny.NameCompanyAr}").FontSize(14);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.AddressAr}").FontSize(12);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.Mobile}").FontSize(12);
                              }
                          });

                    page.Content().Column(content =>
                    {
                        content.Item().AlignCenter().Text($"{date.Date}تقرير الفواتير ليوم :").FontSize(16).Bold();
                        content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  // رقم الفاتورة
                                columns.RelativeColumn(100); // اسم المنتج
                                columns.ConstantColumn(50);  // الكمية
                                columns.ConstantColumn(50);  // السعر
                                columns.ConstantColumn(50);  // الإجمالي
                                columns.ConstantColumn(100); // مدخل البيانات
                                columns.ConstantColumn(100); // وقت وتاريخ الإدخال
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).AlignCenter().Text("ر.ف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الصنف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الكمية").Bold();
                                header.Cell().Border(1).AlignCenter().Text("السعر").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الإجمالي").Bold();
                                header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
                                header.Cell().Border(1).AlignCenter().Text("وقت وتاريخ").Bold();
                            });

                            foreach (var product in products)
                            {
                                table.Cell().Border(1).AlignCenter().Text(product.InvoiceNumber.ToString());
                                table.Cell().Border(1).AlignCenter().Text(product.ProductNameAr);
                                table.Cell().Border(1).AlignCenter().Text(product.Quantity.ToString());
                                table.Cell().Border(1).AlignCenter().Text($"${product.price}");
                                table.Cell().Border(1).AlignCenter().Text($"${product.total}");
                                table.Cell().Border(1).AlignCenter().Text(product.DataEntry);
                                table.Cell().Border(1).AlignCenter().Text(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        });

                        content.Item().PaddingTop(10);


                        // **إضافة الفوتر في نهاية التقرير**
                        content.Item().PaddingTop(20).Table(table =>
                        {
                            // تعريف الأعمدة
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(); // العمود الأول: مجموع الكمية
                                columns.RelativeColumn(); // العمود الثاني: المجموع العام
                            });

                            // المسميات في السطر الأول
                            table.Header(header =>
                            {
                                header.Cell().AlignCenter().Text("مجموع الكمية").FontSize(12).Bold();
                                header.Cell().AlignCenter().Text("المجموع العام").FontSize(12).Bold();
                            });

                            // القيم في السطر الثاني
                            table.Cell().Border(1).AlignCenter().Text($"{totalQuantity}").FontSize(12);
                            table.Cell().Border(1).AlignCenter().Text($"${totalAmount}").FontSize(12);
                        });

                        // إضافة تاريخ الطباعة أسفل التقرير
                        content.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
                    });


                });
            });

            var pdfData = pdfDocument.GeneratePdf();
            return File(pdfData, "application/pdf", "Report.pdf");
        }


        //حسب الكاشير تقرير للفواتير
        [HttpGet("/GeneratePdfByCacherName/{cacherNm}")]
        public IActionResult GeneratePdfByCacherName(string cacherNm)
        {
            var pdfDocument = Document.Create(container =>
            {
                ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
                var compny = dbcontext.TBCompanyInformations.FirstOrDefault();

                // **حساب الإجماليات**
                var products = vmodel.ListViewInvose = iInvose.GetByCacherName(cacherNm);
                var totalQuantity = products.Sum(p => p.Quantity);
                var totalAmount = products.Sum(p => p.total);

                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                          .Column(header =>
                          {
                              header.Item().Border(1).AlignCenter().Text("تقرير الفواتير العام ").FontSize(20).Bold();
                              if (compny != null)
                              {
                                  header.Item().Border(1).AlignCenter().Text($" {compny.NameCompanyAr}").FontSize(14);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.AddressAr}").FontSize(12);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.Mobile}").FontSize(12);
                              }
                          });

                    page.Content().Column(content =>
                    {
                        content.Item().AlignCenter().Text($"تقرير الفواتير التي قام بها العامل {cacherNm}").FontSize(16).Bold();
                        content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  // رقم الفاتورة
                                columns.RelativeColumn(100); // اسم المنتج
                                columns.ConstantColumn(50);  // الكمية
                                columns.ConstantColumn(50);  // السعر
                                columns.ConstantColumn(50);  // الإجمالي
                                columns.ConstantColumn(100); // مدخل البيانات
                                columns.ConstantColumn(100); // وقت وتاريخ الإدخال
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).AlignCenter().Text("ر.ف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الصنف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الكمية").Bold();
                                header.Cell().Border(1).AlignCenter().Text("السعر").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الإجمالي").Bold();
                                header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
                                header.Cell().Border(1).AlignCenter().Text("وقت وتاريخ").Bold();
                            });

                            foreach (var product in products)
                            {
                                table.Cell().Border(1).AlignCenter().Text(product.InvoiceNumber.ToString());
                                table.Cell().Border(1).AlignCenter().Text(product.ProductNameAr);
                                table.Cell().Border(1).AlignCenter().Text(product.Quantity.ToString());
                                table.Cell().Border(1).AlignCenter().Text($"${product.price}");
                                table.Cell().Border(1).AlignCenter().Text($"${product.total}");
                                table.Cell().Border(1).AlignCenter().Text(product.DataEntry);
                                table.Cell().Border(1).AlignCenter().Text(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        });

                        content.Item().PaddingTop(10);


                        // **إضافة الفوتر في نهاية التقرير**
                        content.Item().PaddingTop(20).Table(table =>
                        {
                            // تعريف الأعمدة
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(); // العمود الأول: مجموع الكمية
                                columns.RelativeColumn(); // العمود الثاني: المجموع العام
                            });

                            // المسميات في السطر الأول
                            table.Header(header =>
                            {
                                header.Cell().AlignCenter().Text("مجموع الكمية").FontSize(12).Bold();
                                header.Cell().AlignCenter().Text("المجموع العام").FontSize(12).Bold();
                            });

                            // القيم في السطر الثاني
                            table.Cell().Border(1).AlignCenter().Text($"{totalQuantity}").FontSize(12);
                            table.Cell().Border(1).AlignCenter().Text($"${totalAmount}").FontSize(12);
                        });

                        // إضافة تاريخ الطباعة أسفل التقرير
                        content.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
                    });


                });
            });

            var pdfData = pdfDocument.GeneratePdf();
            return File(pdfData, "application/pdf", "Report.pdf");
        }

        //حسب الكاشير وطريقة الدفع تقرير للفواتير
        [HttpGet("/GeneratePdfByCacherNameAndPayMethod/{cacherNm}/{payMeth}")]
        public IActionResult GeneratePdfByCacherNameAndPayMethod(string cacherNm, string payMeth)
        {
            var pdfDocument = Document.Create(container =>
            {
                ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
                var compny = dbcontext.TBCompanyInformations.FirstOrDefault();

                // **حساب الإجماليات**
                var products = vmodel.ListViewInvose = iInvose.GetByCacherNameAndPay(cacherNm, payMeth);
                var totalQuantity = products.Sum(p => p.Quantity);
                var totalAmount = products.Sum(p => p.total);

                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                          .Column(header =>
                          {
                              header.Item().Border(1).AlignCenter().Text("تقرير الفواتير العام ").FontSize(20).Bold();
                              if (compny != null)
                              {
                                  header.Item().Border(1).AlignCenter().Text($" {compny.NameCompanyAr}").FontSize(14);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.AddressAr}").FontSize(12);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.Mobile}").FontSize(12);
                              }
                          });

                    page.Content().Column(content =>
                    {
                        content.Item().AlignCenter().Text($"تقرير الفواتير التي قام بها العامل {cacherNm} وتم الدفع من خلال {payMeth}").FontSize(16).Bold();
                        content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  // رقم الفاتورة
                                columns.RelativeColumn(100); // اسم المنتج
                                columns.ConstantColumn(50);  // الكمية
                                columns.ConstantColumn(50);  // السعر
                                columns.ConstantColumn(50);  // الإجمالي
                                columns.ConstantColumn(100); // مدخل البيانات
                                columns.ConstantColumn(100); // وقت وتاريخ الإدخال
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).AlignCenter().Text("ر.ف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الصنف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الكمية").Bold();
                                header.Cell().Border(1).AlignCenter().Text("السعر").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الإجمالي").Bold();
                                header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
                                header.Cell().Border(1).AlignCenter().Text("وقت وتاريخ").Bold();
                            });

                            foreach (var product in products)
                            {
                                table.Cell().Border(1).AlignCenter().Text(product.InvoiceNumber.ToString());
                                table.Cell().Border(1).AlignCenter().Text(product.ProductNameAr);
                                table.Cell().Border(1).AlignCenter().Text(product.Quantity.ToString());
                                table.Cell().Border(1).AlignCenter().Text($"${product.price}");
                                table.Cell().Border(1).AlignCenter().Text($"${product.total}");
                                table.Cell().Border(1).AlignCenter().Text(product.DataEntry);
                                table.Cell().Border(1).AlignCenter().Text(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        });

                        content.Item().PaddingTop(10);


                        // **إضافة الفوتر في نهاية التقرير**
                        content.Item().PaddingTop(20).Table(table =>
                        {
                            // تعريف الأعمدة
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(); // العمود الأول: مجموع الكمية
                                columns.RelativeColumn(); // العمود الثاني: المجموع العام
                            });

                            // المسميات في السطر الأول
                            table.Header(header =>
                            {
                                header.Cell().AlignCenter().Text("مجموع الكمية").FontSize(12).Bold();
                                header.Cell().AlignCenter().Text("المجموع العام").FontSize(12).Bold();
                            });

                            // القيم في السطر الثاني
                            table.Cell().Border(1).AlignCenter().Text($"{totalQuantity}").FontSize(12);
                            table.Cell().Border(1).AlignCenter().Text($"${totalAmount}").FontSize(12);
                        });

                        // إضافة تاريخ الطباعة أسفل التقرير
                        content.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
                    });


                });
            });

            var pdfData = pdfDocument.GeneratePdf();
            return File(pdfData, "application/pdf", "Report.pdf");
        }

        //حسب الكاشير وطريقة الدفع وفترة زمنية محددة تقرير للفواتير
        [HttpGet("/GeneratePdfByCacherNameAndPayMethodAndDetetectedPeriod/{cacherNm}/{payMeth}/{startDt}/{endDt}")]
        public IActionResult GeneratePdfByCacherNameAndPayMethodAndDetetectedPeriod(string cacherNm, string payMeth, DateTime startDt, DateTime endDt)
        {
            var pdfDocument = Document.Create(container =>
            {
                ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
                var compny = dbcontext.TBCompanyInformations.FirstOrDefault();

                // **حساب الإجماليات**
                var products = vmodel.ListViewInvose = iInvose.GetAll();
                var totalQuantity = products.Sum(p => p.Quantity);
                var totalAmount = products.Sum(p => p.total);

                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                          .Column(header =>
                          {
                              header.Item().Border(1).AlignCenter().Text("تقرير الفواتير العام ").FontSize(20).Bold();
                              if (compny != null)
                              {
                                  header.Item().Border(1).AlignCenter().Text($" {compny.NameCompanyAr}").FontSize(14);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.AddressAr}").FontSize(12);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.Mobile}").FontSize(12);
                              }
                          });

                    page.Content().Column(content =>
                    {
                        content.Item().AlignCenter().Text("تقرير الفواتير الاجمالي").FontSize(16).Bold();
                        content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  // رقم الفاتورة
                                columns.RelativeColumn(100); // اسم المنتج
                                columns.ConstantColumn(50);  // الكمية
                                columns.ConstantColumn(50);  // السعر
                                columns.ConstantColumn(50);  // الإجمالي
                                columns.ConstantColumn(100); // مدخل البيانات
                                columns.ConstantColumn(100); // وقت وتاريخ الإدخال
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).AlignCenter().Text("ر.ف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الصنف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الكمية").Bold();
                                header.Cell().Border(1).AlignCenter().Text("السعر").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الإجمالي").Bold();
                                header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
                                header.Cell().Border(1).AlignCenter().Text("وقت وتاريخ").Bold();
                            });

                            foreach (var product in products)
                            {
                                table.Cell().Border(1).AlignCenter().Text(product.InvoiceNumber.ToString());
                                table.Cell().Border(1).AlignCenter().Text(product.ProductNameAr);
                                table.Cell().Border(1).AlignCenter().Text(product.Quantity.ToString());
                                table.Cell().Border(1).AlignCenter().Text($"${product.price}");
                                table.Cell().Border(1).AlignCenter().Text($"${product.total}");
                                table.Cell().Border(1).AlignCenter().Text(product.DataEntry);
                                table.Cell().Border(1).AlignCenter().Text(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        });

                        content.Item().PaddingTop(10);


                        // **إضافة الفوتر في نهاية التقرير**
                        content.Item().PaddingTop(20).Table(table =>
                        {
                            // تعريف الأعمدة
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(); // العمود الأول: مجموع الكمية
                                columns.RelativeColumn(); // العمود الثاني: المجموع العام
                            });

                            // المسميات في السطر الأول
                            table.Header(header =>
                            {
                                header.Cell().AlignCenter().Text("مجموع الكمية").FontSize(12).Bold();
                                header.Cell().AlignCenter().Text("المجموع العام").FontSize(12).Bold();
                            });

                            // القيم في السطر الثاني
                            table.Cell().Border(1).AlignCenter().Text($"{totalQuantity}").FontSize(12);
                            table.Cell().Border(1).AlignCenter().Text($"${totalAmount}").FontSize(12);
                        });

                        // إضافة تاريخ الطباعة أسفل التقرير
                        content.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
                    });


                });
            });

            var pdfData = pdfDocument.GeneratePdf();
            return File(pdfData, "application/pdf", "Report.pdf");
        }

        //  حسب كلمة بحث تقرير للفواتير
        [HttpGet("/GeneratePdfByKeywordSearch/{word}")]
        public IActionResult GeneratePdfByKeywordSearch(string word)
        {
            var pdfDocument = Document.Create(container =>
            {
                ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
                var compny = dbcontext.TBCompanyInformations.FirstOrDefault();

                // **حساب الإجماليات**
                var products = vmodel.ListViewInvose = iInvose.GetBySearchWord(word);
                var totalQuantity = products.Sum(p => p.Quantity);
                var totalAmount = products.Sum(p => p.total);

                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                          .Column(header =>
                          {
                              header.Item().Border(1).AlignCenter().Text("تقرير الفواتير العام ").FontSize(20).Bold();
                              if (compny != null)
                              {
                                  header.Item().Border(1).AlignCenter().Text($" {compny.NameCompanyAr}").FontSize(14);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.AddressAr}").FontSize(12);
                                  header.Item().Border(1).AlignCenter().Text($" {compny.Mobile}").FontSize(12);
                              }
                          });

                    page.Content().Column(content =>
                    {
                        content.Item().AlignCenter().Text($"تقرير الفواتير حسب {word}").FontSize(16).Bold();
                        content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  // رقم الفاتورة
                                columns.RelativeColumn(100); // اسم المنتج
                                columns.ConstantColumn(50);  // الكمية
                                columns.ConstantColumn(50);  // السعر
                                columns.ConstantColumn(50);  // الإجمالي
                                columns.ConstantColumn(100); // مدخل البيانات
                                columns.ConstantColumn(100); // وقت وتاريخ الإدخال
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).AlignCenter().Text("ر.ف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الصنف").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الكمية").Bold();
                                header.Cell().Border(1).AlignCenter().Text("السعر").Bold();
                                header.Cell().Border(1).AlignCenter().Text("الإجمالي").Bold();
                                header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
                                header.Cell().Border(1).AlignCenter().Text("وقت وتاريخ").Bold();
                            });

                            foreach (var product in products)
                            {
                                table.Cell().Border(1).AlignCenter().Text(product.InvoiceNumber.ToString());
                                table.Cell().Border(1).AlignCenter().Text(product.ProductNameAr);
                                table.Cell().Border(1).AlignCenter().Text(product.Quantity.ToString());
                                table.Cell().Border(1).AlignCenter().Text($"${product.price}");
                                table.Cell().Border(1).AlignCenter().Text($"${product.total}");
                                table.Cell().Border(1).AlignCenter().Text(product.DataEntry);
                                table.Cell().Border(1).AlignCenter().Text(product.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        });

                        content.Item().PaddingTop(10);


                        // **إضافة الفوتر في نهاية التقرير**
                        content.Item().PaddingTop(20).Table(table =>
                        {
                            // تعريف الأعمدة
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(); // العمود الأول: مجموع الكمية
                                columns.RelativeColumn(); // العمود الثاني: المجموع العام
                            });

                            // المسميات في السطر الأول
                            table.Header(header =>
                            {
                                header.Cell().AlignCenter().Text("مجموع الكمية").FontSize(12).Bold();
                                header.Cell().AlignCenter().Text("المجموع العام").FontSize(12).Bold();
                            });

                            // القيم في السطر الثاني
                            table.Cell().Border(1).AlignCenter().Text($"{totalQuantity}").FontSize(12);
                            table.Cell().Border(1).AlignCenter().Text($"${totalAmount}").FontSize(12);
                        });

                        // إضافة تاريخ الطباعة أسفل التقرير
                        content.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
                    });


                });
            });

            var pdfData = pdfDocument.GeneratePdf();
            return File(pdfData, "application/pdf", "Report.pdf");
        }


    }
}
