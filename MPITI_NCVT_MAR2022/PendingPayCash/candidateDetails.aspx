<%@ Page Language="C#" AutoEventWireup="true" CodeFile="candidateDetails.aspx.cs" Inherits="JD_DD_Approval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Candidate Details</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../js/newPortal_validations.js"></script>
    
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
    </style>

</head>
<body style="background-color: #e6e6e6; font-family: Arial; font-size: 16px; padding: 8px;">
    <form id="form1" runat="server">
        <div>
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
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/iti.png" Height="75px" />
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
                        <asp:Label ID="lblUName" runat="server" Text="" Style="margin-left: 10%; font-weight: bolder; color: black; font-size: 16px;"></asp:Label>
                        

                    </td>
                </tr>

            </table>

            <table id="tbNonOTP" style="width: 100%; font-family: Verdana; background-image: url('../images/back.jpg');"
                cellpadding="0" cellspacing="0">

                <tr>
                    <td colspan="3" style="width: 15%;"></td>
                    <td colspan="14" rowspan="15">
                        <table style="width: 100%; border: 1px solid grey;">
                            <tr>
                                <td colspan="12"></td>
                            </tr>
                            <tr>
                                <td style="width: 5%;"></td>
                                <td colspan="10" rowspan="13">
                                    <table style="width: 100%; border: 1px solid grey; font-size: 14px; border-radius: 8px;"
                                        cellpadding="0" cellspacing="0">
                                        <tr style="background-color: #d8b377; height: 30px;">
                                            <td style="width: 5%;"></td>
                                            <td colspan="10" style="font-size: 15px; font-weight: bold;">Candidate Details
                                            </td>
                                            <td style="width: 5%;"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 5%; height: 20px;">&nbsp;
                                            </td>
                                            <td colspan="10">&nbsp;
                                            </td>
                                            <td style="width: 5%;">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td colspan="4" style="height: 35px; color: red; vertical-align: middle;">
                                                <asp:Label ID="lblCMessage" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="10">
                                                <div style="max-height: 1000px; overflow-y: scroll; font-size: 12px;">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="zone" DataField="zone" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="ITICode" DataField="ITICode" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="ITIName" DataField="ITIName" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Trade" DataField="Trade" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="semester" DataField="semester" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="CandidateName" DataField="CandidateName" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="RollNumber" DataField="RollNumber" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="ADMISSIONYEAR" DataField="ADMISSIONYEAR" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Paper1Status" DataField="Paper1Status" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Paper2Status" DataField="Paper2Status" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Paper3Status" DataField="Paper3Status" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="PracticalStatus" DataField="PracticalStatus" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12" align="right">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12" align="center"><asp:Button ID="btnprint" runat="server" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Download Report" OnClick="btnprint_Click" Visible="false"/>
                                                <br />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td style="height: 50px;"></td>
                                            <td>&nbsp;
                                            </td>
                                            <td></td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="4">&nbsp; &nbsp; &nbsp;
                                                        
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 5%;"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
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
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="3" style="width: 15%;"></td>
                </tr>
                <tr>
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
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
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
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
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
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
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
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
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
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
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
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
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
                    <td></td>
                    <td></td>
                    <td></td>
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
                    <td></td>
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
                    <td></td>
                </tr>
            </table>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <table>
                        <tr>
                            <td align="center">
                                <div id="Background" align="center"></div>
                                <div id="Progress" align="center">
                                    <img src="../loader.gif" style="vertical-align: middle" />
                                    Fetching Records Please Wait...
                                </div>
                            </td>
                        </tr>
                    </table>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </form>
</body>
</html>
