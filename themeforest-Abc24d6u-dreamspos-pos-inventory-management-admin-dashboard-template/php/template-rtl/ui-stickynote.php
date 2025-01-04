<?php include 'layouts/session.php'; ?>
<!DOCTYPE html>
<html lang="en">
    <head>
	<?php include 'layouts/title-meta.php'; ?>
 <?php include 'layouts/head-css.php'; ?> 
       <!-- Sticky CSS -->
		<link rel="stylesheet" href="assets/plugins/stickynote/sticky.css">

    </head>
    <body>
        <div id="global-loader" >
            <div class="whirly-loader"> </div>
        </div>
        <!-- Main Wrapper -->
        <div class="main-wrapper">

			<?php include 'layouts/menu.php'; ?>

            <div class="page-wrapper cardhead">
                <div class="content ">
				
					<!-- Page Header -->
					<div class="page-header">
						<div class="row">
							<div class="col-sm-12">
								<h3 class="page-title">Sticky Note</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item"><a href="index.php">Dashboard</a></li>
									<li class="breadcrumb-item active">Sticky Note</li>
								</ul>
							</div>
						</div>
					</div>
					<!-- /Page Header -->
					
					<div class="row">
					
						<!-- Sticky -->
						<div class="col-md-12">	
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Sticky Note <a class="btn btn-primary float-sm-end m-l-10" id="add_new" href="javascript:void(0);">Add New Note</a></h5>
								</div>
								<div class="card-body">
									 <div class="sticky-note" id="board"></div>
								</div>
							</div>
						</div>
						<!-- /Sticky -->
							
					</div>
				
				</div>		
            </div>
        </div>
        <!-- /Main Wrapper -->
		<?php include 'layouts/customizer.php'; ?>

		<?php include 'layouts/vendor-scripts.php'; ?>
       	<!-- Stickynote JS -->
		<script src="assets/js/jquery-ui.min.js"></script>
		<script src="assets/plugins/stickynote/sticky.js"></script>


	
    </body>
</html>