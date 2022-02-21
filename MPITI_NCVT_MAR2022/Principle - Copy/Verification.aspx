<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Verification.aspx.cs" Inherits="Principle_Verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <table style="width: 100%; font-family: Verdana; background-image: url('../images/back.jpg');"
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
                                <td></td>
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
                   <%--     <nav>
                                    <ul class="nav">
                                        <li><a href="ExamCenter.aspx">Add OMR</a></li>
                                  <li><a href="EditExamCenter.aspx">Update OMR</a></li>
                                        
                                       
                                        <li><a href="#">Reports</a>
                                            <ul>
                                              <li><a href="ExamCenterReport.aspx">Report1</a></li>
                                   
                                            <li><a href="CenterwiseCountReport.aspx">Report2</a></li>
                                            </ul>
                                        </li>
                                        <li><a href="CorrectOMRs.aspx">Update Paper Detail</a></li>
                                         <li><asp:Button ID="btnchangepass" runat="server" Text="Change Password" OnClick="btnchangepass_Click" BackColor="#776655" ForeColor="White" Font-Bold="True" Height="30px" /></li>
                                                       <li><asp:Button ID="btnlogout" runat="server" Text="Logout"  BackColor="#776655" ForeColor="White" Font-Bold="True" Height="30px" OnClick="btnlogout_Click" /></li>
                                    </ul>
                                </nav>--%>
                        <!--Menu code end-->

                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="width: 10%;"></td>
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
                                        <tr style="background-color: #d8b377; height: 25px;">
                                            <td style="width: 5%;"></td>
                                            <td colspan="10" style="font-size: 15px; font-weight: bold;">Principle Verification
                                            </td>
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
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 25px;">
                                                <asp:Label ID="lbl1" runat="server" Text="Exam Type :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="8">
                                                <asp:DropDownList ID="ddlexamtype" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlexamtype_SelectedIndexChanged">
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
                                            <td style="width: 15%; height: 25px;">
                                                <asp:Label ID="lblTradeName" runat="server" Text="Trade Name :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlTradeName" runat="server" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%;">
                                                <asp:Label ID="lblSemester" runat="server" Text="Semester :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="2" style="width: 27%;">
                                                <asp:DropDownList ID="ddlSemester" runat="server" Width="200px">
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
                                                        <%--<asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="GenerateReport" Visible="false" Enabled="false" />--%>
                                            &nbsp;<asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                />
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="HiddenFieldLoginId" runat="server" />
                                            </td>
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
                                            <td colspan="11">
                                      


                                            </td>

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
                                                    <div style="height: 250px; overflow-y: scroll; font-size: 12px;">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>


                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                                                    <Columns>
                                                                       <%-- <asp:TemplateField HeaderStyle-Width="3%">
                                                                            <HeaderTemplate>
                                                                                <asp:CheckBox ID="checkAll" runat="server" AutoPostBack="true" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="checkCan" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="3%" />
                                                                        </asp:TemplateField>--%>
                                                                        <%--<asp:BoundField HeaderText="Sr.No" DataField="Row" />--%>
                                                                        <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Roll Number" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>
                                                                                 <asp:Label ID="lblrollnumber" Text='<%# Bind("RollNumber") %>' runat="server" Visible="true"></asp:Label>
            
                                                                                     
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>                                                                   
                                                                        <asp:BoundField DataField="Name" HeaderStyle-Width="10%" HeaderText="Candidate Name" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderStyle Width="10%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                         <asp:BoundField DataField="FatherName" HeaderStyle-Width="10%" HeaderText="Father Name" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderStyle Width="10%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                         <asp:BoundField DataField="DOB" HeaderStyle-Width="10%" HeaderText="DOB" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderStyle Width="10%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                     
                                                                   
                                                                           <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Paper1" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>
                                                                              <%--   <asp:Label ID="lblppr1" Text='<%# Bind("Paper1") %>' runat="server" Visible="true"></asp:Label>--%>
            
                                                                                       <asp:CheckBox ID="chkpprtradetheory" runat="server"  />
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        
                                                                           <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Paper2" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>
                                                                          <%--       <asp:Label ID="lblppr2" Text='<%# Bind("Paper2") %>' runat="server" Visible="true"></asp:Label>--%>
            
                                                                                       <asp:CheckBox ID="chkEmployabilitySkills" runat="server" />
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                      
                                                                        <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Paper 3" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>

                                                                                        <asp:CheckBox ID="chkWorkshopCalcScience" runat="server" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        
                                                                 <asp:TemplateField  HeaderStyle-Width="8%" HeaderText="Paper 4"  ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>

                                                                                        <asp:CheckBox ID="chkEngineeringDrawing" runat="server" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>


                                                                         <asp:TemplateField  HeaderStyle-Width="8%" HeaderText="Practical"  ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel runat="server">
                                                                                    <ContentTemplate>

                                                                                        <asp:CheckBox ID="chkpractical" runat="server" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="12%" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                    

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </td>
                                                <td>&nbsp; </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp; </td>
                                                <td style="height: 50px;" colspan="10" align="right">
                                                    <asp:HiddenField ID="hdnExaminerId" runat="server" />
                                                    <asp:HiddenField ID="hdnAlert" runat="server" />
                                                    &nbsp; &nbsp;
                                                            
                                                           <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Save"  />&nbsp;
                                                            <asp:Button ID="btnPrint" runat="server" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Print" Visible="false" Enabled="false" />

                               
                                                </td>
                                                <td>&nbsp; </td>
                                            </tr>
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
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    
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
                            </tr>
                        </table>
                    </td>
                    <td colspan="3" style="width: 10%;"></td>
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
                    <td colspan="14"></td>
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
        </div>
    </form>
</body>
</html>
