<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="HelpDesk_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>::MPITI:: </title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 10%;
            height: 26px;
        }
        .style2
        {
            width: 7%;
        }
        .style3
        {
            width: 9%;
        }
        .style5
        {
            width: 7%;
            height: 26px;
        }
        .style6
        {
            width: 9%;
            height: 26px;
        }
        .style7
        {
            width: 2%;
        }
        .style8
        {
            width: 2%;
            height: 26px;
        }
        .style9
        {
            width: 7%;
            height: 6px;
        }
        .style10
        {
            width: 9%;
            height: 6px;
        }
        .style11
        {
            width: 2%;
            height: 6px;
        }
        .style12
        {
            width: 100%;
        }
    </style>

    <script language ="javascript" type="text/javascript">
        function CheckValidations() {

            var Client1 = document.getElementById('chk1');
            var Client2 = document.getElementById('chk2');
            var Client3 = document.getElementById('chk3');

            var Id = document.getElementById('txtLoginId');
            var Pwd = document.getElementById('txtPassword');

            if (Client1.checked == false && Client2.checked == false && Client3.checked == false) {
                alert("**  Please Select any client !!");return false;
            }
            
            if (Id.value == "" && Pwd.value == "") {
                alert("** Please Input your Login Id & Password  !");Id.focus(); return false;
            }

            if (Id.value == "") {
                alert("** Please Input your Login Id  !"); Id.focus(); return false;
            }

            if (Pwd.value == "") {
                alert("**  Please Input your Password  !"); Pwd.focus(); return false;
            }
        }

        function Check1() {
            
            if (Client1.checked == true) {
                Client2.checked = false;
                Client3.checked = false;

            }

        }

        function Check2() {
            
            if (Client2.checked == true) {
                Client1.checked = false;
                Client3.checked = false;
            }

        }

        function Check3() {
            
            if (Client3.checked == true) {
                Client2.checked == false;
                Client1.checked == false;
                alert("** Your selection is invalid ! ");
            }

        }
    </script>
</head>
<body>
<br /><br /><br /><br /><br /><br /><br />
<table align="center" style="width: 745px">
<tr align="right">
<td style="color:Black;">
<%--Today's Date :- 18th April 2013--%>
<script type="text/javascript">
    var todayDate = new Date();
    var date = todayDate.getDate();
    var month = todayDate.getMonth() + 1;
    var year = todayDate.getFullYear();
    var hours = todayDate.getHours();
    var minutes = todayDate.getMinutes();
    var seconds = todayDate.getSeconds();
    //document.writeln(todayDate);
    //document.writeln(todayDate);
    document.writeln("Todays Date :- " + date + " - " + month + " - " + year); 
     </script>
