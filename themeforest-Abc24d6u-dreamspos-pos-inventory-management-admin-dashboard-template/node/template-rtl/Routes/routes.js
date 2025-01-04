const express = require("express");
const route = express.Router();
const public_routes = require("./public.routes");

var LocalStorage = require("node-localstorage").LocalStorage,
  localStorage = new LocalStorage("./local-storage");

var selected_layout = "index";

var changeLayout = function (res) {
  setLayout();
  res.redirect(public_routes.dashboard);
};

route.use(function (req, res, next) {
  let url_replace_options = req.url.replace("?", "");
  res.locals.routes = public_routes;
  res.locals.current_routes = url_replace_options;
  next();
});

var setLayout = function () {
  let current_layout = localStorage.getItem("layout");
  if (current_layout == "index") {
    selected_layout = "index";
  }

};
// setLayout();
route.get("/index", function (req, res) {
  localStorage.setItem("layout", "index");
  changeLayout(res);
});



// redirect
route.get("/", function (req, res) {
  res.redirect(public_routes.signin);
});
// redirect **

// auth
route.get(public_routes.login, (req, res, next) => {
  res.render("Auth/login");
});
route.get(public_routes.signUp, (req, res, next) => {
  res.render("Auth/signup");
});
route.get("/forget-password", (req, res, next) => {
  res.render("Auth/forgetPassword");
});
route.get("/reset-password", (req, res, next) => {
  res.render("Auth/resetPassword");
});


route.get(public_routes.signin, (req, res, next) => {
  res.render("Auth/login/signin");
});
route.get(public_routes.signin2, (req, res, next) => {
  res.render("Auth/login/signin-2");
});
route.get(public_routes.signin3, (req, res, next) => {
  res.render("Auth/login/signin-3");
});
route.get(public_routes.register, (req, res, next) => {
  res.render("Auth/register/register");
});
route.get(public_routes.register2, (req, res, next) => {
  res.render("Auth/register/register-2");
});
route.get(public_routes.register3, (req, res, next) => {
  res.render("Auth/register/register-3");
});
route.get(public_routes.forgotPassword, (req, res, next) => {
  res.render("Auth/forgot-password/forgot-password");
});
route.get(public_routes.forgotPassword2, (req, res, next) => {
  res.render("Auth/forgot-password/forgot-password-2");
});
route.get(public_routes.forgotPassword3, (req, res, next) => {
  res.render("Auth/forgot-password/forgot-password-3");
});
route.get(public_routes.resetPassword, (req, res, next) => {
  res.render("Auth/reset-password/reset-password");
});
route.get(public_routes.resetPassword2, (req, res, next) => {
  res.render("Auth/reset-password/reset-password-2");
});
route.get(public_routes.resetPassword3, (req, res, next) => {
  res.render("Auth/reset-password/reset-password-3");
});
route.get(public_routes.success, (req, res, next) => {
  res.render("Auth/success/success");
});
route.get(public_routes.success2, (req, res, next) => {
  res.render("Auth/success/success-2");
});
route.get(public_routes.success3, (req, res, next) => {
  res.render("Auth/success/success-3");
});
route.get(public_routes.emailVerification, (req, res, next) => {
  res.render("Auth/email-verification/email-verification");
});
route.get(public_routes.emailVerification2, (req, res, next) => {
  res.render("Auth/email-verification/email-verification-2");
});
route.get(public_routes.emailVerification3, (req, res, next) => {
  res.render("Auth/email-verification/email-verification-3");
});
route.get(public_routes.twoStepVerification, (req, res, next) => {
  res.render("Auth/two-step-verification/two-step-verification");
});
route.get(public_routes.twoStepVerification2, (req, res, next) => {
  res.render("Auth/two-step-verification/two-step-verification-2");
});
route.get(public_routes.twoStepVerification3, (req, res, next) => {
  res.render("Auth/two-step-verification/two-step-verification-3");
});
route.get(public_routes.lockScreen, (req, res, next) => {
  res.render("Auth/lock-screen");
});
// auth **

// main
route.get(public_routes.dashboard, (req, res, next) => {
  res.render("layout", {
    page_path: "./dashboard/dashboard",
    layout: selected_layout,
    title: "Dashboard",
  });
});
route.get(public_routes.salesDashboard, (req, res, next) => {
  res.render("layout", {
    page_path: "./dashboard/sales-dashboard",
    layout: selected_layout,
    title: "Sales Dashboard",
  });
});

//------------------------ PRODUCT ---------------------------- //

route.get(public_routes.product_list, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/productlist",
    layout: selected_layout,
    title: "Product List",
  });
});

//====== Code to be start ======== //
//add-product
route.get(public_routes.product_addProduct, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/addproduct",
    active_path: "Add Product",
    layout: selected_layout,
    title: "Add Product",
  });
});

//expired-product
route.get(public_routes.product_expiredProduct, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/expired-product",
    active_path: "Expired Product",
    layout: selected_layout,
    title: "Expired Product",
  });
});

//Low Stock
route.get(public_routes.product_lowStocks, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/low-stocks",
    active_path: "low-stocks",
    layout: selected_layout,
    title: "Low Stocks",
  });
});

//Low Stock
route.get(public_routes.product_units, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/units",
    active_path: "units",
    layout: selected_layout,
    title: "Units",
  });
});

