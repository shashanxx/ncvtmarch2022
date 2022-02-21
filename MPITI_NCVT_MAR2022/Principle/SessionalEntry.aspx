<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionalEntry.aspx.cs" Inherits="Principle_DownloadAdmitCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sessional Marks Entry</title>
    <style>
        .ddlstyle {
            height: 25px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            debugger;
            var e = event || evt;
            var charCode = (e.which) ? e.which : e.keyCode
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 64 || charCode > 91) && (charCode < 96 || charCode > 122)) {
                alert("Enter a valid marks!!");

                return false;
            }

            return true;
        }
        function onlyNumbersWithDot2Decimal(a,evt)
        {
            alert(a);
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if (charCode == 46)
                return true
            if ((charCode > 64 && charCode < 66) || (charCode > 96 && charCode < 98) || charCode == 8 || charCode == 46 || (charCode > 47 && charCode < 58)) {
                
                var attenance = document.getElementById(a).value;
                var ex = /^[0-9]+\.?[0-9]*$/;
                if (ex.test(attenance.value) == false) {
                    alert(attenance.value);
                    attenance.value = attenance.value.substring(0, attenance.value.length - 1);
                    
                }
                    
                return true;
            }
        }

        function onlyNumbersWithDot(evt) {
           
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if (charCode == 46)
                return true
            //if (charCode > 31 && (charCode < 48 || charCode > 57))
            if ((charCode > 64 && charCode < 66) || (charCode > 96 && charCode < 98) || charCode == 8 || charCode == 46 || (charCode > 47 && charCode < 58)) {
                return true;
            }
            else {
                return false;
            }

        }

        function onlyNumbersWithDot(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if (charCode == 46)
                return true
            //if (charCode > 31 && (charCode < 48 || charCode > 57))
            if ((charCode > 64 && charCode < 66) || (charCode > 96 && charCode < 98) || charCode == 8 || charCode == 46 || (charCode > 47 && charCode < 58)) {
                return true;
            }
            else {
                return false;
            }

        }

        function fnAllowAlphaNumerics(e) {
            var key;
            if (window.event)
                key = window.event.keyCode;     //IE
            else
                key = e.which;                  //Firefox
            if ((key > 64 && key < 66) || (key > 96 && key < 98) || key == 8 || key == 46 || (key > 47 && key < 58)) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
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
                    <%--<asp:LinkButton ID="lnkreport" runat="server" OnClick="lnkreport_Click" style="float:right; margin-right:10%;">Summary Report</asp:LinkButton>--%>
                    <asp:LinkButton ID="lnkreportD" runat="server" OnClick="lnkreportD_Click" Style="float: right; margin-right: 10%;">Detailed Report</asp:LinkButton>
                </td>
            </tr>
            <tr style="background-color: #d8b377; height: 25px;">
                <td colspan="20" style="height: 25px; text-align: left; padding-left: 15%">Sessional Marks Entry
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
                                            <span style="color: red;">*&nbsp;</span>
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
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%; font-weight: bold;">
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
                                            <span style="color: red;">*&nbsp;</span>
                                        </td>
                                        <td style="width: 15%; height: 25px; font-weight: bold;">
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
                                            <span style="color: red;">*&nbsp;</span>
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
                                        <td>
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="tr_gridview1" runat="server">
                                        <td>&nbsp;
                                        </td>
                                        <td colspan="10">
                                            <div style="height: 180px; overflow-y: scroll; font-size: 12px;">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" AutoPostBack="true" OnCheckedChanged="checkAll_CheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="checkCan" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Roll No" DataField="RollNo" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:TemplateField HeaderText="Trade Theory sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTraineeID" Text='<%# Bind("TraineeID") %>' runat="server" Visible="false"></asp:Label>
                                                                <asp:TextBox ID="txtTradeTheorySessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Workshop Calc and Science Sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtWorkshopCalcSessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Engineering Drawing Sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtEDSessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trade Practical Sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTradePracticalSessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trade Practical II" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTradePracticalII" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Project Work" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtProjectWork" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Trade Practical II Sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTradePracticalIISessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>

                                     <tr id="tr_gridview2" runat="server">
                                        <td>&nbsp;
                                        </td>
                                        <td colspan="10">
                                            <div style="height: 180px; overflow-y: scroll; font-size: 12px;">
                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width="100%" >
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" AutoPostBack="true" OnCheckedChanged="checkAll_CheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="checkCan" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Roll No" DataField="RollNo" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:TemplateField HeaderText="Trade Theory sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTradeTheorySessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Workshop Calc and Science Sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtWorkshopCalcSessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Engineering Drawing Sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtEDSessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trade Practical Sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTradePracticalSessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trade Practical II" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTradePracticalII" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Project Work" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtProjectWork" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Trade Practical II Sessional" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTradePracticalIISessional" runat="server" oncopy="false" oncut="false" MaxLength="3" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        

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
                                        <td style="height: 50px;">
                                            <asp:Button ID="btn_Otp" runat="server" Visible="false" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Generate OTP" />
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_otp" Visible="false" runat="server" placeholder="Enter OTP"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td colspan="4">&nbsp; &nbsp; &nbsp;
                                                        <asp:Button ID="btnsave" runat="server" OnClick="Button1_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Save" />
                                            &nbsp;<asp:Button ID="btnprint" runat="server" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Print" OnClick="btnprint_Click" />
                                        </td>
                                        <td>&nbsp;
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
