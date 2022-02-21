<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponseOffline.aspx.cs" Inherits="BillPay_Response" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
     <meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../Css/bootstrap.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
<script src="../js/jquery-1.11.1.min.js" type="text/javascript"></script>
    <title>Response::</title>
   

    <script type="text/javascript" src="../Script_Library/jscript.js"></script>

    <script type="text/javascript" src="../Script_Library/expandcollapse.js"></script>

    <script type="text/javascript" src="../Script_Library/planner-accordian.js"></script>

    <script src="../Script_Library/JavaFuncs.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            height: 36px;
        }
        .style2
        {
            height: 20px;
        }
        .style3
        {
            height: 30px;
        }
        .style4
        {
            height: 6px;
        }
        .style5
        {
            height: 7px;
        }
    </style>

    </head>
<body style="margin: 0 0 0 0;">
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
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/iti.png" Height="75px" />
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
                <td colspan="20" style="height: 25px; text-align: center;">
                    <asp:Label ID="lblUName" runat="server" Text="" Style="margin-left: 10%; font-weight: bold;"></asp:Label>
                    <%--<asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>--%>
                </td>
            </tr>
            <tr style="background-color: #d8b377; height: 25px;">
                <td colspan="20" style="height: 25px; float: left; margin-left: 50px; margin-left: 15%; margin-right: 15%;">Payment Details
                </td>
            </tr>
        </table>


<div class="container white_bg">
  <div style="height: 15px;"> </div>
   
  <div class="col-md-9 col-sm-8 col-xs-12">
    <form role="form">
    <div class="panel panel-info">
      
      <div class="panel-body">
        
         
           
          <div class="clearfix"></div>
          <div class="row">
          <table class="registration-cont-Payment"  align="center" border="0" cellpadding="0"
        cellspacing="0" style=" font-size: 12px; color: black;
        background-attachment: scroll; background-image: url(../App_Themes/Images/pagebg1.gif);
        width: 100%; background-repeat: repeat; font-family: Verdana">
       
        <tr>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td style="padding-left:17px;">
                <table cellspacing="1" cellpadding="4" class="registration-cont-PayIndex"
                 style="border-width:2Px; width:65%;">
                    <tr>
                        <td width="40%" align="left" class="style5">
                            </td>
                        <td width="50%" align="left" class="style5">
                            </td>
                    </tr>
                    <tr>
                        <td width="40%" align="left">
                            <b><font face="Verdana, Arial, Helvetica, sans-serif" size="2" >Your Order No / Order ID</font></b></td>
                        <td width="50%" align="left">
                            :
                            <asp:Label ID="respid" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top" width="40%" align="left">
                            <b><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Response Message</font></b></td>
                        <td width="50%" align="left" valign="top">
                            :<asp:Label ID="lblInfo" runat="server"></asp:Label>&nbsp;<br />
                            &nbsp;<asp:Label ID="respmsg" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top" width="40%" align="left" class="style4">
                            </td>
                        <td width="60%" align="left" valign="top" class="style4">
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle" class="style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnProceed" runat="server" Text="Back" Visible="False" ForeColor="Black"
                    Font-Names="Verdana" OnClick="btnProceed_Click" Height="28px" 
                    BorderColor="#BF7631" BorderStyle="Solid" BorderWidth="1px"></asp:Button>&nbsp;
                <asp:Button ID="btnPlzTry" runat="server" Text="Try Again" Visible="False" ForeColor="Black"
                    Font-Names="Verdana" OnClick="btnPlzTry_Click" Height="27px" 
                    BorderColor="#BF7631" BorderStyle="Solid" BorderWidth="1px"></asp:Button></td>
        </tr>
        <tr align="center">
            <td class="style2">
                <asp:Label ID="lblError" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblNote" runat="server" ForeColor="Blue" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr align="center">
            <td>
                <asp:Label ID="respcd" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr align="center">
            <td>
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td style="height: 14px" align="left">
                <%--<b><font style="color:Red;">&nbsp;&nbsp; Note : -</font> If payment is not done successfully then you will be required to Re-Login.</b>--%>
            </td>
        </tr>
        <tr align="center">
            <td style="height: 14px">
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td style="height: 14px">
                &nbsp;</td>
        </tr>
    </table>
          </div>
          <hr />
          <div class="clearfix"></div>
          
        
          
          
          
  
          </div>
        </form>
    </div>
</div>

 

<script type='text/javascript'>

    var dat = Date();
    var res = dat.split(" ");
    var fullDate = res[0] + ' ' + res[1] + ' ' + res[2] + ' ' + res[3];
    document.getElementById("dateTime").innerHTML = fullDate;

    var myVar = setInterval(myTimer, 1000);
    function myTimer() {
        var d = new Date();
        document.getElementById("timer").innerHTML = d.toLocaleTimeString();
    }

    //<![CDATA[
    (function () {
        var quotes = $(".quotes");
        var quoteIndex = -1;

        function showNextQuote() {
            ++quoteIndex;
            quotes.eq(quoteIndex % quotes.length)
            .fadeIn(200)
            .delay(4000)
            .fadeOut(200, showNextQuote);
        }
        showNextQuote();
    })();
    //]]> 

</script> 
<script src="../js/bootstrap.min.js" type="text/javascript"></script>
</form>


</body>
</html>