//varriant-attributes
route.get(public_routes.product_varriantAttributes, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/varriant-attributes",
    active_path: "varriant-attributes",
    layout: selected_layout,
    title: "Varriant Attributes",
  });
});

//warranty
route.get(public_routes.product_warranty, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/warranty",
    active_path: "warranty",
    layout: selected_layout,
    title: "Warranty",
  });
});

//categorylist
route.get(public_routes.product_categoryList, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/categorylist",
    active_path: "Category List",
    layout: selected_layout,
    title: "Category List",
  });
});

//addcategory
route.get(public_routes.product_addCategory, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/addcategory",
    layout: selected_layout,
    title: "Add Category",
  });
});

//subcategorylist
route.get(public_routes.product_subCategoryList, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/subcategorylist",
    layout: selected_layout,
    title: "Sub Category List",
  });
});

//addsubcategory
route.get(public_routes.product_addSubCategory, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/addsubcategory",
    layout: selected_layout,
    title: "Add Sub Category",
  });
});

//brandlist
route.get(public_routes.product_brandList, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/brandlist",
    layout: selected_layout,
    title: "Brand List",
  });
});

//addbrand
route.get(public_routes.product_addBrand, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/addbrand",
    layout: selected_layout,
    title: "Add Brand",
  });
});

//importproduct
route.get(public_routes.product_importProduct, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/importproduct",
    layout: selected_layout,
    title: "Import Product",
  });
});

//printbarcode
route.get(public_routes.product_printBarcode, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/printbarcode",
    layout: selected_layout,
    title: "Print BarCode",
  });
});

//qrcode
route.get(public_routes.product_qrcode, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/qrcode",
    layout: selected_layout,
    title: "Print qrcode",
  });
});

//Product Details
route.get(public_routes.product_productDetails, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/productdetails",
    layout: selected_layout,
    title: "Product Details",
  });
});

//Edit Product
route.get(public_routes.product_editProduct, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/editproduct",
    layout: selected_layout,
    title: "Edit Product",
  });
});

//Edit Category
route.get(public_routes.product_editCategory, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/editcategory",
    layout: selected_layout,
    title: "Edit Category",
  });
});

//Edit Brand
route.get(public_routes.product_editBrand, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/editbrand",
    layout: selected_layout,
    title: "Edit Brand",
  });
});

//Edit Sub Category
route.get(public_routes.product_editSubCategory, (req, res, next) => {
  res.render("layout", {
    page_path: "./product/editsubcategory",
    layout: selected_layout,
    title: "Edit Sub Category",
  });
});

//------------------------ /PRODUCT ---------------------------- //

//------------------------  SALES ---------------------------- //

//Sales
route.get(public_routes.sales_salesList, (req, res, next) => {
  res.render("layout", {
    page_path: "./sales/saleslist",
    layout: selected_layout,
    title: "Sales List",
  });
});

//POS
route.get(public_routes.sales_pos, (req, res, next) => {
  res.render("layout", {
    page_path: "./sales/pos",
    layout: selected_layout,
    title: "POS",
  });
});

//New Sales
route.get(public_routes.sales_newSales, (req, res, next) => {
  res.render("layout", {
    page_path: "./sales/newsales",
    layout: selected_layout,
    title: "New Sales",
  });
});

//SalesReturnList
route.get(public_routes.sales_salesReturnLists, (req, res, next) => {
  res.render("layout", {
    page_path: "./sales/salesreturnlists",
    layout: selected_layout,
    title: "Sales Return List",
  });
});

//NewSalesReturn
route.get(public_routes.sales_newSalesReturn, (req, res, next) => {
  res.render("layout", {
    page_path: "./sales/newsalesreturn",
    layout: selected_layout,
    title: "New Sales Return",
  });
});

// Edit Sales
route.get(public_routes.sales_editSales, (req, res, next) => {
  res.render("layout", {
    page_path: "./sales/editsales",
    layout: selected_layout,
    title: "Edit Sales",
  });
});

// Sales Details
route.get(public_routes.sales_salesDetails, (req, res, next) => {
  res.render("layout", {
    page_path: "./sales/salesdetails",
    layout: selected_layout,
    title: "Sales Details",
  });
});

//EditSalesReturns
route.get(public_routes.sales_editSalesReturns, (req, res, next) => {
  res.render("layout", {
    page_path: "./sales/editsalesreturns",
    layout: selected_layout,
    title: "Edit Sales Returns",
  });
});

//------------------------ /SALES ---------------------------- //
//------------------------ PURCHASE ---------------------------- //

//Purchase List
route.get(public_routes.purchase_purchaseList, (req, res, next) => {
  res.render("layout", {
    page_path: "./purchase/purchaselist",
    layout: selected_layout,
    title: "Purchase List",
  });
});

//Add Purchase
route.get(public_routes.purchase_addPurchase, (req, res, next) => {
  res.render("layout", {
    page_path: "./purchase/addpurchase",
    layout: selected_layout,
    title: "Add Purchase",
  });
});

//Import Purchase
route.get(public_routes.purchase_importPurchase, (req, res, next) => {
  res.render("layout", {
    page_path: "./purchase/importpurchase",
    layout: selected_layout,
    title: "Import Purchase",
  });
});

