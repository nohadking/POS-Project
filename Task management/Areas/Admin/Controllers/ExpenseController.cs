using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Threading.Tasks;


namespace Task_management.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ExpenseController : Controller
	{
		IIExpense iExpense;
		IICompanyInformation iCompanyInformation;
		IIExpenseCategory iExpenseCategory;
		IILevelForeAccount iLevelForeAccount;
		MasterDbcontext dbcontext;
		public ExpenseController(IIExpense iExpense1, IICompanyInformation iCompanyInformation1, IIExpenseCategory iExpenseCategory1, IILevelForeAccount iLevelForeAccount1, MasterDbcontext dbcontext)
		{
			iExpense = iExpense1;
			iCompanyInformation = iCompanyInformation1;
			iExpenseCategory = iExpenseCategory1;
			iLevelForeAccount = iLevelForeAccount1;
			this.dbcontext = dbcontext;
		}
		public IActionResult MyExpense()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
			vmodel.ListViewExpense = iExpense.GetAll();
			ViewBag.ExpenseCategory = vmodel.ListExpenseCategory = iExpenseCategory.GetAll();
			ViewBag.LevelForeAccount = vmodel.ListViewLevelForeAccount = iLevelForeAccount.GetAll();

			ViewBag.Expense = vmodel.ListViewExpense = iExpense.GetAll().GroupBy(i => i.AccountName).Select(g => g.First()).ToList();



			var numberinvose = vmodel.ListViewExpense = iExpense.GetAll();
			ViewBag.nomberMax = numberinvose.Any()
		? numberinvose.Max(c => c.BondNumber) + 1
		: 1;
			return View(vmodel);
		}
		public IActionResult AddExpense(int? IdExpense)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
			vmodel.ListViewExpense = iExpense.GetAll();
			ViewBag.ExpenseCategory = vmodel.ListExpenseCategory = iExpenseCategory.GetAll();
			ViewBag.LevelForeAccount = vmodel.ListViewLevelForeAccount = iLevelForeAccount.GetAll();
			ViewBag.Expense = vmodel.ListViewExpense = iExpense.GetAll().GroupBy(i => i.AccountName).Select(g => g.First()).ToList();
			vmodel.ListViewExpense = iExpense.GetAll();
			ViewBag.ExpenseCategory = vmodel.ListExpenseCategory = iExpenseCategory.GetAll();
			if (IdExpense != null)
			{
				vmodel.Expense = iExpense.GetById(Convert.ToInt32(IdExpense));
				return View(vmodel);
			}
			else
			{
				return View(vmodel);
			}
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBExpense slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdExpense = model.Expense.IdExpense;
				slider.IdExpenseCategory = model.Expense.IdExpenseCategory;
				slider.IdLevelForeAccount = model.Expense.IdLevelForeAccount;
				slider.BondNumber = model.Expense.BondNumber;
				slider.DateBond = model.Expense.DateBond;
				slider.Statement = model.Expense.Statement;
				slider.Amount = model.Expense.Amount;
				slider.DateTimeEntry = model.Expense.DateTimeEntry;
				slider.DataEntry = model.Expense.DataEntry;
				slider.CurrentState = model.Expense.CurrentState;
				if (slider.IdExpense == 0 || slider.IdExpense == null)
				{
					var reqwest = iExpense.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyExpense");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return RedirectToAction("AddExpense");
					}
				}
				else
				{
					var reqestUpdate = iExpense.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyExpense");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
						return RedirectToAction("AddExpense");
					}
				}
			}
			catch
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
				return Redirect(returnUrl);
			}
		}
		[Authorize(Roles = "Admin")]
		public IActionResult DeleteData(int IdExpense)
		{
			var reqwistDelete = iExpense.deleteData(IdExpense);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyExpense");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyExpense");

			}
		}



		////// print pdf ///////////////////
		///expense
		[HttpGet]
		public IActionResult GenerateExpensePdf(string? expense, string? cate, string? oneDate, string? startDate, string? endDate)
		{
			// تقرير عام
			if (expense == null && cate == null && oneDate == null && startDate == null && endDate == null)
			{
				var pdf = CreatePDF(expense, cate, oneDate, startDate, endDate);
				return pdf;
			}
			else
			{
				if (oneDate != null)
				{
					// حسب تاريخ محدد
					var pdf = CreatePDF(expense, cate, oneDate, startDate, endDate);
					return pdf;
				}

				else if (startDate != null && endDate != null)
				{
					if (expense != null)
					{
						// بين تاريخين و حساب
						var pdf = CreatePDF(expense, cate, oneDate, startDate, endDate);
						return pdf;
					}

					else if (cate != null)
					{
						// حسب فئة السند بين تاريخين  
						var pdf = CreatePDF(expense, cate, oneDate, startDate, endDate);
						return pdf;
					}

					else
					{
						//  بين تاريخين  
						var pdf = CreatePDF(expense, cate, oneDate, startDate, endDate);
						return pdf;
					}
				}
				else if (expense != null)
				{
					// حسب حساب  
					var pdf = CreatePDF(expense, cate, oneDate, startDate, endDate);
					return pdf;

				}
				else if (cate != null)
				{
					// حسب فئة السند  
					var pdf = CreatePDF(expense, cate, oneDate, startDate, endDate);
					return pdf;

				}
			}
			return Content("Invalid parameters or no data found.", "text/plain");
		}


		public IActionResult CreatePDF(string? expense, string? category, string? oneDate, string startDate, string endDate)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			var compny = dbcontext.TBCompanyInformations.FirstOrDefault();
			var expenses = new List<TBViewExpense>();

			var pdfDocument = Document.Create(container =>
			{

				// **حساب الإجماليات**
				if (expense == null && category == null && oneDate == null && startDate == null && endDate == null)
				{
					expenses = vmodel.ListViewExpense = iExpense.GetAll();
				}
				else
				{
					if (oneDate != null)
					{
						// حسب تاريخ محدد
						DateTime dt = Convert.ToDateTime(oneDate);
						expenses = vmodel.ListViewExpense = iExpense.GetByDetectedDt(dt);

					}

					else if (startDate != null && endDate != null)
					{
						if (expense != null)
						{
							// حسب الصرف بين تاريخين  
							DateTime startDt = Convert.ToDateTime(startDate);
							DateTime endD = Convert.ToDateTime(endDate);
							expenses = vmodel.ListViewExpense = iExpense.GetByExpenseAndPeriodDate(expense, startDt, endD);
						}

						else if (category != null)
						{
							// حسب فئة الصرف بين تاريخين  
							DateTime startDt = Convert.ToDateTime(startDate);
							DateTime endD = Convert.ToDateTime(endDate);
							expenses = vmodel.ListViewExpense = iExpense.GetByCategoryAndPeriodDate(category, startDt, endD);
						}

						else
						{
							// حسب من تاريخ لتاريخ  
							DateTime startDt = Convert.ToDateTime(startDate);
							DateTime endD = Convert.ToDateTime(endDate);
							expenses = vmodel.ListViewExpense = iExpense.GetByPeriodDate(startDt, endD);
						}
					}
					else if (expense != null)
					{
						// حسب صرفية  
						expenses = vmodel.ListViewExpense = iExpense.GetByExpense(expense);

					}

					else if (category != null)
					{
						// حسب فئة الصرف  
						expenses = vmodel.ListViewExpense = iExpense.GetByCategory(category);

					}
				}
				// زبط هدول معلم 

				//var totalQuantity = accounts.Sum(p => p.Quantity);
				//var totalAmount = accounts.Sum(p => p.TotalAll);

				container.Page(page =>
				{
					page.Size(PageSizes.A4);
					page.Margin(2, Unit.Centimetre);
					page.DefaultTextStyle(x => x.FontSize(12));


					page.Header()
					.Column(header =>
					{
						header.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
						if (expense == null && category == null && oneDate == null && startDate == null && endDate == null)
						{
							header.Item().Border(1).AlignCenter().Text($"تقرير المصاريف العام ").FontSize(20).Bold();
						}
						else
						{
							if (oneDate != null)
							{
								// حسب تاريخ محدد
								header.Item().Border(1).AlignCenter().Text($"تقرير المصاريف لتاريخ {oneDate} ").FontSize(20).Bold();
							}

							else if (startDate != null && endDate != null)
							{
								if (expense != null)
								{
									// حسب اسم مورد بين تاريخين  
									header.Item().Border(1).AlignCenter().Text($"تقرير المصاريف لـ {expense} بين تاريخ {startDate} وتاريخ {endDate} ").FontSize(20).Bold();
								}

								else if (category != null)
								{
									// حسب نوع السند بين تاريخين  
									header.Item().Border(1).AlignCenter().Text($"تقرير المصاريف لفئة  {category} بين تاريخ {startDate} وتاريخ {endDate} ").FontSize(20).Bold();

								}

								else
								{
									// حسب من تاريخ لتاريخ  
									header.Item().Border(1).AlignCenter().Text($"تقرير المصاريف بين تاريخ {startDate} وتاريخ {endDate} ").FontSize(20).Bold();
								}
							}
							else if (expense != null)
							{
								// حسب اسم مورد  
								header.Item().Border(1).AlignCenter().Text($"تقرير مصاريف {expense} ").FontSize(20).Bold();

							}

							else if (category != null)
							{
								// حسب نوع السند  
								header.Item().Border(1).AlignCenter().Text($"تقرير المصاريف لفئة: {category} ").FontSize(20).Bold();

							}
						}

						if (compny != null)
						{
							header.Item().Border(1).AlignCenter().Text($" {compny.NameCompanyAr}").FontSize(14);
							header.Item().Border(1).AlignCenter().Text($" {compny.AddressAr}").FontSize(12);
							header.Item().Border(1).AlignCenter().Text($" {compny.Mobile}").FontSize(12);
						}
					});
					decimal totalAmount = expenses.Sum(e => e.Amount);

					page.Content().Column(content =>
					{
						content.Item().AlignCenter().Text($"تقرير المصاريف").FontSize(16).Bold();
						content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();
						content.Item().Table(table =>
						{
							table.ColumnsDefinition(columns =>
							{
								columns.RelativeColumn(); // مدخل البيانات
								columns.RelativeColumn(); // تاريخ الادخال
								columns.RelativeColumn(); // البيان
								columns.RelativeColumn(); // المبلغ
								columns.RelativeColumn(); // رقم السند
								columns.RelativeColumn(); // فئة الحساب
								columns.RelativeColumn(); // اسم الحساب
							});

							table.Header(header =>
							{

								header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
								header.Cell().Border(1).AlignCenter().Text("تاريخ ادخال البيانات").Bold();
								header.Cell().Border(1).AlignCenter().Text("البيان").Bold();
								header.Cell().Border(1).AlignCenter().Text("المبلغ").Bold();
								header.Cell().Border(1).AlignCenter().Text("رقم السند").Bold();
								header.Cell().Border(1).AlignCenter().Text("فئة الحساب").Bold();
								header.Cell().Border(1).AlignCenter().Text("اسم الحساب").Bold();

							});

							foreach (var ex in expenses)
							{
								string cachname = string.Empty;
								if (ex.DataEntry != null)
								{
									cachname = dbcontext.VwUsers
														 .Where(a => a.Email == ex.DataEntry)
														 .Select(a => a.Name)
														 .FirstOrDefault();
								}


								table.Cell().Border(1).AlignCenter().Text(cachname);
								table.Cell().Border(1).AlignCenter().Text(ex.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
								table.Cell().Border(1).AlignCenter().Text(ex.Statement);
								table.Cell().Border(1).AlignCenter().Text(ex.Amount);
								table.Cell().Border(1).AlignCenter().Text(ex.BondNumber);
								table.Cell().Border(1).AlignCenter().Text(ex.ExpenseCategory);
								table.Cell().Border(1).AlignCenter().Text(ex.AccountName);







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
								header.Cell().AlignCenter().Text("المحاسبة").FontSize(12).Bold();
								header.Cell().AlignCenter().Text("المجموع العام").FontSize(12).Bold();
							});

							// القيم في السطر الثاني
							table.Cell().Border(0).AlignCenter().Text($"----------------").FontSize(12);
							table.Cell().Border(0).AlignCenter().Text($"${totalAmount:C}").FontSize(12);
						});

						// إضافة تاريخ الطباعة أسفل التقرير



					});
					page.Footer().AlignCenter().Text(txt =>
					{
						txt.Span("الصفحة ").FontSize(10).Bold();
						txt.CurrentPageNumber().FontSize(10).Bold(); // رقم الصفحة الحالية
						txt.Span(" من ").FontSize(10).Bold();
						txt.TotalPages().FontSize(10).Bold(); // إجمالي عدد الصفحات
					});

				});
			});
			var pdfData = pdfDocument.GeneratePdf();
			return File(pdfData, "application/pdf", "Report.pdf");
		}
        //public IActionResult CreatePDF(string? expense, string? category, string? oneDate, string startDate, string endDate)
        //{
        //	ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
        //	var compny = dbcontext.TBCompanyInformations.FirstOrDefault();
        //	var expenses = new List<TBViewExpense>();

        //	var pdfDocument = Document.Create(container =>
        //	{
        //		// **استرجاع البيانات بناءً على الفلاتر المحددة**
        //		if (expense == null && category == null && oneDate == null && startDate == null && endDate == null)
        //		{
        //			expenses = vmodel.ListViewExpense = iExpense.GetAll();
        //		}
        //		else
        //		{
        //			if (oneDate != null)
        //			{
        //				DateTime dt = Convert.ToDateTime(oneDate);
        //				expenses = vmodel.ListViewExpense = iExpense.GetByDetectedDt(dt);
        //			}
        //			else if (startDate != null && endDate != null)
        //			{
        //				DateTime startDt = Convert.ToDateTime(startDate);
        //				DateTime endD = Convert.ToDateTime(endDate);

        //				if (expense != null)
        //				{
        //					expenses = vmodel.ListViewExpense = iExpense.GetByExpenseAndPeriodDate(expense, startDt, endD);
        //				}
        //				else if (category != null)
        //				{
        //					expenses = vmodel.ListViewExpense = iExpense.GetByCategoryAndPeriodDate(category, startDt, endD);
        //				}
        //				else
        //				{
        //					expenses = vmodel.ListViewExpense = iExpense.GetByPeriodDate(startDt, endD);
        //				}
        //			}
        //			else if (expense != null)
        //			{
        //				expenses = vmodel.ListViewExpense = iExpense.GetByExpense(expense);
        //			}
        //			else if (category != null)
        //			{
        //				expenses = vmodel.ListViewExpense = iExpense.GetByCategory(category);
        //			}
        //		}

        //		// **حساب مجموع المبالغ**
        //		decimal totalAmount = expenses.Sum(e => e.Amount);

        //		container.Page(page =>
        //		{
        //			page.Size(PageSizes.A4);
        //			page.Margin(1, Unit.Centimetre); // تقليل الهامش لتوسيع الجدول
        //			page.DefaultTextStyle(x => x.FontSize(12));

        //			// **ترويسة التقرير**
        //			page.Header().Column(header =>
        //			{
        //				string reportTitle = "تقرير المصاريف العام";

        //				if (oneDate != null)
        //				{
        //					reportTitle = $"تقرير المصاريف لتاريخ {oneDate}";
        //				}
        //				else if (startDate != null && endDate != null)
        //				{
        //					reportTitle = expense != null
        //						? $"تقرير المصاريف لـ {expense} بين {startDate} و {endDate}"
        //						: category != null
        //							? $"تقرير المصاريف لفئة {category} بين {startDate} و {endDate}"
        //							: $"تقرير المصاريف بين {startDate} و {endDate}";
        //				}
        //				else if (expense != null)
        //				{
        //					reportTitle = $"تقرير مصاريف {expense}";
        //				}
        //				else if (category != null)
        //				{
        //					reportTitle = $"تقرير المصاريف لفئة: {category}";
        //				}

        //				header.Item().AlignCenter().Text(reportTitle).FontSize(20).Bold();

        //				if (compny != null)
        //				{
        //					header.Item().AlignCenter().Text(compny.NameCompanyAr).FontSize(14);
        //					header.Item().AlignCenter().Text(compny.AddressAr).FontSize(12);
        //					header.Item().AlignCenter().Text(compny.Mobile).FontSize(12);
        //				}
        //			});

        //			// **محتوى التقرير**
        //			page.Content().Column(content =>
        //			{
        //				content.Item().AlignCenter().Text("تقرير المصاريف").FontSize(16).Bold();
        //				content.Item().AlignCenter().Text("----------------------------------------------").FontSize(12).Bold();

        //				// **الجدول**
        //				content.Item().Table(table =>
        //				{
        //					table.ColumnsDefinition(columns =>
        //					{
        //						columns.RelativeColumn(); // مدخل البيانات
        //						columns.RelativeColumn(); // تاريخ الادخال
        //						columns.RelativeColumn(); // البيان
        //						columns.RelativeColumn(); // المبلغ
        //						columns.RelativeColumn(); // رقم السند
        //						columns.RelativeColumn(); // فئة الحساب
        //						columns.RelativeColumn(); // اسم الحساب
        //					});

        //					// **رأس الجدول**
        //					table.Header(header =>
        //					{
        //						header.Cell().Border(1).AlignCenter().Text("مدخل البيانات").Bold();
        //						header.Cell().Border(1).AlignCenter().Text("تاريخ الإدخال").Bold();
        //						header.Cell().Border(1).AlignCenter().Text("البيان").Bold();
        //						header.Cell().Border(1).AlignCenter().Text("المبلغ").Bold();
        //						header.Cell().Border(1).AlignCenter().Text("رقم السند").Bold();
        //						header.Cell().Border(1).AlignCenter().Text("فئة الحساب").Bold();
        //						header.Cell().Border(1).AlignCenter().Text("اسم الحساب").Bold();
        //					});

        //					// **صفوف البيانات**
        //					foreach (var ex in expenses)
        //					{
        //						string dataEntryName = dbcontext.VwUsers
        //							.Where(a => a.Email == ex.DataEntry)
        //							.Select(a => a.Name)
        //							.FirstOrDefault() ?? string.Empty;

        //						table.Cell().Border(1).AlignCenter().Text(dataEntryName);
        //						table.Cell().Border(1).AlignCenter().Text(ex.DateTimeEntry.ToString("yyyy-MM-dd HH:mm:ss"));
        //						table.Cell().Border(1).AlignCenter().Text(ex.Statement);
        //						table.Cell().Border(1).AlignCenter().Text($"{ex.Amount:C}"); // تنسيق المبلغ كعملة
        //						table.Cell().Border(1).AlignCenter().Text(ex.BondNumber);
        //						table.Cell().Border(1).AlignCenter().Text(ex.ExpenseCategory);
        //						table.Cell().Border(1).AlignCenter().Text(ex.AccountName);
        //					}
        //				});

        //				// **إجمالي المبلغ**
        //				content.Item().PaddingTop(10).AlignRight().Text($"إجمالي المبلغ: {totalAmount:C}").FontSize(14).Bold();

        //				// **إضافة تاريخ الطباعة**
        //				content.Item().PaddingTop(10).AlignRight().Text($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(10).Bold();
        //			});
        //		});
        //	});

        //	var pdfData = pdfDocument.GeneratePdf();
        //	return File(pdfData, "application/pdf", "Report.pdf");
        //}



        public async Task<IActionResult> CreateDirectPdf(int num)
        {
			var expense = dbcontext.ViewExpense.Where(a => a.BondNumber == num).FirstOrDefault();
			if (expense != null)
			{
                var pdfDocument = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A5.Landscape());
                        page.Margin(10);
                        page.DefaultTextStyle(x => x.FontSize(12));

                        page.Content().Column(column =>
                        {
                            // الصف الأول: التاريخ والمرجع
                            column.Item().Row(row =>
                            {
                                row.RelativeItem(2).Text($"التاريخ:{expense.DateBond.ToString("yyyy/MM/dd")}").Bold();
                                row.RelativeItem(1).AlignRight().Text("ح.أ").Bold();
                                row.RelativeItem(1).Width(50).Border(1);
                                row.RelativeItem(1).AlignRight().Text("دينار").Bold();
                                row.RelativeItem(1).Width(50).Border(1);
                            });

                            // العنوان
                            column.Item().AlignCenter().Text("سند صرف").FontSize(18).Bold();
                            column.Item().AlignCenter().Text("PAYMENT VOUCHER").FontSize(10).Bold().Italic();
                            column.Item().Height(5);

                            // بيانات الدفع
                            column.Item().Row(row =>
                            {
                                row.RelativeItem(1).Text($"إدفعوا إلى السيد : {expense.AccountName}").Bold();
                                row.RelativeItem(3).BorderBottom(1);
                            });

                            column.Item().Row(row =>
                            {
                                row.RelativeItem(1).Text($"مبلغ وقدره : {expense.Amount}").Bold();
                                row.RelativeItem(3).BorderBottom(1);
                            });

                            column.Item().Row(row =>
                            {
                                row.RelativeItem(1).Text($"وذلك عن :{expense.Statement}").Bold();
                                row.RelativeItem(3).BorderBottom(1);
                            });

                            column.Item().Height(10);

                            // تفاصيل الدفع عبر البنك
                            column.Item().Row(row =>
                            {
                                row.RelativeItem(1).Text("Bank : ").Bold();
                                row.RelativeItem(2).BorderBottom(1);
                                row.RelativeItem(1).Text("نقداً ").Bold();
                                row.RelativeItem(1).Box().Border(1).Width(12).Height(12);

                                row.RelativeItem(1).Text("حوالة بنكية ").Bold();
                                row.RelativeItem(1).Box().Border(1).Width(12).Height(12);

                                row.RelativeItem(1).Text("ذمم ").Bold();
                                row.RelativeItem(1).Box().Border(1).Width(12).Height(12);
                            });

                            column.Item().Height(15);

                            // التوقيعات
                            column.Item().Row(row =>
                            {
                                row.RelativeItem(1).Column(subColumn =>
                                {
                                    subColumn.Item().BorderTop(1).Width(100);
                                    subColumn.Item().AlignCenter().Text("المدير Manager").Bold();
                                });

                                row.RelativeItem(1).Column(subColumn =>
                                {
                                    subColumn.Item().BorderTop(1).Width(100);
                                    subColumn.Item().AlignCenter().Text("المحاسب Accountant").Bold();
                                });

                                row.RelativeItem(1).Column(subColumn =>
                                {
                                    subColumn.Item().BorderTop(1).Width(100);
                                    subColumn.Item().AlignCenter().Text("المستلم Receive by").Bold();
                                });
                            });
                        });
                    });
                });

                return File(pdfDocument.GeneratePdf(), "application/pdf", "Expense_Report.pdf");
            }
			return RedirectToAction("MyExpense");
        }



    }
}
