<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Principle_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
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
                color:#cc632a;
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
                    <td colspan="20" style="height: 25px; text-align:center;">
                        <asp:Label ID="lblUName" runat="server" Text="" style="margin-left:10%; font-weight:bold;" ></asp:Label>
                        <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" style="float:right; margin-right:10%;">Logout</asp:LinkButton>
                    </td>
                </tr>
        <tr style="background-color: #d8b377; height: 25px;">
            <td colspan="20" style="height: 25px; float:left; margin-left:50px; margin-left:15%; margin-right:15%;">
                    Dashboard
                    </td>
        </tr>
        </table>
        <%--<div>
            <img src="new.gif" />
            Manual Entry form (for ED and Practical Marks Entry) is available now and will be live till 22nd Sep. 2018

        </div>--%>

        <div id="userdashboard" runat="server" width="100%" style="margin-left:15%; margin-top:20px;">
        
            </div>
    </form>
</body>
</html>
