<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginNew.aspx.cs" Inherits="Login_LoginNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
	<%--<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">--%>
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<%--<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">--%>
<!--===============================================================================================-->
	<%--<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<%--<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">--%>
<!--===============================================================================================-->
	<%--<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">--%>
<!--===============================================================================================-->	
	<%--<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">--%>
<!--===============================================================================================-->
	<%--<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">--%>
<!--===============================================================================================-->
	<%--<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">--%>
<!--===============================================================================================-->	
	<%--<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">--%>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
    <script type="text/javascript">
        function ValidateUser()
        {
            if (document.getElementById("txtUserName").value == "") {
                alert("Please enter Username");
                document.getElementById("txtUserName").focus();
                return false;
            }
            else if (document.getElementById("txtPassword").value == "") {
                alert("Please enter Password");
                document.getElementById("txtPassword").focus();
                return false;
            }
            else
                return true;
        }
    </script>
</head>
<body style="background-color: #e6e6e6; font-family:Arial; font-size:16px; padding:8px;">
    <form id="form1" runat="server">
        <table style="width: 100%; font-family: Arial; background-image: url('../images/back.jpg');"
                cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="19" style="background-color: #cc632a; height: 5px;"></td>
                </tr>
                <tr>
                    <td colspan="20" style="background-color: #d8b377; height: 80px;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="height: 45px; width: 14%;"></td>
                                <td colspan="3" style="width: 25%;">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/iti.png" Height="75px" />
                                </td>
                                <td style="width: 22%;"></td>
                                <td colspan="3" style="width: 25%;" align="center">
                                    <%--<asp:Image ID="Image2" runat="server" ImageUrl="~/images/Aptech.png" Height="70px"
                                        Width="200px" />--%>
                                </td>
                                <td style="width: 14%;"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="background-color: #cc632a; height: 25px;">
                    <td colspan="20" style="height: 25px; text-align:center;">
                        <%--<asp:Label ID="lblUName" runat="server" Text="" style="margin-left:10%; font-weight:bold;" ></asp:Label>
                        <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" style="float:right; margin-right:10%;">Logout</asp:LinkButton>--%>
                    </td>
                </tr>
        <tr style="background-color: #d8b377; height: 25px;">
            <td colspan="20" style="height: 25px; float:left; margin-left:50px; margin-left:15%; margin-right:15%;">
                    Login
                    </td>
        </tr>
        </table>
        <div class="limiter">
            <div class="container-login100">
               
                <div style="font-weight:bold;text-align:center;width:100%;">
                       <%--  Semester exam pattern verification and Steno trades verification will start from 13/May/2019--%>
                    Candidate verification of June 2019 Examination is open till 17 June. Please do not wait for the last date.
                        </div><br />
                <%--<div style="font-weight:bold;text-align:center;">
                          Candidate verification of June 2019 Examination is open till 17 June. Please do not wait for the last date.
                        </div>--%>
                <br /><br /><br />
               <%-- <div style="width:100%; text-align:center; font-size:13px; font-weight:bold;">Student Login, ITI Login , Joint Director Login , Admin login</div>--%>
                <div class="wrap-login100 p-b-30">
                    <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/iti.png" Height="75px" />--%>
                   
                    <div>
                        <div class="wrap-input100 m-b-16">
                            <asp:TextBox ID="txtUserName" runat="server" placeholder="Username" class="input100"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 m-b-20">
                            <span class="btn-show-pass">
                                <i class="fa fa fa-eye"></i>
                            </span>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" class="input100"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="container-login100-form-btn">
                            <asp:Button ID="btnLogin" runat="server" class="login100-form-btn" Text="Login" OnClientClick="return ValidateUser();" OnClick="btnLogin_Click" />

                        </div>

                           <div>

                           
                                
                                <asp:LinkButton ID="lnkforgotpass" runat="server" PostBackUrl="~/Center/ForgotPassword.aspx">Forgot Password</asp:LinkButton>
                           
                                
                             </div>

                        
                    </div>
                </div>
                
            </div>
        </div>
    </form>
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
