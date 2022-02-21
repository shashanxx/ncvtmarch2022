<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
    <script type="text/javascript">
        function ValidationCheck() {
            if (document.getElementById("txtOldPassword").value == "") {
                alert("PLEASE ENTER OLD PASSWORD");
                document.getElementById("txtOldPassword").focus();
                return false;
            }
            if (document.getElementById("txtNewPassword").value == "") {
                alert("PLEASE ENTER NEW PASSWORD");
                document.getElementById("txtNewPassword").focus();
                return false;
            }
            if (document.getElementById("txtCNewPassword").value == "") {
                alert("PLEASE ENTER CONFIRM PASSWORD");
                document.getElementById("txtCNewPassword").focus();
                return false;
            }
            if (document.getElementById("txtNewPassword").value != document.getElementById("txtCNewPassword").value) {
                alert('NEW PASSWORD AND CONFIRM PASSWORD DO NOT MATCH');
                document.getElementById("txtCNewPassword").focus();
                return false;
            }
            if (document.getElementById("txtNewPassword").value == document.getElementById("txtOldPassword").value) {
                alert('OLD PASSWORD AND NEW PASSWORD CAN NOT BE SAME');
                document.getElementById("txtNewPassword").focus();
                return false;
            }
        }
            </script>
</head>
<body>
    <form id="form1" runat="server">
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
                <td colspan="20" style="height: 25px; float: left; margin-left: 50px; margin-left: 15%; margin-right: 15%;">Change Password
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <div width="100%" style="margin-top: 20px;">
            <table style="width: 100%; border: 1px solid grey; font-size: 14px; border-radius: 8px;" cellpadding="10" cellspacing="0">
                <tr>
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight:bold;">User Name</td>
                    <td style="width: 50%; float:left;"><asp:Label ID="lblUserName" runat="server" Style="font-weight: 700"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight:bold;"><span style="color: red;">*&nbsp;</span>Old Password</td>
                    <td style="width: 50%;"><asp:TextBox ID="txtOldPassword" runat="server" Width="150px" Height="20px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight:bold;"><span style="color: red;">*&nbsp;</span>New Password</td>
                    <td style="width: 50%;"><asp:TextBox ID="txtNewPassword" runat="server" Width="150px" Height="20px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight:bold;"><span style="color: red;">*&nbsp;</span>Confirm Password</td>
                    <td style="width: 50%;"><asp:TextBox ID="txtCNewPassword" runat="server" Width="150px" Height="20px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight:bold;"></td>
                    <td style="width: 50%;"><asp:Label ID="lblCMessage" runat="server" Text="" style="font-weight:bold; color:green;"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div style="margin-top: 0px; margin-bottom:50px; text-align:center;">
                            <asp:Button ID="btnSubmit" runat="server" Text="Change Password" Style="width: 180px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;" OnClick="btnSubmit_Click" OnClientClick="return ValidationCheck();" />
                            <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Exit" />
        </div>
                    </td>
                </tr>
            </table>
        </div>
            </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>