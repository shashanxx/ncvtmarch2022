<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfflineCandidateList.aspx.cs" Inherits="Home_CandidateList" enableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Details</title>
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
        function ValidateUser() {
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
                        <asp:Label ID="lblUName" runat="server" Text="" style="margin-left:10%; font-weight:bold;" ></asp:Label>
                    </td>
                </tr>
        
        </table>
        <table width="90%" align="center">
            <tr>
                <td style="text-align:left;"><span style="font-weight:bold;font-color:red;">Important Instructions</span>
					<ol>
						<li>This is a provisional window for ITI’s who have reported issues and closure time for this window is 19/8/2018, 10:00 Hrs.</li>
						<li>Admit card release will be subjected to fees payment.</li>
						<li>Payments can be made against students in case fees payment is pending/refunds initiated.</li>
						<li>In case students approval /verification pending, students records can be updated with payment reference number.</li>
						<li>Order ID’s can be updated against students whose payment is successful but approval /verification pending.</li>
						<li>Students not appearing in portal can be added after prior approval from department subject to successful fees payment.</li>
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    <asp:Button ID="btnAddNew" runat="server" Text="Add New"  BackColor="cadetblue" OnClick="btnAddNew_Click"
                ForeColor="White" class="border btn btn-lg btn-primary btn-block" />
                </td>
            </tr>
            <tr>
                <td style="height:30px;"></td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lbl1" runat="server" Text="Trainee Details" style="font-weight:bold;" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grd_candidate" runat="server" 
                     AutoGenerateColumns="false" ShowFooter="false" OnRowEditing="grd_candidate_RowEditing" DataKeyNames="ID" 
                        OnRowUpdating="GridView1_RowUpdating" AutoGenerateEditButton="true" >

                    <Columns>
                        <asp:BoundField DataField="ITICode" HeaderText="ITICode"/>                        
                        <asp:BoundField DataField="RollNumber" HeaderText="Trainee RollNumber"/>
                        <asp:BoundField DataField="Name" HeaderText="Trainee Name"/>
                        <asp:BoundField DataField="AdmissionYear" HeaderText="AdmissionYear"  ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="ExamType" HeaderText="ExamType" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="TradeName" HeaderText="Trade"/>
                        <asp:BoundField DataField="Sem" HeaderText="Semester" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="PaymentRefNo" HeaderText="Order No / Order ID" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="createddate" HeaderText="Saved Date" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="OfflinePaymentStatus" HeaderText="Offline Payment Status" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="OfflineTranAmount" HeaderText="Offline Transaction Amount" ItemStyle-HorizontalAlign="Center"/>
                        
                    </Columns>
                </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="height:50px;"></td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lbl2" runat="server" Text="Offline Payment Details" style="font-weight:bold;" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grd_payment" runat="server" 
                     AutoGenerateColumns="false" ShowFooter="false">

                    <Columns>
                        <asp:BoundField DataField="Order_no" HeaderText="Order Number" ItemStyle-HorizontalAlign="Center"/>                        
                        <asp:BoundField DataField="total_amount" HeaderText="Transaction Amount" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="paymentstatus" HeaderText="Payment Status" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="trans_msg" HeaderText="Transaction Detail" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="created_date" HeaderText="Transaction Date"  ItemStyle-HorizontalAlign="Center"/>
                        
                    </Columns>
                </asp:GridView>
                </td>
            </tr>
        </table>
    
    
    

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
