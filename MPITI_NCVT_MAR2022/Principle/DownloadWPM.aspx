<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadWPM.aspx.cs" Inherits="Principle_DownloadAdmitCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Download WPM</title>
    <style>
        .ddlstyle {
            height: 25px;
        }
    </style>
</head>
<body style="font-family: Arial; font-size: 16px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                            <td colspan="3" style="width: 25%;" align="center"></td>
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
                <td colspan="20" style="height: 25px; text-align: center;">
                    <asp:Label ID="lblUName" runat="server" Text="" Style="margin-left: 10%; font-weight: bold;"></asp:Label>
                    <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>
                </td>
            </tr>
            <tr style="background-color: #d8b377; height: 25px;">
                <td colspan="20" style="height: 25px; text-align: left; padding-left: 15%">Download WPM
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 10%;"></td>
                <td colspan="14" rowspan="15">
                    <table style="width: 100%; border: none;">
                        <tr>
                            <td colspan="12"></td>
                        </tr>
                        <tr>
                            <td style="width: 5%;"></td>
                            <td colspan="10" rowspan="13">
                                <table style="width: 100%; border: 1px solid grey; font-size: 14px; border-radius: 8px;"
                                    cellpadding="0" cellspacing="0">
                                    <tr style="background-color: #d8b377; height: 25px;">
                                        <td style="width: 5%;"></td>
                                        <td colspan="10" style="font-size: 15px; font-weight: bold;"></td>
                                        <td style="width: 5%;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 5%; height: 18px;">&nbsp;
                                        </td>
                                        <td colspan="10">&nbsp;
                                        </td>
                                        <td style="width: 5%;">&nbsp;
                                        </td>
                                    </tr>
                                     <tr runat="server" id="ititr" visible="false">
                                        <td style="vertical-align: middle; text-align: right;">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%; height: 25px; font-weight: bold;padding: 12px;">
                                            <asp:Label ID="Label1" runat="server" Text="Select ITI:"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddliti" runat="server"  CssClass="ddlstyle" Width="200px" OnSelectedIndexChanged="ddliti_change" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                         <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            
                                        </td>
                                        <td style="width: 15%; font-weight: bold;">
                                           
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                           
                                        </td>
                                        <td></td>                                       
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; height: 25px; font-weight: bold;">
                                            <asp:Label ID="lbladmYear" runat="server" Text="Admission Year :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlAdmissionYear" AutoPostBack="true" OnSelectedIndexChanged="ddlAdmissionYear_SelectedIndexChanged" runat="server" CssClass="ddlstyle" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; font-weight: bold;">
                                            <asp:Label ID="lblTradeName" runat="server" Text="Trade Name :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlTradeName" runat="server" CssClass="ddlstyle" Width="200px">
                                                <%--<asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="TTTT 243">TTTT 243</asp:ListItem>
                                                    <asp:ListItem Value="TTTT 241">TTTT 241</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; height: 25px; font-weight: bold;">
                                            <asp:Label ID="lblSemester" runat="server" Text="Semester :"></asp:Label>

                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlSemester" runat="server" CssClass="ddlstyle" Width="200px">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; font-weight: bold;">
                                            <asp:Label ID="lblExamType" runat="server" Text="Exam Type :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="ddlstyle" Width="200px">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="Reg">Reg</asp:ListItem>
                                                <asp:ListItem Value="Ex">Ex</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr runat="server" id="byrollnumTital"  Visible="false">
                                        <td>&nbsp;
                                        </td>
                                         <td colspan="3">&nbsp;
                                        </td>
                                        <td colspan="5"  style="text-align:center;font-weight: bold;padding: 10px 0px;">
                                            <span>OR Search By Roll Number</span>
                                        </td>
                                         <td colspan="3">&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr runat="server" id="byrollnumtxtbox"  Visible="false">
                                        
                                        <td>&nbsp;
                                        </td>
                                        <td colspan="3">&nbsp;
                                        </td>
                                        <td colspan="5" style="text-align:center">
                                            <asp:TextBox ID="rollnumber" runat="server" />
                                        </td>
                                        <td colspan="3">&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td style="height: 18px;">&nbsp;
                                        </td>
                                        <td></td>
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
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td colspan="7" align="center">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Search" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                OnClick="btnSubmit_Click" />&nbsp;
                                            &nbsp;<asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnExit_Click" />
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td align="center" colspan="7">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td colspan="11"></td>

                                        <tr>
                                            <td></td>
                                            <td colspan="4" style="height: 25px; color: red; vertical-align: middle;">
                                                <asp:Label ID="lblCMessage" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="12" style="text-align:center;">
                                                <table align="center" cellpadding="0" cellspacing="0" width="90%" border="1" style="border-style: groove" runat="server" id="tbl_note" visible="false"> 
                                                    <tr>
                                                        <td colspan="4"><strong>Browser Print settings should be as follow:</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Layout</td>
                                                        <td><strong>Landscape</strong></td>
                                                        <td>Paper Size</td>
                                                        <td><strong>A4</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Margins</td>
                                                        <td><strong>None</strong></td>
                                                        <td>Scale :</td>
                                                        <td><strong>74</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td  colspan="4" style="padding-left:10px;text-align:left;"><strong><u>Note:</u></strong><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.Tick/Select Background graphics option in Print setting<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2.If Candidate Photo or Barcode is not displaying on marksheet, kindly refresh the marksheet page</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="height:20px;"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp; </td>
                                            <td colspan="10">
                                                <asp:UpdatePanel ID="updategrid" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#cc632a" CellPadding="5" AllowPaging="true" PageSize='<%# Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["PageSize"].ToString()) %>' OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Roll Number" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("[Roll Number]") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DOB(DDMMYYYY)" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Admission Year" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAdmYear" runat="server" Text='<%# Eval("[Admission Year]") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Trade" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTrade" runat="server" Text='<%# Eval("Trade") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sem" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSem" runat="server" Text='<%# Eval("Sem") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Exam Type" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExamType" runat="server" Text='<%# Eval("[Exam Type]") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="100WPM Result" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblWPMResult" runat="server" Text='<%# Eval("[WPMResult]") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Download WPM" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <div id="dvDownload" runat="server" visible="true"><a href="WPM.aspx?rollno=<%# Eval("[Roll Number]") %>" target="_blank">
                                                                            <img runat="server" id="img_pdf" src="pdfImage.png"></img></a></div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>&nbsp; </td>
                                        </tr>
                                    </tr>

                                </table>
                            </td>
                            <td style="width: 5%;"></td>
                        </tr>
                    </table>
                </td>
                <td colspan="3" style="width: 10%;"></td>
            </tr>
        </table>
    </form>
</body>
</html>
