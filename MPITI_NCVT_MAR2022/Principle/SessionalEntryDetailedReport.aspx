<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionalEntryDetailedReport.aspx.cs" Inherits="Principle_DownloadAdmitCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sessional Detailed Report</title>
    <style>
        .ddlstyle{
            height:25px;
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
                <td colspan="20" style="height: 25px; text-align: left; padding-left:15%">
                    Sessional Detailed Report
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
                                            <asp:Label ID="lbladmYear" runat="server" Text="Admission Year :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlAdmissionYear" OnSelectedIndexChanged="ddlAdmissionYear_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="ddlstyle" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; font-weight:bold;">
                                            <asp:Label ID="lblTradeName" runat="server" Text="Trade Name :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlTradeName" runat="server" CssClass="ddlstyle" Width="200px">
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
                                            <asp:Label ID="lblSemester" runat="server" Text="Semester :"></asp:Label>

                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlSemester" runat="server" CssClass="ddlstyle" Width="200px">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Sem 1</asp:ListItem>
                                                <asp:ListItem Value="2">Sem 2</asp:ListItem>
                                                <asp:ListItem Value="3">Sem 3</asp:ListItem>
                                                <asp:ListItem Value="4">Sem 4</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <%--<span style="color: red;">*&nbsp;</span>--%>
                                        </td>
                                        <td style="width: 15%; font-weight:bold;">
                                            <asp:Label ID="lblExamType" runat="server" Text="Exam Type :"></asp:Label>
                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2" style="width: 27%;">
                                            <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="ddlstyle" Width="200px">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="Reg">Reg</asp:ListItem>
                                               <%-- <asp:ListItem Value="Ex">Ex</asp:ListItem>--%>
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
                                        </tr>

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
                                            <td><asp:HiddenField ID="HiddenField2" runat="server" /></td>
                                            <td></td>
                                        </tr>                                    
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="10">
                                                <div  id="div_sem" runat="server" style="height: 180px; overflow-y: scroll; font-size: 12px;">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" >
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Roll No" DataField="RollNo" ItemStyle-HorizontalAlign="Center" />                                                            
                                                            <asp:BoundField HeaderText="Trade Theory Sessional" DataField="TradeTheorySessional" ItemStyle-HorizontalAlign="Center" /> 
                                                            <asp:BoundField HeaderText="Workshop Calc Sessional" DataField="WorkshopCalcSessional" ItemStyle-HorizontalAlign="Center" />      
                                                            <asp:BoundField HeaderText="ED Sessional" DataField="EDSessional" ItemStyle-HorizontalAlign="Center" />  
                                                            <asp:BoundField HeaderText="TradePracticalSessional" DataField="TradePracticalSessional" ItemStyle-HorizontalAlign="Center" />  
                                                            <asp:BoundField HeaderText="TradePracticalII" DataField="TradePracticalII" ItemStyle-HorizontalAlign="Center" />  
                                                            <asp:BoundField HeaderText="ProjectWork" DataField="ProjectWork" ItemStyle-HorizontalAlign="Center" />  
                                                            <asp:BoundField HeaderText="TradePracticalIISessional" DataField="TradePracticalIISessional" ItemStyle-HorizontalAlign="Center" />  
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    <tr >
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="10">
                                                <div id="div_year" runat="server" style="height: 180px; overflow-y: scroll; font-size: 12px;">
                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width="100%" >
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Roll No" DataField="RollNo" ItemStyle-HorizontalAlign="Center" />                                                            
                                                            <asp:BoundField HeaderText="Trade Theory Sessional" DataField="TradeTheorySessional" ItemStyle-HorizontalAlign="Center" /> 
                                                            <asp:BoundField HeaderText="Workshop Calc Sessional" DataField="WorkshopCalcSessional" ItemStyle-HorizontalAlign="Center" />      
                                                            <asp:BoundField HeaderText="ED Sessional" DataField="EDSessional" ItemStyle-HorizontalAlign="Center" />  
                                                            <asp:BoundField HeaderText="TradePracticalSessional" DataField="TradePracticalSessional" ItemStyle-HorizontalAlign="Center" />  
                                                            <asp:BoundField HeaderText="TradePracticalII" DataField="TradePracticalII" ItemStyle-HorizontalAlign="Center" />  
                                                            <asp:BoundField HeaderText="ProjectWork" DataField="ProjectWork" ItemStyle-HorizontalAlign="Center" />  
                                                            <asp:BoundField HeaderText="TradePracticalIISessional" DataField="TradePracticalIISessional" ItemStyle-HorizontalAlign="Center" />  
                                                            <%--<asp:BoundField HeaderText="Exists District" DataField="ExistsDistrict" ItemStyle-HorizontalAlign="Center" />--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12" align="right">
                                                <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel" Visible="false" Style="width:200px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                    OnClick="btnExportToExcel_Click" />
                                            </td>
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
