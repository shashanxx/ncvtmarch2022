<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamCenter.aspx.cs" Inherits="Center_ExamCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<script type="text/javascript" src="..js/date_time.js"></script>--%>
    <script type="text/javascript" language="javascript" src="../js/newPortal_validations.js"></script>
    <link href="../Styles/Site.css" rel="stylesheet" />
    <script type="text/javascript" src="../Styles/epoch_classes.js"></script>
    <link href="../Styles/epoch_styles.css" type="text/css" rel="stylesheet" />
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
    <script type="text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
    </script>
    <script type="text/javascript">
        window.onload = function () {

            if (document.getElementById('txtdob') != null) {
                dp_cal1 = new Epoch('epoch_popup', 'popup', document.getElementById('txtdob'));
            }

            if (document.getElementById('txtDomicileDate') != null) {

                dp_cal2 = new Epoch('epoch_popup', 'popup', document.getElementById('txtDomicileDate'));
            }
            if (document.getElementById('txtnoncrimNoDate') != null) {
                dp_cal3 = new Epoch('epoch_popup', 'popup', document.getElementById('txtnoncrimNoDate'));
            }

            if (document.getElementById('txtlicensefromdate') != null) {
                dp_cal4 = new Epoch('epoch_popup', 'popup', document.getElementById('txtlicensefromdate'));
            }

            if (document.getElementById('txtlicensetodate') != null) {
                dp_cal5 = new Epoch('epoch_popup', 'popup', document.getElementById('txtlicensetodate'));
            }

            //onEligibleStatusChange();

            //OnDomicileCheckChange();

            if (document.getElementById('tbldtls') != null) {
                OnDomicilePropertiesCheck();

                CheckFileUpload();
                //MarriedStatusCheckChange();

                //FunChkTwins(); //well try
            }

        }
        //onPostStatus();

        try { history.go(1); } catch (e) { }







    </script>
    <script type="text/javascript">
        function FormatIt(obj) {

            if (obj.value.length == 2) // Day

                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month

                obj.value = obj.value + "/";


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
                    <td colspan="20" style="background-color: #cc632a; height: 25px;" align="right">

                        <!--Menu code start-->
                        <nav>
                                    <ul class="nav">
                                        <li><a href="ExamCenter.aspx">Add OMR</a></li>
                                  <li><a href="EditExamCenter.aspx">Update OMR</a></li>
                                          <%-- <li><a href="Regclosed.aspx">Update OMR</a></li>--%>
                                       
                                        <li><a href="#">Reports</a>
                                            <ul>
                                              <li><a href="ExamCenterReport.aspx">Report1</a></li>
                                       <%--          <li><a href="#">Report1</a></li>--%>
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
                                            <td colspan="10" style="font-size: 15px; font-weight: bold;">Add OMR / Practical Marks
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
                                                <span style="color: red;">*&nbsp;</span>
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
                                        <tr id="tr1" runat="server" visible="false">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="height: 25px;">
                                                <asp:Label ID="lblPaper" runat="server" Text="Paper :"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlPaper" runat="server" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2"></td>
                                            <td></td>
                                            <td></td>
                                            <td colspan="2"></td>
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
                                        <tr id="tr2" runat="server" visible="false">
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="10">
                                                <hr style="color: brown;" />
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trInt" runat="server" visible="false">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="height: 25px;">
                                                <asp:Label ID="lbliname" runat="server" Text="Internal Name"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtIntName" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                            <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblExName" runat="server" Text="External Name"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtExName" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr id="trIntAdd" runat="server" visible="false">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="height: 25px;">
                                                <asp:Label ID="lbliadd0" runat="server" Text="Address"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtIntAdd" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                            <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblexadd" runat="server" Text="Address"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtExAdd" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr id="trIntPost" runat="server" visible="false">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="height: 25px;">
                                                <asp:Label ID="lbliPost" runat="server" Text="Post"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtIntPost" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                            <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblExPost" runat="server" Text="Post"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtExPost" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr id="trexamdate" runat="server" visible="false">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="height: 25px;">
                                                <asp:Label ID="Label1" runat="server" Text="Exam Date"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <%--<asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>--%>
                                                <input name="txtdob" runat="server" type="text" maxlength="10" id="txtdob"
                                                    oncopy="return false" oncut="return false" onpaste="return false"
                                                    style="border: thin solid #000080; width: 200px; font-family: Verdana, Geneva, Tahoma, sans-serif;"
                                                    title="Date" onkeydown="return false" />
                                            </td>
                                            <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td colspan="2">&nbsp;</td>
                                            <td></td>
                                        </tr>
                                        <tr id="trInt2" runat="server" visible="false">
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
                                                        <%--<asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="GenerateReport" Visible="false" Enabled="false" />--%>
                                            &nbsp;<asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                OnClick="btnExit_Click" />
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="HiddenFieldLoginId" runat="server" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td align="center" colspan="7">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td colspan="11">
                                                <table width="100%">
                                                </table>


                                            </td>

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
                                                <td>&nbsp; </td>
                                                <td colspan="10">
                                                    <div style="height: 250px; overflow-y: scroll; font-size: 12px;">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>


                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound" Width="100%">
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
                                                                        <asp:BoundField DataField="RollNo" HeaderStyle-Width="12%" HeaderText="Roll No.">
                                                                            <HeaderStyle Width="12%" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Session" HeaderStyle-Width="10%" HeaderText="Session" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderStyle Width="10%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="TraineeName" HeaderStyle-Width="10%" HeaderText="Trainee Name" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderStyle Width="10%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ITIName" HeaderStyle-Width="25%" HeaderText="ITI Name">
                                                                            <HeaderStyle Width="25%" />
                                                                        </asp:BoundField>
                                                                        <%--<asp:BoundField HeaderText="Trade Code" DataField="TradeCode" HeaderStyle-Width="12%" />--%>
                                                                        <asp:BoundField DataField="TradeName" HeaderStyle-Width="22%" HeaderText="Trade Name">
                                                                            <HeaderStyle Width="22%" />
                                                                        </asp:BoundField>

                                                                        <asp:TemplateField HeaderStyle-Width="12%" HeaderText="Trade Code" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txttradecode" runat="server" MaxLength="3" onkeypress="return CreateNumericTextControl(this,event)"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-Width="8%" HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>

                                                                                        <asp:DropDownList ID="ddlpresentabsent" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpresentabsent_SelectedIndexChanged">
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
                                                                        <asp:TemplateField HeaderStyle-Width="28%" HeaderText="Enter OMR Answer Sheet No / Practical Marks" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtOMRCode" runat="server" AutoPostBack="True" MaxLength="8" oncopy="return false" oncut="return false" onkeypress="return CreateAlphaNumericTextControl(this,event)" onpaste="return false" OnTextChanged="txtOMRCode_TextChanged" Style="text-transform: uppercase;" Visible="false" Width="130px" Enabled="false"></asp:TextBox>
                                                                                <asp:TextBox ID="txtPracticalMarks" runat="server" Enabled="false" MaxLength="3" oncopy="return false" oncut="return false" onkeypress="return CreateNumericTextControl(this,event)" onpaste="return false" Visible="false" Width="90px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="28%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date of Exam(dd/mm/yyyy)" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="12%">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtDOExam" runat="server" MaxLength="10" oncut="false" Enabled="false" onkeyup="FormatIt(this);"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Session (Morning/Evening)" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>

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
                                                                                <asp:Label ID="lblTraineeID" runat="server" Text='<%# Bind("TraineeID") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </td>
                                                <td>&nbsp; </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp; </td>
                                                <td style="height: 50px;" colspan="10" align="right">
                                                    <asp:HiddenField ID="hdnExaminerId" runat="server" />
                                                    <asp:HiddenField ID="hdnAlert" runat="server" />
                                                    &nbsp; &nbsp;
                                                            
                                                           <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Save" Visible="false" />&nbsp;
                                                            <asp:Button ID="btnPrint" runat="server" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Print" Visible="false" Enabled="false" OnClick="btnPrint_Click" />

                                                    <%-- OnClientClick="SetTarget();"  --%>
                                                </td>
                                                <td>&nbsp; </td>
                                            </tr>
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
                                <td>
                                    
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
                    <td colspan="14"></td>
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
                <ProgressTemplate>
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
                </ProgressTemplate>
            </asp:UpdateProgress>
            <%--      </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </form>
</body>
</html>
