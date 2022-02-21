<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminCompositeReport.aspx.cs" Inherits="Admin_AdminCompositeReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Composite Report</title>
    <style>
        .ddlstyle{
            height:25px;
        }
    </style>
</head>
<body style="font-family: Arial; font-size: 16px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress ID="uprgsMaster" runat="server" DisplayAfter="1" DynamicLayout="false">
                    <ProgressTemplate>
                        <div id="divprogress" align="center" style="width: 100%; height: 100%; min-height: 100%; position: fixed; z-index: 100002; top: 0px; left: 0px; background-color: Gray; filter: alpha(opacity=80); opacity: 0.8; z-index: 10000;">
                            <img id="Img1" alt="Wait" style="opacity: 1; margin-top: 250px;" runat="server" src="~/images/loader_transparent.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
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
                <td colspan="20" style="height: 25px; text-align: center;">
                    <asp:Label ID="lblUName" runat="server" Text="" Style="margin-left: 10%; font-weight: bold;"></asp:Label>
                    <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>
                </td>
            </tr>
            <tr style="background-color: #d8b377; height: 25px;">
                <td colspan="20" style="height: 25px; text-align: left; padding-left: 15%">Admin Composite Report
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
                                    <tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; height: 25px; font-weight:bold;">
                                            <asp:Label ID="lblZone" runat="server" Text="Zone :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlZone" runat="server" CssClass="ddlstyle" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlZone" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; font-weight:bold;">
                                            <asp:Label ID="lblDistrict" runat="server" Text="District :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddlstyle" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlDistrict" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
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
       
                                        </td>
                                        <td style="width: 15%; height: 25px; font-weight:bold;">
                                            <asp:Label ID="Label2" runat="server" Text="ITI Type :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlTTIType" runat="server" CssClass="ddlstyle" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlTTIType_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="PVT" Value="PVT"></asp:ListItem>
                                                <asp:ListItem Text="GOVT" Value="GOVT"></asp:ListItem>
                                            </asp:DropDownList>            
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            
                                        </td>
                                        <td style="width: 15%; font-weight:bold;">
                                            <asp:Label ID="Label1" runat="server" Text="ITI :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                           <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                            <asp:DropDownList ID="ddlITICode" runat="server" CssClass="ddlstyle" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlITICode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                                    </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlITICode" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
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
                                        <td style="width: 15%; height: 25px; font-weight:bold;">
                                            <asp:Label ID="lblTradeName" runat="server" Text="Trade Name :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                            <asp:DropDownList ID="ddlTradeName" runat="server" CssClass="ddlstyle" Width="200px">
                                                <%--<asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="TTTT 243">TTTT 243</asp:ListItem>
                                                    <asp:ListItem Value="TTTT 241">TTTT 241</asp:ListItem>--%>
                                            </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                        </td>
                                        
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; font-weight:bold;">
                                            <asp:Label ID="lbladmYear" runat="server" Text="Admission Year :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlAdmissionYear" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlAdmissionYear_SelectedIndexChanged" CssClass="ddlstyle" Width="200px">
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
                                        <td style="width: 15%; height: 25px; font-weight:bold;">
                                            <asp:Label ID="lblExamType" runat="server" Text="Exam Type :"></asp:Label>

                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="ddlstyle" Width="200px">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="Reg">Reg</asp:ListItem>
                                                <asp:ListItem Value="Ex">Ex</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; font-weight:bold;">
                                            <asp:Label ID="lblSemester" runat="server" Text="Semester :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlSemester" runat="server" CssClass="ddlstyle" Width="200px">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Sem 1</asp:ListItem>
                                                <asp:ListItem Value="2">Sem 2</asp:ListItem>
                                                <asp:ListItem Value="3">Sem 3</asp:ListItem>
                                                <asp:ListItem Value="4">Sem 4</asp:ListItem>
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
                                            <td>&nbsp; </td>
                                            <td colspan="10">
                                                <asp:UpdatePanel ID="updategrid" runat="server">
                                                    <ContentTemplate>
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#cc632a" CellPadding="5" AllowPaging="true" PageSize='<%# Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["PageSize"].ToString()) %>' OnPageIndexChanging="GridView1_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ITI Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblITIName" runat="server" Text='<%# Eval("ITIName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Zone" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("Zone") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="District" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                                                        <asp:TemplateField HeaderText="Sem/Year" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSem" runat="server" Text='<%# Eval("Sem/Year") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Exam Type" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExamType" runat="server" Text='<%# Eval("[Exam Type]") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Choice Locked" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblChoicelocked" runat="server" Text='<%# Eval("[Choice Locked]") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Students Status" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStStatus" runat="server" Text='<%# Eval("[Students Status]") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Paper1" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblp1" runat="server" Text='<%# Eval("Paper1") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Paper2" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblp2" runat="server" Text='<%# Eval("Paper2") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Paper3" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblp3" runat="server" Text='<%# Eval("Paper3") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Practical" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblprac" runat="server" Text='<%# Eval("practical") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Transaction Date and Time" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransactionDate" runat="server" Text='<%# Eval("[Transaction Date and Time]") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("PID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Result Status ED" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblResultStatusED" runat="server" Text='<%# Eval("ResultStatusED") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Result Status Practical" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblResultStatusPractical" runat="server" Text='<%# Eval("ResultStatusPractical") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                        </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div style="margin-top: 30px; margin-bottom: 30px;" id="divReport" runat="server" visible="false">
                                                    <asp:Button ID="btnGenerateExcel" runat="server" Text="Generate Excel" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;" OnClick="btnGenerateExcel_Click" />
                                                    <asp:Button ID="btnGeneratePdf" runat="server" Text="Generate PDF" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnGeneratePdf_Click" />
                                                </div>
                                            </td>
                                            <td>&nbsp; </td>
                                        </tr>
                                        <%--<tr>
                                            <td>&nbsp; </td>
                                            <td style="height: 50px;" colspan="10" align="right">&nbsp; &nbsp;
                                                            
                                                           &nbsp;
                                                            <asp:Button ID="btnPrint" runat="server" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Print" Visible="false" Enabled="false" />


                                            </td>
                                            <td>&nbsp; </td>
                                        </tr>--%>
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
