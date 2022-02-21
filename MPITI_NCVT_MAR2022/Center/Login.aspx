<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Center_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 25%; height: 90px;">
                </td>
                <td colspan="18">
                </td>
                <td style="width: 25%;">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="18">
                    <table style="width: 100%; border: 1px solid black; font-family: Verdana;" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td rowspan="12" style="width: 20%;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Left.jpg" Height="450px" />
                            </td>
                            <td style="width: 5%;">
                            </td>
                            <td style="width: 70%;">
                            </td>
                            <td style="width: 5%;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="font-size: 20px; font-weight: bold;" align="center">
                                Login
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 50px;">
                            </td>
                            <td style="color: red; font-size: 12px; vertical-align: bottom; padding-bottom: 5px;">
                                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                            </td>
                            <td>
                                Login ID
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                            </td>
                            <td>
                                <asp:TextBox ID="txtLoginID" runat="server" Text="" Width="299px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                            </td>
                            <td>
                                Password
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Text="" Width="299px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnLogin" runat="server" Text="Log In" Style="width: 125px; border-radius: 5px;
                                    background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnLogin_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                           
                                
                                <asp:LinkButton ID="lnkforgotpass" runat="server" PostBackUrl="~/Center/ForgotPassword.aspx">Forgot Password</asp:LinkButton>
                           
                                
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 100px;" cellpadding="0" cellspacing="0">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Bottom.jpg" Width="755px"
                                    Height="100px" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 90px;">
                </td>
                <td colspan="18">
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
