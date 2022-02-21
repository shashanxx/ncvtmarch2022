<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WPM.aspx.cs" Inherits="Principle_Marksheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WPM</title>
    <script type="text/javascript">
        function PrintDiv() {
            document.getElementById("lnkPrint").style.display = 'none';
            document.getElementById("LinkButton1").style.display = 'none';

            var divToPrint = document.getElementById('edit');
            var popupWin = window.print('AdmitCard.aspx', '_blank', 'width=1000px,height=500px,location=no,left=200px');
        }

    </script>
    <style type="text/css" media="print">
        @media print {
            body {
                -webkit-print-color-adjust: exact;
                margin-left: 10px;
                margin-right: 10px;
                margin-top: 10px;
                margin-bottom: 10px;
                zoom: 80%;
            }
        }

        @page {
            size: A4 portrait;
            /*margin-left: 0px;
    margin-right: 0px;
    margin-top: 0px;
    margin-bottom: 0px;
    margin: 0;
    -webkit-print-color-adjust: exact;
    zoom:74;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="PrintDiv" style="width: 95%; margin: 0px auto; font-family: Verdana; font-size: 13px; line-height: 13px; padding: 10px 20px 10px 20px;">            
            <table align="center" style="width: 95%; background: url(watermark.png); background-repeat: no-repeat; background-position: center center;padding-top:30px;font-size:15px;">
                <tr>
                    <td colspan="2" style="font-size: 35px; text-align: center; color: darkblue; font-weight: bold; line-height: 35px;font-family:Times New Roman;">STATE BOARD OF EXAMINATION
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 20px; text-align: center; color: darkblue; line-height: 20px;font-family:Times New Roman;padding-top:5px;">State Council of Vocational Training MadhyaPradesh
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;padding-top:10px;">
                        <img width='100px' height='100px' src="wpmLogo.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height:25px;"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left;">
                        <asp:Label runat="server" ID="lbl1" style="font-weight:bold;" Text="अनुक्रमांक - "> </asp:Label>
                        <asp:Label runat="server" ID="lblmarksheetNoSteno" Text="">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height:25px;"></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 30px; text-align: center; font-weight: bold; line-height: 30px;text-decoration:underline;">प्रमाण-पत्र
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height:45px;"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left;padding-top:10px;">
                        <asp:Label runat="server" ID="Label9"  Text="प्रमाणित किया जाता है की श्री/कुमारी/श्रीमती "> </asp:Label>
                        <asp:Label runat="server" ID="lblNameSteno" style="font-weight:bold;" Text="">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left;padding-top:30px;">
                        <asp:Label runat="server" ID="Label10"  Text="आत्मज/आत्मजा/पति श्री "> </asp:Label>
                        <asp:Label runat="server" ID="lblFatherNameSteno" style="font-weight:bold;" Text="">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left;padding-top:30px;">
                        <asp:Label runat="server" ID="Label15"  Text="रोल नंबर "> </asp:Label>
                        <asp:Label runat="server" ID="lblRollNoSteno" style="font-weight:bold;" Text="">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left;padding-top:30px;width:35%;">
                        <asp:Label runat="server" ID="Label14"  Text="संस्था "> </asp:Label>
                        <asp:Label runat="server" ID="lblItiNameSteno" style="font-weight:bold;" Text=""></asp:Label>
                    </td>
                    <td style="text-align: left;padding-top:30px;width:35%;">
                        <asp:Label runat="server" ID="Label17"  Text="जिला- "> </asp:Label>
                        <asp:Label runat="server" ID="lblDistrictSteno" style="font-weight:bold;" Text=""></asp:Label>
                        <asp:Label runat="server" ID="Label16"  Text=" द्वारा "> </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left;padding-top:30px;">
                        <asp:Label runat="server" ID="Label18"  Text="अखिल भारतीय/राज्य व्यवसायिक परीक्षा  "> </asp:Label>
                        <asp:Label runat="server" ID="Label19" style="font-weight:bold;" Text="JAN-2021">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left;padding-top:30px;">
                        <asp:Label runat="server" ID="Label20"  Text="में शीघ्रलेखन हिंदी/अंग्रेजी की परीक्षा १०० शब्द प्रति मिनट की गति से "> </asp:Label>
                        <asp:Label runat="server" ID="Label21" style="font-weight:bold;" Text="उत्तीर्ण ">
                        </asp:Label>
                        <asp:Label runat="server" ID="Label22"  Text="की एवं उसके उपलक्ष्य में यह प्रमाण-पत्र प्रदान किया जाता है ।"> </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right;padding-top:40px;">
                        
                        <table width="100%">
                            <tr>
                                <td style="width:30%;"></td>
                                <td style="width:40%;">                                    
                                </td>
                                <td style="width:30%;text-align:center;"><asp:PlaceHolder ID="plBarCodeSteno" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right;padding-top:40px;">
                        <table width="100%">
                            <tr>
                                <td style="width:35%;text-align:center;font-weight:bold;">Signature of Principal of ITI<br />with seal</td>
                                <td style="width:35%;text-align:center;">
                                    <table align="center" width="60%">
                                        <tr>
                                            <td style="text-align:center;border:1px solid #000;height:30px;">checked by</td>
                                            
                                        </tr>
                                        <tr><td style="height:50px;border:1px solid #000;"></td></tr>
                                    </table>
                                    <br />
                                    (Signature Certificate holder)
                                </td>
                                <td style="width:30%;text-align:center;font-weight:bold;"><img width='200px' height='70px' src="../images/signature.jpg" /><br />Secretary<br />State Board of Examination<br />Madhya Pradesh</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;padding-top:20px;font-weight:bold;">Print Date & Time :
                        <asp:Label ID="lblDateSteno" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div style="text-align: center; width: 95%;">
                <asp:LinkButton ID="lnkPrint" runat="server" Text="Print" OnClientClick="PrintDiv();" CssClass="lblengfont"></asp:LinkButton>
                &nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Close" OnClientClick="javascript:window.close();" CssClass="lblengfont"></asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
