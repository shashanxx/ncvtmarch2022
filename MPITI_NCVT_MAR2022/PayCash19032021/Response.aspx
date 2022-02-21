<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Response.aspx.cs" Inherits="BillPay_Response" %>


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


   <div class="topdiv">
  <div class="container text-right">
    <div class="dateTime"><img src="../img/icon-date.jpg" alt="" /> <span id="dateTime"></span> | <span id="timer"></span> IST | 
        <a href="http://www.aicte-india.org/" target="_blank" style="color: #FFFFFF">Contact us</a></div>
  </div>
</div>
<div class="top_banner">
  <div class="container">
    <div class="col-md-2">
      <div class="logo">  <img src="../Images/JSSCHEADER.jpg" alt="" /></div>
    </div>
    <div class="col-md-10">
       <div class="banner_text">
      <h1><strong><asp:Label ID="lblCMAT" runat ="server"  ></asp:Label> <br><asp:Label ID="lblCMAT1" runat ="server"  ></asp:Label></strong></h1>
    </div>
    </div>
  </div>
</div>
<div class="clearfix"></div>
<div class="highlights">
  <div class="container">
    <div class="col-md-2 col-sm-3 col-xs-3"><img src="../img/highlights.jpg" alt="" /></div>
  <div class="col-md-10 col-sm-9 col-xs-9" style="color: #FF6600; font-weight:bold"">
        <%--<marquee direction="left">Online Registration for CMAT 2016 Started</marquee>--%>
    </div>
  </div>
</div>
<div class="clearfix"></div>
<nav class="navbar navbar-inverse" role="navigation">
  <div class="container">
  
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"> <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>
    </div>
    <div class="navMargin">
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul id="ctl00_TopLinks_BLinks" class="nav navbar-nav navbar-left">
       
        <li class="active"><a href="../Home/ListofExam.aspx"><asp:Label ID="lblhome" runat ="server"  ></asp:Label></a></li>
        <li runat="server" visible="false"><a href="#"><asp:Label ID="lbleligibilty" runat ="server"  ></asp:Label></a></li>
        <li runat="server" visible="false"><a href="#"><asp:Label ID="lblpaymentprocess" runat ="server"  ></asp:Label></a></li>
        <li><a href="#" runat="server" visible="false"><asp:Label ID="lbltestcities" runat ="server"  ></asp:Label></a></li>
        <li><a href="#" runat="server" visible="false"><asp:Label ID="lbltestpatern" runat ="server"  ></asp:Label></a></li>
        <li class="dropdown" runat="server" visible="false"> <a href="#" class="dropdown-toggle" data-toggle = "dropdown"><asp:Label ID="lblnotification" runat ="server"  ></asp:Label><b class="caret"></b></a>
          <ul class="dropdown-menu">
              <li><a target="_blank" href="#" runat="server" visible="false"><asp:Label ID="lbladvertisement" runat ="server"  ></asp:Label></a></li>
            <li><a target="_blank" href="#" runat="server" visible="false"><asp:Label ID="lblpressrelese" runat ="server"  ></asp:Label></a></li>
            <li  runat="server" visible="false"><a href="#"><asp:Label ID="lblstategovernment" runat ="server"  ></asp:Label></a></li>
            <li  runat="server" visible="false"><a href="#"><asp:Label ID="lbluniversity" runat ="server"  ></asp:Label></a></li>
            
          </ul>
        </li>

         <li class="active"><a target="_blank" href="#"><asp:Label ID="lblPressr" runat ="server"></asp:Label></a></li>

                <li class="dropdown" style="display:none"> <a href="#" class="dropdown-toggle" data-toggle = "dropdown"><b class="caret"></b></a>
          <ul class="dropdown-menu">
              <li><a target="_blank" href="#"><asp:Label ID="lblPressEng" runat ="server"  Visible="false"></asp:Label></a></li>
            <li><a href="#" Visible="false" runat="server"><asp:Label ID="lblPressHindi" runat ="server"  ></asp:Label></a></li>
         
          </ul>
        </li>

         <li runat="server" visible="false"><a href="#"><asp:Label ID="lblpassresult" runat ="server"  ></asp:Label></a></li>
        <li runat="server" visible="false"><a href="#"><asp:Label ID="lblfaq" runat ="server"  ></asp:Label></a></li>
      </ul>
    </div>
    </div>
  </div>
</nav>
<div class="container white_bg">
  <div style="height: 15px;"> </div>
   
  <div class="col-md-9 col-sm-8 col-xs-12">
    <h3> Online Payment Response</h3><form role="form">
    <div class="panel panel-info">
      <div class="panel-heading">
        <h3 class="panel-title"> Online Payment Response</h3>
      </div>
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
                            <b><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Your Order ID</font></b></td>
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
                <asp:Button ID="btnProceed" runat="server" Text="Proceed" Visible="False" ForeColor="Black"
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
                <b><font style="color:Red;">&nbsp;&nbsp; Note : -</font> If payment is not done successfully then you will be required to Re-Login.</b>
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
</div>
 
<div class="navbar navbar-default navbar-default">
  <div class="container">
    <div class="col-md-8 col-sm-6 col-xs-12">
      <p class="navbar-text pull-left"><strong>All rights reserved (C) 2017. Attest Testing Services</strong><br />
       </p>
    </div>
    <div class="col-md-4 col-sm-6 col-xs-12">
      <div class="text-right">
       <%-- <div class="f-callus">Visitor Counts: <span class="visCount">200</span></div>--%>
      </div>
    </div>
    <!--<p class="navbar-text pull-left">All rights reserved (C) 2015. AICTE-CMAT<br />
      By accessing any information provided in this website, you implicitly agree to the <a href="#">terms and conditions</a>.</p>
    <a href="#" class="navbar-btn btn pull-right">Contact us</a>--> </div>
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
