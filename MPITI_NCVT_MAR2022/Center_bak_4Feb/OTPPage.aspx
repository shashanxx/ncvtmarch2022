<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OTPPage.aspx.cs" Inherits="Center_OTPPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" language="javascript" src="../js/newPortal_validations.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

         <table style="width: 100%; background-color: #d8b377">
             <tr>
                            <td colspan="9" style="background-color: #cc632a; height: 15px;"></td>
                        </tr>
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
                            <td colspan="9" style="background-color: #cc632a; height: 15px;"></td>
                        </tr>
             </table>
      <table id="tbOTP" style="width: 100%; font-family: Verdana; background-image: url('../images/back.jpg');"
                        cellpadding="0" cellspacing="0" visible="true">
          <tr>
                    <td>

                        &nbsp;&nbsp;</td>
              </tr>
          <tr style="align-content :center">
                    <td style="align-content:center">

                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

                        <br style="text-align: center" />

                        <br />

                        </td>
              </tr>
                <tr style="align-items:center">
                    <td>
                        Enter OTP : <asp:TextBox ID="txtOTP" runat="server"></asp:TextBox>
                    &nbsp;
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Resend OTP</asp:LinkButton>
                        <br />
                        <br />
                    </td>

                </tr>
                 <tr style="align-items:center">
                    <td>
                        <br />
                        <asp:Button ID="btnOTPSubmit" runat="server" Text="Submit" OnClick="btnOTPSubmit_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" />

                         <br />

                         </td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
