<?php include 'layouts/session.php'; ?>
<!DOCTYPE html>
<html lang="en">
<head>
 <?php include 'layouts/title-meta.php'; ?>
 <?php include 'layouts/head-css.php'; ?>
</head>
<body>
<div id="global-loader" >
<div class="whirly-loader"> </div>
</div>
	<!-- main Wrapper-->
    <div class="main-wrapper">
    <?php include 'layouts/menu.php'; ?>


    <div class="page-wrapper cardhead">
                <div class="content container-fluid">
				
					<!-- Page Header -->
					<div class="page-header">
						<div class="row">
							<div class="col-sm-12">
								<h3 class="page-title">Form Select</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item"><a href="index.php">Dashboard</a></li>
									<li class="breadcrumb-item active">Form Select</li>
								</ul>
							</div>
						</div>
					</div>
					<!-- /Page Header -->
					
					<div class="row">
						<div class="col-md-6">
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Basics</h5>
								</div>
								<div class="card-body">
									<select class="form-select" aria-label="Default select example">
									  	<option selected>Open this select menu</option>
									 	 <option value="1">One</option>
									 	 <option value="2">Two</option>
									 	 <option value="3">Three</option>
									</select>
								</div>
							</div>
						</div>

						<div class="col-md-6">
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Sizing</h5>
								</div>
								<div class="card-body">
									<select class="form-select form-select-lg mb-3" aria-label=".form-select-lg example">
										  <option selected>Open this select menu</option>
										  <option value="1">One</option>
										  <option value="2">Two</option>
										  <option value="3">Three</option>
									</select>

									<select class="form-select form-select-sm" aria-label=".form-select-sm example">
										  <option selected>Open this select menu</option>
										  <option value="1">One</option>
										  <option value="2">Two</option>
										  <option value="3">Three</option>
									</select>
								</div>
							</div>
						</div>
						
						<div class="col-md-6">
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Multiple Select</h5>
								</div>
								<div class="card-body">
									<select class="form-select" multiple aria-label="multiple select example">
										<option selected>Open this select menu</option>
	  									<option value="1">One</option>
	  									<option value="2">Two</option>
	  									<option value="3">Three</option>
									</select>
								</div>
							</div>
						</div>					
						
					</div>
				
				</div>				
            </div>


    </div>
<!-- end main Wrapper-->
<?php include 'layouts/customizer.php'; ?>
<!-- JAVASCRIPT -->
<?php include 'layouts/vendor-scripts.php'; ?>
</body>
</html>