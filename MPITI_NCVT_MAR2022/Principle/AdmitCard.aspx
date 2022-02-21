<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmitCard.aspx.cs" Inherits="Principle_AdmitCard" %>

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
</style>
        <style type="text/css" media="print">
@media print {
  body {
      -webkit-print-color-adjust: exact;        
    margin-left: 10px;
    margin-right: 10px;
    margin-top: 10px;
    margin-bottom: 10px;
    zoom:100%;
  }
}
@page {
    size:A4 portrait;
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
    <div id="PrintDiv" style="width:750px; margin:0px auto; font-size:18px; line-height:18px; border:0px solid #000; padding:10px 20px 10px 20px;" class="hinditext">
<div style="text-align:center;">
<p style="margin:0px; padding:0px;"><img src="logo.jpg" alt="" width="120"/></p>

<h3 style="margin:0px; padding:0px; font-family: kruti dev;"> e/;izns'k vkbZ-Vh- vkbZ- ¿,u-lh-oh-Vh-À vkWuykbu ijh{kk& <span style="font-family:Calibri;"> AUGUST -  2019</span> <br />dEI;wVj vk/kkfjr ijh{kk& <span style="font-family:Calibri;"> AUGUST - 2019 </span><br/>
¿  izos'k&i=  À
</h3>
</div>

<table width="100%" border="1" cellspacing="0" cellpadding="0" style="margin:3px 0px 0px 0px; background:url(watermark.png); background-repeat: no-repeat; background-position: center center;">
  <tbody>
    <tr>
      <td style="padding:2px 8px 10px 8px; width:50%;">ijh{kkFkhZ dk uke%&	<asp:Label ID="lblName" runat="server" Text="" CssClass="lblengfont" /> </td>
      <td style="padding:2px 8px 10px 8px;  width:50%;">firk dk uke%& <asp:Label ID="lblFatherName" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
    <tr>
      <td style="padding:2px 8px 10px 8px;">vkbZ-Vh-vkbZ- dk uke%& <asp:Label ID="lblIITName" runat="server" Text="" CssClass="lblengfont" /></td>
      <td style="padding:2px 8px 10px 8px;">lsesLVj<span style="font-family: Calibri">/year</span>%&<asp:Label ID="lblSemester" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
     <tr>
      <td style="padding:2px 8px 2px 8px;" colspan="2">Vªs+M dk uke%& <asp:Label ID="lblTrade" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
     <tr>
      <td style="padding:2px 8px 2px 8px;">ijh{kkFkhZ dk jftLVªs’ku <br/>
uEcj@ jksy ua-% <asp:Label ID="lblRollNumber" runat="server" Text="" CssClass="lblengfont" /></td>
      <td style="padding:2px 8px 2px 8px;">tUefrfFk%& <asp:Label ID="lblDOB" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
       <tr>
      <td style="padding:2px 8px 20px 8px;" colspan="2">ijh{kk dsUnz dk uke o irk%& <asp:Label ID="lblCentre" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
     <tr>
      <td style="padding:2px 8px 10px 8px;">ijh{kk dh rkjh[k%& <asp:Label ID="lblPaper1Date" runat="server" Text="" CssClass="lblengfont" /></td>
      <td style="padding:2px 8px 10px 8px;">ijh{kk dh rkjh[k%& <asp:Label ID="lblPaper2Date" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
      <tr>
      <td style="padding:2px 8px 2px 8px;">isij 1 %& <asp:Label ID="lblPaper1Name" runat="server" Text="" CssClass="lblengfont" /></td>
      <td style="padding:2px 8px 2px 8px;">isij 2 %& <asp:Label ID="lblPaper2Name" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
      <tr>
      <td style="padding:2px 8px 10px 8px;">ijh{kk dk le; %& <asp:Label ID="lblPaper1Time" runat="server" Text="" CssClass="lblengfont" /></td>
      <td style="padding:2px 8px 10px 8px;">ijh{kk dk le; %& <asp:Label ID="lblPaper2Time" runat="server" Text="" CssClass="lblengfont" /></td>
    </tr>
      <tr>
      <td>&nbsp;</td>
      <td >&nbsp;</td>
    </tr>
         <tr>
      <td style="padding:2px 8px 0px 8px;"><div style="border: 1px solid; width: 110px; margin: 30px auto 0px auto;  vertical-align: middle; display: block; padding: 20px 30px 20px 30px;
 text-align: center;">viuk ikliksVZ lkbZt QksVks
;gk¡ fpidk;sA
,oa izkpk;Z
}kjk lR;kfir djk;</div></td>
      <td style="padding:2px 8px 0px 8px;" valign="top">ijh{kk dh rkjh[k%& <asp:Label ID="lblDate1" runat="server" Text=""  CssClass="lblengfont"></asp:Label>
      
  <table width="100%" border="1" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td style="padding:2px 8px 20px 8px;">&nbsp;</td>
      <td style="padding:2px 8px 20px 8px;">&nbsp;</td>
    </tr>    
  </tbody>
</table>
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td style="padding:2px 8px 10px 8px; text-align:center;">ijh{kkFkhZ ds gLrk{kj</td>
      <td style="padding:2px 8px 10px 8px;  text-align:center;">oh{kd ds gLrk{kj</td>
    </tr>    
  </tbody>
</table>
ijh{kk dh rkjh[k%& <asp:Label ID="lblDate2" runat="server" Text=""  CssClass="lblengfont"></asp:Label>
  <table width="100%" border="1" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td style="padding:2px 8px 20px 8px;">&nbsp;</td>
      <td style="padding:2px 8px 20px 8px;">&nbsp;</td>
    </tr>    
  </tbody>
</table>
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td style="padding:2px 8px 10px 8px; text-align:center;">ijh{kkFkhZ ds gLrk{kj</td>
      <td style="padding:2px 8px 10px 8px;  text-align:center;">oh{kd ds gLrk{kj</td>
    </tr>    
  </tbody>
</table>
      
       </td>
    </tr>
  </tbody>
</table>
  <table width="50%" border="1" cellspacing="0" cellpadding="0" style="margin:20px 0px 0px 0px;">
  <tbody>
    <tr>
      <td style="padding:20px 8px 10px 8px; text-align:center;">&nbsp;</td>
    </tr>    
  </tbody>
  </table>
    <table width="50%" border="0" cellspacing="0" cellpadding="0" style="margin:0px 0px 0px 0px;">
  <tbody>
    <tr>
      <td style="padding:0px 8px 0px 8px; text-align:center;"><strong>¼ laLFkk izeq[k ds gLrk{kj ,oa lhy ½</strong></td>
    </tr>    
  </tbody>
  </table>
<p style="text-align:center; font-size:24px; margin:10px 8px -15px 0px;"><strong>&%  <span style="background:#ffff00;">ijh{kkfFkZ;ksa ds fy, funsZ'k </span> %&</strong> </p>
<%--<ol style="list-style:none; background:url(watermark.png); background-repeat: no-repeat; background-position: center center;">--%>
        <ol style="list-style:none;">
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">1.</span>ijh{kk fnol ij ijh{kkFkhZ dks izos'k i= ds lkFk&lkFk ,u-lh-oh-Vh-&,e-vkbZ-,l- iksVZy }kjk tkjh gkWy fVdV ysdj vkuk vfuok;Z gSA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">2.</span>ijh{kkFkhZ dks funsZf'kr fd;k tkrk gS fd ijh{kk izkjaHk gksus ls de ls de 60 feuV igys ijh{kk dsUnz ij mifLFkr gksaA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">3.</span>ijh{kkFkhZ dks vius ijh{kk izos'k i= ds lkFk uhps fn;s x;s izekf.kr ewy igpku i=ksa esa ls<strong> dksbZ ,d </strong>¿ osfyM vkbZ-Mh- izwQ & vksfjtuy À dks lkFk ykuk gksxkA ,slk u djus ij ijh{kk esa lEefyr gksus dh vuqefr ugha nh tk;sxhA fuEufyf[kr esa ls dksbZ ,d izekf.kr igpku i= dh ewy izfr ykuk vko’;d gSA<br/><br/>


izekf.kr igpku i=%&

<ul>
<li>vkbZ-Vh-vkbZ- vkbZ-Mh- dkMZ</li>
<li>ernkrk igpku i=</li>
<li>ikliksVZ</li>
<li>isu dkMZ</li>
<li>Mªkbfoax ykblsal</li>
<li>QksVks yxk gqvk jk"Vªh;d`r cSad iklcqd</li>
<li>;w-vkbZ-Mh-vkbZ ¿vk/kkj dkMZÀ</li>
<li>QksVks yxh gqbZ nloha ;k ckjgoh d{kk dh ekdZ'khV</li>
</ul>
</li>

<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">4.</span>bl ijh{kk dk vkadyu dEI;wVj vk/kkfjr gksxkA ijh{kkFkhZ dks ijh{kk ds 'kq:vkr esa viuk ;wtj use] ikloMZ] vkSj fiu ,aVj djuk gksxkA ;wtj use] ikloMZ vkSj fiu ijh{kk ds le; fn;k tk;sxkA d`i;k bl ckr dks lqfuf'pr dj ysa fd LØhu ij n'kkZ;k x;k vkidk fooj.k lgh gSA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">5.</span>mu Nk=ksa dks ijh{kk dsUnz esa izos'k ugha djus fn;k tk;sxk ftuds izos'k i= ij muds QksVks dh gkMZ dkWih ugha yxh gq;h gSA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">6.</span>ijh{kkFkhZ dks oh{kd dh mifLFkfr esa izos'k i= esa fn;s x;s LFkku ij gLrk{kj djuk gksxkA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">7.</span>ijh{kkFkhZ dks izos'k i= lR;kiu ds ckn gh ijh{kk d{k esa izos'k fn;k tk;sxkA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">8.</span>izos'k i= ij n'kkZ, x, LFkku ,oa le; ij mifLFkr gksuk ijh{kkFkhZ dk nkf;Ro gksxkA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">9.</span>izR;sd ijh{kkFkhZ dks vkWuykbu ijh{kk nsus ds fy, ,d&,d dEI;wVj fn;k tk;sxkA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">10.</span>udyh ijh{kk ¿ekWd ,DtkeÀ ijh{kkFkhZ dks dEI;wVj vk/kkfjr vkWuykbu ijh{kk nsus ds fy, lgk;rk djsxkA vPNh rjg ls ifjfpr gksus ds fy, ijh{kkFkhZ ftruh ckj pkgsa mruh ckj udyh ijh{kk ¿EkkWd ,DtkeÀ ns ldrs gSA udyh ijh{kk ¿ekWd ,DtkeÀ osclkbZV 
 <span style="font-family: Arial, Helvetica, sans-serif; font-size:16px;">mpiti.cbtexam.in</span> ij miyC/k gSA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">11.</span>ijh{kk dsUnz esa ijh{kk izkjaHk gksus ds 15 fefuV ckn rd gh izos”k dh vuqefr nh tkosxhA blds ckn fdlh Hkh ifjfLFkrh esa ijh{kkFkhZ dks izos'k djus ugha fn;k tk;sxkA</li>

<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">12.</span>ijh{kkFkhZ dks vius lkFk dsoy isu@isfUly vkSj ijh{kk ds nLrkost ¿izos'k i=] izekf.kr igpku i=À ykuk gksxkA</li>
    
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">13.</span>mijksDr ds vfrfjDr vU; oLrq,¡ tSls% eksckbZy Qksu] cSx] midj.k] fdrkcsa ¿cqDlÀ] dkWfi;k ¿uksVcqdÀ] ?kM+h] istlZ] lSy QksUl bR;kfn oLrqvksa dks ijh{kk gkWy ds vUnj ys tkus dh vuqefr ugha gSA ijh{kkFkhZ dh dksbZ Hkh oLrq pksjh gks tkus ;k xqe gks tkus ij] ijh{kk e.My@ dsUnz dh ftEesnkjh ugha gksxhA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">14.</span>ijh{kk ds nkSjku dksbZ Hkh ijh{kkFkhZ ;fn fdlh vuqfpr ek/;e dk lgkjk ysrs gq, ik;k x;k ;k dksbZ vuqfpr O;ogkj djrs gq, ik;k x;k rks og ijh{kk nsus ds fy, v;ksX; Bgjk;k tk,xk] ftlesa ijh{kk ds nkSjku fdlh Hkh vH;FkhZ dks enn djuk ;k mlls enn ysuk Hkh 'kkfey gSA</li>
<br/>
<li>fuEufyf[kr esa ls dksbZ Hkh fØ;kdyki@ xfrfof/k ijh{kkFkhZ }kjk mi;ksx esa ykus ij mls vuqfpr lk/ku       ¿vu Qs;j ehUlÀ ds varxZr ekuk tkosxkA</li>
<ol style="list-style:none;">
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">1.</span>ijh{kkfFkZ;ksa dks vius izos'k i= esa fdlh Hkh izdkj dh tkudkjh esa dkaVNkV djus ijA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">2.</span>ijh{kk d{k esa vU; ijh{kkFkhZ ls fdlh Hkh izdkj dk lEidZ@udy djrs ik;s tkus ijA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">3.</span>vius LFkku ij fdlh vU; O;fDr ls ijh{kk fnykuk ;k ijh{kkFkhZ ds LFkku ij vU; dksbZ O;fDr mifLFkr gksus ijA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">4.</span>ijh{kk d{k esa vius ikl fdlh Hkh izdkj dh izfrcaf/kr lkexzh j[kukA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">5.</span>ijh{kk ds nkSjku fpYykuk] cksyuk] dkukQwlh djuk] b'kkjs djuk o vU; izdkj ls laidZ lk/kukA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">6.</span>l{ke vf/kdkjh ds funsZ”kksa dh vogsyuk@voKk djuk ;k muds funsZ'kksa dk ikyu u djukA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">7.</span>ijh{kk dk;Z esa yxs deZpkjh@ vf/kdkjh dks ijs'kku djuk] /kedkuk ;k 'kkjhfjd pksV igqapkukA</li>
<br/>
<li><strong><span style="background:#ffff00;">uksV%& </span></strong>mi;qZDr vuqfpr lk/kuksa dk mi;ksx djus ij vH;FkhZ ds fo:) U;kkf;d dk;Zokgh dh tkosxh]
      iz'u i= dk ewY;kadu ugha fd;k tkosxk rFkk mldk vH;fFkZRo fujLr dj fn;k tkosxkA



</li>
<br/>
</ol>

<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">15.</span>ijh{kk dsUnzkLFky ifjorZu ds fy, fdlh Hkh vkosnu dks Lohdkj ugha fd;k tkosxkA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">16.</span>ijh{kkfFkZ;ksa dks ijh{kk ds nkSjku oh{kd }kjk fn;s x;s funsZ'kksa dk ikyu djuk vfuok;Z gSA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">17.</span>izkpk;Z }kjk lR;kfir vH;FkhZ dks viuk ikliksVZ lkbZt QksVks izos'k i= esa fu/kkZfjr LFkku ij fpidkuk vfuok;Z gSaA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block;">18.</span>vH;FkhZ ijh{kk ds vafre fnu izos'k i= ijh{kk gkWy esa tek djok dj tkosaA ;g lqfuf'fpr djsa fd izos'k i= dh ,d izfrfyfi vH;FkhZ dks vius ikl j[kuk vfuok;Z gSA</li>
<li><span style="font-family: Arial, Helvetica, sans-serif; font-size:14px; margin:0px 8px 0px 0px; display:inline-block; font-weight:bold;">19.</span><strong>vH;FkhZ dks de ls de 60 fefuV rd ijh{kk gkWy esa cSBuk vfuok;Z gS ,oa iz'u&i= lcfeV djus ds ckn gh ijh{kk gkWy ls tkus dh vuqefr nh tkosxhA</strong></li>
    

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