//Edit Purchase
route.get(public_routes.purchase_editPurchase, (req, res, next) => {
  res.render("layout", {
    page_path: "./purchase/editpurchase",
    layout: selected_layout,
    title: "Edit Purchase",
  });
});
//------------------------ /PURCHASE ---------------------------- //
//------------------------ EXPENSES ---------------------------- //

//Expense List
route.get(public_routes.expense_expenseList, (req, res, next) => {
  res.render("layout", {
    page_path: "./expense/expenselist",
    layout: selected_layout,
    title: "Expense List",
  });
});



//Expense Category
route.get(public_routes.expense_expenseCategory, (req, res, next) => {
  res.render("layout", {
    page_path: "./expense/expensecategory",
    layout: selected_layout,
    title: "Expense Category",
  });
});



//------------------------ /EXPENSES ---------------------------- //
//------------------------ QUOTATION ---------------------------- //

//Quotation List
route.get(public_routes.quotation_quotationList, (req, res, next) => {
  res.render("layout", {
    page_path: "./quotation/quotationlist",
    layout: selected_layout,
    title: "Quotation List",
  });
});

//Add Quotation
route.get(public_routes.quotation_addQuotation, (req, res, next) => {
  res.render("layout", {
    page_path: "./quotation/addquotation",
    layout: selected_layout,
    title: "Add Quotation",
  });
});

//Edit Quotation
route.get(public_routes.quotation_editQuotation, (req, res, next) => {
  res.render("layout", {
    page_path: "./quotation/editquotation",
    layout: selected_layout,
    title: "Edit Quotation",
  });
});
//------------------------ /QUOTATION ---------------------------- //
//------------------------ TRANSFER---------------------------- //

//Transfer List
route.get(public_routes.transfer_transferList, (req, res, next) => {
  res.render("layout", {
    page_path: "./transfer/transferlist",
    layout: selected_layout,
    title: "Transfer List",
  });
});

//Add Transfer
route.get(public_routes.transfer_addTransfer, (req, res, next) => {
  res.render("layout", {
    page_path: "./transfer/addtransfer",
    layout: selected_layout,
    title: "Add Transfer",
  });
});

//Import Transfer
route.get(public_routes.transfer_importTransfer, (req, res, next) => {
  res.render("layout", {
    page_path: "./transfer/importtransfer",
    layout: selected_layout,
    title: "Import Transfer",
  });
});

//Import Transfer
route.get(public_routes.transfer_editTransfer, (req, res, next) => {
  res.render("layout", {
    page_path: "./transfer/edittransfer",
    layout: selected_layout,
    title: "Edit Transfer",
  });
});

//------------------------ /TRANSFER---------------------------- //
//------------------------ RETURN ---------------------------- //

// Sales Return List
route.get(public_routes.return_salesReturnList, (req, res, next) => {
  res.render("layout", {
    page_path: "./return/salesreturnlist",
    layout: selected_layout,
    title: "Sales Return List",
  });
});

// Add Sales Return
route.get(public_routes.return_addSalesReturn, (req, res, next) => {
  res.render("layout", {
    page_path: "./return/addsalesreturn",
    layout: selected_layout,
    title: "Add Sales Return",
  });
});

// Purchase Return List
route.get(public_routes.return_purchaseReturnList, (req, res, next) => {
  res.render("layout", {
    page_path: "./return/purchasereturnlist",
    layout: selected_layout,
    title: "Purchase Return List",
  });
});

// Add Purchase List
route.get(public_routes.return_addPurchaseReturn, (req, res, next) => {
  res.render("layout", {
    page_path: "./return/addpurchasereturn",
    layout: selected_layout,
    title: "Add Purchase Return",
  });
});

// Edit Sales Return
route.get(public_routes.return_editSalesReturn, (req, res, next) => {
  res.render("layout", {
    page_path: "./return/editsalesreturn",
    layout: selected_layout,
    title: "Edit Sales Return",
  });
});

//Edit Purchase Return
route.get(public_routes.return_editPurchaseReturn, (req, res, next) => {
  res.render("layout", {
    page_path: "./return/editpurchasereturn",
    layout: selected_layout,
    title: "Edit Purchase Return",
  });
});

//------------------------ /RETURN ---------------------------- //
//------------------------ PEOPLE ---------------------------- //

//Customer List
route.get(public_routes.people_customerList, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/customerlist",
    layout: selected_layout,
    title: "Customer List",
  });
});

//Add Customer
route.get(public_routes.people_addCustomer, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/addcustomer",
    layout: selected_layout,
    title: "Add Customer",
  });
});

//Supplier List
route.get(public_routes.people_supplierList, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/supplierlist",
    layout: selected_layout,
    title: "Supper List",
  });
});

//Add Supplier
route.get(public_routes.people_addSupplier, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/addsupplier",
    layout: selected_layout,
    title: "Add Supplier",
  });
});

//User List
route.get(public_routes.people_userList, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/userlist",
    layout: selected_layout,
    title: "User List",
  });
});

//Add User
route.get(public_routes.people_addUser, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/adduser",
    layout: selected_layout,
    title: "Add User",
  });
});

//Store List
route.get(public_routes.people_storeList, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/storelist",
    layout: selected_layout,
    title: "Store List",
  });
});

