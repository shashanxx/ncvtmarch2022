<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DD_Approval.aspx.cs" Inherits="JD_DD_Approval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DD Approval</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../js/newPortal_validations.js"></script>
    <script type="text/javascript">
        function alertMsg() {
            if (confirm('Are you sure you want to approve this DD?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
    </style>

</head>
<body style="background-color: #e6e6e6; font-family: Arial; font-size: 16px; padding: 8px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                    <td colspan="20" style="height: 25px; text-align: center;">
                        <asp:Label ID="lblUName" runat="server" Text="" Style="margin-left: 10%; font-weight: bolder; color: black; font-size: 16px;"></asp:Label>
                        <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>

                    </td>
                </tr>

            </table>

            <table id="tbNonOTP" style="width: 100%; font-family: Verdana; background-image: url('../images/back.jpg');"
                cellpadding="0" cellspacing="0">

                <tr>
                    <td colspan="3" style="width: 15%;"></td>
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
                                        <tr style="background-color: #d8b377; height: 30px;">
                                            <td style="width: 5%;"></td>
                                            <td colspan="10" style="font-size: 15px; font-weight: bold;">DD Approval
                                            </td>
                                            <td style="width: 5%;"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 5%; height: 20px;">&nbsp;
                                            </td>
                                            <td colspan="10">&nbsp;
                                            </td>
                                            <td style="width: 5%;">&nbsp;
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
                                        <tr>
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 30px;">
                                                <asp:Label ID="Label1" runat="server" Text="District :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddldistrict" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%;">
                                                <asp:Label ID="lblNameOfITI" runat="server" Text="Name of ITI :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="2" style="width: 27%;">
                                                <asp:DropDownList ID="ddlNameofITI" runat="server" Width="200px">
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
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="10">
                                                <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>

                                        <tr>

                                            <td colspan="12" align="center">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Search" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                    OnClick="btnSubmit_Click" />&nbsp;
                                            <asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                OnClick="btnExit_Click" />
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td colspan="4" style="height: 35px; color: red; vertical-align: middle;">
                                                <asp:Label ID="lblCMessage" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="10">
                                                <div style="max-height: 1000px; overflow-y: scroll; font-size: 12px;">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="GridView1_RowDataBound" DataKeyNames= "PID">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="PID" DataField="PID" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="DD Number" DataField="TID" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Amount" DataField="TotalAmount" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Bank Name" DataField="BankName" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Issuing Branch" DataField="IssuingBranch" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="DD Date" DataField="DDDate" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Principle Name" DataField="PrinicipalName" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Principle Mobile No." DataField="PrincipalMobileNo" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:TemplateField HeaderText="View DD" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <div>
                                                                            <a href='<%# Eval("[ddpath]") %>' target="_blank">View DD</a>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View DD Details" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <div>
                                                                            <a href="DD_Details.aspx?pid=<%# Eval("[PID]") %>&itiCode=<%# Eval("[ITICode]") %>" target="_blank">View DD Details</a>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Approval Status" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("[ApprovedbyJD]") %>' style="display:none;"></asp:Label>
                                                                    <div>
                                                                        <asp:Button ID="btnApprove" runat="server" Text="Approve" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnApprove_Click" OnClientClick="return alertMsg();" />
                                                                        <asp:Label ID="lblStatustxt" runat="server" Text='Approved'></asp:Label>
                                                                    </div>                                                                    
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
                                            <td colspan="12" align="right">
                                                <br />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td style="height: 50px;"></td>
                                            <td>&nbsp;
                                            </td>
                                            <td></td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="4">&nbsp; &nbsp; &nbsp;
                                                        
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
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
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
                    <td colspan="3" style="width: 15%;"></td>
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
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </form>
</body>
</html>
