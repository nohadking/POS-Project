const public_routes = {};

public_routes.login = "/login";

public_routes.signUp = "/sign-up";

public_routes.pageNotFound = "/error-404";

public_routes.serverError = "/error-500";

public_routes.dashboard = "/dashboard";

public_routes.salesDashboard = "/sales-dashboard";

public_routes.components = "/components";

public_routes.blankPage = "/blank-page";

public_routes.activities = "/activities";

public_routes.profile = "/profile";

// -- Product Router-- //
public_routes.product_list = "/product-list";

public_routes.product_addProduct = "/add-product";

public_routes.product_expiredProduct = "/expired-products";

public_routes.product_lowStocks = "/low-stocks";

public_routes.product_categoryList = "/category-list";

public_routes.product_units = "/units";

public_routes.product_qrcode = "/qrcode";

public_routes.product_warranty = "/warranty";

public_routes.product_varriantAttributes = "/varriant-attributes";

public_routes.product_addCategory = "/add-category";

public_routes.product_subCategoryList = "/sub-category-list";

public_routes.product_addSubCategory = "/add-sub-category";

public_routes.product_brandList = "/brand-list";

public_routes.product_addBrand = "/add-brand";

public_routes.product_importProduct = "/import-products";

public_routes.product_printBarcode = "/print-barcode";

public_routes.product_productDetails = "/product-details";

public_routes.product_editProduct = "/edit-product";

public_routes.product_editCategory = "/edit-category";

public_routes.product_editBrand = "/edit-brand";

public_routes.product_editSubCategory = "/edit-sub-category";

// -- sales Router-- //

public_routes.sales_salesList = "/sales-list";

public_routes.sales_pos = "/pos";

public_routes.sales_newSales = "/new-sales";

public_routes.sales_salesReturnLists = "/sales-return-lists";

public_routes.sales_newSalesReturn = "/new-sales-returns";

public_routes.sales_editSales = "/edit-sales";

public_routes.sales_salesDetails = "/sales-details";

public_routes.sales_editSalesReturns = "/edit-sales-returns";

// -- Purchase Router-- //

public_routes.purchase_purchaseList = "/purchase-list";

public_routes.purchase_addPurchase = "/add-purchase";

public_routes.purchase_importPurchase = "/import-purchase";

public_routes.purchase_editPurchase = "/edit-purchase";

// -- Expense Router-- //

public_routes.expense_expenseList = "/expense-list";

public_routes.expense_addExpense = "/add-expense";

public_routes.expense_expenseCategory = "/expense-category";

public_routes.expense_editExpense = "/edit-expense";

// -- Quotation Router-- //

public_routes.quotation_quotationList = "/quotation-list";

public_routes.quotation_addQuotation = "/add-quotation";

public_routes.quotation_editQuotation = "/edit-quotation";

// -- Transfer Router-- //

public_routes.transfer_transferList = "/transfer-list";

public_routes.transfer_addTransfer = "/add-transfer";

public_routes.transfer_importTransfer = "/import-transfer";

public_routes.transfer_editTransfer = "/edit-transfer";

// -- Return Router-- //

public_routes.return_salesReturnList = "/sales-return-list";

public_routes.return_addSalesReturn = "/add-sales-return";

public_routes.return_purchaseReturnList = "/purchase-return-list";

public_routes.return_addPurchaseReturn = "/add-purchase-return";

public_routes.return_editSalesReturn = "/edit-sales-return";

public_routes.return_editPurchaseReturn = "/edit-purchase-return";

// -- People Router-- //

public_routes.people_customerList = "/customer-list";

public_routes.people_supplierList = "/supplier-list";

public_routes.people_userList = "/user-list";

public_routes.people_storeList = "/store-list";

public_routes.people_addSupplier = "/add-supplier";

public_routes.people_addCustomer = "/add-customer";

public_routes.people_addUser = "/add-user";

public_routes.people_addStore = "/add-store";

public_routes.people_editCustomer = "/edit-customer";

public_routes.people_editUser = "/edit-user";

public_routes.people_editList = "/edit-list";

public_routes.people_editSupplier = "/edit-supplier";

// -- Place Router-- //

public_routes.place_stateList = "/state-list";

public_routes.place_countriesList = "/countries-list";

public_routes.place_newCountry = "/new-country";

public_routes.place_newState = "/new-state";

public_routes.place_editCountry = "/edit-country";

public_routes.place_editState = "/edit-state";

// -- Elements Router-- //

public_routes.elements_sweetAlerts = "/sweet-alerts";

public_routes.elements_toolTip = "/tool-tip";

public_routes.elements_popOver = "/popover";

public_routes.elements_ribbon = "/ribbon";

public_routes.elements_clipboard = "/clipboard";

public_routes.elements_dragDrop = "/drag-drop";

public_routes.elements_rangeSlider = "/range-slider";

public_routes.elements_rating = "/rating";

public_routes.elements_toastr = "/toastr";

public_routes.elements_textEditor = "/text-editor";

public_routes.elements_counter = "/counter";

