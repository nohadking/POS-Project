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
                            <div class="login-userheading text-center">
                                <h3>Verify Your Email</h3>
                                <h4 class="verfy-mail-content">We've sent a link to your  email ter4@example.com. Please follow the link inside to continue</h4>
                            </div>
                            <div class="signinform text-center">
                                <h4>Didn't receive an email? <a href="javascript:void(0);" class="hover-a resend">Resend Link</a></h4>
                            </div>
                            <div class="form-login">
                                <a class="btn btn-login" href="index.php">Skip Now</a>
                            </div>
                            <div class="my-4 d-flex justify-content-center align-items-center copyright-text">
                                <p>Copyright &copy; 2023 DreamsPOS. All rights reserved</p>
                            </div>
                        </div>
                    </div>
                    <div class="login-img">
                        <img src="assets/img/authentication/email02.png" alt="img">
                    </div>
                </div>
			</div>
        </div>
		<!-- /Main Wrapper -->

<!-- JAVASCRIPT -->
<?php include 'layouts/vendor-scripts.php'; ?>
</body>
</html>