//Add Store
route.get(public_routes.people_addStore, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/addstore",
    layout: selected_layout,
    title: "Add Store",
  });
});

//Edit Customer
route.get(public_routes.people_editCustomer, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/editcustomer",
    layout: selected_layout,
    title: "Edit Customer",
  });
});

//Edit user
route.get(public_routes.people_editUser, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/edituser",
    layout: selected_layout,
    title: "Edit user",
  });
});

//Edit
route.get(public_routes.people_editList, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/editstore",
    layout: selected_layout,
    title: "Edit List",
  });
});

//Edit Supplier
route.get(public_routes.people_editSupplier, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/editsupplier",
    layout: selected_layout,
    title: "Edit Supplier",
  });
});

//------------------------ /PEOPLE ---------------------------- //
//------------------------ PLACE ---------------------------- //

//New Country
route.get(public_routes.place_newCountry, (req, res, next) => {
  res.render("layout", {
    page_path: "./places/newcountry",
    layout: selected_layout,
    title: "New Country",
  });
});

//Countries List
route.get(public_routes.place_countriesList, (req, res, next) => {
  res.render("layout", {
    page_path: "./places/countrieslist",
    layout: selected_layout,
    title: "Country List",
  });
});

//New State
route.get(public_routes.place_newState, (req, res, next) => {
  res.render("layout", {
    page_path: "./places/newstate",
    layout: selected_layout,
    title: "New State",
  });
});

//State List
route.get(public_routes.place_stateList, (req, res, next) => {
  res.render("layout", {
    page_path: "./places/statelist",
    layout: selected_layout,
    title: "State List",
  });
});

//Edit country
route.get(public_routes.place_editCountry, (req, res, next) => {
  res.render("layout", {
    page_path: "./places/editcountry",
    layout: selected_layout,
    title: "Edit Country",
  });
});

//Edit State
route.get(public_routes.place_editState, (req, res, next) => {
  res.render("layout", {
    page_path: "./places/editstate",
    layout: selected_layout,
    title: "Edit State",
  });
});

//
//------------------------ /PLACE ---------------------------- //
//------------------------ Components ---------------------------- //
route.get(public_routes.components, (req, res, next) => {
  res.render("layout", {
    page_path: "./components/components",
    layout: selected_layout,
    title: "Components",
  });
});
//------------------------ /Components ---------------------------- //
//------------------------ Blank Page ---------------------------- //
route.get(public_routes.blankPage, (req, res, next) => {
  res.render("layout", {
    page_path: "./blankpage/blankpage",
    layout: selected_layout,
    title: "Blank Page",
  });
});
//------------------------ /Blank Page ---------------------------- //
//------------------------ Error Pages ---------------------------- //

// 404 - Error
route.get(public_routes.pageNotFound, (req, res, next) => {
  res.render("index-error", {
    page_path: "./error/error404",
    layout: "index-error",
    title: "404 Error",
  });
});

// 500 - Error
route.get(public_routes.serverError, (req, res, next) => {
  res.render("index-error", {
    page_path: "./error/error500",
    layout: "index-error",
    title: "500 Error",
  });
});
// underMaintenance
route.get(public_routes.underMaintenance, (req, res, next) => {
  res.render("index-error", {
    page_path: "./error/under-maintenance",
    layout: "index-error",
    title: "Under Maintenance",
  });
});
// underMaintenance
route.get(public_routes.comingSoon, (req, res, next) => {
  res.render("index-error", {
    page_path: "./error/coming-soon",
    layout: "index-error",
    title: "Coming Soon",
  });
});
//------------------------ /Error Pages ---------------------------- //
//------------------------ Elements ---------------------------- //

//Sweet Alerts
route.get(public_routes.elements_sweetAlerts, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/sweetalerts",
    layout: selected_layout,
    title: "Sweet Alerts",
  });
});

//Tooltip
route.get(public_routes.elements_toolTip, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/tooltip",
    layout: selected_layout,
    title: "Tool Tip",
  });
});

//Popover
route.get(public_routes.elements_popOver, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/popover",
    layout: selected_layout,
    title: "Popover",
  });
});

//Ribbon
route.get(public_routes.elements_ribbon, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/ribbon",
    layout: selected_layout,
    title: "Ribbon",
  });
});

//Clipboard
route.get(public_routes.elements_clipboard, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/clipboard",
    layout: selected_layout,
    title: "Clipboard",
  });
});

//Drag & Drop
route.get(public_routes.elements_dragDrop, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/drag&drop",
    layout: selected_layout,
    title: "Drag & Drop",
  });
});

//Range Slider
route.get(public_routes.elements_rangeSlider, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/rangeslider",
    layout: selected_layout,
    title: "Range Slider",
  });
});

//Rating
route.get(public_routes.elements_rating, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/rating",
    layout: selected_layout,
    title: "Rating",
  });
});

//Toastr
route.get(public_routes.elements_toastr, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/toastr",
    layout: selected_layout,
    title: "Toastr",
  });
});

//Text Editor
route.get(public_routes.elements_textEditor, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/texteditor",
    layout: selected_layout,
    title: "Text Editor",
  });
});

//Counter
route.get(public_routes.elements_counter, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/counter",
    layout: selected_layout,
    title: "Counter",
  });
});

//Scrollbar
route.get(public_routes.elements_scrollBar, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/scrollbar",
    layout: selected_layout,
    title: "Scrollbar",
  });
});

