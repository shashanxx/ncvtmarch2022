<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="Principle_Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thanks Page</title>
    <script type="text/javascript">

        function PrintDiv() {
            document.getElementById("tbl1").style.display = 'none';
            document.getElementById("btnPrint").style.display = 'none';
            document.getElementById("btnExit").style.display = 'none';
            var popupWin = window.print('Print.aspx', '_blank', 'width=1000px,height=500px,location=no,left=200px');
        }
    </script>
</head>
<body style="font-family: Arial; font-size: 16px;">
    <form id="form1" runat="server">
        <table id="tbl1" style="width: 100%; font-family: Arial; background-image: url('../images/back.jpg');"
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
                <td colspan="20" style="height: 25px; float: left; margin-left: 50px; margin-left: 15%; margin-right: 15%;">Payment Acknowledgement
                </td>
            </tr>
        </table>
        <div width="100%" style="margin-top: 20px;">
            <div style="text-align:center; font-weight:bold; margin-bottom:50px;">ITI Code : <asp:Label ID="lblItiCode" runat="server" style="margin-right:20px;"></asp:Label> ITI Name : <asp:Label ID="lblItiName" runat="server"></asp:Label></div>
            <div><asp:Label ID="lblPID" runat="server" Style="font-weight: bold;"></asp:Label></div>
            <div id="dvstatus" runat="server"></div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" HeaderStyle-BackColor="#cc632a" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Roll No" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("RollNumber") %>'></asp:Label>
                        </ItemTemplate>

                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Father's Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFatherName" runat="server" Text='<%# Eval("FatherName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date of Birth(DDMMYYYY)" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Admission Year" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblAdmissionYear" runat="server" Text='<%# Eval("AdmissionYear") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trade" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTrade" runat="server" Text='<%# Eval("Trade") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Semester" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblSemester" runat="server" Text='<%# Eval("Semester") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exam Type" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblExamtype" runat="server" Text='<%# Eval("Examtype") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Candidate's Eligibility" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCanEligibility" runat="server" Text='<%# Eval("Eligibility") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Candidate's Approval Status" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblApprovalStatus" runat="server" Text='<%# Eval("ApprovalStatus") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="Paper1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkPaper1" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper1")) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paper2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkPaper2" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper2")) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paper3" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkPaper3" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper3")) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Workshop Calc & Science" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkWorkshopCalc" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("WorkshopCalcScience")) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Engineering Drawing" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEngDrawing" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("EngineeringDrawing")) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Practical" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkPractical" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("practical")) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>

                    

                    <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtAmount" runat="server" Style="color: black; margin-left: 20px; border: none" Enabled="false" BackColor="#ffffff" Text='<%# Eval("Amount") %>' Width="50px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Payment Status" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnPayMode" runat="server" Value='<%# Eval("PaymentMode") %>' />
                            <asp:HiddenField ID="hdnTID" runat="server" Value='<%# Eval("TID") %>' />
                            <asp:Label ID="lblPaymentStatus" style="font-weight:bold" runat="server" Text='<%# Eval("PaymentStatus") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                        <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                    </asp:TemplateField>

                    
                </Columns>

                <HeaderStyle BackColor="#CC632A"></HeaderStyle>
            </asp:GridView>
            <div style="margin-top: 10px; float: right;" id="divtotal" runat="server" visible="false">
                Total no of students :
                <asp:Label ID="lbltotalstucount" runat="server" Text="0"></asp:Label>&nbsp;&nbsp
                                                                    Total Payment :
                <asp:Label ID="lbltotalstuPayment" runat="server" Text="0"></asp:Label>
            </div>
            <br />
            <div style="margin-top: 30px;" id="divPrincipalInfo" runat="server" visible="false">
                Principal Name: <asp:label ID="lblPName" runat="server" style="margin:0px 70px 0px 5px; height:25px;"></asp:label>   
                Principal Mobile Number: <asp:label ID="lblPMobileNo" runat="server" style="margin:0px 40px 0px 5px; height:25px;"></asp:label> 
            </div>
            <br />
            <div style="margin-top: 30px;">
                <asp:Button ID="btnPrint" runat="server" Text="Print Payment Summary" OnClientClick="PrintDiv();" Style="width: 170px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;" />
                <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Exit" />
            </div>
        </div>
    </form>
</body>
</html>
