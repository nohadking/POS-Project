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
                        <form action="success-3.php">
                            <div class="login-userset">
                                <div class="login-userheading">
                                    <h3>Reset password?</h3>
                                    <h4>Enter New Password & Confirm Password to get inside</h4>
                                </div>
                                <div class="form-login">
                                    <label> Old Password</label>
                                    <div class="pass-group">
                                        <input type="password" class="pass-input">
                                        <span class="fas toggle-password fa-eye-slash"></span>
                                    </div>
                                </div>
                                <div class="form-login">
                                    <label>New Password</label>
                                    <div class="pass-group">
                                        <input type="password" class="pass-inputa">
                                        <span class="fas toggle-passworda fa-eye-slash"></span>
                                    </div>
                                </div>
                                <div class="form-login">
                                    <label> New Confirm Passworrd</label>
                                    <div class="pass-group">
                                        <input type="password" class="pass-inputs">
                                        <span class="fas toggle-passwords fa-eye-slash"></span>
                                    </div>
                                </div>
                                <div class="form-login">
                                    <button type="submit" class="btn btn-login">Change Password</button>
                                </div>
                                <div class="signinform text-center">
                                    <h4>Return to <a href="signin-3.php" class="hover-a"> login </a></h4>
                                </div>
                            </div>
                        </form>
                       
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