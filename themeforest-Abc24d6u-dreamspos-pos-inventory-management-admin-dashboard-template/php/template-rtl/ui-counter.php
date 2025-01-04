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
        <!-- Main Wrapper -->
        <div class="main-wrapper">

			<?php include 'layouts/menu.php'; ?>

            <div class="page-wrapper cardhead">
                <div class="content container-fluid">
				
					<!-- Page Header -->
					<div class="page-header">
						<div class="row">
							<div class="col-sm-12">
								<h3 class="page-title">Counter</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item"><a href="index.php">Dashboard</a></li>
									<li class="breadcrumb-item active">Counter</li>
								</ul>
							</div>
						</div>
					</div>
					<!-- /Page Header -->
					
					<div class="row">
					
						<!-- Counter -->
						<div class="col-md-4">	
							<div class="card">
								<div class="card-body">
									<h5>Clients</h5>
									<h6 class="counter">3,000</h6>
								</div>
							</div>
						</div>
						<!-- /Counter -->
						
						<!-- Counter -->
						<div class="col-md-4">	
							<div class="card">
								<div class="card-body">
									<h5>Total Sales</h5>
									<h6 class="counter">10,000</h6>
								</div>
							</div>
						</div>
						<!-- /Counter -->
						
						<!-- Counter -->
						<div class="col-md-4">	
							<div class="card">
								<div class="card-body">
									<h5>Total Projects</h5>
									<h6 class="counter">15,000</h6>
								</div>
							</div>
						</div>
						<!-- /Counter -->
						
						<!-- Counter -->
						<div class="col-md-4">	
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Count Down</h5>
								</div>
								<div class="card-body">
									<h6>Time Count from 3</h6>
									<span id="timer-countdown"></span>
								</div>
							</div>
						</div>
						<!-- /Counter -->
						
						<!-- Counter -->
						<div class="col-md-4">	
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Count Up</h5>
								</div>
								<div class="card-body">
									<h6>Time Counting From 0</h6>
									<span id="timer-countup"></span>
								</div>
							</div>
						</div>
						<!-- /Counter -->
						
						<!-- Counter -->
						<div class="col-md-4">	
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Count Inbetween</h5>
								</div>
								<div class="card-body">
									<h6>Time counting from 30 to  20</h6>
									<span id="timer-countinbetween"></span>
								</div>
							</div>
						</div>
						<!-- /Counter -->
						
						<!-- Counter -->
						<div class="col-md-4">	
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Count Callback</h5>
								</div>
								<div class="card-body">
									<h6>Count from 10 to 0 and calls timer end callback</h6>
									<span id="timer-countercallback"></span>
								</div>
							</div>
						</div>
						<!-- /Counter -->
						
						<!-- Counter -->
						<div class="col-md-4">	
							<div class="card">
								<div class="card-header">
									<h5 class="card-title">Custom Output</h5>
								</div>
								<div class="card-body">
									<h6>Changed output pattern</h6>
									<span id="timer-outputpattern"></span>
								</div>
							</div>
						</div>
						<!-- /Counter -->
							
					</div>
				
				</div>	
            </div>
        </div>
        <!-- /Main Wrapper -->
		<?php include 'layouts/customizer.php'; ?>
		<?php include 'layouts/vendor-scripts.php'; ?>
		<!-- Stickynote JS -->
		<script src="assets/plugins/countup/jquery.counterup.min.js"></script>
		<script src="assets/plugins/countup/jquery.waypoints.min.js"></script>
		<script src="assets/plugins/countup/jquery.missofis-countdown.js"></script>
        
    </body>
</html>