public_routes.elements_scrollBar = "/scrollbar";

public_routes.elements_spinner = "/spinner";

public_routes.elements_notification = "/notifications";

public_routes.elements_lightBox = "/light-box";

public_routes.elements_stickyNote = "/sticky-note";

public_routes.elements_timeLine = "/timeline";

public_routes.elements_formWizard = "/form-wizard";

// -- Charts Router-- //

public_routes.charts_apexCharts = "/apex-charts";

public_routes.charts_chartsJs = "/chart-js";

public_routes.charts_morrisCharts = "/morris-charts";

public_routes.charts_flotCharts = "/flot-charts";

public_routes.charts_peityCharts = "/peity-charts";

// -- Icons Router-- //

public_routes.icons_fontAwesomeIcons = "/fontAwesome-icons";

public_routes.icons_featherIcons = "/feather-icons";

public_routes.icons_ionicIcons = "/ionic-icons";

public_routes.icons_materialIcons = "/material-icons";

public_routes.icons_pe7Icons = "/pe7-icons";

public_routes.icons_simpleLineIcons = "/simpleline-icons";

public_routes.icons_themifyIcons = "/themify-icons";

public_routes.icons_weatherIcons = "/weather-icons";

public_routes.icons_typiconIcons = "/typicon-icons";

public_routes.icons_flagIcons = "/flag-icons";

// -- Form Router-- //

public_routes.form_basicInputs = "/basic-inputs";

public_routes.form_inputGroups = "/input-group";

public_routes.form_horizontalForm = "/horizontalForm";

public_routes.form_verticalForm = "/vertical-form";

public_routes.form_formMask = "/form-mask";

public_routes.form_formValidation = "/forn-validation";

public_routes.form_formSelected2 = "/form-selected2";

public_routes.form_fileUpload = "/file-upload";

// -- Table Router-- //

public_routes.table_basicTable = "/basic-tables";

public_routes.table_dataTable = "/data-table";

// -- Application Router-- //

public_routes.application_chat = "/chat";

public_routes.application_calendar = "/calendar";

public_routes.application_email = "/email";

// -- Report Router-- //

public_routes.report_purchaseOrderReport = "/purchase-order-report";

public_routes.report_inventoryReport = "/inventory-report";

public_routes.report_salesReport = "/sales-report";

public_routes.report_invoiceReport = "/invoice-report";

public_routes.report_purchaseReport = "/purchase-report";

public_routes.report_supplierReport = "/supplier-report";

public_routes.report_customerReport = "/customer-report";

// -- users Router-- //

public_routes.users_newUser = "/new-user";

public_routes.users_usersList = "/users-list";

// -- users Router-- //

public_routes.setting_generalSetting = "/general-setting";

public_routes.setting_emailSetting = "/email-setting";

public_routes.setting_paymentSetting = "/payment-setting";

public_routes.setting_currencySetting = "/currency-setting";

public_routes.setting_groupPermission = "/group-permission";

public_routes.setting_createPermission = "/create-permission";

public_routes.setting_taxRates = "/tax-rates";

public_routes.setting_editPermission = "/edit-permission";

public_routes.call_history = "/call-history";

public_routes.audio_call = "/audio-call";

public_routes.video_call = "/video-call";

public_routes.notes = "/notes";

public_routes.todo = "/todo";

public_routes.file_manager = "/file-manager";

public_routes.manageStocks = "/manage-stocks";
public_routes.stockAdjustment = "/stock-adjustment";
public_routes.stockTransfer = "/stock-transfer";
public_routes.coupons = "/coupons";
public_routes.warehouse = "/warehouse";
public_routes.employees_list = "/employees-list";
public_routes.employees_grid = "/employees-grid";
public_routes.edit_employees = "/edit-employee";
public_routes.add_employees = "/add-employee";
public_routes.department_list = "/department-list";
public_routes.department_grid = "/department-grid";
public_routes.designation = "/designation";
public_routes.shift = "/shift";
public_routes.attendance_employee = "/attendance-employee";
public_routes.attendance_admin = "/attendance-admin";
public_routes.leave_types = "/leave-types";
public_routes.leaves_employee = "/leaves-employee";
public_routes.leaves_admin = "/leaves-admin";
public_routes.holidays = "/holidays";
public_routes.payroll_list = "/payroll-list";
public_routes.payslip = "/payslip";
public_routes.report_profit_and_loss = "/profit-and-loss";
public_routes.report_taxReports = "/tax-reports";
public_routes.report_incomeReport = "/income-report";
public_routes.report_expenseReport = "/expense-report";
public_routes.delete_account = "/delete-account";
public_routes.roles_permissions = "/roles-permissions";
public_routes.permissions = "/permissions";
//Auth
public_routes.signin = "/signin";
public_routes.signin2 = "/signin-2";
public_routes.signin3 = "/signin-3";
public_routes.register = "/register";
public_routes.register2 = "/register-2";
public_routes.register3 = "/register-3";
public_routes.forgotPassword = "/forgot-password";
public_routes.forgotPassword2 = "/forgot-password-2";
public_routes.forgotPassword3 = "/forgot-password-3";
public_routes.resetPassword = "/reset-password";
public_routes.resetPassword2 = "/reset-password-2";
public_routes.resetPassword3 = "/reset-password-3";
public_routes.success = "/success";
public_routes.success2 = "/success-2";
public_routes.success3 = "/success-3";
public_routes.emailVerification = "/email-verification";
public_routes.emailVerification2 = "/email-verification-2";
public_routes.emailVerification3 = "/email-verification-3";
public_routes.twoStepVerification = "/two-step-verification";
public_routes.twoStepVerification2 = "/two-step-verification-2";
public_routes.twoStepVerification3 = "/two-step-verification-3";
public_routes.lockScreen = "/lock-screen";
public_routes.underMaintenance = "/under-maintenance";
public_routes.comingSoon = "/coming-soon";
//Settings
public_routes.generalSettings = "/general-settings";
public_routes.connectedApps = "/connected-apps";
public_routes.notification = "/notification";
public_routes.securitySettings = "/security-settings";