//Spinner
route.get(public_routes.elements_spinner, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/spinner",
    layout: selected_layout,
    title: "Spinner",
  });
});

//Notification
route.get(public_routes.elements_notification, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/notifications",
    layout: selected_layout,
    title: "Notifiaction",
  });
});

//Lightbox
route.get(public_routes.elements_lightBox, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/lightbox",
    layout: selected_layout,
    title: "Light Box",
  });
});

//Sticky Note
route.get(public_routes.elements_stickyNote, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/stickynote",
    layout: selected_layout,
    title: "Sticky Note",
  });
});

// Timeline
route.get(public_routes.elements_timeLine, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/timeline",
    layout: selected_layout,
    title: "Timelilne",
  });
});

//Form Wizard
route.get(public_routes.elements_formWizard, (req, res, next) => {
  res.render("layout", {
    page_path: "./elements/formwizard",
    layout: selected_layout,
    title: "Form Wizard",
  });
});

//------------------------ /Elements ---------------------------- //
//------------------------ Charts ---------------------------- //

//Apex Charts
route.get(public_routes.charts_apexCharts, (req, res, next) => {
  res.render("layout", {
    page_path: "./charts/apexcharts",
    layout: selected_layout,
    title: "Apex Charts",
  });
});

//Chart JS
route.get(public_routes.charts_chartsJs, (req, res, next) => {
  res.render("layout", {
    page_path: "./charts/chartjs",
    layout: selected_layout,
    title: "Chart Js",
  });
});

//Morris Charts
route.get(public_routes.charts_morrisCharts, (req, res, next) => {
  res.render("layout", {
    page_path: "./charts/morrischarts",
    layout: selected_layout,
    title: "Morris Charts",
  });
});

//Flot Charts
route.get(public_routes.charts_flotCharts, (req, res, next) => {
  res.render("layout", {
    page_path: "./charts/flotcharts",
    layout: selected_layout,
    title: "Flot Charts",
  });
});

//Peity Charts
route.get(public_routes.charts_peityCharts, (req, res, next) => {
  res.render("layout", {
    page_path: "./charts/peitycharts",
    layout: selected_layout,
    title: "Peity Charts",
  });
});
//------------------------ /Charts ---------------------------- //
//------------------------ Map ---------------------------- //
route.get(public_routes.maps_leaflet, (req, res, next) => {
  res.render("layout", {
    page_path: "./map/maps-leaflet",
    layout: selected_layout,
    title: "Maps",
  });
});
route.get(public_routes.maps_vector, (req, res, next) => {
  res.render("layout", {
    page_path: "./map/maps-vector",
    layout: selected_layout,
    title: "Maps",
  });
});
//------------------------ Icons ---------------------------- //

//FontAwesome Icons
route.get(public_routes.icon_bootstrap, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/icon-bootstrap",
    layout: selected_layout,
    title: "Icons",
  });
});
route.get(public_routes.icon_remix, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/icon-remix",
    layout: selected_layout,
    title: "Icons",
  });
});
route.get(public_routes.icon_tabler, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/icon-tabler",
    layout: selected_layout,
    title: "Icons",
  });
});
route.get(public_routes.icons_fontAwesomeIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/fontawesomeicons",
    layout: selected_layout,
    title: "Font Awesome Icons",
  });
});

//Feather Icons
route.get(public_routes.icons_featherIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/feathericons",
    layout: selected_layout,
    title: "Feather Icons",
  });
});

//Ionic Icons
route.get(public_routes.icons_ionicIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/ionicicons",
    layout: selected_layout,
    title: "Ionic Icons",
  });
});

//Material Icons
route.get(public_routes.icons_materialIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/materialicons",
    layout: selected_layout,
    title: "Material Icons",
  });
});

//Pe7 Icons
route.get(public_routes.icons_pe7Icons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/pe7icons",
    layout: selected_layout,
    title: "Pe7 Icons",
  });
});

//SimpleLine Icons
route.get(public_routes.icons_simpleLineIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/simplelineicons",
    layout: selected_layout,
    title: "Simpleline Icons",
  });
});

//Themify Icons
route.get(public_routes.icons_themifyIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/themifyicons",
    layout: selected_layout,
    title: "Themify Icons",
  });
});

//Weather Icons
route.get(public_routes.icons_weatherIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/weathericons",
    layout: selected_layout,
    title: "Weather Icons",
  });
});

//Typicon Icons
route.get(public_routes.icons_typiconIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/typiconicons",
    layout: selected_layout,
    title: "Typicon Icons",
  });
});

//Flag Icons
route.get(public_routes.icons_flagIcons, (req, res, next) => {
  res.render("layout", {
    page_path: "./icons/flagicons",
    layout: selected_layout,
    title: "Flag Icons",
  });
});
//------------------------ /Icons ---------------------------- //
//------------------------ Forms ---------------------------- //

//Basic Inputs
route.get(public_routes.form_pickers, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/form-pickers",
    layout: selected_layout,
    title: "Basic Inputs",
  });
});
route.get(public_routes.form_basicInputs, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/basicinputs",
    layout: selected_layout,
    title: "Basic Inputs",
  });
});

//Input Group
route.get(public_routes.form_inputGroups, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/inputgroups",
    layout: selected_layout,
    title: "Input Groups",
  });
});

