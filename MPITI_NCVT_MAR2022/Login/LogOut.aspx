<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogOut.aspx.cs" Inherits="Principle_LogOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 30%;
        }
    </style>
</head>
<body style="font-family:Arial; font-size:16px;">
    <form id="form1" runat="server">
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
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/iti.png" Height="75px" />
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
                    <td colspan="20" style="height: 25px; text-align:center;">
                        
                    </td>
                </tr>
        <tr style="background-color: #d8b377; height: 25px;">
            <td colspan="20" style="height: 25px; float:left; margin-left:50px; margin-left:15%; margin-right:15%;">
                    
                    </td>
        </tr>
        </table>
    <div width="100%" style="margin-left:15%; margin-right:15%; margin-top:20px; text-align:center;">
        You have been successfully Logged Out
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Login Again</asp:LinkButton>
            </div>
    </form>
</body>
</html>
