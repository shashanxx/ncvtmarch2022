<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="OfflineEntryForm.aspx.cs" Inherits="Candidate_EntryForm" %>

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
                        <%--<asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" style="float:right; margin-right:10%;">Logout</asp:LinkButton>--%>
                    </td>
                </tr>
        
        </table>

    <table width="100%">
        <tr>
            <td style="text-align:right;">
                ITI Code:
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtITICode" runat="server" MaxLength="20" CssClass="form-control " Enabled="false" placeholder="ITI Code" onkeypress="return CreateCAPSStringTextBox(this,event)" Style="text-transform: uppercase;"></asp:TextBox>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                ITI Contact No:
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtITIContactNo" runat="server" MaxLength="12" CssClass="form-control " placeholder="ITI Contact No" onkeypress="return CreateCAPSStringTextBox(this,event)" Style="text-transform: uppercase;"></asp:TextBox>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                Trainee Roll Number:
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtRollNumber" runat="server" MaxLength="20" CssClass="form-control " placeholder="Roll Number" onkeypress="return CreateCAPSStringTextBox(this,event)" Style="text-transform: uppercase;"></asp:TextBox>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                Trainee Name:
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="form-control " placeholder="Name" onkeypress="return CreateCAPSStringTextBox(this,event)" Style="text-transform: uppercase;"></asp:TextBox>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                Trainee DOB:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpddate" runat="server" CssClass="form-control" Width="75px" Font-Size="12px">
                    <asp:ListItem Value="0">DAY</asp:ListItem>
                    <asp:ListItem Value="01">01</asp:ListItem>
                    <asp:ListItem Value="02">02</asp:ListItem>
                    <asp:ListItem Value="03">03</asp:ListItem>
                    <asp:ListItem Value="04">04</asp:ListItem>
                    <asp:ListItem Value="05">05</asp:ListItem>
                    <asp:ListItem Value="06">06</asp:ListItem>
                    <asp:ListItem Value="07">07</asp:ListItem>
                    <asp:ListItem Value="08">08</asp:ListItem>
                    <asp:ListItem Value="09">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                    <asp:ListItem Value="19">19</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="21">21</asp:ListItem>
                    <asp:ListItem Value="22">22</asp:ListItem>
                    <asp:ListItem Value="23">23</asp:ListItem>
                    <asp:ListItem Value="24">24</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                    <asp:ListItem Value="26">26</asp:ListItem>
                    <asp:ListItem Value="27">27</asp:ListItem>
                    <asp:ListItem Value="28">28</asp:ListItem>
                    <asp:ListItem Value="29">29</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="31">31</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="drpdmonth" runat="server" CssClass="form-control" Width="90px" Font-Size="12px">
                    <asp:ListItem Value="0">MONTH</asp:ListItem>
                    <asp:ListItem Value="01">JAN</asp:ListItem>
                    <asp:ListItem Value="02">FEB</asp:ListItem>
                    <asp:ListItem Value="03">MAR</asp:ListItem>
                    <asp:ListItem Value="04">APR</asp:ListItem>
                    <asp:ListItem Value="05">MAY</asp:ListItem>
                    <asp:ListItem Value="06">JUN</asp:ListItem>
                    <asp:ListItem Value="07">JUL</asp:ListItem>
                    <asp:ListItem Value="08">AUG</asp:ListItem>
                    <asp:ListItem Value="09">SEP</asp:ListItem>
                    <asp:ListItem Value="10">OCT</asp:ListItem>
                    <asp:ListItem Value="11">NOV</asp:ListItem>
                    <asp:ListItem Value="12">DEC</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="drpdyear" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='YEAR'>YEAR</asp:ListItem>
                    <asp:ListItem Value='1952'>1952</asp:ListItem>
                    <asp:ListItem Value='1953'>1953</asp:ListItem>
                    <asp:ListItem Value='1954'>1954</asp:ListItem>
                    <asp:ListItem Value='1955'>1955</asp:ListItem>
                    <asp:ListItem Value='1956'>1956</asp:ListItem>
                    <asp:ListItem Value='1957'>1957</asp:ListItem>
                    <asp:ListItem Value='1958'>1958</asp:ListItem>
                    <asp:ListItem Value='1959'>1959</asp:ListItem>
                    <asp:ListItem Value='1960'>1960</asp:ListItem>
                    <asp:ListItem Value='1961'>1961</asp:ListItem>
                    <asp:ListItem Value='1962'>1962</asp:ListItem>
                    <asp:ListItem Value='1963'>1963</asp:ListItem>
                    <asp:ListItem Value='1964'>1964</asp:ListItem>
                    <asp:ListItem Value='1965'>1965</asp:ListItem>
                    <asp:ListItem Value='1966'>1966</asp:ListItem>
                    <asp:ListItem Value='1967'>1967</asp:ListItem>
                    <asp:ListItem Value='1968'>1968</asp:ListItem>
                    <asp:ListItem Value='1969'>1969</asp:ListItem>
                    <asp:ListItem Value='1970'>1970</asp:ListItem>
                    <asp:ListItem Value='1971'>1971</asp:ListItem>
                    <asp:ListItem Value='1972'>1972</asp:ListItem>
                    <asp:ListItem Value='1973'>1973</asp:ListItem>
                    <asp:ListItem Value='1974'>1974</asp:ListItem>
                    <asp:ListItem Value='1975'>1975</asp:ListItem>
                    <asp:ListItem Value='1976'>1976</asp:ListItem>
                    <asp:ListItem Value='1977'>1977</asp:ListItem>
                    <asp:ListItem Value='1978'>1978</asp:ListItem>
                    <asp:ListItem Value='1979'>1979</asp:ListItem>
                    <asp:ListItem Value='1980'>1980</asp:ListItem>
                    <asp:ListItem Value='1981'>1981</asp:ListItem>
                    <asp:ListItem Value='1982'>1982</asp:ListItem>
                    <asp:ListItem Value='1983'>1983</asp:ListItem>
                    <asp:ListItem Value='1984'>1984</asp:ListItem>
                    <asp:ListItem Value='1985'>1985</asp:ListItem>
                    <asp:ListItem Value='1986'>1986</asp:ListItem>
                    <asp:ListItem Value='1987'>1987</asp:ListItem>
                    <asp:ListItem Value='1988'>1988</asp:ListItem>
                    <asp:ListItem Value='1989'>1989</asp:ListItem>
                    <asp:ListItem Value='1990'>1990</asp:ListItem>
                    <asp:ListItem Value='1991'>1991</asp:ListItem>
                    <asp:ListItem Value='1992'>1992</asp:ListItem>
                    <asp:ListItem Value='1993'>1993</asp:ListItem>
                    <asp:ListItem Value='1994'>1994</asp:ListItem>
                    <asp:ListItem Value='1995'>1995</asp:ListItem>
                    <asp:ListItem Value='1996'>1996</asp:ListItem>
                    <asp:ListItem Value='1997'>1997</asp:ListItem>
                    <asp:ListItem Value='1998'>1998</asp:ListItem>
                    <asp:ListItem Value='1999'>1999</asp:ListItem>
					<asp:ListItem Value='1999'>2000</asp:ListItem>
					<asp:ListItem Value='1999'>2001</asp:ListItem>
					<asp:ListItem Value='1999'>2002</asp:ListItem>
					<asp:ListItem Value='1999'>2003</asp:ListItem>
					<asp:ListItem Value='1999'>2004</asp:ListItem>
					<asp:ListItem Value='1999'>2005</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                Admission Year:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpAdmissionYear" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='YEAR'>YEAR</asp:ListItem>
                    <asp:ListItem Value='2014'>2014</asp:ListItem>
                    <asp:ListItem Value='2015'>2015</asp:ListItem>
                    <asp:ListItem Value='2016'>2016</asp:ListItem>
                    <asp:ListItem Value='2017'>2017</asp:ListItem>

                </asp:DropDownList>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                Trade:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpTrade" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">

                </asp:DropDownList>
                <br />
            </td>            
        </tr>
        <tr>
            <td style="text-align:right;">
                Semester:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpSem" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='0'>Select</asp:ListItem>
                    <asp:ListItem Value='1'>1</asp:ListItem>
                    <asp:ListItem Value='2'>2</asp:ListItem>
                    <asp:ListItem Value='3'>3</asp:ListItem>
                    <asp:ListItem Value='4'>4</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
        <tr>
            <td style="text-align:right;">
                Exam Type:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpExamType" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='0'>Select</asp:ListItem>
                    <asp:ListItem Value='Reg'>Reg</asp:ListItem>
                    <asp:ListItem Value='Ex'>Ex</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
        <tr>
            <td style="text-align:right;">
                Paper 1:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpPaper1" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='0'>Select</asp:ListItem>
                    <asp:ListItem Value='Y'>Y</asp:ListItem>
                    <asp:ListItem Value='N'>N</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
         <tr>
            <td style="text-align:right;">
                Paper 2:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpPaper2" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='0'>Select</asp:ListItem>
                    <asp:ListItem Value='Y'>Y</asp:ListItem>
                    <asp:ListItem Value='N'>N</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
         <tr>
            <td style="text-align:right;">
                Paper 3:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpPaper3" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='0'>Select</asp:ListItem>
                    <asp:ListItem Value='Y'>Y</asp:ListItem>
                    <asp:ListItem Value='N'>N</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
         <tr>
            <td style="text-align:right;">
                Paper 4:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpPaper4" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='0'>Select</asp:ListItem>
                    <asp:ListItem Value='Y'>Y</asp:ListItem>
                    <asp:ListItem Value='N'>N</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
        <tr>
            <td style="text-align:right;">
                Preference City 1:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpPrefCity1" runat="server" CssClass="form-control" Width="80px" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="ddlExamcenter_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
        <tr>
            <td style="text-align:right;">
                Preference City 2:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpPrefCity2" runat="server" CssClass="form-control" Width="80px" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="ddlExamcenter2_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
        <tr>
            <td style="text-align:right;">
                Preference City 3:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpPrefCity3" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                </asp:DropDownList>
                <br />
            </td>            
        </tr>
        <tr>
            <td style="text-align:right;">
                Current Status:
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="drpCurrentStatus" runat="server" CssClass="form-control" Width="80px" Font-Size="12px">
                    <asp:ListItem Value='0'>Select</asp:ListItem>
                    <asp:ListItem Value='Approval Pending'>Approval Pending</asp:ListItem>
                    <asp:ListItem Value='Verified'>Verified</asp:ListItem>
                    <asp:ListItem Value='Approved'>Approved</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                Amount:
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtAmount" runat="server" MaxLength="20" CssClass="form-control " placeholder="Amount" onkeypress="return CreateCAPSStringTextBox(this,event)" Style="text-transform: uppercase;"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <a target="_blank" href="../PayCash/PayOffline.aspx?Username=<%=Session["Username"]%>">Pay Offline</a>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                Transaction Date and Time:
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtTransDateTime" runat="server" MaxLength="50" CssClass="form-control " placeholder="Transaction Date and Time" onkeypress="return CreateCAPSStringTextBox(this,event)" Style="text-transform: uppercase;"></asp:TextBox>
                <br />
            </td>
            
        </tr>
        <tr>
            <td style="text-align:right;">
                Order No / Order ID:
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtPaymentRefNo" runat="server" MaxLength="50" CssClass="form-control " placeholder="PaymentReferenceNo" onkeypress="return CreateCAPSStringTextBox(this,event)" Style="text-transform: uppercase;"></asp:TextBox>
                <br />
            </td>
            
        </tr>
        <tr>
            <td colspan="2" style="height:30px;"></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit"  BackColor="cadetblue" OnClick="btnSubmit_Click"
                ForeColor="White" class="border btn btn-lg btn-primary btn-block" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back"  BackColor="cadetblue" OnClick="btnBack_Click"
                ForeColor="White" class="border btn btn-lg btn-primary btn-block" />
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

    


   

