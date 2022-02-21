<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmitCardPrac.aspx.cs" Inherits="Principle_AdmitCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Admit Card</title>
    <script type="text/javascript">
        function PrintDiv() {
            document.getElementById("lnkPrint").style.display = 'none';
            document.getElementById("LinkButton1").style.display = 'none';

            var divToPrint = document.getElementById('edit');
            var popupWin = window.print('AdmitCard.aspx', '_blank', 'width=1000px,height=500px,location=no,left=200px');
        }

    </script>
    <style type="text/css">
        @font-face {
            font-family: kruti dev;
            src: url( './fonts/Kruti_Dev.ttf' ) format("truetype");
        }
        /*.hinditext {
    font-family: kruti dev;  
    font-size:18px;
}*/
        .lblengfont {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="PrintDiv" style="width: 750px; margin: 0px auto; font-size: 18px; line-height: 18px; border: 4px solid #000; padding: 10px 20px 10px 20px;" class="hinditext">
            <div style="text-align: center;">
                <p style="margin: 0px; padding: 0px;">
                    <img src="logo.jpg" alt="" width="120" /></p>
                <h3 style="margin: 0px; padding: 0px; font-family: ariel;">NCVT <asp:Label runat="server" ID="lblAnnualOrSemester" Text=""></asp:Label> Examination- 2020
                    <br />
                    <br />
                    (Admit Card for Practical – Examination) Sept-2021
                </h3>
            </div>

            <table width="100%" border="1" cellspacing="0" cellpadding="0" style="margin: 3px 0px 0px 0px; background: url(watermark.png); background-repeat: no-repeat; background-position: center center;">
                <tbody>
                    <tr>
                        <td style="padding: 2px 8px 10px 8px; width: 50%; font-family: ariel;"><strong>Application Roll No.:-</strong><asp:Label ID="lblRollNumber" runat="server" Text="" CssClass="lblengfont" />
                        </td>
                        <td style="padding: 2px 8px 10px 8px; width: 50%; font-family: ariel;"><strong>Student Name:-</strong>
                            <asp:Label ID="lblName" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 10px 8px; font-family: ariel;"><strong>Date of Birth:-</strong>
                            <asp:Label ID="lblDOB" runat="server" Text="" CssClass="lblengfont" />
                        </td>
                        <td style="padding: 2px 8px 10px 8px; font-family: ariel;"><strong>Semester/Year:-</strong>
                            <asp:Label ID="lblSemester" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 2px 8px; font-family: ariel;"><strong>Father Name:-</strong>
                            <asp:Label ID="lblFatherName" runat="server" Text="" CssClass="lblengfont" />
                        </td>
                        <td style="padding: 2px 8px 2px 8px; font-family: ariel"><strong>Institute Code:-</strong>
                            <asp:Label ID="lblITICode" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 2px 8px; font-family: ariel;"><strong>Gender:-</strong>
                            <asp:Label ID="lblGender" runat="server" Text="" CssClass="lblengfont" /></td>
                        <td style="padding: 2px 8px 2px 8px; font-family: ariel"><strong>Institute Name:-</strong>
                            <asp:Label ID="lblIITName" runat="server" Text="" CssClass="lblengfont" />
                            <asp:Label ID="Label2" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 20px 8px; font-family: ariel" colspan="2"><strong>Practical Exam Centre:-</strong>
                            <asp:Label ID="lblCentre" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 2px 8px; font-family: ariel;"><strong>Trade:-</strong>
                            <asp:Label ID="lblTrade" runat="server" Text="" CssClass="lblengfont" /></td>
                        <td style="padding: 2px 8px 2px 8px; font-family: ariel"><strong>Subject:-</strong>
                            <asp:Label ID="Label4" runat="server" Text="Practical" CssClass="lblengfont" />
                            <asp:Label ID="Label5" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>

                    <tr>
                        <td style="padding: 2px 8px 2px 8px; font-family: ariel;" colspan="2"><strong>Start Date and Time of Exam:-</strong>
                            <asp:Label ID="lblPaper1Date" runat="server" Text="" CssClass="lblengfont" /></td>
                        <%--<td style="padding: 2px 8px 2px 8px; font-family: ariel"><strong>Time of Exam:-</strong>
                            <asp:Label ID="Label6" runat="server" Text="09:00 AM to 05:00 PM" CssClass="lblengfont" />
                            <asp:Label ID="Label7" runat="server" Text="" CssClass="lblengfont" /></td>--%>
                    </tr>

                    <%--<tr>
      <td style="padding:2px 8px 10px 8px;">ijh{kk dh rkjh[k%& </td>
      <td style="padding:2px 8px 10px 8px;">ijh{kk dh rkjh[k%& <asp:Label ID="lblPaper2Date" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
      <tr>
      <td style="padding:2px 8px 2px 8px;">isij 1 %& <asp:Label ID="lblPaper1Name" runat="server" Text="" CssClass="lblengfont" /></td>
      <td style="padding:2px 8px 2px 8px;">isij 2 %& <asp:Label ID="lblPaper2Name" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
      <tr>
      <td style="padding:2px 8px 10px 8px;">ijh{kk dk le; %& <asp:Label ID="lblPaper1Time" runat="server" Text="" CssClass="lblengfont" /></td>
      <td style="padding:2px 8px 10px 8px;">ijh{kk dk le; %& <asp:Label ID="lblPaper2Time" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>--%>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 0px 8px;">
                            <div style="border: 1px solid; width: 110px; height: 120px; margin: 10px auto 10px auto; vertical-align: middle; display: block; padding: 20px 30px 20px 30px; text-align: center;">
                                Paste your photograph here and get it attested by the head of your institution
                            </div>
                        </td>
                        <td style="padding: 2px 8px 0px 8px;" valign="top">
                            <table width="100%" border="1" cellspacing="0" cellpadding="0" style="margin: 20px 0px 0px 0px; height: 100px;">
                                <tbody>
                                    <tr>
                                        <td style="padding: 20px 8px 10px 8px; text-align: center;">&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin: 0px 0px 0px 0px;">
                                <tbody>
                                    <tr>
                                        <td style="padding: 0px 8px 0px 8px; text-align: center;"><strong>Seal and Signature of Institution Head</strong></td>
                                    </tr>
                                </tbody>
                            </table>

                        </td>
                    </tr>
                </tbody>
            </table>

            <p style="text-align: center; font-size: 24px; margin: 10px 8px -15px 0px;"><strong>-:<span style="background: #ffff00; font-family: ariel">Practical Examination Instructions</span>:- </strong></p>
            <ol style="list-style: none; background: url(watermark.png); background-repeat: no-repeat; background-position: center center;">
                <li><span style="font-family: Arial, Helvetica, sans-serif; font-size: 14px; margin: 0px 8px 0px 0px; display: inline-block;">1.</span><span style="font-family: ariel">The Examination Centre address on this Admit Card might be changed. Please confirm with the principal
of your institution at least 2 days before of the practical examination.</span></li>
                <li><span style="font-family: Arial, Helvetica, sans-serif; font-size: 14px; margin: 0px 8px 0px 0px; display: inline-block;">2.</span><span style="font-family: ariel">Please carry a valid photo identity card along with this Admit Card to the Practical exam Centre.</span></li>
                <li><span style="font-family: Arial, Helvetica, sans-serif; font-size: 14px; margin: 0px 8px 0px 0px; display: inline-block;">3.</span><span style="font-family: ariel">Please ensure that you report to the Practical exam center at least 30 minute prior to the start time.</span></li>
                <li><span style="font-family: Arial, Helvetica, sans-serif; font-size: 14px; margin: 0px 8px 0px 0px; display: inline-block;">4.</span><span style="font-family: ariel">For any other error in the Admit Card please contact to the principal of your institution. Any correction on this Admit Card must be counter signed by the Principal.</span></li>
              </ol>



            <div style="text-align: center; width: 750px;">
                <asp:LinkButton ID="lnkPrint" runat="server" Text="Print" OnClientClick="PrintDiv();" CssClass="lblengfont"></asp:LinkButton>
                &nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Close" OnClientClick="javascript:window.close();" CssClass="lblengfont"></asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