//Horizontal Form
route.get(public_routes.form_horizontalForm, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/horizontalform",
    layout: selected_layout,
    title: "Horizontal Form",
  });
});

//Vertical Form
route.get(public_routes.form_verticalForm, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/verticalform",
    layout: selected_layout,
    title: "Vertical Form",
  });
});

//Form Mask
route.get(public_routes.form_formMask, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/formmask",
    layout: selected_layout,
    title: "Form Mask",
  });
});

//Form Validation
route.get(public_routes.form_formValidation, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/formvalidation",
    layout: selected_layout,
    title: "Form Validation",
  });
});

//Form Select2
route.get(public_routes.form_formSelected2, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/formselect2",
    layout: selected_layout,
    title: "Form Select2",
  });
});

//File Upload
route.get(public_routes.form_fileUpload, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/fileupload",
    layout: selected_layout,
    title: "File Upload",
  });
});
route.get(public_routes.form_checkbox_radios, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/form-checkbox-radios",
    layout: selected_layout,
    title: "Form",
  });
});
route.get(public_routes.form_grid_gutters, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/form-grid-gutters",
    layout: selected_layout,
    title: "Form",
  });
});
route.get(public_routes.form_select, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/form-select",
    layout: selected_layout,
    title: "Form",
  });
});
route.get(public_routes.form_floating_labels, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/form-floating-labels",
    layout: selected_layout,
    title: "Form",
  });
});
route.get(public_routes.form_wizard, (req, res, next) => {
  res.render("layout", {
    page_path: "./forms/form-wizard",
    layout: selected_layout,
    title: "Form",
  });
});
//------------------------ /Forms ---------------------------- //
//------------------------ Table ---------------------------- //

//Basic Tables
route.get(public_routes.table_basicTable, (req, res, next) => {
  res.render("layout", {
    page_path: "./table/basictables",
    layout: selected_layout,
    title: "Basic Tables",
  });
});

//Data Tebles
route.get(public_routes.table_dataTable, (req, res, next) => {
  res.render("layout", {
    page_path: "./table/datatable",
    layout: selected_layout,
    title: "Data Table",
  });
});
//------------------------ /Table ---------------------------- //
//------------------------ Application ---------------------------- //

//Chat
route.get(public_routes.application_chat, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/chat",
    layout: selected_layout,
    title: "Chat",
  });
});
route.get(public_routes.social_feed, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/social-feed",
    layout: selected_layout,
    title: "social-feed",
  });
});
route.get(public_routes.kanban_view, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/kanban-view",
    layout: selected_layout,
    title: "kanban-view",
  });
});
route.get(public_routes.call_history, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/call-history",
    layout: selected_layout,
    title: "Call",
  });
});
route.get(public_routes.audio_call, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/audio-call",
    layout: selected_layout,
    title: "audio-call",
  });
});
route.get(public_routes.video_call, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/video-call",
    layout: selected_layout,
    title: "video-call",
  });
});
route.get(public_routes.file_manager, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/file-manager",
    layout: selected_layout,
    title: "File-manager",
  });
});
route.get(public_routes.file_shared, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/file-shared",
    layout: selected_layout,
    title: "File-manager",
  });
});
route.get(public_routes.file_document, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/file-document",
    layout: selected_layout,
    title: "File-manager",
  });
});
route.get(public_routes.file_recent, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/file-recent",
    layout: selected_layout,
    title: "File-manager",
  });
});
route.get(public_routes.file_favourites, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/file-favourites",
    layout: selected_layout,
    title: "File-manager",
  });
});
route.get(public_routes.file_archived, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/file-archived",
    layout: selected_layout,
    title: "File-manager",
  });
});
route.get(public_routes.file_manager_deleted, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/file-manager-deleted",
    layout: selected_layout,
    title: "File-manager",
  });
});
route.get(public_routes.notes, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/notes",
    layout: selected_layout,
    title: "Notes",
  });
});
route.get(public_routes.todo, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/todo",
    layout: selected_layout,
    title: "todo",
  });
});

//Calendar
route.get(public_routes.application_calendar, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/calendar",
    layout: selected_layout,
    title: "Calendar",
  });
});

//Email
route.get(public_routes.application_email, (req, res, next) => {
  res.render("layout", {
    page_path: "./application/email",
    layout: selected_layout,
    title: "Email",
  });
});
//------------------------ /Application ---------------------------- //
//------------------------ Report ---------------------------- //

//Purchase Order Report
route.get(public_routes.report_purchaseOrderReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/purchaseorderreport",
    layout: selected_layout,
    title: "Purchase Order Report",
  });
});

//Inventory Report
route.get(public_routes.report_inventoryReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/inventoryreport",
    layout: selected_layout,
    title: "Inventory Report",
  });
});

//Sales Report
route.get(public_routes.report_salesReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/salesreport",
    layout: selected_layout,
    title: "Sales Report",
  });
});

//Invoice Report
route.get(public_routes.report_invoiceReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/invoicereport",
    layout: selected_layout,
    title: "Invoice Report",
  });
});

//Purchase Report
route.get(public_routes.report_purchaseReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/purchasereport",
    layout: selected_layout,
    title: "Purchase Report",
  });
});

