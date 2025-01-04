	<!-- Sidebar -->
        <div class="sidebar horizontal-sidebar">
				<div id="sidebar-menu-3" class="sidebar-menu">
					<ul class="nav">
						<li class="submenu">
							<a href="index.php" class="<?php echo ($page =='index.php'||$page =='sales-dashboard.php'||$page =='chat.php'||$page =='video-call.php'||$page =='audio-call.php'||$page =='call-history.php'||$page =='calendar.php'||$page =='email.php'||$page =='todo.php'||$page =='notes.php'||$page =='file-manager.php'||$page == 'file-archived.php'||$page =='file-document.php'||$page =='file-favourites.php'||$page =='file-manager-seleted.php'||$page =='file-recent.php'||$page =='file-shared.php'||$page =='file-manager-deleted.php') ? 'active subdrop' : '' ;?>"><i data-feather="grid"></i><span> Main Menu</span> <span class="menu-arrow"></span></a>
							<ul>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='index.php'||$page =='sales-dashboard.php') ? 'active subdrop' : '' ;?>"><span>Dashboard</span> <span class="menu-arrow"></span></a>
									<ul>
										<li><a href="index.php"class="<?php echo ($page =='index.php') ? 'active' : '' ;?>">Admin Dashboard</a></li>
										<li><a href="sales-dashboard.php"class="<?php echo ($page =='sales-dashboard.php') ? 'active' : '' ;?>">Sales Dashboard</a></li>
									</ul>
								</li>  							
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='chat.php'||$page =='video-call.php'||$page =='audio-call.php'||$page =='call-history.php'||$page =='calendar.php'||$page =='email.php'||$page =='todo.php'||$page =='notes.php'||$page =='file-manager.php'||$page == 'file-archived.php'||$page =='file-document.php'||$page =='file-favourites.php'||$page =='file-manager-seleted.php'||$page =='file-recent.php'||$page =='file-shared.php'||$page =='file-manager-deleted.php') ? 'active subdrop' : '' ;?>"><span>Application</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="chat.php"class="<?php echo ($page =='chat.php') ? 'active' : '' ;?>">Chat</a></li>
										<li class="submenu submenu-two"><a href="javascript:void(0);"class="<?php echo ($page =='video-call.php'||$page =='audio-call.php'||$page =='call-history.php') ? 'active subdrop' : '' ;?>"><span>Call</span><span class="menu-arrow inside-submenu"></span></a>
											<ul>
												<li><a href="video-call.php"class="<?php echo ($page =='video-call.php') ? 'active' : '' ;?>">Video Call</a></li>
												<li><a href="audio-call.php"class="<?php echo ($page =='audio-call.php') ? 'active' : '' ;?>">Audio Call</a></li>
												<li><a href="call-history.php"class="<?php echo ($page =='call-history.php') ? 'active' : '' ;?>">Call History</a></li>
											</ul>
										</li>
										<li><a href="calendar.php"class="<?php echo ($page =='calendar.php') ? 'active' : '' ;?>">Calendar</a></li>
										<li><a href="email.php"class="<?php echo ($page =='email.php') ? 'active' : '' ;?>">Email</a></li>
										<li><a href="todo.php"class="<?php echo ($page =='todo.php') ? 'active' : '' ;?>">To Do</a></li>
										<li><a href="notes.php"class="<?php echo ($page =='notes.php') ? 'active' : '' ;?>">Notes</a></li>
										<li><a href="file-manager.php"class="<?php echo ($page =='file-manager.php'||$page == 'file-archived.php'||$page =='file-document.php'||$page =='file-favourites.php'||$page =='file-manager-seleted.php'||$page =='file-recent.php'||$page =='file-shared.php'||$page =='file-manager-deleted.php') ? 'active' : '' ;?>">File Manager</a></li>
									</ul>
								</li>
							</ul>
						</li>
						<li  class="submenu">
							<a href="javascript:void(0);"class="<?php echo ($page =='product-list.php'||$page =='product-details.php'||$page =='add-product.php'||$page =='edit-product.php'||$page =='expired-products.php'||$page =='low-stocks.php'||$page =='category-list.php'||$page =='sub-categories.php'||$page =='brand-list.php'||$page =='units.php'||$page =='varriant-attributes.php'||$page =='warranty.php'||$page =='barcode.php'||$page =='qrcode.php') ? 'active subdrop' : '' ;?>"><img src="assets/img/icons/product.svg" alt="img"><span> Inventory </span> <span class="menu-arrow"></span></a>
							<ul>
								<li><a href="product-list.php" class="<?php echo ($page =='product-list.php'||$page =='product-details.php') ? 'active' : '' ;?>"><span>Products</span></a></li>
								<li><a href="add-product.php"class="<?php echo ($page =='add-product.php'||$page =='edit-product.php') ? 'active' : '' ;?>"><span>Create Product</span></a></li>
								<li><a href="expired-products.php"class="<?php echo ($page =='expired-products.php') ? 'active' : '' ;?>"><span>Expired Products</span></a></li>
								<li><a href="low-stocks.php"class="<?php echo ($page =='low-stocks.php') ? 'active' : '' ;?>"><span>Low Stocks</span></a></li>
								<li><a href="category-list.php"class="<?php echo ($page =='category-list.php') ? 'active' : '' ;?>" ><span>Category</span></a></li>
								<li><a href="sub-categories.php"class="<?php echo ($page =='sub-categories.php') ? 'active' : '' ;?>"><span>Sub Category</span></a></li>
								<li><a href="brand-list.php"class="<?php echo ($page =='brand-list.php') ? 'active' : '' ;?>"><span>Brands</span></a></li>
								<li><a href="units.php"class="<?php echo ($page =='units.php') ? 'active' : '' ;?>"><span>Units</span></a></li>
								<li><a href="varriant-attributes.php"class="<?php echo ($page =='varriant-attributes.php') ? 'active' : '' ;?>"><span>Variant Attributes</span></a></li>
								<li><a href="warranty.php"class="<?php echo ($page =='warranty.php') ? 'active' : '' ;?>"><span>Warranties</span></a></li>									
								<li><a href="barcode.php"class="<?php echo ($page =='barcode.php') ? 'active' : '' ;?>"><span>Print Barcode</span></a></li>
								<li><a href="qrcode.php"class="<?php echo ($page =='qrcode.php') ? 'active' : '' ;?>"><span>Print QR Code</span></a></li>
							</ul>
						</li>
						<li class="submenu">
							<a href="javascript:void(0);"class="<?php echo ($page =='sales-list.php'||$page =='sales-returns.php'||$page =='quotation-list.php'||$page =='pos.php'||$page =='coupons.php'||$page =='purchase-list.php'||$page =='purchase-order-report.php'||$page =='purchase-returns.php'||$page =='manage-stocks.php'||$page =='stock-adjustment.php'||$page =='stock-transfer.php'||$page =='expense-list.php'||$page =='expense-category.php') ? 'active subdrop' : '' ;?>"><img src="assets/img/icons/purchase1.svg" alt="img"><span>Sales &amp; Purchase</span> <span class="menu-arrow"></span></a>
							<ul>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='sales-list.php'||$page =='invoice-report.php'||$page =='sales-returns.php'||$page =='quotation-list.php'||$page =='pos.php'||$page =='coupons.php') ? 'active subdrop ' : '' ;?>"><span>Sales</span><span class="menu-arrow"></span></a>
									<ul>	
										<li><a href="sales-list.php"class="<?php echo ($page =='sales-list.php') ? 'active' : '' ;?>"><span>Sales</span></a></li>
										<li><a href="invoice-report.php"class="<?php echo ($page =='invoice-report.php') ? 'active' : '' ;?>"><span>Invoices</span></a></li>
										<li><a href="sales-returns.php"class="<?php echo ($page =='sales-returns.php') ? 'active' : '' ;?>"><span>Sales Return</span></a></li>	
										<li><a href="quotation-list.php"class="<?php echo ($page =='quotation-list.php') ? 'active' : '' ;?>"><span>Quotation</span></a></li>								
										<li><a href="pos.php"class="<?php echo ($page =='pos.php') ? 'active' : '' ;?>"><span>POS</span></a></li>
										<li><a href="coupons.php"class="<?php echo ($page =='coupons.php') ? 'active' : '' ;?>"><span>Coupons</span></a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='purchase-list.php'||$page =='purchase-order-report.php'||$page =='purchase-returns.php'||$page =='manage-stocks.php'||$page =='stock-adjustment.php'||$page =='stock-transfer.php') ? 'active subdrop' : '' ;?>"><span>Purchase</span><span class="menu-arrow"></span></a>
									<ul>	
										<li><a href="purchase-list.php"class="<?php echo ($page =='purchase-list.php') ? 'active' : '' ;?>"><span>Purchases</span></a></li>
										<li><a href="purchase-order-report.php"class="<?php echo ($page =='purchase-order-report.php') ? 'active' : '' ;?>"><span>Purchase Order</span></a></li>
										<li><a href="purchase-returns.php"class="<?php echo ($page =='purchase-returns.php') ? 'active' : '' ;?>"><span>Purchase Return</span></a></li>	
										<li><a href="manage-stocks.php"class="<?php echo ($page =='manage-stocks.php') ? 'active' : '' ;?>"><span>Manage Stock</span></a></li>
										<li><a href="stock-adjustment.php"class="<?php echo ($page =='stock-adjustment.php') ? 'active' : '' ;?>"><span>Stock Adjustment</span></a></li>
										<li><a href="stock-transfer.php"class="<?php echo ($page =='stock-transfer.php') ? 'active' : '' ;?>"><span>Stock Transfer</span></a></li>	
									</ul>
								</li>						
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='expense-list.php'||$page =='expense-category.php') ? 'active subdrop' : '' ;?>"><span>Expenses</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="expense-list.php"class="<?php echo ($page =='expense-list.php') ? 'active' : '' ;?>">Expenses</a></li>
										<li><a href="expense-category.php"class="<?php echo ($page =='expense-category.php') ? 'active' : '' ;?>">Expense Category</a></li>
									</ul>
								</li>
							</ul>
						</li>
						<li class="submenu">
							<a href="javascript:void(0);" class="<?php echo ($page =='customers.php'||$page =='suppliers.php'||$page =='store-list.php'||$page =='warehouse.php'||$page =='roles-permissions.php'||$page =='permissions.php'||$page =='delete-account.php'||$page =='ui-alerts.php'||$page =='ui-accordion.php'||$page =='ui-avatar.php'||$page =='ui-badges.php'||$page =='ui-borders.php'||$page =='ui-buttons.php'||$page =='ui-buttons-group.php'||$page =='ui-breadcrumb.php'||$page =='ui-cards.php'||$page =='ui-carousel.php'||$page =='ui-colors.php'
                                                                       ||$page =='ui-dropdowns.php'||$page =='ui-grid.php'||$page =='ui-images.php'||$page =='ui-lightbox.php'||$page =='ui-media.php'||$page =='ui-modals.php'||$page =='ui-offcanvas.php'||$page =='ui-pagination.php'||$page =='ui-popovers.php'||$page =='ui-progress.php'||$page =='ui-placeholders.php'||$page =='ui-rangeslider.php'||$page =='ui-spinner.php'
                                                                       ||$page =='ui-sweetalerts.php'||$page =='ui-nav-tabs.php'||$page =='ui-toasts.php'||$page =='ui-tooltips.php'||$page =='ui-typography.php'||$page =='ui-video.php'||$page =='ui-counter.php'||$page =='ui-scrollbar.php'||$page =='ui-spinner.php'||$page =='ui-activities.php'||$page =='ui-lightbox.php'||$page =='ui-stickynote.php'||$page =='ui-timeline.php'||$page =='ui-form-wizard.php'||$page =='chart-apex.php'||$page =='chart-c3.php'||$page =='chart-js.php'||$page =='chart-morris.php'||$page =='chart-flot.php'||$page =='chart-peity.php'||$page =='icon-fontawesome.php'||$page =='icon-feather.php'||$page =='icon-ionic.php'||$page =='icon-material.php'||$page =='icon-pe7.php'
                                                                       ||$page =='icon-simpleline.php'||$page =='icon-themify.php'||$page =='icon-weather.php'||$page =='icon-typicon.php'||$page =='icon-flag.php'||$page =='form-basic-inputs.php'||$page =='form-checkbox-radios.php'||$page =='form-input-groups.php'||$page =='form-grid-gutters.php'||$page =='form-select.php'||$page =='form-mask.php'||$page =='form-fileupload.php'||$page =='form-horizontal.php'||$page =='form-vertical.php'||$page =='form-floating-labels.php'||$page =='form-validation.php'||$page =='form-select2.php'||$page =='form-wizard.php'||$page =='tables-basic.php'||$page =='data-tables.php'||$page=='activities.php') ? 'active subdrop' : '' ;?>"><img src="assets/img/icons/users1.svg" alt="img"><span>User Management</span> <span class="menu-arrow"></span></a>
							<ul>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='customers.php'||$page =='suppliers.php'||$page =='store-list.php'||$page =='warehouse.php') ? 'active subdrop' : '' ;?>"><span>People</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="customers.php"class="<?php echo ($page =='customers.php') ? 'active' : '' ;?>"><span>Customers</span></a></li>
										<li><a href="suppliers.php"class="<?php echo ($page =='suppliers.php') ? 'active' : '' ;?>"><span>Suppliers</span></a></li>
										<li><a href="store-list.php"class="<?php echo ($page =='store-list.php') ? 'active' : '' ;?>"><span>Stores</span></a></li>
										<li><a href="warehouse.php"class="<?php echo ($page =='warehouse.php') ? 'active' : '' ;?>"><span>Warehouses</span></a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='roles-permissions.php'||$page =='delete-account.php'||$page =='permissions.php') ? 'active' : '' ;?>"><span>Roles &amp; Permissions</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="roles-permissions.php"class="<?php echo ($page =='roles-permissions.php'||$page =='permissions.php') ? 'active' : '' ;?>"><span>Roles & Permissions</span></a></li>
								<li><a href="delete-account.php"class="<?php echo ($page =='delete-account.php') ? 'active' : '' ;?>"><span>Delete Account Request</span></a></li>
								
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);" class="<?php echo ($page =='ui-alerts.php'||$page =='ui-accordion.php'||$page =='ui-avatar.php'||$page =='ui-badges.php'||$page =='ui-borders.php'||$page =='ui-buttons.php'||$page =='ui-buttons-group.php'||$page =='ui-breadcrumb.php'||$page =='ui-cards.php'||$page =='ui-carousel.php'||$page =='ui-colors.php'
                                                                       ||$page =='ui-dropdowns.php'||$page =='ui-grid.php'||$page =='ui-images.php'||$page =='ui-lightbox.php'||$page =='ui-media.php'||$page =='ui-modals.php'||$page =='ui-offcanvas.php'||$page =='ui-pagination.php'||$page =='ui-popovers.php'||$page =='ui-progress.php'||$page =='ui-placeholders.php'||$page =='ui-rangeslider.php'||$page =='ui-spinner.php'
                                                                       ||$page =='ui-sweetalerts.php'||$page =='ui-nav-tabs.php'||$page =='ui-toasts.php'||$page =='ui-tooltips.php'||$page =='ui-typography.php'||$page =='ui-video.php') ? 'active subdrop' : '' ;?>"><span>Base UI</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="ui-alerts.php"class="<?php echo ($page =='ui-alerts.php') ? 'active' : '' ;?>">Alerts</a></li>
										<li><a href="ui-accordion.php"class="<?php echo ($page =='ui-accordion.php') ? 'active' : '' ;?>">Accordion</a></li>
										<li><a href="ui-avatar.php"class="<?php echo ($page =='ui-avatar.php') ? 'active' : '' ;?>">Avatar</a></li>
										<li><a href="ui-badges.php"class="<?php echo ($page =='ui-badges.php') ? 'active' : '' ;?>">Badges</a></li>
										<li><a href="ui-borders.php"class="<?php echo ($page =='ui-borders.php') ? 'active' : '' ;?>">Border</a></li>
										<li><a href="ui-buttons.php"class="<?php echo ($page =='ui-buttons.php') ? 'active' : '' ;?>">Buttons</a></li>
										<li><a href="ui-buttons-group.php"class="<?php echo ($page =='ui-buttons-group.php') ? 'active' : '' ;?>">Button Group</a></li>
										<li><a href="ui-breadcrumb.php"class="<?php echo ($page =='ui-breadcrumb.php') ? 'active' : '' ;?>">Breadcrumb</a></li>
										<li><a href="ui-cards.php"class="<?php echo ($page =='ui-cards.php') ? 'active' : '' ;?>">Card</a></li>
										<li><a href="ui-carousel.php"class="<?php echo ($page =='ui-carousel.php') ? 'active' : '' ;?>">Carousel</a></li>
										<li><a href="ui-colors.php"class="<?php echo ($page =='ui-colors.php') ? 'active' : '' ;?>">Colors</a></li>
										<li><a href="ui-dropdowns.php"class="<?php echo ($page =='ui-dropdowns.php') ? 'active' : '' ;?>">Dropdowns</a></li>
										<li><a href="ui-grid.php"class="<?php echo ($page =='ui-grid.php') ? 'active' : '' ;?>">Grid</a></li>
										<li><a href="ui-images.php"class="<?php echo ($page =='ui-images.php') ? 'active' : '' ;?>">Images</a></li>
										<li><a href="ui-lightbox.php"class="<?php echo ($page =='ui-lightbox.php') ? 'active' : '' ;?>">Lightbox</a></li>
										<li><a href="ui-media.php"class="<?php echo ($page =='ui-media.php') ? 'active' : '' ;?>">Media</a></li>
										<li><a href="ui-modals.php"class="<?php echo ($page =='ui-modals.php') ? 'active' : '' ;?>">Modals</a></li>
										<li><a href="ui-offcanvas.php"class="<?php echo ($page =='ui-offcanvas.php') ? 'active' : '' ;?>">Offcanvas</a></li>
										<li><a href="ui-pagination.php"class="<?php echo ($page =='ui-pagination.php') ? 'active' : '' ;?>">Pagination</a></li>
										<li><a href="ui-popovers.php"class="<?php echo ($page =='ui-popovers.php') ? 'active' : '' ;?>">Popovers</a></li>
										<li><a href="ui-progress.php"class="<?php echo ($page =='ui-progress.php') ? 'active' : '' ;?>">Progress</a></li>
										<li><a href="ui-placeholders.php"class="<?php echo ($page =='ui-placeholders.php') ? 'active' : '' ;?>">Placeholders</a></li>
										<li><a href="ui-rangeslider.php"class="<?php echo ($page =='ui-rangeslider.php') ? 'active' : '' ;?>">Range Slider</a></li>
										<li><a href="ui-spinner.php"class="<?php echo ($page =='ui-spinner.php') ? 'active' : '' ;?>">Spinner</a></li>
										<li><a href="ui-sweetalerts.php"class="<?php echo ($page =='ui-sweetalerts.php') ? 'active' : '' ;?>">Sweet Alerts</a></li>
										<li><a href="ui-nav-tabs.php"class="<?php echo ($page =='ui-nav-tabs.php') ? 'active' : '' ;?>">Tabs</a></li>
										<li><a href="ui-toasts.php"class="<?php echo ($page =='ui-toasts.php') ? 'active' : '' ;?>">Toasts</a></li>
										<li><a href="ui-tooltips.php"class="<?php echo ($page =='ui-tooltips.php') ? 'active' : '' ;?>">Tooltips</a></li>
										<li><a href="ui-typography.php"class="<?php echo ($page =='ui-typography.php') ? 'active' : '' ;?>">Typography</a></li>
										<li><a href="ui-video.php"class="<?php echo ($page =='ui-video.php') ? 'active' : '' ;?>">Video</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='ui-counter.php'||$page =='ui-scrollbar.php'||$page =='ui-spinner.php'||$page =='ui-activities.php'||$page =='ui-lightbox.php'||$page =='ui-stickynote.php'||$page =='ui-timeline.php'||$page =='ui-form-wizard.php') ? 'active subdrop' : '' ;?>"><span>Advanced UI</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="ui-counter.php"class="<?php echo ($page =='ui-counter.php') ? 'active' : '' ;?>">Counter</a></li>
										<li><a href="ui-scrollbar.php"class="<?php echo ($page =='ui-scrollbar.php') ? 'active' : '' ;?>">Scrollbar</a></li>
										<li><a href="ui-spinner.php"class="<?php echo ($page =='ui-spinner.php') ? 'active' : '' ;?>">Spinner</a></li>
										<li><a href="ui-activities.php" class="<?php echo ($page =='ui-activities.php') ? 'active' : '' ;?>">Notification</a></li>
										<li><a href="ui-lightbox.php"class="<?php echo ($page =='ui-lightbox.php') ? 'active' : '' ;?>">Lightbox</a></li>
										<li><a href="ui-stickynote.php"class="<?php echo ($page =='ui-stickynote.php') ? 'active' : '' ;?>">Sticky Note</a></li>
										<li><a href="ui-timeline.php"class="<?php echo ($page =='ui-timeline.php') ? 'active' : '' ;?>">Timeline</a></li>
										<li><a href="ui-form-wizard.php"class="<?php echo ($page =='ui-form-wizard.php') ? 'active' : '' ;?>">Form Wizard</a></li>
									</ul>
								</li>
								<li  class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='chart-apex.php'||$page =='chart-c3.php'||$page =='chart-js.php'||$page =='chart-morris.php'||$page =='chart-flot.php'||$page =='chart-peity.php') ? 'active subdrop' : '' ;?>"><span>Charts</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="chart-apex.php"class="<?php echo ($page =='chart-apex.php') ? 'active' : '' ;?>">Apex Charts</a></li>
										<li><a href="chart-c3.php"class="<?php echo ($page =='chart-c3.php') ? 'active' : '' ;?>">Chart C3</a></li>
										<li><a href="chart-js.php"class="<?php echo ($page =='chart-js.php') ? 'active' : '' ;?>">Chart Js</a></li>
										<li><a href="chart-morris.php"class="<?php echo ($page =='chart-morris.php') ? 'active' : '' ;?>">Morris Charts</a></li>
										<li><a href="chart-flot.php"class="<?php echo ($page =='chart-flot.php') ? 'active' : '' ;?>">Flot Charts</a></li>
										<li><a href="chart-peity.php"class="<?php echo ($page =='chart-peity.php') ? 'active' : '' ;?>">Peity Charts</a></li>
									</ul>
								</li>
								<li  class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='icon-fontawesome.php'||$page =='icon-feather.php'||$page =='icon-ionic.php'||$page =='icon-material.php'||$page =='icon-pe7.php') ? 'active' : '' ;?>"><span>Primary Icons</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="icon-fontawesome.php"class="<?php echo ($page =='icon-fontawesome.php') ? 'active subdrop' : '' ;?>">Fontawesome Icons</a></li>
										<li><a href="icon-feather.php"class="<?php echo ($page =='icon-feather.php') ? 'active' : '' ;?>">Feather Icons</a></li>
										<li><a href="icon-ionic.php"class="<?php echo ($page =='icon-ionic.php') ? 'active' : '' ;?>">Ionic Icons</a></li>
										<li><a href="icon-material.php"class="<?php echo ($page =='icon-material.php') ? 'active' : '' ;?>">Material Icons</a></li>
										<li><a href="icon-pe7.php"class="<?php echo ($page =='icon-pe7.php') ? 'active' : '' ;?>">Pe7 Icons</a></li>
									</ul>
								</li>
								<li  class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='icon-simpleline.php'||$page =='icon-themify.php'||$page =='icon-weather.php'||$page =='icon-typicon.php'||$page =='icon-flag.php') ? 'active subdrop' : '' ;?>"><span>Secondary Icons</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="icon-simpleline.php"class="<?php echo ($page =='icon-simpleline.php') ? 'active' : '' ;?>">Simpleline Icons</a></li>
										<li><a href="icon-themify.php"class="<?php echo ($page =='icon-themify.php') ? 'active' : '' ;?>">Themify Icons</a></li>
										<li><a href="icon-weather.php"class="<?php echo ($page =='icon-weather.php') ? 'active' : '' ;?>">Weather Icons</a></li>
										<li><a href="icon-typicon.php"class="<?php echo ($page =='icon-typicon.php') ? 'active' : '' ;?>">Typicon Icons</a></li>
										<li><a href="icon-flag.php"class="<?php echo ($page =='icon-flag.php') ? 'active' : '' ;?>">Flag Icons</a></li>
									</ul>
								</li>
								<li class="submenu">
								<a href="javascript:void(0);"class="<?php echo ($page =='form-basic-inputs.php'||$page =='form-checkbox-radios.php'||$page =='form-input-groups.php'||$page =='form-grid-gutters.php'||$page =='form-select.php'||$page =='form-mask.php'||$page =='form-fileupload.php'||$page =='form-horizontal.php'||$page =='form-vertical.php'||$page =='form-floating-labels.php'||$page =='form-validation.php'||$page =='form-select2.php'||$page =='form-wizard.php') ? 'active subdrop' : '' ;?>"><span> Forms</span><span class="menu-arrow"></span></a>
								<ul>
									<li class="submenu submenu-two">
										<a href="javascript:void(0);"class="<?php echo ($page =='form-basic-inputs.php'||$page =='form-checkbox-radios.php'||$page =='form-input-groups.php'||$page =='form-grid-gutters.php'||$page =='form-select.php'||$page =='form-mask.php'||$page =='form-fileupload.php') ? 'active subdrop' : '' ;?>"><span>Form Elements</span><span class="menu-arrow inside-submenu"></span></a>
										<ul>
											<li><a href="form-basic-inputs.php"class="<?php echo ($page =='form-basic-inputs.php') ? 'active' : '' ;?>">Basic Inputs</a></li>
											<li><a href="form-checkbox-radios.php"class="<?php echo ($page =='form-checkbox-radios.php') ? 'active' : '' ;?>">Checkbox & Radios</a></li>
											<li><a href="form-input-groups.php"class="<?php echo ($page =='form-input-groups.php') ? 'active' : '' ;?>">Input Groups</a></li>
											<li><a href="form-grid-gutters.php"class="<?php echo ($page =='form-grid-gutters.php') ? 'active' : '' ;?>">Grid & Gutters</a></li>
											<li><a href="form-select.php"class="<?php echo ($page =='form-select.php') ? 'active' : '' ;?>">Form Select</a></li>
											<li><a href="form-mask.php"class="<?php echo ($page =='form-mask.php') ? 'active' : '' ;?>">Input Masks</a></li>
											<li><a href="form-fileupload.php"class="<?php echo ($page =='form-fileupload.php') ? 'active' : '' ;?>">File Uploads</a></li>
										</ul>
									</li>
									<li class="submenu submenu-two">
										<a href="javascript:void(0);"class="<?php echo ($page =='form-horizontal.php'||$page =='form-vertical.php'||$page =='form-floating-labels.php') ? 'active' : '' ;?>"><span> Layouts</span><span class="menu-arrow inside-submenu"></span></a>
										<ul>
											<li><a href="form-horizontal.php"class="<?php echo ($page =='form-horizontal.php') ? 'active' : '' ;?>">Horizontal Form</a></li>
											<li><a href="form-vertical.php"class="<?php echo ($page =='form-vertical.php') ? 'active' : '' ;?>">Vertical Form</a></li>
											<li><a href="form-floating-labels.php"class="<?php echo ($page =='form-floating-labels.php') ? 'active' : '' ;?>">Floating Labels</a></li>
										</ul>
									</li>
									<li><a href="form-validation.php"class="<?php echo ($page =='form-validation.php') ? 'active' : '' ;?>">Form Validation</a></li>
									<li><a href="form-select2.php"class="<?php echo ($page =='form-select2.php') ? 'active' : '' ;?>">Select2</a></li>
									<li><a href="form-wizard.php"class="<?php echo ($page =='form-wizard.php') ? 'active' : '' ;?>">Form Wizard</a></li>
								</ul>
							</li>
								<li  class="submenu">
									<a href="javascript:void(0);" class="<?php echo ($page =='tables-basic.php'||$page =='data-tables.php') ? 'active subdrop' : '' ;?>"><span>Tables</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="tables-basic.php" class="<?php echo ($page =='tables-basic.php') ? 'active' : '' ;?>">Basic Tables </a></li>
										<li><a href="data-tables.php" class="<?php echo ($page =='data-tables.php') ? 'active' : '' ;?>">Data Table </a></li>
									</ul>
								</li>
							</ul>
						</li>
						<li class="submenu">
							<a href="javascript:void(0);"class="<?php echo ($page =='profile.php'||$page =='countries.php'||$page =='states.php'||$page =='employees-grid.php'||$page =='department-grid.php'||$page =='designation.php'||$page =='shift.php'||$page =='attendance-employee.php'||$page =='attendance-admin.php'||$page =='leaves-admin.php'||$page =='leaves-employee.php'||$page =='leave-types.php'||$page =='holidays.php'||$page =='payroll-list.php'||$page =='payslip.php'||$page=='blank-page.php'||$page=='add-employee.php'||$page=='edit-employee.php'||$page=='employees-list.php'||$page=='department-list.php') ? 'active subdrop' : '' ;?>"><i data-feather="user"></i><span>Profile</span> <span class="menu-arrow"></span></a>
							<ul>
								<li><a href="profile.php"class="<?php echo ($page =='profile.php') ? 'active' : '' ;?>"><span>Profile</span></a></li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='signin.php') ? 'active' : '' ;?>"><span>Authentication</span><span class="menu-arrow"></span></a>
									<ul>
										<li class="submenu submenu-two"><a href="javascript:void(0);"class="<?php echo ($page =='signin.php'||$page =='signin-2.php'||$page =='signin-3.php') ? 'active' : '' ;?>">Login<span class="menu-arrow inside-submenu"></span></a>
											<ul>
												<li><a href="signin.php"class="<?php echo ($page =='signin.php') ? 'active' : '' ;?>">Cover</a></li>
												<li><a href="signin-2.php"class="<?php echo ($page =='signin-2.php') ? 'active' : '' ;?>">Illustration</a></li>
												<li><a href="signin-3.php"class="<?php echo ($page =='signin-3.php') ? 'active' : '' ;?>">Basic</a></li>
											</ul>
										</li>
										<li class="submenu submenu-two"><a href="javascript:void(0);"class="<?php echo ($page =='register.php'||$page =='register-2.php'||$page =='register-3.php') ? 'active' : '' ;?>">Register<span class="menu-arrow inside-submenu"></span></a>
											<ul>
												<li><a href="register.php"class="<?php echo ($page =='register.php') ? 'active' : '' ;?>">Cover</a></li>
												<li><a href="register-2.php"class="<?php echo ($page =='register-2.php') ? 'active' : '' ;?>">Illustration</a></li>
												<li><a href="register-3.php"class="<?php echo ($page =='register-3.php') ? 'active' : '' ;?>">Basic</a></li>
											</ul>
										</li>
										<li class="submenu submenu-two"><a href="javascript:void(0);"class="<?php echo ($page =='forgot-password.php'||$page =='forgot-password-2.php'||$page =='forgot-password-3.php') ? 'active' : '' ;?>">Forgot Password<span class="menu-arrow inside-submenu"></span></a>
											<ul>
												<li><a href="forgot-password.php"class="<?php echo ($page =='forgot-password.php') ? 'active' : '' ;?>">Cover</a></li>
												<li><a href="forgot-password-2.php"class="<?php echo ($page =='forgot-password-2.php') ? 'active' : '' ;?>">Illustration</a></li>
												<li><a href="forgot-password-3.php"class="<?php echo ($page =='forgot-password-3.php') ? 'active' : '' ;?>">Basic</a></li>
											</ul>
										</li>
										<li class="submenu submenu-two"><a href="javascript:void(0);"class="<?php echo ($page =='reset-password.php'||$page =='reset-password-2.php'||$page =='reset-password-3.php') ? 'active subdrop' : '' ;?>">Reset Password<span class="menu-arrow inside-submenu"></span></a>
											<ul>
												<li><a href="reset-password.php"class="<?php echo ($page =='reset-password.php') ? 'active' : '' ;?>">Cover</a></li>
												<li><a href="reset-password-2.php"class="<?php echo ($page =='reset-password-2.php') ? 'active' : '' ;?>">Illustration</a></li>
												<li><a href="reset-password-3.php"class="<?php echo ($page =='reset-password-3.php') ? 'active' : '' ;?>">Basic</a></li>
											</ul>
										</li>
										<li class="submenu submenu-two"><a href="javascript:void(0);"class="<?php echo ($page =='email-verification.php'||$page =='email-verification-2.php'||$page =='email-verification-3.php') ? 'active' : '' ;?>">Email Verification<span class="menu-arrow inside-submenu"></span></a>
											<ul>
												<li><a href="email-verification.php"class="<?php echo ($page =='email-verification.php') ? 'active' : '' ;?>">Cover</a></li>
												<li><a href="email-verification-2.php"class="<?php echo ($page =='email-verification-2.php') ? 'active' : '' ;?>">Illustration</a></li>
												<li><a href="email-verification-3.php"class="<?php echo ($page =='email-verification-3.php') ? 'active' : '' ;?>">Basic</a></li>
											</ul>
										</li>
										<li class="submenu submenu-two"><a href="javascript:void(0);"class="<?php echo ($page =='two-step-verification.php'||$page =='two-step-verification-2.php'||$page =='two-step-verification-3.php'||$page =='lock-screen.php') ? 'active' : '' ;?>">2 Step Verification<span class="menu-arrow inside-submenu"></span></a>
											<ul>
												<li><a href="two-step-verification.php"class="<?php echo ($page =='two-step-verification.php') ? 'active' : '' ;?>">Cover</a></li>
												<li><a href="two-step-verification-2.php"class="<?php echo ($page =='two-step-verification-2.php') ? 'active' : '' ;?>">Illustration</a></li>
												<li><a href="two-step-verification-3.php"class="<?php echo ($page =='two-step-verification-3.php') ? 'active' : '' ;?>">Basic</a></li>										
											</ul>
										</li>
										<li><a href="lock-screen.php"class="<?php echo ($page =='lock-screen.php') ? 'active' : '' ;?>">Lock Screen</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='error-404.php'||$page =='error-500.php'||$page =='blank-page.php'||$page =='coming-soon.php'||$page =='under-maintenance.php') ? 'active' : '' ;?>"><span>Pages</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="error-404.php"class="<?php echo ($page =='error-404.php') ? 'active' : '' ;?>">404 Error </a></li>
										<li><a href="error-500.php"class="<?php echo ($page =='error-500.php') ? 'active' : '' ;?>">500 Error </a></li>
										<li>
											<a href="blank-page.php"class="<?php echo ($page =='blank-page.php') ? 'active' : '' ;?>" ><span>Blank Page</span> </a>
										</li>
										<li>
											<a href="coming-soon.php" class="<?php echo ($page =='coming-soon.php') ? 'active' : '' ;?>"><span>Coming Soon</span> </a>
										</li>
										<li>
											<a href="under-maintenance.php"class="<?php echo ($page =='under-maintenance.php') ? 'active' : '' ;?>" ><span>Under Maintenance</span> </a>
										</li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='countries.php'||$page =='states.php') ? 'active' : '' ;?>"><span>Places</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="countries.php"class="<?php echo ($page =='countries.php') ? 'active' : '' ;?>">Countries</a></li>
										<li><a href="states.php"class="<?php echo ($page =='states.php') ? 'active' : '' ;?>">States</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='employees-grid.php'||$page=='add-employee.php'||$page=='edit-employee.php'||$page=='employees-list.php'||$page =='department-grid.php'||$page=='department-list.php'||$page =='designation.php'||$page =='shift.php') ? 'active' : '' ;?>"><span>Employees</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="employees-grid.php"class="<?php echo ($page =='employees-grid.php'||$page=='add-employee.php'||$page=='edit-employee.php'||$page=='employees-list.php') ? 'active' : '' ;?>"><span>Employees</span></a></li>
										<li><a href="department-grid.php"class="<?php echo ($page =='department-grid.php'||$page=='department-list.php') ? 'active' : '' ;?>"><span>Departments</span></a></li>
										<li><a href="designation.php"class="<?php echo ($page =='designation.php') ? 'active' : '' ;?>"><span>Designation</span></a></li>
										<li><a href="shift.php"class="<?php echo ($page =='shift.php') ? 'active' : '' ;?>"><span>Shifts</span></a></li>	
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='attendance-employee.php'||$page =='attendance-admin.php') ? 'active' : '' ;?>"><span>Attendence</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="attendance-employee.php"class="<?php echo ($page =='attendance-employee.php') ? 'active' : '' ;?>">Employee Attendence</a></li>
										<li><a href="attendance-admin.php"class="<?php echo ($page =='attendance-admin.php') ? 'active' : '' ;?>">Admin Attendence</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='leaves-admin.php'||$page =='leaves-employee.php'||$page =='leave-types.php'||$page =='holidays.php') ? 'active subdrop' : '' ;?>"><span>Leaves &amp; Holidays</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="leaves-admin.php"class="<?php echo ($page =='leaves-admin.php') ? 'active' : '' ;?>">Admin Leaves</a></li>
										<li><a href="leaves-employee.php"class="<?php echo ($page =='leaves-employee.php') ? 'active' : '' ;?>">Employee Leaves</a></li>
										<li><a href="leave-types.php"class="<?php echo ($page =='leave-types.php') ? 'active' : '' ;?>">Leave Types</a></li>
										<li><a href="holidays.php"class="<?php echo ($page =='holidays.php') ? 'active' : '' ;?>"><span>Holidays</span></a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="payroll-list.php"class="<?php echo ($page =='payroll-list.php'||$page =='payslip.php') ? 'active' : '' ;?>"><span>Payroll</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="payroll-list.php"class="<?php echo ($page =='payroll-list.php') ? 'active' : '' ;?>">Employee Salary</a></li>
										<li><a href="payslip.php"class="<?php echo ($page =='payslip.php') ? 'active' : '' ;?>">Payslip</a></li>
									</ul>
								</li>
							</ul>
						</li>
						<li class="submenu">
							<a href="javascript:void(0);"class="<?php echo ($page =='sales-report.php'||$page =='purchase-report.php'||$page =='inventory-report.php'||$page =='invoice-report.php'||$page =='supplier-report.php'||$page =='customer-report.php'||$page =='expense-report.php'||$page =='income-report.php'||$page =='tax-reports.php'||$page =='profit-and-loss.php') ? 'active subdrop' : '' ;?>"><img src="assets/img/icons/printer.svg" alt="img"><span>Reports</span> <span class="menu-arrow"></span></a>
							<ul>
								<li><a href="sales-report.php"class="<?php echo ($page =='sales-report.php') ? 'active' : '' ;?>"><span>Sales Report</span></a></li>
								<li><a href="purchase-report.php"class="<?php echo ($page =='purchase-report.php') ? 'active' : '' ;?>"><span>Purchase report</span></a></li>
								<li><a href="inventory-report.php"class="<?php echo ($page =='inventory-report.php') ? 'active' : '' ;?>"><span>Inventory Report</span></a></li>									
								<li><a href="invoice-report.php"class="<?php echo ($page =='invoice-report.php') ? 'active' : '' ;?>"><span>Invoice Report</span></a></li>
								<li><a href="supplier-report.php"class="<?php echo ($page =='supplier-report.php') ? 'active' : '' ;?>"><span>Supplier Report</span></a></li>
								<li><a href="customer-report.php"class="<?php echo ($page =='customer-report.php') ? 'active' : '' ;?>"><span>Customer Report</span></a></li>
								<li><a href="expense-report.php"class="<?php echo ($page =='expense-report.php') ? 'active' : '' ;?>"><span>Expense Report</span></a></li>
								<li><a href="income-report.php"class="<?php echo ($page =='income-report.php') ? 'active' : '' ;?>"><span>Income Report</span></a></li>
								<li><a href="tax-reports.php"class="<?php echo ($page =='tax-reports.php') ? 'active' : '' ;?>"><span>Tax Report</span></a></li>
								<li><a href="profit-and-loss.php"class="<?php echo ($page =='profit-and-loss.php') ? 'active' : '' ;?>"><span>Profit & Loss</span></a></li>
							</ul>
						</li>
						<li class="submenu">
							<a href="javascript:void(0);"class="<?php echo ($page =='general-settings.php'||$page =='security-settings.php'||$page =='notification.php'||$page =='connected-apps.php'||$page =='system-settings.php'||$page =='company-settings.php'||$page =='localization-settings.php'||$page =='prefixes.php'||$page =='preference.php'||$page =='appearance.php'||$page =='social-authentication.php'||$page =='language-settings.php'||$page=='language-settings-web.php'
							||$page =='invoice-settings.php'||$page =='printer-settings.php'||$page =='pos-settings.php'||$page =='custom-fields.php'||$page =='email-settings.php'||$page =='sms-gateway.php'||$page =='otp-settings.php'||$page =='gdpr-settings.php'||$page =='payment-gateway-settings.php'||$page =='bank-settings-grid.php'||$page=='bank-settings-list.php'||$page =='tax-rates.php'||$page =='currency-settings.php'||$page =='storage-settings.php'||$page =='ban-ip-address.php') ? 'active' : '' ;?>"><img src="assets/img/icons/settings.svg" alt="img"><span> Settings</span> <span class="menu-arrow"></span></a>
							<ul>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='general-settings.php'||$page =='security-settings.php'||$page =='notification.php'||$page =='connected-apps.php') ? 'active' : '' ;?>"><span>General Settings</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="general-settings.php"class="<?php echo ($page =='general-settings.php') ? 'active' : '' ;?>">Profile</a></li>
										<li><a href="security-settings.php"class="<?php echo ($page =='security-settings.php') ? 'active' : '' ;?>">Security</a></li>
										<li><a href="notification.php"class="<?php echo ($page =='notification.php') ? 'active' : '' ;?>">Notifications</a></li>
										<li><a href="connected-apps.php"class="<?php echo ($page =='connected-apps.php') ? 'active' : '' ;?>">Connected Apps</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='system-settings.php'||$page =='company-settings.php'||$page =='localization-settings.php'||$page =='prefixes.php'||$page =='preference.php'||$page =='appearance.php'||$page =='social-authentication.php'||$page =='language-settings.php'||$page=='language-settings-web.php') ? 'active' : '' ;?>"><span>Website Settings</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="system-settings.php"class="<?php echo ($page =='system-settings.php') ? 'active' : '' ;?>">System Settings</a></li>
										<li><a href="company-settings.php"class="<?php echo ($page =='company-settings.php') ? 'active' : '' ;?>">Company Settings </a></li>
										<li><a href="localization-settings.php"class="<?php echo ($page =='localization-settings.php') ? 'active' : '' ;?>">Localization</a></li>
										<li><a href="prefixes.php"class="<?php echo ($page =='prefixes.php') ? 'active' : '' ;?>">Prefixes</a></li>
										<li><a href="preference.php"class="<?php echo ($page =='preference.php') ? 'active' : '' ;?>">Preference</a></li>
										<li><a href="appearance.php"class="<?php echo ($page =='appearance.php') ? 'active' : '' ;?>">Appearance</a></li>
										<li><a href="social-authentication.php"class="<?php echo ($page =='social-authentication.php') ? 'active' : '' ;?>">Social Authentication</a></li>
										<li><a href="language-settings.php"class="<?php echo ($page =='language-settings.php'||$page=='language-settings-web.php') ? 'active' : '' ;?>">Language</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='invoice-settings.php'||$page =='printer-settings.php'||$page =='pos-settings.php'||$page =='custom-fields.php') ? 'active' : '' ;?>"><span>App Settings</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="invoice-settings.php"class="<?php echo ($page =='invoice-settings.php') ? 'active' : '' ;?>">Invoice</a></li>
										<li><a href="printer-settings.php"class="<?php echo ($page =='printer-settings.php') ? 'active' : '' ;?>">Printer</a></li>
										<li><a href="pos-settings.php"class="<?php echo ($page =='pos-settings.php') ? 'active' : '' ;?>">POS</a></li>
										<li><a href="custom-fields.php"class="<?php echo ($page =='custom-fields.php') ? 'active' : '' ;?>">Custom Fields</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='email-settings.php'||$page =='sms-gateway.php'||$page =='otp-settings.php'||$page =='gdpr-settings.php') ? 'active subdrop' : '' ;?>"><span>System Settings</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="email-settings.php"class="<?php echo ($page =='email-settings.php') ? 'active' : '' ;?>">Email</a></li>
										<li><a href="sms-gateway.php"class="<?php echo ($page =='sms-gateway.php') ? 'active' : '' ;?>">SMS Gateways</a></li>
										<li><a href="otp-settings.php"class="<?php echo ($page =='otp-settings.php') ? 'active' : '' ;?>">OTP</a></li>
										<li><a href="gdpr-settings.php"class="<?php echo ($page =='gdpr-settings.php') ? 'active' : '' ;?>">GDPR Cookies</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='payment-gateway-settings.php'||$page =='bank-settings-grid.php'||$page =='tax-rates.php'||$page =='currency-settings.php'||$page=='bank-settings-list.php') ? 'active' : '' ;?>"><span>Financial Settings</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="payment-gateway-settings.php"class="<?php echo ($page =='payment-gateway-settings.php') ? 'active' : '' ;?>">Payment Gateway</a></li>
										<li><a href="bank-settings-grid.php"class="<?php echo ($page =='bank-settings-grid.php'||$page=='bank-settings-list.php') ? 'active' : '' ;?>">Bank Accounts</a></li>
										<li><a href="tax-rates.php"class="<?php echo ($page =='tax-rates.php') ? 'active' : '' ;?>">Tax Rates</a></li>
										<li><a href="currency-settings.php"class="<?php echo ($page =='currency-settings.php') ? 'active' : '' ;?>">Currencies</a></li>
									</ul>
								</li>
								<li class="submenu">
									<a href="javascript:void(0);"class="<?php echo ($page =='storage-settings.php'||$page =='ban-ip-address.php') ? 'active' : '' ;?>"><span>Other Settings</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="storage-settings.php"class="<?php echo ($page =='storage-settings.php') ? 'active' : '' ;?>">Storage</a></li>
										<li><a href="ban-ip-address.php"class="<?php echo ($page =='ban-ip-address.php') ? 'active' : '' ;?>">Ban IP Address</a></li>
									</ul>
								</li>
								<li><a href="javascript:void(0);"><span>Documentation</span></a></li>
								<li><a href="javascript:void(0);"><span>Changelog v2.0.3</span></a></li>
								<li class="submenu">
									<a href="javascript:void(0);"><span>Multi Level</span><span class="menu-arrow"></span></a>
									<ul>
										<li><a href="javascript:void(0);">Level 1.1</a></li>
										<li class="submenu submenu-two"><a href="javascript:void(0);">Level 1.2<span class="menu-arrow inside-submenu"></span></a>
											<ul>
												<li><a href="javascript:void(0);">Level 2.1</a></li>
												<li class="submenu submenu-two submenu-three"><a href="javascript:void(0);">Level 2.2<span class="menu-arrow inside-submenu inside-submenu-two"></span></a>
													<ul>
														<li><a href="javascript:void(0);">Level 3.1</a></li>
														<li><a href="javascript:void(0);">Level 3.2</a></li>
													</ul>
												</li>
											</ul>
										</li>
									</ul>
								</li>
							</ul>
						</li> 
					</ul>
				</div>
		</div>
	<!-- /Sidebar -->