</td>
</tr>
</table>
<br />
<div id="wrapper">
  <h1><a href=""><img src="images/logo.gif" height="47"  /></a></h1>
  <table style="width: 528px">
  <tr>
  <td style="width: 7%">
  </td>
  <td class="style2">
      &nbsp;</td>
  <td style="width: 7%">
  </td>
  <td class="style3">
      &nbsp;</td>
  <td style="width: 7%">
  </td>
  <td style="width: 7%">
      &nbsp;</td>
  <td class="style7">
      &nbsp;</td>
  <td style="width: 7%">
  </td>
  <td style="width: 7%">
  </td>
  <td style="width: 7%">
  </td>
  <td class="style7">
  </td>
  <td style="width: 7%">
  </td>
  <td style="width: 7%">
  </td>

  <td class="style3">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  </tr>
  <tr>
  <td class="style1" style="width: 7%">
  </td>
  <td class="style5">
      &nbsp;</td>
  <td class="style1" style="width: 7%">
  </td>
  <td class="style6">
      &nbsp;</td>
  <td class="style1" style="width: 7%">
  </td>
  <td class="style1" style="width: 7%">
      &nbsp;</td>
  <td class="style8">
      &nbsp;</td>
  <td class="style1" style="width: 7%">
  </td>
  <td class="style1" style="width: 7%">
  </td>
  <td class="style1" style="width: 7%">
  </td>
  <td class="style8">
  </td>
  <td class="style1" style="width: 7%">
  </td>
  <td class="style1" style="width: 7%">
  </td>

  <td class="style6">
      &nbsp;</td>

  <td class="style1" style="width: 7%">
      &nbsp;</td>

  <td class="style1" style="width: 7%">
      &nbsp;</td>

  <td class="style1" style="width: 7%">
      &nbsp;</td>

  <td class="style1" style="width: 7%">
      &nbsp;</td>

  <td class="style1" style="width: 7%">
      &nbsp;</td>

  <td class="style1" style="width: 7%">
      &nbsp;</td>

  </tr>
  <tr runat="server" visible="false">
  <td style="width: 7%">
      &nbsp;</td>
  <td class="style2">
      &nbsp;</td>
  <td style="width: 7%">
      &nbsp;</td>
  <td class="style3">
      &nbsp;</td>
  <td style="width: 7%">
      &nbsp;</td>
  <td style="width: 7%">
      &nbsp;</td>
  <td class="style7">
      &nbsp;</td>
  <td style="width: 7%">
      &nbsp;</td>
  <td style="width: 7%">
      &nbsp;</td>
  <td style="width: 7%">
      &nbsp;</td>
  <td class="style7">
      &nbsp;</td>
  <td style="width: 7%">
      &nbsp;</td>
  <td style="width: 7%">
      &nbsp;</td>

  <td class="style3">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  <td style="width: 7%">
      &nbsp;</td>

  </tr>
  <tr runat="server" visible="false">
  <td colspan="2" align="center">
      DASH BOARD</td>
  <td colspan="2" align="center">
      ADD COLLEGE</td>
  <td colspan="3" align="center">
      EDIT COLLEGE</td>
  <td colspan="4" align="center">
      ADD/EDIT EXAM DATE</td>
  <td align="center" colspan="3">
      GET SCHEDULED DATA</td>
  <td align="center" colspan="6">
      LOG OUT</td>

  </tr>
  <tr runat="server" visible="false">
  <td class="style9">
      </td>
  <td class="style9">
      </td>
  <td class="style9">
      </td>
  <td class="style10">
      </td>
  <td class="style9">
      </td>
  <td class="style9">
      </td>
  <td class="style11">
      </td>
  <td class="style9">
      </td>
  <td class="style9">
      </td>
  <td class="style9">
      </td>
  <td class="style11">
      </td>
  <td class="style9">
      </td>
  <td class="style9">
      </td>

  <td class="style10">
      </td>

  <td class="style9">
      </td>

  <td class="style9">
      </td>

  <td class="style9">
      </td>

  <td class="style9">
      </td>

  <td class="style9">
      </td>

  <td class="style9">
      </td>

  </tr>
  </table>
  <div id="booking">
    <h2 style="height:33px; "><br />
        <font style="color:White;font-weight:bold; font-family:Arial; font-size:15px; text-transform:capitalize;">MPITI Login </font></h2>
      <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
      <div class="jtype" align="left">
      <%--  <label for="Cmat">CMAT</label>--%>

        <%--<label for="Gpat">GPAT</label>&nbsp;--%>

       <%-- <label for="Others">Others</label>&nbsp;--%>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
          <table cellpadding="0" cellspacing="0" class="style12">
              <tr>
                  <td style="display:none;">
                      
                      <asp:CheckBox ID="chk1" runat="server" AutoPostBack="true" 
                          onchange="return Check1();" oncheckedchanged="chk1_CheckedChanged" 
                          Text="JCECEB" visible="true"/>
                      <asp:CheckBox ID="chk2" runat="server" AutoPostBack="true" 
                          onchange="return Check2();" oncheckedchanged="chk2_CheckedChanged" 
                          Text="TECHNICAL" visible="False"/>
                      <asp:CheckBox ID="chk3" runat="server" AutoPostBack="true" 
                          onChange="return Check3();" oncheckedchanged="chk3_CheckedChanged" 
                          Text="TECHNICIAN" Visible="False" />
                  </td>
              </tr>
          </table>
          </ContentTemplate>
         </asp:UpdatePanel>
      </div>
      <!-- end .jtype -->
      <table summary="" cellspacing="0" cellpadding="0" border="0" 
          style="width: 225px">
        <tr>
          <th colspan="2" style="color:White;font-family:Arial; font-size:12px; font-weight:bold;">Login Id&nbsp;
              </th>
        </tr>
        <tr>
          <th colspan="2">
              <asp:TextBox ID="txtLoginId" runat="server" BorderStyle="None" Height="18px" 
                  Width="145px"></asp:TextBox>
            </th>
        </tr>
        <tr>
          <th colspan="2" style="color:White; font-family:Arial; font-size:12px; font-weight:bold;">Password</th>
        </tr>
        <tr>
          <th colspan="2">
              <asp:TextBox ID="txtPassword" runat="server" BorderStyle="None" Height="18px" 
                  Width="145px" MaxLength="12" TextMode="Password"></asp:TextBox>
              <asp:Button ID="btnSubmit" runat="server" 
                  OnClientClick="return CheckValidations();" Text="Submit" CssClass="submit" 
                  Height="20px" onclick="btnSubmit_Click" />
            </th>
        </tr>
        <tr>
          <th>&nbsp;</th>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <th>&nbsp;</th>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <th>&nbsp;</th>
          <td>&nbsp;
              &nbsp;
              </td>
        </tr>
      </table>
      </form>
  </div>
  <!-- end booking -->
  <!-- end nav -->
  <!-- end packages -->
   
  <div id="main"> <img src="images/people.jpg" 
          alt="two people having a walk" class="block" />
          <br />
    <%--<h2><img src="images/title_hottest_locations.gif" height="24"
            alt="hottest locations" /></h2>--%>
  </div>
 
  <!-- end main -->
  <div id="footer"> &copy; Copyright MPITI Booking Window</div>
  <!-- end footer -->
</div>
<!-- end wrapper -->
</body>
</html>