//Supplier Report
route.get(public_routes.report_supplierReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/supplierreport",
    layout: selected_layout,
    title: "Suppler Report",
  });
});

//Customer Report
route.get(public_routes.report_customerReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/customerreport",
    layout: selected_layout,
    title: "Customer Report",
  });
});

//profit-and-loss
route.get(public_routes.report_profit_and_loss, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/profit-and-loss",
    layout: selected_layout,
    title: "Report",
  });
});

//tax-reports
route.get(public_routes.report_taxReports, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/tax-reports",
    layout: selected_layout,
    title: "Report",
  });
});

//income-report
route.get(public_routes.report_incomeReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/income-report",
    layout: selected_layout,
    title: "Report",
  });
});

//expense-report
route.get(public_routes.report_expenseReport, (req, res, next) => {
  res.render("layout", {
    page_path: "./report/expense-report",
    layout: selected_layout,
    title: "Report",
  });
});
//------------------------ /Report ---------------------------- //
//------------------------ Users ---------------------------- //

//New User
route.get(public_routes.users_newUser, (req, res, next) => {
  res.render("layout", {
    page_path: "./users/newuser",
    layout: selected_layout,
    title: "New User",
  });
});

//Users List
route.get(public_routes.users_usersList, (req, res, next) => {
  res.render("layout", {
    page_path: "./users/userslist",
    layout: selected_layout,
    title: "Users List",
  });
});
//Users List
route.get(public_routes.delete_account, (req, res, next) => {
  res.render("layout", {
    page_path: "./users/delete-account",
    layout: selected_layout,
    title: "Delete Account",
  });
});
//Users List
route.get(public_routes.roles_permissions, (req, res, next) => {
  res.render("layout", {
    page_path: "./users/roles-permissions",
    layout: selected_layout,
    title: "Users",
  });
});
//Users List
route.get(public_routes.permissions, (req, res, next) => {
  res.render("layout", {
    page_path: "./users/permissions",
    layout: selected_layout,
    title: "Users",
  });
});

//------------------------ /Users ---------------------------- //
//------------------------ Settings ---------------------------- //

//General Setting
route.get(public_routes.setting_generalSetting, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/general",
    layout: selected_layout,
    title: "General Settings",
  });
});

//Email Setting
route.get(public_routes.setting_emailSetting, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/emailset",
    layout: selected_layout,
    title: "Email Settings",
  });
});

//Payment Setting
route.get(public_routes.setting_paymentSetting, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/payment",
    layout: selected_layout,
    title: "Payment Settings",
  });
});

//Currency Setting
route.get(public_routes.setting_currencySetting, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/currency",
    layout: selected_layout,
    title: "Currency Settings",
  });
});

//Group Permission
route.get(public_routes.setting_groupPermission, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/grouppermission",
    layout: selected_layout,
    title: "Group Permissions",
  });
});

//Create Permission
route.get(public_routes.setting_createPermission, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/createpermission",
    layout: selected_layout,
    title: "Create Permission",
  });
});

//Tax Rates
route.get(public_routes.setting_taxRates, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/taxrates",
    layout: selected_layout,
    title: "Tax Rates",
  });
});

//Edit Permission
route.get(public_routes.setting_editPermission, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/editpermission",
    layout: selected_layout,
    title: "Edit Permission",
  });
});
//general-settings
route.get(public_routes.generalSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/general-settings/general-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//general-settings
route.get(public_routes.securitySettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/general-settings/security-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//general-settings
route.get(public_routes.connectedApps, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/general-settings/connected-apps",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.notification, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/general-settings/notification",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.systemSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/website-settings/system-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.companySettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/website-settings/company-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.localizationSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/website-settings/localization-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.languageSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/website-settings/language-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.socialAuthentication, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/website-settings/social-authentication",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.appearance, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/website-settings/appearance",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.preference, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/website-settings/preference",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.prefixes, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/website-settings/prefixes",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.customFields, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/app-settings/custom-fields",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.posSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/app-settings/pos-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.printerSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/app-settings/printer-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.invoiceSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/app-settings/invoice-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.emailSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/system-settings/email-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.gdprSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/system-settings/gdpr-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.otpSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/system-settings/otp-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.smsGateway, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/system-settings/sms-gateway",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.currencySettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/financial-settings/currency-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.bankSettingsGrid, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/financial-settings/bank-settings-grid",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.bankSettingsList, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/financial-settings/bank-settings-list",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.paymentGatewaySettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/financial-settings/payment-gateway-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.storageSettings, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/other-settings/storage-settings",
    layout: selected_layout,
    title: "Settings",
  });
});
//settings
route.get(public_routes.banIpAddress, (req, res, next) => {
  res.render("layout", {
    page_path: "./settings/other-settings/ban-ip-address",
    layout: selected_layout,
    title: "Settings",
  });
});
//------------------------ /Settings ---------------------------- //
//------------------------  Activities / Profile---------------------------- //

//Activities
route.get(public_routes.activities, (req, res, next) => {
  res.render("layout", {
    page_path: "./activities/activities",
    layout: selected_layout,
    title: "Activies",
  });
});

//Activities
route.get(public_routes.profile, (req, res, next) => {
  res.render("layout", {
    page_path: "./activities/profile",
    layout: selected_layout,
    title: "Profile",
  });
});

