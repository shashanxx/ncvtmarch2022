<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DDPaymentSummary.aspx.cs" Inherits="Principle_PaymentSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Summary</title>
    <script src="../js/newPortal_validations.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ValidateControls()
        {
            var PName = document.getElementById('txtPName');
            var PMobileNo = document.getElementById('txtPMobileNo');
            var CHKAGR = document.getElementById('CHKAGR');
            if (PName.value == "")
            {
                PName.focus();
                alert('Please Enter Prinicipal Name');
                return false;
            }
            if (PMobileNo.value == "") {
                PMobileNo.focus();
                alert('Please Enter Principal Mobile Number');
                return false;
            }
            if (PMobileNo.value.length < 10)
            {
                PMobileNo.focus();
                alert('Please Enter Valid Mobile Number');
                return false;
            }
            if (!CHKAGR.checked) {
                CHKAGR.focus();
                alert('Please Select Disclaimer');
                return false;
            }

            return true;
        }
    </script>
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
                <td colspan="20" style="height: 25px; float: left; margin-left: 50px; margin-left: 15%; margin-right: 15%;">Payment Summary
                </td>
            </tr>
        </table>
        <div width="100%" style="margin-top: 20px;">
            <div id="OldTrans" runat="server" style="margin:7px; color:red;"></div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" HeaderStyle-BackColor="#cc632a">
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
                            <asp:Label ID="lblSemester" runat="server" Text='<%# Eval("Year") %>'></asp:Label>
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
            <div style="margin-top: 30px;" id="divDisclaimer" runat="server" visible="false">
                <span style="color: red;">*&nbsp;</span>Principal Name: <asp:TextBox ID="txtPName" runat="server" style="margin:0px 70px 0px 20px; height:25px; border:1px solid #808080;"></asp:TextBox>   
                <span style="color: red;">*&nbsp;</span>Principal Mobile Number: <asp:TextBox ID="txtPMobileNo" runat="server" style="margin:0px 40px 0px 20px; height:25px; border:1px solid #808080;" MaxLength="10" onkeypress="return CreateNumericTextControl(this,event,false)"></asp:TextBox> 
                <br />
                <div style="margin-top:90px;"><span style="color: red;">*&nbsp;</span>
                <asp:CheckBox ID="CHKAGR" runat="server" />
                       I have checked and hereby confirm all the details given are best to my knowledge.
                    </div>
            </div>
            <br />
            <div style="margin-top: 0px; margin-bottom:20px;">
                <asp:Button ID="btnTerminate" runat="server" Text="Terminate Existing Transaction" Style="width: 230px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;display:none;" OnClick="btnTerminate_Click" Visible="false" />
                <asp:Button ID="btnProceed" runat="server" Text="Proceed to Payment Online Mode" Style="width: 230px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;display:none;" OnClick="btnProceed_Click" Visible="false" OnClientClick="return ValidateControls();" />
                <asp:Button ID="btnProceedDD" runat="server" Text="Proceed to Payment DD Mode" Style="width: 230px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;" OnClick="btnProceedDD_Click" Visible="true" OnClientClick="return ValidateControls();" />
                <asp:Button ID="btnFinalVerify" runat="server" Text="Verify" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnFinalVerify_Click" Visible="false" OnClientClick="return ValidateControls();" />
                <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Exit" />
            </div>
        </div>
    </form>
</body>
</html>
