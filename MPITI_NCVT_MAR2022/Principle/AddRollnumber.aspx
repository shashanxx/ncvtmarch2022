<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRollnumber.aspx.cs" Inherits="Principle_AddRollnumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add RollNumber</title>
    <style>
        .ddlstyle {
            height: 25px;
        }
    </style>
</head>
<body style="font-family: Arial; font-size: 16px;">
    <form id="form1" runat="server">
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
                <td colspan="20" style="height: 25px; text-align: left; padding-left: 15%">Add RollNumber
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
                                            <asp:DropDownList ID="ddlAdmissionYear" AutoPostBack="true" OnSelectedIndexChanged="ddlAdmissionYear_change" runat="server" CssClass="ddlstyle" Width="200px">
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
                                            <asp:Label ID="lblSemester" runat="server" Text="Semester/Year :"></asp:Label>

                                        </td>
                                        <td style="width: 2%;"></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlSemester" runat="server" CssClass="ddlstyle" Width="200px">  
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="1" Value="2"></asp:ListItem>
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
                                                &nbsp;</td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        
                                        
                                    </tr>

                                </table>

                                <script>
                                    function isNumber(evt) {
                                        evt = (evt) ? evt : window.event;
                                        var charCode = (evt.which) ? evt.which : evt.keyCode;
                                        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                                            return false;
                                        }
                                        return true;
                                    }
                                </script>
                                <center><asp:Label ID="Label1" runat="server" style="color:red;" Text="Important Instruction" Font-Bold="true"></asp:Label></center>
                                <center><asp:Label ID="Label2" runat="server" style="color:red;" Text="&#8220;Please enter the roll number of the student after 19082.&#8221;" Font-Bold="true"></asp:Label></center>
                                <center><asp:Label ID="Label3" runat="server" style="color:red;" Text="&#8220;कृपया विधार्थी का 19082 के बाद का रोल नंबर दर्ज करें।&#8221;" Font-Bold="true"></asp:Label></center>
                                <br />
                                <asp:Label ID="errormsg" runat="server" style="color:red;"></asp:Label>
                                <asp:GridView  ID="gv" runat="server"  OnRowEditing="Editdata" OnPageIndexChanging="pageddata" OnRowUpdating="Updatedata" OnRowCancelingEdit="Canceldata" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:TemplateField HeaderText="RollNumber" >
                <ItemTemplate>
                    
                    <asp:Label ID="lblRollNumber" runat="server" Text='<%#Eval("RollNumber") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate >
                    <asp:Label ID="lblStartingRollNo2" runat="server" Text="19082"></asp:Label>
                    <asp:TextBox ID="txRollNumber" MaxLength="10" TextMode="SingleLine" onkeypress="return isNumber(event);" runat="server" Text='<%#Eval("RollNumber") %>'></asp:TextBox>
                    <asp:regularexpressionvalidator id="RegularExpressionValidator1" ControlToValidate="txRollNumber" ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" >
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FatherName" >
                <ItemTemplate>
                    <asp:Label ID="lblFatherName" runat="server" Text='<%#Eval("FatherName") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOB" >
                <ItemTemplate>
                    <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="admissionyear" >
                <ItemTemplate>
                    <asp:Label ID="lbladmissionyear" runat="server" Text='<%#Eval("admissionyear") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Semester" >
                <ItemTemplate>
                    <asp:Label ID="lblSemester" runat="server" Text='<%#Eval("Semester") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trade" >
                <ItemTemplate>
                    <asp:Label ID="lblTrade" runat="server" Text='<%#Eval("Trade") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ITICode" >
                <ItemTemplate>
                    <asp:Label ID="lblITICode" runat="server" Text='<%#Eval("ITICode") %>'></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ITIname" >
                <ItemTemplate>
                    <asp:Label ID="lblITIname" runat="server" Text='<%#Eval("ITIname") %>'></asp:Label>
                    <asp:HiddenField ID="Hiddenid" runat="server" Value='<%# Eval("id") %>' />
                </ItemTemplate>                
            </asp:TemplateField>            
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
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