public_routes.systemSettings = "/system-settings";
public_routes.companySettings = "/company-settings";
public_routes.localizationSettings = "/localization-settings";
public_routes.languageSettings = "/language-settings";
public_routes.socialAuthentication = "/social-authentication";
public_routes.appearance = "/appearance";
public_routes.preference = "/preference";
public_routes.prefixes = "/prefixes";
public_routes.invoiceSettings = "/invoice-settings";
public_routes.printerSettings = "/printer-settings";
public_routes.posSettings = "/pos-settings";
public_routes.customFields = "/custom-fields";
public_routes.gdprSettings = "/gdpr-settings";
public_routes.otpSettings = "/otp-settings";
public_routes.smsGateway = "/sms-gateway";
public_routes.emailSettings = "/email-settings";
public_routes.currencySettings = "/currency-settings";
public_routes.bankSettingsGrid = "/bank-settings-grid";
public_routes.paymentGatewaySettings = "/payment-gateway-settings";
public_routes.banIpAddress = "/ban-ip-address";
public_routes.storageSettings = "/storage-settings";


public_routes.ui_carousel = "/ui-carousel";
public_routes.ui_cards = "/ui-cards";
public_routes.ui_breadcrumb = "/ui-breadcrumb";
public_routes.ui_buttons_group = "/ui-buttons-group";
public_routes.ui_buttons = "/ui-buttons";
public_routes.ui_borders = "/ui-borders";
public_routes.ui_badges = "/ui-badges";
public_routes.ui_avatar = "/ui-avatar";
public_routes.ui_accordion = "/ui-accordion";
public_routes.ui_alerts = "/ui-alerts";
public_routes.ui_progress = "/ui-progress";
public_routes.ui_popovers = "/ui-popovers";
public_routes.ui_pagination = "/ui-pagination";
public_routes.ui_offcanvas = "/ui-offcanvas";
public_routes.ui_modals = "/ui-modals";
public_routes.ui_media = "/ui-media";
public_routes.ui_lightbox = "/ui-lightbox";
public_routes.ui_images = "/ui-images";
public_routes.ui_grid = "/ui-grid";
public_routes.ui_dropdowns = "/ui-dropdowns";
public_routes.ui_colors = "/ui-colors";
public_routes.ui_video = "/ui-video";
public_routes.ui_typography = "/ui-typography";
public_routes.ui_tooltips = "/ui-tooltips";
public_routes.ui_toasts = "/ui-toasts";
public_routes.ui_nav_tabs = "/ui-nav-tabs";
public_routes.ui_sweetalerts = "/ui-sweetalerts";
public_routes.ui_spinner = "/ui-spinner";
public_routes.ui_rangeslider = "/ui-rangeslider";
public_routes.ui_placeholders = "/ui-placeholders";
public_routes.form_checkbox_radios = "/form-checkbox-radios";
public_routes.form_grid_gutters = "/form-grid-gutters";
public_routes.form_select = "/form-select";
public_routes.form_floating_labels = "/form-floating-labels";
public_routes.form_wizard = "/form-wizard";
public_routes.bankSettingsList = "/bank-settings-list";
public_routes.file_manager_deleted = "/file-manager-deleted";
public_routes.file_archived = "/file-archived";
public_routes.file_favourites = "/file-favourites";
public_routes.file_recent = "/file-recent";
public_routes.file_document = "/file-document";
public_routes.file_shared = "/file-shared";
public_routes.icon_tabler = "/icon-tabler";
public_routes.icon_bootstrap = "/icon-bootstrap";
public_routes.icon_remix = "/icon-remix";
public_routes.form_pickers = "/form-pickers";
public_routes.maps_vector = "/maps-vector";
public_routes.maps_leaflet = "/maps-leaflet";
public_routes.ui_sortable = "/ui-sortable";
public_routes.ui_swiperjs = "/ui-swiperjs";
public_routes.social_feed = "/social-feed";
public_routes.kanban_view = "/kanban-view";














module.exports = public_routes;
