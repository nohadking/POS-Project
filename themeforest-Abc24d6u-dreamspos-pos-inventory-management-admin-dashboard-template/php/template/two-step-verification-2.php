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
				<div class="login-wrapper">
                    <div class="login-content">
                        <div class="login-userset">
                            <div class="login-userset">
                                <div class="login-logo logo-normal">
                                    <img src="assets/img/logo.png" alt="img">
                                </div>
                            </div>    
                            <a href="index.php" class="login-logo logo-white">
                                <img src="assets/img/logo-white.png"  alt="">
                            </a>
                            <div class="login-userheading">
                                <h3>Login With Your Email Address</h3>
                                <h4 class="verfy-mail-content">We sent a verification code to your email. Enter the code from the email in the field below</h4>
                            </div>
                            <form action="index.php" class="digit-group">
                                <div class="wallet-add">
                                    <div class="otp-box"> 
                                        <div class="forms-block text-center"> 
                                            <input type="text" id="digit-1" maxlength="1" value=""> 
                                            <input type="text" id="digit-2" maxlength="1" value="">
                                            <input type="text" id="digit-3" maxlength="1" value=""> 
                                            <input type="text" id="digit-4" maxlength="1" value=""> 
                                        </div> 
                                    </div>
                                </div>
                                <div class="Otp-expire text-center">
                                    <p>Otp will expire in 09 :10</p>
                                </div>
                                <div class="form-login mt-4">
                                    <button type="submit" class="btn btn-login">Verify My Account</button>
                                </div>
                            </form>
                            <div class="my-4 d-flex justify-content-center align-items-center copyright-text">
                                <p>Copyright &copy; 2023 DreamsPOS. All rights reserved</p>
                            </div>
                        </div>
                    </div>
                    <div class="login-img">
                        <img src="assets/img/authentication/step-two.png" alt="img">
                    </div>
                </div>
			</div>
        </div>
		<!-- /Main Wrapper -->
		
        <?php include 'layouts/customizer.php'; ?>

        <?php include 'layouts/vendor-scripts.php'; ?>
	
    </body>
</html>