//manage-stocks
route.get(public_routes.manageStocks, (req, res, next) => {
  res.render("layout", {
    page_path: "./stock/manage-stocks",
    layout: selected_layout,
    title: "Manage Stocks",
  });
});

//stock-adjustment
route.get(public_routes.stockAdjustment, (req, res, next) => {
  res.render("layout", {
    page_path: "./stock/stock-adjustment",
    layout: selected_layout,
    title: "Stock Adjustment",
  });
});

//stock-transfer
route.get(public_routes.stockTransfer, (req, res, next) => {
  res.render("layout", {
    page_path: "./stock/stock-transfer",
    layout: selected_layout,
    title: "Stock Transfer",
  });
});

//coupons
route.get(public_routes.coupons, (req, res, next) => {
  res.render("layout", {
    page_path: "./coupons/coupons",
    layout: selected_layout,
    title: "Coupons",
  });
});

//warehouse
route.get(public_routes.warehouse, (req, res, next) => {
  res.render("layout", {
    page_path: "./people/warehouse",
    layout: selected_layout,
    title: "warehouse",
  });
});
//employees_grid
route.get(public_routes.employees_grid, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/employees/employees-grid",
    layout: selected_layout,
    title: "employees-grid",
  });
});
//employees_list
route.get(public_routes.employees_list, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/employees/employees-list",
    layout: selected_layout,
    title: "employees-list",
  });
});
//edit_employees
route.get(public_routes.edit_employees, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/employees/edit-employee",
    layout: selected_layout,
    title: "Edit Employees",
  });
});
//add_employees
route.get(public_routes.add_employees, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/employees/add-employee",
    layout: selected_layout,
    title: "Add Employees",
  });
});
//department_grid
route.get(public_routes.department_grid, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/department/department-grid",
    layout: selected_layout,
    title: "Department Grid",
  });
});
//department_list
route.get(public_routes.department_list, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/department/department-list",
    layout: selected_layout,
    title: "Department List",
  });
});
//designation
route.get(public_routes.designation, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/designation",
    layout: selected_layout,
    title: "Designation",
  });
});
//shift
route.get(public_routes.shift, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/shift",
    layout: selected_layout,
    title: "Shift",
  });
});
//attendance_admin
route.get(public_routes.attendance_admin, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/attendance/attendance-admin",
    layout: selected_layout,
    title: "Attendance Admin",
  });
});
//attendance_employee
route.get(public_routes.attendance_employee, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/attendance/attendance-employee",
    layout: selected_layout,
    title: "Attendance Employee",
  });
});
//leave_types
route.get(public_routes.leave_types, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/leaves/leave-types",
    layout: selected_layout,
    title: "Leave Types",
  });
});
//leaves_employee
route.get(public_routes.leaves_employee, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/leaves/leaves-employee",
    layout: selected_layout,
    title: "Leaves Employee",
  });
});
//leaves_admin
route.get(public_routes.leaves_admin, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/leaves/leaves-admin",
    layout: selected_layout,
    title: "Leaves Admin",
  });
});
//holidays
route.get(public_routes.holidays, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/holidays",
    layout: selected_layout,
    title: "Holidays",
  });
});
//payslip
route.get(public_routes.payslip, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/payroll/payslip",
    layout: selected_layout,
    title: "Payslip",
  });
});
//holidays
route.get(public_routes.payroll_list, (req, res, next) => {
  res.render("layout", {
    page_path: "./hrm/payroll/payroll-list",
    layout: selected_layout,
    title: "Payroll List",
  });
});

//------------------------ /Activities/Profile ---------------------------- //

//------------------------ Elements ---------------------------- //


route.get(public_routes.ui_sortable, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-sortable",
    layout: selected_layout,
    title: "Base-UI",
  });
});
route.get(public_routes.ui_swiperjs, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-swiperjs",
    layout: selected_layout,
    title: "Base-UI",
  });
});
route.get(public_routes.ui_carousel, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-carousel",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_cards, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-cards",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_breadcrumb, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-breadcrumb",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_buttons_group, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-buttons-group",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_buttons, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-buttons",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_borders, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-borders",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_badges, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-badges",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_avatar, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-avatar",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_accordion, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-accordion",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_alerts, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-alerts",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_colors, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-colors",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_popovers, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-popovers",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_pagination, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-pagination",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_offcanvas, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-offcanvas",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_modals, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-modals",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_media, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-media",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_lightbox, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-lightbox",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_images, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-images",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_grid, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-grid",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_dropdowns, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-dropdowns",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_progress, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-progress",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_video, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-video",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_typography, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-typography",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_tooltips, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-tooltips",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_toasts, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-toasts",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_nav_tabs, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-nav-tabs",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_sweetalerts, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-sweetalerts",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_spinner, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-spinner",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_rangeslider, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-rangeslider",
    layout: selected_layout,
    title: "Base-UI",
  });
});

route.get(public_routes.ui_placeholders, (req, res, next) => {
  res.render("layout", {
    page_path: "./base-ui/ui-placeholders",
    layout: selected_layout,
    title: "Base-UI",
  });
});


//------------------------ /Elements ---------------------------- //

// main **

// wild card route
route.all("*", function (req, res) {
  res.redirect(public_routes.signin);
});
// wild card route **

module.exports = route;
