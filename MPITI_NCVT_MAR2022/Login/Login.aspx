<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Login</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
</head>
<body>

 	<div class="limiter">
		<div class="container-login100">
           
			<div class="wrap-login100 p-t-90 p-b-30">
                 <asp:Image ID="Image1" runat="server" ImageUrl="~/images/iti.png" Height="75px" />
				<form class="login100-form validate-form" runat="server">
					<span class="login100-form-title p-b-40">
						Student Login
					</span>

					<div>
						<div class="wrap-input100 m-b-16" data-validate="Please enter Username">
						<input class="input100" type="text" name="email" placeholder="Username">
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 m-b-20" data-validate = "Please enter password">
						<span class="btn-show-pass">
							<i class="fa fa fa-eye"></i>
						</span>
						<input class="input100" type="password" name="pass" placeholder="Password">
						<span class="focus-input100"></span>
					</div>
                        	<div class="container-login100-form-btn">
					
                            <asp:Button ID="btnStudLogin" runat="server" class="login100-form-btn" Text="Login" OnClick="btnStudLogin_Click" />
				
					</div>
					</div>

					<div class="text-center p-t-55 p-b-30">
						<span class="login100-form-title p-b-40">
							ITI Login
			               
					</span>
					</div>

					<div class="wrap-input100 m-b-16" data-validate="Username">
						<input class="input100" type="text" name="email" placeholder="Username" id="txtpusername" runat="server"/>
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 m-b-20" data-validate = "Please enter password">
						<span class="btn-show-pass">
							<i class="fa fa fa-eye"></i>
						</span>
						<input class="input100" type="password" name="pass" placeholder="Password" id="txtppassword" runat="server"/>
						<span class="focus-input100"></span>
					</div>
                    	<div class="container-login100-form-btn">
                            <asp:Button ID="btnprLogin" runat="server" Text="Login" class="login100-form-btn" OnClick="btnprLogin_Click" />
					</div>
                    <div class="text-center p-t-55 p-b-30">
						<span class="login100-form-title p-b-40">

							Admin  Login
						</span>
					</div>

					<div class="wrap-input100 m-b-16" data-validate="Username">
						<input class="input100" type="text" name="email" placeholder="Username"/>
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 m-b-20" data-validate = "Username">
						<span class="btn-show-pass">
							<i class="fa fa fa-eye"></i>
						</span>
						<input class="input100" type="password" name="pass" placeholder="Password"/>
						<span class="focus-input100"></span>
					</div>
					<div class="container-login100-form-btn">
					  <asp:Button ID="btnadminLogin" runat="server" Text="Login" class="login100-form-btn" />
					</div>
					
					
					
				</form>
			</div>
		</div>
	</div>
	
	
<!--===============================================================================================-->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>
</body>
</html>
