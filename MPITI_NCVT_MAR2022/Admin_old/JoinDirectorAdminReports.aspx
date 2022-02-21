<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JoinDirectorAdminReports.aspx.cs" Inherits="Admin_JoinDirectorAdminReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Site.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../js/newPortal_validations.js"></script>
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 64 || charCode > 91) && (charCode < 96 || charCode > 122)) {
                alert("Enter a valid marks!!");

                return false;
            }

            return true;
        }

        function onlyNumbersWithDot(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if (charCode == 46)
                return true
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <table style="width: 100%; font-family: Verdana; background-image: url('../images/back.jpg');"
                        cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="20" style="background-color: #cc632a; height: 15px;"></td>
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
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Aptech.png" Height="70px"
                                                Width="200px" />
                                        </td>
                                        <td style="width: 14%;"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <span id="date_time" style="color: white;"></span>
                                            <script type="text/javascript">                                    window.onload = date_time('date_time');</script>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="20" style="background-color: #cc632a; height: 25px;" align="right">

                                <!--Menu code start-->
                       <nav>
                                    <ul class="nav">
                                        <li><a href="CenterAdminReport.aspx">OMR Reports</a></li>
                                        <li><a href="JoinDirectorAdminReports.aspx">Join Director Reports</a></li>
                                            <li><a href="CenterAdminOMRMasterData.aspx">Center Master Reports</a></li>
                                        <li><a href="JoinDirectorMasterData.aspx">Join Director Master Reports</a></li>
                                      
                                        
                                    </ul>
                                </nav>
                                <!--Menu code end-->

                            </td>
                        </tr>
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
                                                    <td colspan="10" style="font-size: 15px; font-weight: bold;">Join Director Report
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
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 30px;">
                                                        <asp:Label ID="lblSession" runat="server" Text="Session :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="8">
                                                        <asp:DropDownList ID="ddlSession" runat="server" Width="200px" AutoPostBack="True">
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
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 30px;">
                                                        <asp:Label ID="Label1" runat="server" Text="Semester :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlSemester" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                     <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                             <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                    <asp:Label ID="Label2" runat="server" Text="Entry Type :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;">
                                                        
                                                    </td>
                                                    <td colspan="2" style="width: 27%;">
                                                <asp:DropDownList ID="ddlEntryType" runat="server" Width="200px">
                                                            <asp:ListItem Value="0" Text="Select Entry Type"></asp:ListItem>
                                                           <asp:ListItem Value="ED" Text="Engg. Drawing"></asp:ListItem>
                                                            <asp:ListItem Value="Steno" Text="Steno Practical Marks"></asp:ListItem>
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
                                                        <span style="color: red;">&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 30px;">
                                                      
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2">
                                                        
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        &nbsp;</td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        
                                                    </td>
                                                    <td></td>
                                                </tr>
                              
                                                <tr>
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;"></span>
                                                    </td>
                                                    <td style="width: 15%; height: 30px;">
                                                      
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        
                                                    </td>
                                                   <%-- <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="lblPaper" runat="server" Text="Paper :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlPaper" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 5%;"></td>--%>
                                                </tr>
                                       
                                                <%--<tr>
                                        <td style="vertical-align: middle; text-align: right;">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="height: 30px;">
                                            <asp:Label ID="lblDuration" runat="server" Text="Duration :"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlDuration" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSlot" runat="server" Text="Slot :"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlSlot" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                                                <%--    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="10">
                                            <hr style="color: brown;" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                                <%--<tr>
                                        <td>
                                        </td>
                                        <td style="height: 20px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td colspan="7" align="center">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Search" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnSubmit_Click"
                                                          />&nbsp;
                                            <asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnExit_Click"
                                               />

                                                    </td>
                                                    <td>
                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                    </td>
                                                    <td></td>
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
                                                        <div id="divreports" style="height: 180px; overflow-y: scroll; font-size: 12px;" runat="server">
                                                             <asp:Label Id="lbls1" Text="Session:-" runat="server" Font-Size="14px"></asp:Label> <asp:Label Id="lbls2" Text="" runat="server" Font-Size="14px"></asp:Label>
                                                            <br />
                                                             <asp:Label Id="lblsem1" Text="Semester:-" runat="server" Font-Size="14px"></asp:Label> <asp:Label Id="lblsem2" Text="" runat="server" Font-Size="14px"></asp:Label>
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%">
                                                <Columns>

                                                       <asp:TemplateField HeaderText="Sr.No" ItemStyle-HorizontalAlign="Center">
                                                            
                                                 <ItemTemplate>
                                                 <%#Container.DataItemIndex+1 %>
                                                 </ItemTemplate>
                                                </asp:TemplateField>
                                       
                                             
                                                         <asp:BoundField HeaderText="ITI District" DataField="ITIDistrict" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="ITI Code" DataField="ITICode" ItemStyle-HorizontalAlign="Center" />
                                               
                                                    <asp:BoundField HeaderText="ITI Name" DataField="ITIName" ItemStyle-HorizontalAlign="Center" />
                                                  <%--  <asp:BoundField HeaderText="Entry Type" DataField="JD" ItemStyle-HorizontalAlign="Center" />--%>
                                                    <asp:BoundField HeaderText="Entry Count" DataField="JDCount" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Total Entry Count" DataField="JDTotalCount" ItemStyle-HorizontalAlign="Center" />
                                                    
                                                    
                                                    
                                              
                                                </Columns>
                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td style="height: 50px;">&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="4">&nbsp; &nbsp; &nbsp;
                                                        
                                                        &nbsp;<asp:Button ID="btnprint" runat="server" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Export to Excel" OnClick="btnprint_Click"/>
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