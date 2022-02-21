<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminStudentVerification.aspx.cs" Inherits="Admin_AdminStudentVerification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Student Status</title>
    <style>
        .ddlstyle {
            height: 25px;
        }
    </style>
    <script type="text/javascript">
        function FiltervalidationCheck() {
            if (document.getElementById("ddlDivision").value == "0") {
                alert("Please select Zone");
                document.getElementById("ddlDivision").focus();
                return false;
            }
            else if (document.getElementById("ddlDistrict").value == "0") {
                alert("Please select District");
                document.getElementById("ddlDistrict").focus();
                return false;
            }
            else if (document.getElementById("ddlITICode").value == "0") {
                alert("Please select ITI Name");
                document.getElementById("ddlITICode").focus();
                return false;
            }
            else if (document.getElementById("ddlStatus").value == "0") {
                alert("Please select Status");
                document.getElementById("ddlStatus").focus();
                return false;
            }
            else
                return true;
        }

        function GridvalidationCheck() {
            var gvDrv = document.getElementById("<%=GridView1.ClientID %>");
            var check = true;
            for (i = 0; i < gvDrv.rows.length - 1; i++) {
                if (document.getElementById('GridView1_ddlCanEligibility_' + i).value == "0") {
                    alert("Please select candidates eligibility");
                    document.getElementById('GridView1_ddlCanEligibility_' + i).focus();
                    check = false;
                    break;
                }
            }
            return check;
        }
        </script>
</head>
<body style="font-family: Arial; font-size: 16px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
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
                                <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>
                            </td>
                        </tr>
                        <tr style="background-color: #d8b377; height: 25px;">
                            <td colspan="20" style="height: 25px; text-align: left; padding-left: 15%">Update Student Status
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 10%;"></td>
                            <td colspan="14" rowspan="15">
                                <table style="width: 100%; border: none;">
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
                                                    <td colspan="10" style="font-size: 15px; font-weight: bold;"></td>
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
                                                        <asp:Label ID="lblDivision" runat="server" Text="Zone :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlDivision" runat="server" CssClass="ddlstyle" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="lblDistrict" runat="server" Text="District :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddlstyle" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
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
                                                        <asp:Label ID="lblITIName" runat="server" Text="ITI Name:"></asp:Label>

                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlITICode" runat="server" CssClass="ddlstyle" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="lblStatus" runat="server" Text="Status :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="200px" CssClass="ddlstyle">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="verified">Verified</asp:ListItem>
                                                            <asp:ListItem Value="approval pending">Approval Pending</asp:ListItem>
                                                            <asp:ListItem Value="discharged">Discharged</asp:ListItem>
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
                                                            OnClientClick="return FiltervalidationCheck();" OnClick="btnSubmit_Click" />&nbsp;
                                                        <%--<asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="GenerateReport" Visible="false" Enabled="false" />--%>
                                            &nbsp;<asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnExit_Click" />
                                                    </td>
                                                    <td>
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
                                                    <td colspan="11"></td>

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
                                                            <%--<div style="height: 250px; font-size: 12px;">--%>
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>


                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="GridView1_RowDataBound" HeaderStyle-BackColor="#cc632a" CellPadding="5">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Roll No" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <%--<asp:HiddenField ID="hdntbledited" runat="server" Value='<%# Eval("isedited") %>' />--%>
                                                                                    <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("RollNumber") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Father's Name" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFatherName" runat="server" Text='<%# Eval("FatherName") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date of Birth(DDMMYYYY)" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Choice Locked" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCLocked" runat="server" Text='<%# Eval("ChoiceLocked") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Candidate's Eligibility" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnApprovalStatus" runat="server" Value='<%# Eval("ApprovalStatus") %>'></asp:HiddenField>
                                                                                    <asp:Label ID="lblCanEligibility" runat="server" Text='<%# Eval("Eligibility") %>' Visible="false"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlCanEligibility" runat="server" Width="130px" Visible="false" CssClass="ddlstyle">
                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        <asp:ListItem Value="for non-verification">For Non-Verification</asp:ListItem>
                                                                                        <asp:ListItem Value="for verification">For Verification</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <div style="margin-top: 30px; margin-bottom:30px;">
                                                                        <asp:HiddenField ID="hdnrows" runat="server" />
                                                                        <asp:Button ID="btnGridPrevious" runat="server" Text="Previous" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;" OnClick="btnGridPrevious_Click" Visible="false" />
                                                                        <asp:Button ID="btnGridNext" runat="server" Text="Save & Next" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnGridNext_Click" Visible="false" /><%-- OnClientClick="return GridvalidationCheck();"--%>
                                                                        <asp:Button ID="btnNext" runat="server" Text="Next" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnNext_Click" Visible="false" />
                                                                        <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Visible="false" /><%--OnClientClick="return GridvalidationCheck();"--%>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <%--</div>--%>
                                                        </td>
                                                        <td>&nbsp; </td>
                                                    </tr>
                                                </tr>

                                            </table>
                                        </td>
                                        <td style="width: 5%;"></td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="3" style="width: 10%;"></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
