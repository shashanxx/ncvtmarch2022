<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ITIPendingPayment.aspx.cs" Inherits="Principle_ITIPendingPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdateProgress ID="uprgsMaster" runat="server" DisplayAfter="1" DynamicLayout="false">
                <ProgressTemplate>
                    <div id="divprogress" align="center" style="width: 100%; height: 100%; min-height: 100%; position: fixed; z-index: 100002; top: 0px; left: 0px; background-color: Gray; filter: alpha(opacity=80); opacity: 0.8; z-index: 10000;">
                        <img id="Img1" alt="Wait" style="opacity: 1; margin-top: 250px;" runat="server" src="~/images/loader_transparent.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
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
                            <td colspan="20" style="height: 25px; text-align: center; font-weight: bold; padding-left: 15%">ITI Pending Amount
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 10%;"></td>
                            <td colspan="11" style="background-color: #fae2bb; width: 80%; height: 100px;">
                                <br />
                                <table style="background-color: #fae2bb; width: 100%">
                                    <tr style="text-align: center;">
                                        <td>August -September 2018 Pending Amount:
                                            <asp:Label ID="lblFinalAmount" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
                                            
                                        </td>
                                    </tr>
                                    <tr style="text-align: center;">
                                        <td>
                                            <br />
                                            <asp:Button ID="btnDetails" runat="server" Text="View Candidate Details" OnClick="btnDetails_Click" Style="width: 250px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnPayOnline" runat="server" Text="PAY ONLINE" OnClick="btnPayOnline_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" />
                                            &nbsp;&nbsp;&nbsp;

                                            <asp:Button ID="btnPayDD" Visible="false" runat="server" Text="PAY DD" OnClick="btnPayDD_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>


                            </td>

                            <td colspan="3" style="width: 10%;"></td>

                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>    
        <asp:PostBackTrigger ControlID="btnDetails" />
        </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
