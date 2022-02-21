<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmitCardStenoPrac.aspx.cs" Inherits="Principle_AdmitCardStenoPrac" %>

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
            var popupWin = window.print('AdmitCardStenoPrac.aspx', '_blank', 'width=1000px,height=500px,location=no,left=200px');
        }

    </script>
    <style type="text/css">
@font-face {  
  font-family: kruti dev ;  
  src: url( './fonts/Kruti_Dev.ttf' ) format("truetype");  
}  
.hinditext {
    font-family: kruti dev;  
    font-size:18px;
}
.lblengfont{
    font-family: Arial, Helvetica, sans-serif; font-size:14px;
}

table {
  border-collapse: collapse;
}

table, td, th {
  border: 1px solid black;
  padding:3px;
}
    .auto-style1 {
        width: 165px;
    }
    .auto-style2 {
        text-align: justify;
        text-indent: -18.0pt;
        line-height: 115%;
        font-size: 11.0pt;
        font-family: Calibri, sans-serif;
        margin-left: 36.0pt;
        margin-right: 0cm;
        margin-top: 0cm;
        margin-bottom: 10.0pt;
    }
pre
	{margin-bottom:.0001pt;
	font-size:10.0pt;
	font-family:"Courier New";
	    margin-left: 0cm;
        margin-right: 0cm;
        margin-top: 0cm;
    }
    .auto-style3 {
        text-align: justify;
        text-indent: -18.0pt;
        line-height: 115%;
        font-size: 11.0pt;
        font-family: Calibri, sans-serif;
        margin-left: 36.0pt;
        margin-right: 0cm;
        margin-top: 0cm;
        margin-bottom: .0001pt;
    }
    .auto-style4 {
        text-align: justify;
        line-height: 115%;
        font-size: 11.0pt;
        font-family: Calibri, sans-serif;
        margin-left: 36.0pt;
        margin-right: 0cm;
        margin-top: 0cm;
        margin-bottom: .0001pt;
    }
    .auto-style5 {
        text-align: right;
        line-height: 115%;
        font-size: 11.0pt;
        font-family: Calibri, sans-serif;
        margin-left: 36.0pt;
        margin-right: 0cm;
        margin-top: 0cm;
        margin-bottom: .0001pt;
    }
    .auto-style6 {
        width: 390.0pt;
        border-collapse: collapse;
        line-height: 115%;
        font-size: 11.0pt;
        font-family: Calibri, sans-serif;
    }
    .auto-style7 {
        text-align: justify;
        line-height: 115%;
        font-size: 11.0pt;
        font-family: Calibri, sans-serif;
        margin-left: 36.0pt;
        margin-right: 0cm;
        margin-top: 0cm;
        margin-bottom: 10.0pt;
    }
    .auto-style8 {
        width: 275px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="PrintDiv" style="width: 750px; margin: 0px auto; font-size: 18px; line-height: 1; border: 4px solid #000; padding: 10px 20px 10px 20px;" class="hinditext">
            <div style="text-align: center;">
                <p style="margin: 0px; padding: 0px;">
                    <img src="logo.jpg" alt="" width="120" />
                </p>
                <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                    <b><span style="font-size: 16.0pt; line-height: 1; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">e/;izns”k vkbZ-Vh-vkbZ </span><span style="font-size: 20.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">¿,<span style="font-size: 16.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">u</span>-lh-oh-Vh-À</span><span style="font-size: 16.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"> vk”kqfyfi fganh @vaxzsth @lfpoky; </span><span lang="EN-US" style="font-size: 16.0pt; line-height: 115%; font-family: Kruti Dev 010;">i)fr</span><span lang="EN-US" style="font-size: 13.0pt; line-height: 115%; font-family: Kruti Dev 010;">
                    </span></b>
                </p>

                <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                    <b><span style="font-size: 16.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">vkWuykbu okf’kZd izk;ksfxd ijh{kk &amp; 2021</span></b>
                </p>

                <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                    <b><span style="font-size: 18.0pt; mso-bidi-font-size: 14.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">¿ izos”k&amp;i= À</span></b>
                </p>
            </div>

            <table width="100%" border="1" cellspacing="0" cellpadding="0" style="margin: 3px 0px 0px 0px; background: url(watermark.png); background-repeat: no-repeat; background-position: center center;">
                <tbody>
                    <tr>
                        <td style="padding: 2px 8px 10px 8px; width: 50%;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">ijh{kkFkhZ dk uke%&amp;</span><span style="color: rgb(0, 0, 0); font-family: kruti dev 010; font-size: 18px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;"> </span>
                            <asp:Label ID="lblName" runat="server" Text="" CssClass="lblengfont" />
                        </td>
                        <td style="padding: 2px 8px 10px 8px; width: 50%;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">firk dk uke%&amp;</span>
                            <asp:Label ID="lblFatherName" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 10px 8px;">
                            <p class="MsoNormal">
                                <span style="font-family: Kruti Dev 010; mso-ansi-language: EN-IN">vkbZ-Vh-vkbZ- dk uke%&amp;<asp:Label ID="lblIITName" runat="server" Text="" CssClass="lblengfont" /></span>
                            </p>
                        </td>
                        <td style="padding: 2px 8px 10px 8px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 2px 8px;" colspan="2">
                            <p class="MsoNormal">
                                <span style="font-family: Kruti Dev 010; mso-ansi-language: EN-IN">Vªs+M dk uke%&amp;<o:p><asp:Label ID="lblTrade" runat="server" Text="" CssClass="lblengfont" /></o:p></span>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 2px 8px;">
                            <p class="MsoNormal">
                                <span style="font-family: Kruti Dev 010; mso-ansi-language: EN-IN">ijh{kkFkhZ dk jftLVªs</span><span lang="HI" style="font-size: 10.0pt; mso-ansi-font-size: 11.0pt; line-height: 115%; font-family: Mangal; mso-ascii-font-family: Kruti Dev 010; mso-hansi-font-family: Kruti Dev 010; mso-ansi-language: EN-IN">श</span><span style="font-family: Kruti Dev 010; mso-ansi-language: EN-IN">u</span>
                            </p>
                            <span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">uEcj@ jksyua-%</span>
                            <asp:Label ID="lblRollNumber" runat="server" Text="" CssClass="lblengfont" /></td>
                        <td style="padding: 2px 8px 2px 8px;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">tUefrfFk%&amp;</span>
                            <asp:Label ID="lblDOB" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 20px 8px;" colspan="2"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">ijh{kk dsUnz dk uke o irk%&amp;</span>
                            <asp:Label ID="lblCentre" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 10px 8px;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">ijh{kk dh rkjh[k%&amp;</span>
                            <asp:Label ID="lblPaper1Date" runat="server" Text="" CssClass="lblengfont" /></td>
                        <td style="padding: 2px 8px 10px 8px;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">ijh{kk dh rkjh[k%&amp;</span>
                            <asp:Label ID="lblPaper2Date" runat="server" Text="" CssClass="lblengfont" /></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 2px 8px;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">isij 1 %&amp;</span> <b><span lang="EN-GB" style="font-size: 11.0pt; font-family: Calibri,sans-serif; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-ansi-language: EN-GB; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Job 1, Job 2 and Job 3</span></b><span lang="EN-GB" style="font-size: 11.0pt; font-family: Calibri,sans-serif; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-ansi-language: EN-GB; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></td>
                        <td style="padding: 2px 8px 2px 8px;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">isij 2 %&amp;</span>&nbsp; <b><span lang="EN-GB" style="font-size: 11.0pt; font-family: Calibri,sans-serif; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-ansi-language: EN-GB; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Job 4 (80 WPM) and Job 5 (100 WPM)</span></b></td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 10px 8px;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">ijh{kk dk le; %&amp; </span>
                            <asp:Label ID="lblPaper1Time" runat="server" Text="" CssClass="lblengfont" /></td>
                        <td style="padding: 2px 8px 10px 8px;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">ijh{kk dk le; %&amp; </span>&nbsp;<asp:Label ID="lblPaper2Time" runat="server" Text="" CssClass="lblengfont" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 8px 0px 8px;">
                            <div style="border: 1px solid; width: 110px; margin: 30px auto 0px auto; vertical-align: middle; display: block; padding: 20px 30px 20px 30px; text-align: center;">
                                <p align="center" class="MsoNormal">
                                    <span style="mso-bidi-font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">viuh ikliksVZ lkbZt QksVks ;gk¡ fpidk;sA</span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span style="mso-bidi-font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">,oa izkpk;Z</span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span style="mso-bidi-font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">}kjk lR;kfir djk;s</span>
                                </p>
                            </div>
                        </td>
                        <td style="padding: 2px 8px 0px 8px;" valign="top">
                            <p class="MsoNormal">
                                <span style="font-family: Kruti Dev 010; mso-ansi-language: EN-IN">ijh{kk dh rkjh[k%&amp;<b><o:p><asp:Label ID="lblDate1" runat="server" Text=""  CssClass="lblengfont"></asp:Label>
      
              </o:p></b></span>
                            </p>

                            <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td style="padding: 2px 8px 20px 8px;">&nbsp;</td>
                                        <td style="padding: 2px 8px 20px 8px;">&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td style="padding: 2px 8px 10px 8px; text-align: center;" class="auto-style1"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">ijh{kkFkhZ ds gLrk{kj</span></td>
                                        <td style="padding: 2px 8px 10px 8px; text-align: center;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">oh{kd ds gLrk{kj</span></td>
                                    </tr>
                                </tbody>
                            </table>
                            <p class="MsoNormal">
                                <span style="font-family: Kruti Dev 010; mso-ansi-language: EN-IN">ijh{kk dh rkjh[k%&amp;<b><o:p><asp:Label ID="lblDate2" runat="server" Text=""  CssClass="lblengfont"></asp:Label>
              </o:p></b></span>
                            </p>
                            &nbsp;<table width="100%" border="1" cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td style="padding: 2px 8px 20px 8px;">&nbsp;</td>
                                        <td style="padding: 2px 8px 20px 8px;">&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td style="padding: 2px 8px 10px 8px; text-align: center;" class="auto-style1"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">ijh{kkFkhZ ds gLrk{kj</span></td>
                                        <td style="padding: 2px 8px 10px 8px; text-align: center;"><span style="font-size: 11.0pt; mso-bidi-font-size: 10.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-fareast-font-family: Times New Roman; mso-fareast-theme-font: minor-fareast; mso-bidi-font-family: Mangal; mso-ansi-language: EN-IN; mso-fareast-language: EN-US; mso-bidi-language: HI">oh{kd ds gLrk{kj</span></td>
                                    </tr>
                                </tbody>
                            </table>

                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="50%" border="1" cellspacing="0" cellpadding="0" style="margin: 20px 0px 0px 0px;">
                <tbody>
                    <tr>
                        <td style="padding: 20px 8px 10px 8px; text-align: center;">&nbsp;</td>
                    </tr>
                </tbody>
            </table>
            <table width="50%" border="0" cellspacing="0" cellpadding="0" style="margin: 0px 0px 0px 0px;">
                <tbody>
                    <tr>
                        <td style="padding: 0px 8px 0px 8px; text-align: center;">
                            <p class="MsoNormal">
                                <span style="font-size: 12.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">laLFkk izeq[k ds gLrk{kj</span>
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
            <p align="center" class="MsoNormal">
                <b><span style="font-size: 14.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">&amp;%</span><u><span style="font-size: 16.0pt; line-height: 115%; font-family: Kruti Dev 010; background: yellow; mso-highlight: yellow; mso-ansi-language: EN-IN">ijh{kkfFkZ;ksa ds fy, funsZ”k</span></u><span style="font-size: 14.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">%&amp;</span></b>
            </p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">1 &amp; ijh{kkFkhZ dks funsZ”kr fd;k tkrk gS fd ijh{kk izkjaHk gksus ls de ls de 45 feuV igys ijh{kk dsUnz ij mifLFkr gks A</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">2 &amp; ijh{kkFkhZ dks vius ijh{kk izos”ki= ds lkFk uhps fn;s x;s izekf.kr ewy igpku i=ksa esa ls <b>dksbZ ,d </b>¿ osfyM vkbZ-Mh- izwQ&amp;vksfjtuy À dks lkFk ykuk gksxkA ,slk u djus ij ijh{kk esa lEefyr gksus dh vuqefr ugha nh tk;sxhAfuEufyf[kr esa ls dksbZ ,d izekf.kr igpku i= dh ewy izfr ykuk vfuok;Z gksxkA</span></p>

            <p><span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b>izekf.kr igpku i=%&amp;</b></span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> vkbZ-Vh-vkbZ- igpku i=</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> ernkrk igpku i=</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> ikliksVZ</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> isudkMZ</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> Mªkbfoax ykblsal</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> QksVks yxk gqvk jk&quot;Vªh; d`r cSad iklcqd</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> ;w-vkbZ-Mh-vkbZ ¿vk/kkjdkMZÀ</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 100%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> QksVks yxh gqbZ nloha ;k ckjgoh d{kk dh ekdZ”khV</span></p>

            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">3 &amp; ,sls Nk=ksa dks ijh{kk dsUnz esa izos”ki= ij izkpk;Z }kjk lR;kfir QksVks dh gkMZ dkWih ugha yxh gq;h gSA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">4 &amp; ijh{kkFkhZ dks oh{kd dh mifLFkfr esa izos”ki= esa fn;s x;s LFkku ij gLrk{kj djuk gksxkA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">5 &amp; ijh{kkFkhZ dks izos”ki= lR;kiu ds ckn gh ijh{kk d{k esa izos”kfn;k tk;sxkA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">6 &amp; izos”ki= ij n”kkZ, x, LFkku ,oa le; ij mifLFkr gksuk ijh{kkFkhZ dk nkf;Ro gksxkA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">7 &amp; vkWuykbu ijh{kk ls vPNh rjg ls ifjfpr gksus ds fy, ijh{kkFkhZ ftruh ckj pkgsa mruh ckj udyh ijh{kk ¿EkkWd ,DtkeÀ ns ldrs gSA udyh ijh{kk ¿ekWd ,DtkeÀ osclkbZV <b style="font-family: Arial">mpiti.cbtexam.in</b> ij miyC/k gSaA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">8 &amp; fdlh Hkh n”kk esa mEehnokj dks ijh{kk ds lekiu ls igys ijh{kk d{k dks NksM+us fd vuqefr ugha nh tk,xhA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">9 &amp; <b>हिन्दी टाइपिंग के लिए मंगल फॉन्ट का उपयोग किया जाएगा</b></span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">10 &amp; ijh{k.k daI;wVj ij vkWuykbu eksM esa vk;ksftr fd;k tk,xk vkSj “kCnksa dk vuqPNsn dsoy daI;wVj Ldzhu ij gh fn;k tk,xkA</span></p>


            <pre><span lang="EN-US" style="font-size:12.0pt;mso-bidi-font-size:
10.0pt;font-family:&quot;Nirmala UI&quot;,&quot;sans-serif&quot;;color:#212121">Below given table shows the structure of examination.</span></pre>
            <pre><span lang="EN-US" style="font-size:12.0pt;mso-bidi-font-size:
10.0pt;font-family:&quot;Nirmala UI&quot;,&quot;sans-serif&quot;;color:#212121"><o:p>&nbsp;</o:p></span></pre>
            <table border="0" cellpadding="0" cellspacing="0" class="auto-style6" style="mso-yfti-tbllook: 1184; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt" width="520">
                <tr style="mso-yfti-irow: 0; mso-yfti-firstrow: yes; height: 15.0pt">
                    <td colspan="4" nowrap valign="bottom" width="520">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Steno English&amp; Secretarial Practice English</span></b>
                        </p>
                    </td>
                </tr>
                <tr style="mso-yfti-irow: 1; height: 15.0pt">
                    <td rowspan="2" width="64">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Paper 1</span></b>
                        </p>
                        <%--<p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">(Day 1)</span></b>
                        </p>--%>
                    </td>
                    <td width="179">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 1</span></b>
                        </p>
                    </td>
                    <td class="auto-style8">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 2</span></b>
                        </p>
                    </td>
                    <td width="121">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 3</span></b>
                        </p>
                    </td>
                </tr>
                <tr style="mso-yfti-irow: 2; height: 15.0pt">
                    <td width="179">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">400 words typing- 10 mins</span>
                        </p>
                    </td>
                    <td class="auto-style8">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Letter Typing - 30 Mins</span>
                        </p>
                    </td>
                    <td width="121">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">MS Excel- 30 mins</span>
                        </p>
                    </td>
                </tr>
                <tr style="mso-yfti-irow: 3; height: 15.0pt">
                    <td rowspan="2" width="64">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Paper 2</span></b>
                        </p>
                        <%--                        <p align="center" class="MsoNormal">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">(Day 2)</span></b>
                        </p>--%>
                    </td>
                    <td width="179">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 4</span></b>
                        </p>
                    </td>
                    <td class="auto-style8">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 5</span></b>
                        </p>
                    </td>
                    <td width="121"></td>
                </tr>
                <tr style="mso-yfti-irow: 4; height: 45.0pt">
                    <td width="179">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Dictation @ 80 WPM - 5 mins and typing time 40 mins</span>
                        </p>
                    </td>
                    <td class="auto-style8">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Dictation @ 100 WPM - 5 mins and typing time 50 mins</span>
                        </p>
                    </td>
                    <td width="121">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">-</span>
                        </p>
                    </td>
                </tr>
                <tr style="mso-yfti-irow: 5; height: 15.0pt">
                    <td colspan="4" nowrap valign="bottom" width="520">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Steno Hindi</span></b>
                        </p>
                    </td>
                </tr>
                <tr style="mso-yfti-irow: 6; height: 15.0pt">
                    <td rowspan="2" width="64">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Paper 1</span></b>
                        </p>
                        <%--                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">(Day 1)</span></b>
                        </p>--%>
                    </td>
                    <td width="179">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 1</span></b>
                        </p>
                    </td>
                    <td class="auto-style8">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 2</span></b>
                        </p>
                    </td>
                    <td width="121">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 3</span></b>
                        </p>
                    </td>
                </tr>
                <tr style="mso-yfti-irow: 7; height: 15.0pt">
                    <td width="179">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">300 words typing- 10 mins</span>
                        </p>
                    </td>
                    <td class="auto-style8">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Letter Typing - 30 Mins</span>
                        </p>
                    </td>
                    <td width="121">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">MS Excel- 30 mins</span>
                        </p>
                    </td>
                </tr>
                <tr style="mso-yfti-irow: 8; height: 15.0pt">
                    <td rowspan="2" width="64">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Paper 2</span></b>
                        </p>
                        <%--<p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">(Day 2)</span></b>
                        </p>--%>
                    </td>
                    <td width="179">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 4</span></b>
                        </p>
                    </td>
                    <td class="auto-style8">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <b><span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Job 5</span></b>
                        </p>
                    </td>
                    <td width="121"></td>
                </tr>
                <tr style="mso-yfti-irow: 9; mso-yfti-lastrow: yes; height: 45.0pt">
                    <td width="179">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Dictation @ 80 WPM - 5 mins and typing time 40 mins</span>
                        </p>
                    </td>
                    <td class="auto-style8">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">Dictation @ 100 WPM - 5 mins and typing time 50 mins</span>
                        </p>
                    </td>
                    <td width="121">
                        <p align="center" class="MsoNormal" style="margin: 0px; padding: 0px;">
                            <span lang="EN-GB" style="mso-fareast-font-family: Times New Roman; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB">-</span>
                        </p>
                    </td>
                </tr>
            </table>


            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">11 &amp; ijh{kkFkhZ dks vius lkFk dsoy isu@isfUly vkSj ijh{kk ds nLrkost ¿ izos”ki=] izekf.kr igpkui=À ykus dh vuqefr gksxhA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">12 &amp; mijksDr ds vfrfjDr vU; oLrq,¡ tSls% eksckbZy Qksu] cSx] midj.k] fdrkcsa ¿cqDlÀ] dkWfi;k ¿uksVcqdÀ] ?kM+h] istlZ] lSy Qksu bR;kfn oLrqvksa dks ijh{kk gkWy ds vUnj ys tkus dh vuqefr ugha gS ijh{kkFkhZ dh dksbZ Hkh oLrq pksjh gks tkus ;k xqe gks tkus ij] ijh{kk e.My@dsUnz dh ftEesnkjh ugha gksxhA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">13 &amp; ijh{kk ds nkSjku dksbZ Hkh ijh{kkFkhZ ;fn fdlh vuqfpr ek/;e dk lgkjk ysrs gq, ik;k x;k ;k dksbZ vuqfpr O;ogkj djrs gq, ik;k x;k rks og ijh{kk nsus ds fy, v;ksX; Bgjk;k tk,xk] ftlesa ijh{kk ds nkSjku fdlh Hkh vH;kFkhZ dks enn djuk ;k mlls enn ysuk Hkh &#39;kkfey gSA</span></p>

            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">14 &amp; fuEufyf[kr esa ls dksbZ Hkh fØ;kdyki@ xfrfof/k ijh{kkFkhZ }kjk mi;ksx esa ykus ij mls vuqfpr lk/ku ¿vu Qs;jehUlÀ ds varxZr ekuk tkosxkA</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> ijh{kkfFkZ;ksa dks vius izos”k i= esa fdlh Hkh izdkj dh tkudkjh esa dkaV NkV djus ijA</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> ijh{kk d{k esa vU; ijh{kkFkhZ ls fdlh Hkh izdkj dk lEidZ@udy djrs ik;s tkus ijA</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> vius LFkku ij fdlh vU; O;fDr ls ijh{kk fnykuk ;k ijh{kkFkhZ ds LFkku ij vU; dksbZ O;fDr mifLFkr gksus ijA</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> ijh{kk d{k esa vius ikl fdlh Hkh izdkj dh izfrcaf/kr lkexzh j[kus ijA</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> ijh{kk ds nkSjku fpYykuk] cksyuk] dkukQwlh djuk] b”kkjs djuk o vU; izdkj ls laidZ lk/kus ijA</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> l{ke vf/kdkjh ds funsZ”kksa dh vogsyuk@voKk djuk ;k muds funs”kksZ dk ikyu u djus ijA</span></p>
            <p>&emsp;<span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN"><b style="font-family: arial">·</b> ijh{kk dk;Z esa yxs deZpkjh@ vf/kdkjh dks ijs”kku djus] /kedkus ;k &#39;kkjhfjd pksV igqapkus ijA</span></p>


            <p class="MsoNormal">
                &nbsp;&nbsp;&nbsp;&nbsp;<b><span style="font-size: 14.0pt; line-height: 115%; font-family: Kruti Dev 010; background: yellow; mso-highlight: yellow; mso-ansi-language: EN-IN">uksV</span><span style="font-size: 12.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">%&amp;</span></b><span style="font-size: 12.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">mi;qZDr vuqfpr lk/kuksa dk mi;ksx djus ij vH;kFkhZ ds fo:) U;kkf;d dk;Zokgh dh tkosxh]</span>
            </p>
            <p class="MsoNormal">
                &nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 12.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">iz”ui= dk ewY;kadu ugha fd;k tkosxk rFkk mldk vH;fFkZRo fujLr dj fn;k tkosxkA</span>
            </p>


            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">15 &amp; ijh{kk dsUnzk LFky ifjorZu ds fy, fdlh Hkh vkosnu dks Lohdkj ugha fd;k tkosxkA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">16 &amp; ijh{kkfFkZ;ksa dks ijh{kk ds nkSjku oh{kd }kjk fn;s x;s funsZ”kksa dk ikyu djuk vfuok;Z gSA</span></p>
            <p><span style="font-size: 11.0pt; line-height: 115%; font-family: Kruti Dev 010; mso-ansi-language: EN-IN">17 &amp; vH;kFkhZ dks ijh{kk ds vafre fnu izos”ki= ijh{kk gkWy esa tek djok dj tkosaA ;g lqfu”fpr djsa fd izos”ki= dh ,d izfrfyfi vH;kFkhZ dks vius ikl j[kuk vfuok;Z gSA</span></p>


            <div style="text-align: center; width: 750px;">
                <asp:LinkButton ID="lnkPrint" runat="server" Text="Print" OnClientClick="PrintDiv();" CssClass="lblengfont"></asp:LinkButton>
                &nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Close" OnClientClick="javascript:window.close();" CssClass="lblengfont"></asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
