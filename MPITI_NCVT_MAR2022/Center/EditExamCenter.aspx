<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditExamCenter.aspx.cs" Inherits="Center_EditExamCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <title></title>
    <%--<script type="text/javascript" src="..js/date_time.js"></script>--%>
    <script type="text/javascript" language="javascript" src="../js/newPortal_validations.js"></script>
    <link href="../Styles/Site.css" rel="stylesheet" />
    <style type="text/css">
        .hideGridColumn {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function myconfirmbox() {
            if (confirm("Are You Sure, want to do this ?")) {
                document.getElementById("hdnAlert").value = "1";
            }
            else {
                document.getElementById("hdnAlert").value = "2";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <table style="width: 100%; font-family: Verdana; background-image: url('../images/back.jpg');"
                        cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="20" style="background-color: #cc632a; height: 5px;"></td>
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
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Aptech.png" Height="70px"
                                                Width="200px" />
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
                        <tr>
                            <td colspan="20" style="background-color: #cc632a; height: 15px;">

                                <!--Menu code start-->
                                <nav>
                                    <ul class="nav">
                                        <li><a href="ExamCenter.aspx">Add OMR</a></li>
                                        <li><a href="EditExamCenter.aspx">Update OMR</a></li>
                                        <li><a href="#">Reports</a>
                                            <ul>
                                                    <li><a href="ExamCenterReport.aspx">Report1</a></li>
                                               <li><a href="CenterwiseCountReport.aspx">Report2</a></li>
                                            </ul>
                                        </li>
                                         <li><a href="CorrectOMRs.aspx">Update Paper Detail</a></li>
                                          <li><asp:Button ID="btnchangepass" runat="server" Text="Change Password" OnClick="btnchangepass_Click" BackColor="#776655" ForeColor="White" Font-Bold="True" Height="30px" /></li>
                                                       <li><asp:Button ID="btnlogout" runat="server" Text="Logout"  BackColor="#776655" ForeColor="White" Font-Bold="True" Height="30px" OnClick="btnlogout_Click" /></li>
                                    </ul>
                                </nav>
                                <!--Menu code end-->

                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 10%;"></td>
                            <td colspan="14" rowspan="15">
                                <table style="width: 100%; border: 1px solid grey;">
                                    <tr>
                                        <td colspan="12"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 5%;"></td>
                                        <td colspan="10" rowspan="13">
                                            <table style="width: 100%; border: 1px solid grey; font-size: 14px; border-radius: 8px;"
                                                cellpadding="0" cellspacing="0">
                                                <tr style="background-color: #d8b377; height: 25px;">
                                                    <td style="width: 5%;"></td>
                                                    <td colspan="10" style="font-size: 15px; font-weight: bold;">Update OMR / Practical Marks
                                                    </td>
                                                    <td style="width: 5%;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5%; height: 18px;">&nbsp;
                                                    </td>
                                                    <td colspan="10">&nbsp;
                                                    </td>
                                                    <td style="width: 5%;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 25px;">
                                                        <asp:Label ID="lblSession" runat="server" Text="Session :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="8">
                                                        <asp:DropDownList ID="ddlSession" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <hr style="color: brown;" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 25px;">
                                                        <asp:Label ID="lblNameOfITI" runat="server" Text="Name of ITI :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlNameofITI" runat="server" Width="200px" OnSelectedIndexChanged="ddlNameofITI_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="lblSemester" runat="server" Text="Semester :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlSemester" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <hr style="color: brown;" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 25px;">
                                                        <asp:Label ID="lblTradeName" runat="server" Text="Trade Name :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlTradeName" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <%--<span style="color: red;">*&nbsp;</span>--%>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="lblEntryType" runat="server" Text="Entry Type :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlEntryType" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlEntryType_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select entry type" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="OMR Answer Sheet No" Value="O"></asp:ListItem>
                                                            <asp:ListItem Text="Practical Marks" Value="P"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 5%;"></td>
                                                </tr>
                                                <tr id="trDurationSlot" runat="server" visible="false">
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <hr style="color: brown;" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <hr style="color: brown;" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="tr1" runat="server">
                                                    <td style="vertical-align: middle; text-align: right;"  id="redstar" runat="server">
                                                        <%--<span style="color: red;">*&nbsp;</span>--%>
                                                    </td>
                                                    <td style="height: 25px;">
                                                        <asp:Label ID="lblPaper" runat="server" Text="Paper :"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlPaper" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRollNo" runat="server" Text="Roll No. :"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtRollNo" AutoPostBack="true" runat="server" Width="195px" onkeypress="return CreateNumericTextControl(this,event)" OnTextChanged="txtRollNo_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                
                                                <tr id="trDurationSlot1" runat="server" visible="false">
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="height: 25px;">
                                                        <asp:Label ID="lblDuration" runat="server" Text="Duration :"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlDuration" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSlot" runat="server" Text="Slot :"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlSlot" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr id="tr2" runat="server" visible="true">
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <hr style="color: brown;" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="height: 18px;">&nbsp;
                                                    </td>
                                                    <td></td>
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
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td colspan="7" align="center">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Search" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                            OnClick="btnSubmit_Click" />&nbsp;
                                            <asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                OnClick="btnExit_Click" />
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="4" style="height: 25px; color: red; vertical-align: middle;">
                                                        <asp:Label ID="lblCMessage" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <div style="height: 250px; overflow-y: scroll; font-size:12px;">
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="OnRowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-Width="3%">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="checkAll" runat="server" AutoPostBack="true" OnCheckedChanged="checkAll_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="checkCan" runat="server" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="3%" />
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField HeaderText="Sr.No" DataField="Row" />--%>
                                                                    <asp:BoundField HeaderText="Roll No." DataField="RollNo" HeaderStyle-Width="12%">
                                                                        <HeaderStyle Width="12%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Session" DataField="Session" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderStyle Width="10%" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="ITI Name" DataField="ITIName" HeaderStyle-Width="25%">
                                                                        <HeaderStyle Width="25%" />
                                                                    </asp:BoundField>
                                                                        <asp:BoundField HeaderText="Trainee Name" DataField="traineename" HeaderStyle-Width="20%">
                                                                        <HeaderStyle Width="20%" />
                                                                    </asp:BoundField>
                                                                    <%--<asp:BoundField HeaderText="Trade Code" DataField="TradeCode" HeaderStyle-Width="12%" />--%>
                                                                    <asp:BoundField HeaderText="Trade Name" DataField="TradeName" HeaderStyle-Width="22%">
                                                                        <HeaderStyle Width="22%" />
                                                                    </asp:BoundField>
                                                                           <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Trade Code" ItemStyle-HorizontalAlign="Center">
                                                                                       <ItemTemplate>
                                                                                           <asp:TextBox ID="txttradecode" runat="server" MaxLength="3" onkeypress="return CreateNumericTextControl(this,event)"  Text='<%# Bind("Tradecode1") %>'></asp:TextBox>
                                                                                       </ItemTemplate>
                                                                                   </asp:TemplateField>
                                                                    
                                                                        <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Present/Absent" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>
                                                                                      <asp:Label ID="lblpresentabsent" Text='<%# Bind("PresentAbsent") %>' runat="server" Visible="false"></asp:Label>
                                                                                <asp:DropDownList ID="ddlpresentabsent" runat="server" AutoPostBack="true">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Present" Value="P"></asp:ListItem>
                                                                                    <asp:ListItem Text="Absent" Value="A"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Enter OMR Answer Sheet No" HeaderStyle-Width="28%" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtOMRCode" Text='<%# Bind("OMRMarks") %>' runat="server" MaxLength="8" Width="130px" AutoPostBack="True" oncopy="return false" oncut="return false" onpaste="return false" onkeypress="return CreateAlphaNumericTextControl(this,event)" OnTextChanged="txtOMRCode_TextChanged" Style="text-transform: uppercase;" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="txtPracticalMarks" Text='<%# Bind("OMRMarks") %>' runat="server" MaxLength="3" Width="90px" oncopy="return false" oncut="return false" onpaste="return false" onkeypress="return CreateNumericTextControl(this,event)" Visible="false"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="28%" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date of Exam(dd/mm/yyyy)" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="12%">          
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtDOExam" runat="server" MaxLength="10" oncut="false" Enabled="true" onkeyup = "FormatIt(this);" Text='<%# Bind("DateOfExam") %>'></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Session (Morning/Evening)" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>
                                                                                 <asp:Label ID="lblsessionme" Text='<%# Bind("Sessionme") %>' runat="server" Visible="false"></asp:Label>
                                                                                <asp:DropDownList ID="ddlsessionme" runat="server">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Morning" Value="M"></asp:ListItem>
                                                                                    <asp:ListItem Text="Evening" Value="E"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                 
                                                                    <%--<asp:TemplateField HeaderText="Enter Practical Marks" HeaderStyle-Width="21%" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtPracticalMarks" runat="server" MaxLength="3" Width="90px" oncopy="return false" oncut="return false" onpaste="return false" onkeypress="return CreateNumericTextControl(this,event)"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="22%" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>--%>
                                                                    <%--<asp:BoundField HeaderText="Trainee ID" DataField="TraineeID" HeaderStyle-Width="1%" ItemStyle-CssClass="hideGridColumn" />--%>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTraineeID" Text='<%# Bind("TraineeID") %>' runat="server" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                           <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblexaminerid" Text='<%# Bind("ExaminerId") %>' runat="server" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="GridView2_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-Width="3%">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="checkAll" runat="server" AutoPostBack="true" OnCheckedChanged="checkAll_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="checkCan" runat="server" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="3%" />
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField HeaderText="Sr.No" DataField="Row" />--%>
                                                                    <asp:BoundField HeaderText="Roll No." DataField="RollNo" HeaderStyle-Width="12%">
                                                                        <HeaderStyle Width="12%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Session" DataField="Session" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderStyle Width="10%" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="ITI Name" DataField="ITIName" HeaderStyle-Width="25%">
                                                                        <HeaderStyle Width="25%" />
                                                                    </asp:BoundField>
                                                                         <asp:BoundField HeaderText="Trainee Name" DataField="traineename" HeaderStyle-Width="20%">
                                                                        <HeaderStyle Width="20%" />
                                                                    </asp:BoundField>
                                                                    <%--<asp:BoundField HeaderText="Trade Code" DataField="TradeCode" HeaderStyle-Width="12%" />--%>
                                                                    <asp:BoundField HeaderText="Trade Name" DataField="TradeName" HeaderStyle-Width="22%">
                                                                        <HeaderStyle Width="22%" />
                                                                    </asp:BoundField>
                                                                           
                                                                    
                                                                        <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Present/Absent" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>
                                                                                      <asp:Label ID="lblpresentabsent1" Text='<%# Bind("PresentAbsent") %>' runat="server" Visible="false"></asp:Label>
                                                                                <asp:DropDownList ID="ddlpresentabsent1" runat="server" AutoPostBack="true">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Present" Value="P"></asp:ListItem>
                                                                                    <asp:ListItem Text="Absent" Value="A"></asp:ListItem>
                                                                                    <asp:ListItem Text="Left out" Value="L"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Practical Marks" HeaderStyle-Width="28%" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtOMRCode" Text='<%# Bind("OMRMarks") %>' runat="server" MaxLength="8" Width="130px" AutoPostBack="True" oncopy="return false" oncut="return false" onpaste="return false" onkeypress="return CreateAlphaNumericTextControl(this,event)" OnTextChanged="txtOMRCode_TextChanged" Style="text-transform: uppercase;" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="txtPracticalMarks" Text='<%# Bind("OMRMarks") %>' runat="server" MaxLength="3" Width="90px" oncopy="return false" oncut="return false" onpaste="return false" onkeypress="return CreateNumericTextControl(this,event)" Visible="false"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="28%" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                        
                                                                    <%--<asp:TemplateField HeaderText="Enter Practical Marks" HeaderStyle-Width="21%" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtPracticalMarks" runat="server" MaxLength="3" Width="90px" oncopy="return false" oncut="return false" onpaste="return false" onkeypress="return CreateNumericTextControl(this,event)"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="22%" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>--%>
                                                                    <%--<asp:BoundField HeaderText="Trainee ID" DataField="TraineeID" HeaderStyle-Width="1%" ItemStyle-CssClass="hideGridColumn" />--%>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTraineeID" Text='<%# Bind("TraineeID") %>' runat="server" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                           <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblexaminerid" Text='<%# Bind("ExaminerId") %>' runat="server" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td style="height: 50px;">&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="7" align="right">
                                                        
                                                        <asp:HiddenField ID="hdnAlert" runat="server" />
                                                        &nbsp; &nbsp;
                                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Update" Visible="false" />
                                                        &nbsp;
                                                        <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Print" Visible="false" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 5%;"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
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
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="3" style="width: 10%;"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
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
                            <td></td>
                            <td></td>
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
                            <td></td>
                            <td></td>
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
              <%--  </ContentTemplate>                
            </asp:UpdatePanel>--%>
        </div>
    </form>
</body>
</html>
