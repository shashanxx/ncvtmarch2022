<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DirectPracticalMarksEntry.aspx.cs" Inherits="Principle_DirectPracticalMarksEntry" %>

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
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function onlyNumbersWithDot(evt) {
            var txt_marks = document.getElementById('txt_marks');
            var hfUserType = document.getElementById('hfUserType');
            var e = event || evt;
            var charCode = e.which || e.keyCode;

            if (txt_marks.value.toUpperCase() == "NA")
                return false;


            if (hfUserType.value == "6") {
                if (charCode == 97 || charCode == 110 || charCode == 65 || charCode == 78) {
                    if (txt_marks.value.length == 0 && (charCode == 110 || charCode == 78)) {
                        return true
                    }
                    else {
                        if ((charCode == 97 || charCode == 65) && txt_marks.value.toUpperCase() == "N")
                            return true
                        else
                            return false;
                    }
                }
            }

            if (charCode == 8 || (charCode > 47 && charCode < 58) || charCode == 46) {
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
<body style="background-color: #e6e6e6; font-family: Arial; font-size: 16px; padding: 8px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:HiddenField ID="hfUserType" runat="server" />
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
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Dashboard.aspx" Style="float: right; margin-right: 10%;">Home</asp:LinkButton>
                        <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>
                        <%--<asp:LinkButton ID="lnkreport" runat="server" OnClick="lnkreport_Click" style="float:right; margin-right:10%;">Summary Report</asp:LinkButton>
                        <asp:LinkButton ID="lnkreportD" runat="server" OnClick="lnkreportD_Click" style="float:right; margin-right:10%;">Detailed Report</asp:LinkButton>--%>
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
                                            <td colspan="10" style="font-size: 15px; font-weight: bold;">Practical Marks Entry Form
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
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="10">
                                                <hr style="color: brown;" />
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12" style="padding-left: 50px;">
                                                <b>
                                                    <span id="div1" runat="server" style="font-size: 18px; font-family: Calibri;">
                                                        <span style="color: red">Note: Kindly do not enter any Absent candidate entry.
                                                            <br />
                                                            Kindly enter correct and valid- Roll number, Semester and all other fields </span>
                                                        <br />
                                                        <br />
                                                    </span>
                                                </b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 30px;">
                                                <asp:Label ID="Label2" runat="server" Text="Entry Type :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlentrytype" runat="server" Width="200px" OnSelectedIndexChanged="ddlentrytype_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="ED" Text="Engg Drawing"></asp:ListItem>
                                                    <asp:ListItem Value="SE" Text="Stenographer & Secretarial Assistant (English)"></asp:ListItem>
                                                    <asp:ListItem Value="SH" Text="Stenographer & Secretarial Assistant (Hindi)"></asp:ListItem>
                                                    <asp:ListItem Value="SP" Text="Secretarial Practice (English)"></asp:ListItem>
                                                    <asp:ListItem Value="PR" Text="Practical Marks"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2"></td>
                                            <td style="width: 15%;"></td>
                                            <td style="width: 2%;" runat="server" id="td_tradeType"><span style="color: red;">*&nbsp;</span><asp:Label ID="Label1" runat="server" Text="Trade Type :"></asp:Label></td>
                                            <td colspan="2" style="width: 27%;">
                                                <asp:DropDownList ID="ddlTradeType" runat="server" Width="200px">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="Engg" Text="Enginnering"></asp:ListItem>
                                                    <asp:ListItem Value="Non-Engg" Text="Non-Enginnering"></asp:ListItem>
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
                                            <td colspan="9" style="text-align: center;">
                                                <table width="100%">

                                                    <tr style="text-align: left; font-weight: bold">
                                                        <td>MIS CODE
                                                            <br />
                                                            <asp:TextBox ID="txt_ItiCode" runat="server" MaxLength="10"></asp:TextBox>
                                                        </td>
                                                        <td>Roll Number
                                                            <br />
                                                            <asp:TextBox ID="txt_rollno" runat="server" MaxLength="12" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        </td>
                                                        <td>Candidate Name
                                                            <br />
                                                            <asp:TextBox ID="txt_name" runat="server" MaxLength="200"></asp:TextBox>
                                                        </td>
                                                        <td>Semester
                                                            <br />
                                                            <asp:DropDownList ID="ddlSemester" runat="server" Width="200px">
                                                                <asp:ListItem Value='0'>Select</asp:ListItem>
                                                                <asp:ListItem Value='1'>Sem 1</asp:ListItem>
                                                                <asp:ListItem Value='2'>Sem 2</asp:ListItem>
                                                                <asp:ListItem Value='3'>Sem 3</asp:ListItem>
                                                                <asp:ListItem Value='4'>Sem 4</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td runat="server" id="tdDict100" visible="true">Dictation100WPM
                                                            <br />
                                                            <asp:DropDownList ID="ddl_dictation100" runat="server">
                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="PASS" Value="P"></asp:ListItem>
                                                                <asp:ListItem Text="FAIL" Value="F"></asp:ListItem>
                                                                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                                <asp:ListItem Text="ABSENT" Value="AB"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td runat="server" id="tdMarks" visible="false">Marks
                                                            <br />
                                                            <asp:TextBox ID="txt_marks" runat="server" MaxLength="5" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick="return ValidateControls();"
                                                                Style="width: 75px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Add" />
                                                            <asp:HiddenField ID="hd_isAdd" runat="server" Value="0" />
                                                        </td>
                                                    </tr>
                                                </table>
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
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="10">
                                                <%--<div id="div_data" runat="server"></div>--%>
                                                <asp:GridView ID="grd_candidate" runat="server"
                                                    AutoGenerateColumns="false" ShowFooter="false" Width="80%" OnRowDataBound="grd_candidate_RowDataBound">

                                                    <Columns>
                                                        <asp:BoundField DataField="ITICode" HeaderText="MIS CODE" />
                                                        <asp:BoundField DataField="RollNumber" HeaderText="Roll Number" />
                                                        <asp:BoundField DataField="Name" HeaderText="Candidate Name" />
                                                        <asp:BoundField DataField="Semester" HeaderText="Semester" />
                                                        <asp:BoundField DataField="100Wpm" HeaderText="Dictation 100WPM" />
                                                        <asp:BoundField DataField="Marks" HeaderText="Marks" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField DataField="EntryType" HeaderText="EntryType" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField DataField="TradeType" HeaderText="TradeType" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:TemplateField HeaderText="Remove">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td>&nbsp;
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

                                        <tr id="tr_save">
                                            <td>&nbsp;
                                            </td>
                                            <td style="height: 50px;">
                                                <asp:Button ID="btn_Otp" runat="server" OnClick="btn_Otp_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Generate OTP" />
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_otp" runat="server" placeholder="Enter OTP"></asp:TextBox>
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
                    <td colspan="3" style="width: 15%;"></td>
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
        </div>

        <script type="text/javascript">

            window.onload = function () {
                setInterval('changestate()', 300);
            };
            var currentState = 'show';
            function changestate() {
                if (currentState == 'show') {
                    document.getElementById('div1').style.backgroundColor = "#A2E8E2"
                    currentState = 'hide';
                }
                else {
                    document.getElementById('div1').style.backgroundColor = "white"
                    currentState = 'show';
                }
            }

            function ValidateControls() {
                var ddlentrytype = document.getElementById("ddlentrytype");
                var ddlTradeType = document.getElementById("ddlTradeType");
                var txt_ItiCode = document.getElementById("txt_ItiCode");
                var txt_rollno = document.getElementById("txt_rollno");
                var ddlSemester = document.getElementById("ddlSemester");
                var ddl_dictation100 = document.getElementById("ddl_dictation100");
                var txt_marks = document.getElementById("txt_marks");

                if (ddlentrytype.value == '0') {
                    alert('Please select Entry Type');
                    ddlentrytype.focus();
                    return false;
                }


                if (ddlTradeType != null && ddlTradeType.value == '0') {
                    alert('Please select Trade Type');
                    ddlTradeType.focus();
                    return false;
                }

                if (txt_ItiCode.value == '') {
                    alert('Please enter MIS Code');
                    txt_ItiCode.focus();
                    return false;
                }
                if (txt_ItiCode.value.length != 10) {
                    alert('Length of MIS CODE must be 10');
                    txt_ItiCode.focus();
                    return false;
                }

                if (txt_rollno.value == '') {
                    alert('Please enter Roll Number');
                    txt_rollno.focus();
                    return false;
                }
                if (txt_rollno.value.length != 12) {
                    alert('Length of Roll Number must be 12');
                    txt_rollno.focus();
                    return false;
                }

                if (ddlSemester.value == '0') {
                    alert('Please select Semester');
                    ddlSemester.focus();
                    return false;
                }
                if (ddl_dictation100 != null && ddl_dictation100.value == '0') {
                    alert('Please select  Dictation 100WPM');
                    ddl_dictation100.focus();
                    return false;
                }

                if (txt_marks != null && txt_marks.value == '') {
                    alert('Please enter Marks');
                    ddlTradeType.focus();
                    return false;
                }
            }

        </script>

    </form>
</body>
</html>
