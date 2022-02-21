<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JDReports.aspx.cs" Inherits="Center_JDReports" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <link href="../Styles/Site.css" rel="stylesheet" />
        <script type="text/javascript" language="javascript" src="../js/newPortal_validations.js"></script>
    <title></title>
      <script language="javascript" type="text/javascript">
          function isNumberKey(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 64 || charCode > 91) && (charCode < 96 || charCode > 122)) {
                  alert("Enter a valid percentage otherwise put 'RA' !!");

                  return false;
              }

              return true;
          }

          function onlyNumbersWithDot(evt) {
              var e = event || evt; // for trans-browser compatibility
              var charCode = e.which || e.keyCode;
              if (charCode == 46)
                  return true
              if (charCode > 31 && (charCode < 48 || charCode > 57))
                  return false;
              return true;
          }
         </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
    <table style="width: 100%; font-family: Verdana; background-image: url('../images/back.jpg');"
            cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="20" style="background-color: #cc632a; height: 15px;">
                </td>
            </tr>
            <tr>
                <td colspan="20" style="background-color: #d8b377; height: 80px;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 45px; width: 14%;">
                            </td>
                            <td colspan="3" style="width: 25%;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/iti.png" Height="75px" />
                            </td>
                            <td style="width: 22%;">
                            </td>
                            <td colspan="3" style="width: 25%;" align="center">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Aptech.png" Height="70px"
                                    Width="200px" />
                            </td>
                            <td style="width: 14%;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <span id="date_time" style="color: white;"></span>
                                <script type="text/javascript">    window.onload = date_time('date_time');</script>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
               
                    <td colspan="20" style="background-color: #cc632a; height: 25px;" align="right">

                                <!--Menu code start-->
                                <nav>
                                    <ul class="nav">
                                    <li><a href="Joindirector.aspx">Entry Form</a></li>
                                        <li><a href="UpdateJoinDirectorMarks.aspx">Edit Form</a></li>
                                        <li><a href="#">Reports</a>
                                            <ul>
                                           <li><a href="JDReports.aspx">Report1</a></li>
                                               <li><a href="DirectorwiseCountReport.aspx">Report2</a></li>
                                            </ul>
                                        </li>
                                          <li><asp:Button ID="btnchangepass" runat="server" Text="Change Password" OnClick="btnchangepass_Click" BackColor="#776655" ForeColor="White" Font-Bold="True" Height="30px" /></li>
                                                       <li><asp:Button ID="btnlogout" runat="server" Text="Logout"  BackColor="#776655" ForeColor="White" Font-Bold="True" Height="30px" OnClick="btnlogout_Click" /></li>
                                    </ul>
                                </nav>
                                <!--Menu code end-->

                            </td>
                
            </tr>
            <tr>
                <td colspan="3" style="width: 15%;">
                </td>
                <td colspan="14" rowspan="15">
                    <table style="width: 100%; border: 1px solid grey;">
                        <tr>
                            <td colspan="12">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5%;">
                            </td>
                            <td colspan="10" rowspan="13">
                                <table style="width: 100%; border: 1px solid grey; font-size: 14px; border-radius: 8px;"
                                    cellpadding="0" cellspacing="0">
                                    <tr style="background-color: #d8b377; height: 30px;">
                                        <td style="width: 5%;">
                                        </td>
                                        <td colspan="10" style="font-size: 15px; font-weight: bold;">
                                       Join Director Reports
                                        </td>
                                        <td style="width: 5%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 5%; height: 20px;">
                                            &nbsp;
                                        </td>
                                        <td colspan="10">
                                            &nbsp;
                                        </td>
                                        <td style="width: 5%;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%; height: 30px;">
                                            <asp:Label ID="lblSession" runat="server" Text="Session :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;">
                                        </td>
                                        <td colspan="8">
                                            <asp:DropDownList ID="ddlSession" runat="server" Width="200px" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                     <tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%; height: 30px;">
                                            <asp:Label ID="Label2" runat="server" Text="District :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;">
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddldistrict" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                                 <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="Label3" runat="server" Text="Entry Type :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlentrytype" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlentrytype_SelectedIndexChanged">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="ED" Text="Engg Drawing"></asp:ListItem>
                                                            <asp:ListItem Value="TT" Text="Steno Practical Marks"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%; height: 30px;">
                                            <asp:Label ID="lblNameOfITI" runat="server" Text="Name of ITI :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;">
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlNameofITI" runat="server" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%;">
                                            <asp:Label ID="lblSemester" runat="server" Text="Semester :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;">
                                        </td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlSemester" runat="server" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%; height: 30px;">
                                            <asp:Label ID="lblTradeName" runat="server" Text="Trade Name :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;">
                                        </td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlTradeName" runat="server" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                <%--        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%;">
                                            <asp:Label ID="lblPaper" runat="server" Text="Paper :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;">
                                        </td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlPaper" runat="server" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 5%;">
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <span style="color: red;">&nbsp;</span>
                                        </td>
                                        <td style="width: 15%; height: 30px;">
                                            <asp:Label ID="Label1" runat="server" Text="Search by Roll No"></asp:Label>
                                        </td>
                                        <td style="width: 2%;">
                                        </td>
                                        <td colspan="8">
                                      
                                            <asp:TextBox ID="txtrollno" runat="server" Width="200px" OnTextChanged="txtrollno_TextChanged" AutoPostBack="True"  onkeypress="return CreateNumericTextControl(this,event)"></asp:TextBox>
                                      
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="height: 30px;">
                                            <asp:Label ID="lblDuration" runat="server" Text="Duration :"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlDuration" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSlot" runat="server" Text="Slot :"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlSlot" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                                <%--    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                     <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                        </td>
                                        <td style="height: 20px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td colspan="7" align="center">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Search" Style="width: 125px; border-radius: 5px;
                                                background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnSubmit_Click" />&nbsp;
                                            <asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px;
                                                background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnExit_Click" />
                                           
                                        </td>
                                        <td> <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:HiddenField ID="hiddenloginid" runat="server" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="4" style="height: 35px; color: red; vertical-align: middle;">
                                            <asp:Label ID="lblCMessage" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="10" style="text-align:center" >
                                            <div style="height: 180px; overflow-y: scroll; font-size:12px; text-align:center">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="80%">
                                                <Columns>
                                                      <asp:TemplateField HeaderText="Sr.No" ItemStyle-HorizontalAlign="Center">
                                                            
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                                                 <%--   <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="checkAll" runat="server" AutoPostBack="true" OnCheckedChanged="checkAll_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="checkCan" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                             <%--        <asp:TemplateField HeaderText="Sr.No">
                                               <ItemTemplate>
                                                   <%#Container.DisplayIndex+1 %>
                                                   <itemstyle width="30px" />
                                               </ItemTemplate>
                                               <ItemStyle BorderWidth="1px"  Font-Size="Small" ForeColor="#400000"
                                                   Width="30px" />
                                               <HeaderStyle BorderWidth="1px" />
                                           </asp:TemplateField>--%>
                                                   <%-- <asp:BoundField HeaderText="Sr.No" DataField="Row" />--%>
                                                    <asp:BoundField HeaderText="Roll No" DataField="RollNo" ItemStyle-HorizontalAlign="Center" />
                                                <%--    <asp:BoundField HeaderText="ITI Name" DataField="ITIName" />
                                                    <asp:BoundField HeaderText="Trade Code" DataField="TradeCode" />
                                                    <asp:BoundField HeaderText="Trade Name" DataField="TradeName" />--%>
                                                    <asp:TemplateField HeaderText="Enter Marks" HeaderStyle-Width="240px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtpractmarks" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblID" Text='<%# Bind("Id") %>' runat="server" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                     <%-- <asp:TemplateField HeaderText="Enter ED Marks" HeaderStyle-Width="240px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtedmarks" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                            </div>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="height: 50px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                            </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="text-align:right">
                                           
                                            <asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Print" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 5%;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                            </td>
                            <td class="auto-style1">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="3" style="width: 15%;">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <progresstemplate>
                            <table>
                                <tr>
                                    <td align="center">
                                        <div id="Background" align="center"></div>
                                        <div id="Progress" align="center">
                                            <img src="../loader.gif" style="vertical-align: middle" />
                                            Fetching Records Please Wait...
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </progresstemplate>
                    </asp:UpdateProgress>
               <%--     </ContentTemplate>
                </asp:UpdatePanel>--%>
    </div>
    </form>
</body>
</html>
