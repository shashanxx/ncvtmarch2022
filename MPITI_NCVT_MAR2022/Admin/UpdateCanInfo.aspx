<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateCanInfo.aspx.cs" Inherits="Admin_UpdateCanInfo" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Candidate Info</title>
    <style type="text/css">
        @charset "utf-8";
        /* CSS Document */

        @import url(http://fonts.googleapis.com/css?family=Lato:300,400,700);

        @font-face {
            font-family: 'fontawesome';
            src: url('../fonts/fontawesome.eot');
            src: url('../fonts/fontawesome.eot?#iefix') format('embedded-opentype'), url('../fonts/fontawesome.svg#fontawesome') format('svg'), url('../fonts/fontawesome.woff') format('woff'), url('../fonts/fontawesome.ttf') format('truetype');
            font-weight: normal;
            font-style: normal;
        }

        .icon_center_div {
            width: 100%;
            height: 550px;
            margin-left: auto;
            margin-right: auto;
            padding: 10px;
        }

        .icon_box {
            text-decoration: none;
            width: 305px;
            height: 137px;
            float: left;
            padding-left: 5px;
            padding-right: 5px;
            border: #fff solid 1px;
            display: block;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -khtml-border-radius: 5px;
            border-radius: 5px;
            font-family: 'Lato', Calibri, Arial, sans-serif;
            margin-top: 5px;
        }


            .icon_box:hover {
                border-color: #cc632a;
                background-color: #d8b3778f;
            }

            .icon_box h1 {
                text-decoration: none;
                width: 240px;
                font-size: 16px;
                color: #d1383e;
                font-family: 'Lato', Calibri, Arial, sans-serif;
                text-align: left;
                margin: 0px;
                padding: 0px;
                line-height: 35px;
            }

                .icon_box h1 a {
                    color: #cc632a;
                }

            .icon_box p {
                text-decoration: none;
                font-size: 13px;
                font-weight: 400;
                color: #626262;
                font-family: 'Lato', Calibri, Arial, sans-serif;
                width: 240px;
                margin-left: 0 px;
            }

        .alink {
            text-decoration: none;
        }

        .div_img_style {
            float: left;
            margin-right: 5px;
            width: 55px;
            vertical-align: top;
        }

        .imgstyle {
            float: left;
            margin-top: 12px;
            margin-right: 5px;
            border: 0px;
        }

        .data {
            width: 100px;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%; font-family: Arial; background-image: url('../images/back.jpg');"
            cellpadding="0" cellspacing="0">

            <tr>
                <td colspan="2" style="background-color: #d8b377; height: 80px;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 45px; width: 14%;"></td>
                            <td colspan="3" style="width: 25%;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/iti.png" Height="75px" />
                            </td>
                            <td style="width: 22%;"></td>
                            <td colspan="3" style="width: 25%;" align="center"></td>
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
                <td colspan="2" style="height: 25px; text-align: center;">
                    <asp:Label ID="lblUName" runat="server" Text="" Style="margin-left: 10%; font-weight: bold;"></asp:Label>
                    <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>
                </td>
            </tr>
            <tr style="background-color: #d8b377; height: 25px;">
                <td colspan="2" style="height: 25px; text-align: center;">Search Candidate
                </td>
            </tr>
            <tr style="width: 50%">
                <td style="height: 30px" colspan="2"></td>
            </tr>
            <tr style="text-align: left; width: 50%;">
                <td></td>
                <td>Enter Roll Number :
                    <asp:TextBox ID="txtSearch" runat="server" Width="250px"  MaxLength="20"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="return validate();"
                        OnClick="btnSearch_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" />
                </td>
            </tr>
            <tr  style="width:100%">
                <td colspan="2" style="width:100%">
                    <br />
                    <br />
                    <div style="overflow-y: scroll; height:200px;width:1400px;">
                        <asp:GridView ID="gvData" AutoGenerateColumns="false" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" DataKeyNames="Id"
                            OnRowDataBound="gvData_RowDataBound" OnRowEditing="gvData_RowEditing" OnRowUpdating="gvData_RowUpdating" OnRowCancelingEdit="gvData_RowCancelingEdit"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="3500px">
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                            <Columns>
                                <asp:CommandField ButtonType="Link" ShowEditButton="true" ItemStyle-Width="150">
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:CommandField>


                                <asp:TemplateField HeaderText="Roll Number" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNumber" runat="server" Text='<%# Eval("RollNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRollNumber" Enabled="false" runat="server" Text='<%# Eval("RollNumber") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" ItemStyle-Width="500">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Father Name" ItemStyle-Width="350">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFatherName" runat="server" Text='<%# Eval("FatherName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtFatherName" runat="server" Text='<%# Eval("FatherName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mother Name" ItemStyle-Width="350">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMotherName" runat="server" Text='<%# Eval("MotherName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMotherName" runat="server" Text='<%# Eval("MotherName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DOB" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <ajaxToolkit:ToolkitScriptManager ID="toolkit1" runat="server" CombineScripts="false"></ajaxToolkit:ToolkitScriptManager>
                                        <asp:TextBox ID="txtDOB" runat="server" Font-Size="18px" Text='<%# Eval("DOB") %>' Width="120px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                            TargetControlID="txtDOB" PopupButtonID="image1">
                                        </ajaxToolkit:CalendarExtender>

                                        <asp:Image ID="image1" runat="server" AlternateText="" ImageUrl="Cal.png" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlGender" runat="server" Text='<%# Eval("Gender") %>'>
                                            <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                            <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category" ItemStyle-Width="350">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlCategory" runat="server" Text='<%# Eval("Category") %>'>
                                            <asp:ListItem Value="General" Text="General"></asp:ListItem>
                                            <asp:ListItem Value="Other Backward Class" Text="Other Backward Class"></asp:ListItem>
                                            <asp:ListItem Value="Schedule Castes" Text="Schedule Castes"></asp:ListItem>
                                            <asp:ListItem Value="Schedule Tribes" Text="Schedule Tribes"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TTI Type" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTTIType" runat="server" Text='<%# Eval("TTIType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTTIType" runat="server" Text='<%# Eval("TTIType") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ITI Code" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblITICode" runat="server" Text='<%# Eval("ITICode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                         <asp:Label ID="lblITICode" runat="server" Text='<%# Eval("ITICode") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ITI Name" ItemStyle-Width="550">
                                    <ItemTemplate>
                                        <asp:Label ID="lblITIName" runat="server" Text='<%# Eval("ITIName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtITIName" runat="server" Text='<%# Eval("ITIName") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exists Zone" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExistsZone" runat="server" Text='<%# Eval("ExistsZone") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtExistsZone" runat="server" Text='<%# Eval("ExistsZone") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exists District" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExistsDistrict" runat="server" Text='<%# Eval("ExistsDistrict") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtExistsDistrict" runat="server" Text='<%# Eval("ExistsDistrict") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Division" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("Division") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("Division") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="District" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Eligibility" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEligibility" runat="server" Text='<%# Eval("Eligibility") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEligibility" runat="server" Text='<%# Eval("Eligibility") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Admission Year" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdmissionYear" runat="server" Text='<%# Eval("AdmissionYear") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                         <asp:Label ID="lblAdmissionYear" runat="server" Text='<%# Eval("AdmissionYear") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trade" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrade" runat="server" Text='<%# Eval("Trade") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                       <asp:Label ID="lblTrade" runat="server" Text='<%# Eval("Trade") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Verification Date" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVerificationDate" runat="server" Text='<%# Eval("VerificationDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtVerificationDate" Enabled="false" runat="server" Text='<%# Eval("VerificationDate") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Verified By" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVerifiedBy" runat="server" Text='<%# Eval("VerifiedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtVerifiedBy" Enabled="false" runat="server" Text='<%# Eval("VerifiedBy") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approval Status" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprovalStatus" runat="server" Text='<%# Eval("ApprovalStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtApprovalStatus" Enabled="false" runat="server" Text='<%# Eval("ApprovalStatus") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <br />
                        <br />
                        <asp:GridView ID="gvDataDiff" AutoGenerateColumns="false" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" DataKeyNames="Id" Visible="false"
                            OnRowDataBound="gvDataDiff_RowDataBound" OnRowEditing="gvData_RowEditing" OnRowUpdating="gvDataDiff_RowUpdating" OnRowCancelingEdit="gvData_RowCancelingEdit"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="1300px">
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                            <Columns>
                                <asp:CommandField ButtonType="Link" ShowEditButton="true" ItemStyle-Width="150">
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="Semester" ItemStyle-Width="70">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSemester" runat="server" Text='<%# Eval("Semester") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlSemester" runat="server" Text='<%# Eval("Semester") %>' Enabled="false" Width="70px">
                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exam Type" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExamType" runat="server" Text='<%# Eval("ExamType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlExamType" runat="server" Text='<%# Eval("ExamType") %>' Width="70px">
                                            <asp:ListItem Value="Ex" Text="Ex"></asp:ListItem>
                                            <asp:ListItem Value="REG" Text="REG"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Before Paper 1" ItemStyle-Width="120">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeforePaper1" runat="server" Text='<%# Eval("chkPaper1") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlBeforePaper1" runat="server" Text='<%# Eval("chkPaper1") %>' Width="70px">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Before Paper 2" ItemStyle-Width="120">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeforePaper2" runat="server" Text='<%# Eval("chkPaper2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlBeforePaper2" runat="server" Text='<%# Eval("chkPaper2") %>' Width="70px">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Before Paper 3" ItemStyle-Width="120">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeforePaper3" runat="server" Text='<%# Eval("chkPaper3") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlBeforePaper3" runat="server" Text='<%# Eval("chkPaper3") %>' Width="70px">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Before Paper 4" ItemStyle-Width="120">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeforePaper4" runat="server" Text='<%# Eval("chkPractical") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlBeforePaper4" runat="server" Text='<%# Eval("chkPractical") %>' Width="70px">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="After Paper 1" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaper1" runat="server" Text='<%# Eval("Paper1") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPaper1" runat="server" Text='<%# Eval("Paper1") %>' Enabled="false">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="After Paper 2" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaper2" runat="server" Text='<%# Eval("Paper2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPaper2" runat="server" Text='<%# Eval("Paper2") %>' Enabled="false">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="After Paper 3" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaper3" runat="server" Text='<%# Eval("Paper3") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPaper3" runat="server" Text='<%# Eval("Paper3") %>' Enabled="false">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="After Practical" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPractical" runat="server" Text='<%# Eval("Practical") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPractical" runat="server" Text='<%# Eval("Practical") %>' Enabled="false">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>

        </table>

        <script type="text/javascript">
            function onlyNumbersWithDot(evt) {
                var e = event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;

                if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;

                return true;

            }

            function validate() {
                var txtSearch = document.getElementById("txtSearch");
                if (txtSearch.value == '') {
                    txtSearch.focus();
                    alert('Please enter Roll Number.')
                    return false;
                }
                return true;
            }

        </script>
    </form>
</body>
</html>
