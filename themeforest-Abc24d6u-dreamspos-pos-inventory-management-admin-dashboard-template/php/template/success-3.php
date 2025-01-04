<?php include 'layouts/session.php'; ?>
<!DOCTYPE html>
<html lang="en">
    <head>
    <?php include 'layouts/title-meta.php'; ?>
    <?php include 'layouts/head-css.php'; ?>		
    </head>
    <body class="account-page">

        <div id="global-loader" >
			<div class="whirly-loader"> </div>
		</div>
	
		<!-- Main Wrapper -->
        <div class="main-wrapper">
			<div class="account-content">
				<div class="login-wrapper login-new">
                    <div class="login-content user-login">
                        <div class="login-logo">
                            <img src="assets/img/logo.png" alt="img">
                            <a href="index.php" class="login-logo logo-white">
                                <img src="assets/img/logo-white.png"  alt="">
                            </a>
                        </div>
                        <div class="login-userset">
                            <div class="login-userheading text-center">
                                <img src="assets/img/icons/check-icon.svg" alt="Icon">
                                <h3 class="text-center">Success</h3>
                                <h4 class="verfy-mail-content text-center">Your Passwrod Reset Successfully!</h4>
                            </div>
                            
                           
                            <div class="form-login">
                                <a class="btn btn-login mt-0" href="signin-3.php">Back to Login</a>
                            </div>
                            <div class="my-4 d-flex justify-content-center align-items-center copyright-text">
                                <p>Copyright © 2023-Dreamspos</p>
                            </div>
                        </div>
                    </div>
                    <div class="my-4 d-flex justify-content-center align-items-center copyright-text">
                        <p>Copyright &copy; 2023 DreamsPOS. All rights reserved</p>
                    </div>
                </div>
			</div>
        </div>
		<!-- /Main Wrapper -->
        <?php include 'layouts/customizer.php'; ?>
        <?php include 'layouts/vendor-scripts.php'; ?>

    </body>
</html>