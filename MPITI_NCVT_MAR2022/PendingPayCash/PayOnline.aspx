<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="PayOnline.aspx.cs" Inherits="PayOnline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Details</title>
    <style>
        .ddlstyle {
            height: 25px;
            border: 1px solid grey;
        }
    </style>
    <script type="text/javascript">
        function ValidationCheck() {
            //if (document.getElementById("ddlCardType").value == "0") {
            //    alert("PLEASE CHOOSE CARD TYPE");
            //    document.getElementById("ddlCardType").focus();
            //    return false;
            //}
            //if(document.getElementById('lblamountvalue').innerText=="" || document.getElementById('lblamountvalue').innerText=="0")
            //{
            //    alert("YOUR AMOUNT IS ZERO. PLEASE SUBMIT FORM AGAIN");
            //    document.getElementById("lblamountvalue").focus();
            //    return false;
            //}
        }
    </script>
</head>
<body style="font-family: Arial; font-size: 16px;">
    <form id="nonseamless" method="post" action="ccavRequestHandler.aspx">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
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
            <%--<tr style="background-color: #cc632a; height: 25px;">
                <td colspan="20" style="height: 25px; text-align: center;">
                    <asp:Label ID="lblUName" runat="server" Text="" Style="margin-left: 10%; font-weight: bold;"></asp:Label>
                    <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>
                </td>
            </tr>--%>
            <tr style="background-color: #d8b377; height: 25px;">
                <td colspan="20" style="height: 25px; float: left; margin-left: 50px; margin-left: 15%; margin-right: 15%;">Payment Details
                </td>
            </tr>
        </table>
        <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>--%>
        <div width="100%" style="margin-top: 20px;">
            <table style="width: 100%; border: 1px solid grey; font-size: 18px; border-radius: 8px;" cellpadding="10" cellspacing="0">
                <tr>
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight: bold;">ORDER NO.</td>
                    <td style="width: 50%; float: left;">
                        <asp:Label ID="lblordernoTextvalue" runat="server" Style="font-weight: 700"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight: bold;">ACTUAL FEE</td>
                    <td style="width: 50%;">
                        <asp:Label ID="lblActualFeeValue" runat="server" Style="font-weight: 700"></asp:Label>&nbsp;&nbsp<span style="color: blue">+ Bank charges applicable *</span></td>
                </tr>
                <tr style="display: none;">
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight: bold;">BANK CHARGES</td>
                    <td style="width: 50%;">
                        <asp:Label ID="lblBankChargesValue" runat="server" Style="font-weight: 700"></asp:Label></td>
                </tr>
                <tr style="display: none;">
                    <td style="width: 30%;"></td>
                    <td style="width: 20%; text-align: left; font-weight: bold;">TOTAL</td>
                    <td style="width: 50%;">
                        <asp:Label ID="lblamountvalue" runat="server" Style="font-weight: 700"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div style="margin-top: 0px; margin-bottom: 50px; text-align: center;">
                            <%-- <asp:Button ID="btnProceed" runat="server" Text="Pay Online" Style="width: 180px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;" OnClick="btnProceed_Click" OnClientClick="return ValidationCheck();" />
                                    <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Exit" />
                                    <%--<input type="submit" name="btnContinue" value="Pay Online" id="btnContinue" onclick="return ValidationCheck();" style="width: 230px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;" />--%>

                            <input type="submit" visible="false" name="btnContinue" style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" value="Pay Online" id="btnContinue" /><br />
                            <input type="hidden" name="merchant_id" id="merchant_id" runat="server" value="" />
                            <input type="hidden" name="order_id" id="order_id" runat="server" value="" />
                            <input type="hidden" name="amount" id="amount" runat="server" value="" />
                            <input type="hidden" name="currency" id="currency" runat="server" value="" />
                            <input type="hidden" name="redirect_url" id="redirect_url" runat="server" value="" />
                            <input type="hidden" name="cancel_url" id="cancel_url" runat="server" value="" />
                            <input type="hidden" name="hfCId" id="hfCId" runat="server" value="" />
                            <input type="hidden" name="payment_option" id="payment_option" runat="server" value="" />
                            <%--<input type="hidden" name="hfCId" id="Hidden1" runat="server" value="" />--%>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <%--  </ContentTemplate>
          <%--  <Triggers>
                <asp:PostBackTrigger ControlID="btnProceed" />
            </Triggers>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>


