<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Center_ChangePassword" %>

<!DOCTYPE html>

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
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ChangePassword.jpg" Height="450px" />
                            </td>
                            <td style="width: 35%;">
                            </td>
                            <td style="width: 40%;">
                            </td>
                            <td style="width: 5%;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="font-size: 20px; font-weight: bold;" align="left">
                                Change Password
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                            </td>
                            <td style="color: red; font-size: 12px; vertical-align: bottom; padding-bottom: 5px;">
                                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                                Old Password</td>
                            <td>
                                <asp:TextBox ID="txtoldpass" runat="server" Text="" Width="299px" TextMode="Password" MaxLength="18"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                                New
                                Password</td>
                            <td>
                                <asp:TextBox ID="txtnewPassword" runat="server" TextMode="Password" Text="" Width="299px" onkeypress="return CreateAlphaNumericTextControl(this,event)" MaxLength="8"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                                Password Recovery Question</td>
                            <td>
                                <asp:DropDownList ID="ddlpassque" Width="299px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                              
                            </td>
                            <td>
                              
                            </td>
                            <td>
                                
                            </td>
                        </tr>      <tr>
                            <td style="height: 20px;">
                                Answer</td>
                            <td>
                                <asp:TextBox ID="txtans" runat="server" TextMode="Password" Text="" Width="299px" onkeypress="return CreateAlphaNumericTextControl(this,event)" MaxLength="30"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td style="vertical-align:top;">
                               
                                <asp:Button ID="btnchangepass" runat="server" Text="Change" Style="width: 125px; border-radius: 5px;
                                    background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnLogin_Click" />
                                &nbsp;<asp:Button ID="btnlogout" runat="server" Text="Logout" Style="width: 125px; border-radius: 5px;
                                    background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnlogout_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                                </td>
                            <td>
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

