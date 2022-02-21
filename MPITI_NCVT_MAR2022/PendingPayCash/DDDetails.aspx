<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DDDetails.aspx.cs" Inherits="Principle_DDDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DD Details</title>
    <script src="../js/newPortal_validations.js" type="text/javascript"></script>
    <style>
        .ddlstyle {
            height: 25px;
        }
    </style>
    <script type="text/javascript">
        function previewFile(event) {

            var uploadCandidatephoto;
            var preview;
            var file;

            if (event.id == "fu_DD") {
                uploadCandidatephoto = document.getElementById('fu_DD');
                preview = document.getElementById('imageDD');
            }


            if (uploadCandidatephoto.value == '') { uploadCandidatephoto.focus(); alert('Please upload DD'); return false; }

            if (uploadCandidatephoto.files['0'].type.indexOf('jpg') <= -1 && uploadCandidatephoto.files['0'].type.indexOf('jpeg') <= -1) {
                alert('Oops ! Error occured while uploading, DD should be in .jpeg or jpg format only');
                return false;
            }
            if (uploadCandidatephoto.files['0'].size > 200000) {
                alert('Oops ! Error occured while uploading, DD size should be 200KB');
                return false;
            }

            if (event.id == "fu_DD")
                file = document.getElementById('fu_DD').files[0];
            else
                file = document.getElementById('fu_DD').files[0];

            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }

        function ValidationCheck() {
            if (document.getElementById("txtDDnumber").value == "") {
                alert("Please Enter DD Number");
                document.getElementById("txtDDnumber").focus();
                return false;
            }
            else if (document.getElementById("txtBankName").value == "") {
                alert("Please Enter Bank Name");
                document.getElementById("txtBankName").focus();
                return false;
            }
            else if (document.getElementById("txtIssuingBranch").value == "") {
                alert("Please Enter Issuing Branch");
                document.getElementById("txtIssuingBranch").focus();
                return false;
            }
            else if (document.getElementById("txtDDDate").value == "") {
                alert("Please Enter DD Date");
                document.getElementById("txtDDDate").focus();
                return false;
            }
            else if (document.getElementById("txtAmount").value == "") {
                alert("Please Enter Amount");
                document.getElementById("txtAmount").focus();
                return false;
            }
            else
                return true;
        }
        </script>
</head>
<body style="font-family: Arial; font-size: 16px;">
    <form id="form1" runat="server">
        <div>
            <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server"></cc1:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
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
                            <td colspan="20" style="height: 25px; text-align: left; padding-left: 15%">DD Details
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
                                                    <td colspan="11" style="width: 5%; height: 18px;">
                                                        <asp:Label ID="lblPID" runat="server" Style="font-weight: bold;"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr></tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10"></td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td style="width: 10%;"><span style="color: red;">*&nbsp;</span>
                                                        <asp:Label ID="lblDDnumber" runat="server" Text="DD Number"></asp:Label>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:TextBox ID="txtDDnumber" runat="server" Width="150px" Height="20px" MaxLength="15" onkeypress="return CreateNumericTextControl(this,event,false)"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 5%;"></td>
                                                    <td style="width: 10%;"><span style="color: red;">*&nbsp;</span>
                                                        <asp:Label ID="lblBankName" runat="server" Text="Bank Name"></asp:Label>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:TextBox ID="txtBankName" runat="server" Width="150px" Height="20px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 5%;"></td>
                                                    <td style="width: 10%;"><span style="color: red;">*&nbsp;</span>
                                                        <asp:Label ID="lblIssuingBranch" runat="server" Text="Issuing Branch"></asp:Label>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:TextBox ID="txtIssuingBranch" runat="server" Width="150px" Height="20px"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2" style="width: 15%;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <%--<hr style="color: brown;" />--%>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td style="width: 10%;"><span style="color: red;">*&nbsp;</span>
                                                        <asp:Label ID="lblDDDate" runat="server" Text="DD Date"></asp:Label>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:TextBox ID="txtDDDate" runat="server" Width="150px" Height="20px" autocomplete="off" onKeyPress = "javascript: return false;" onPaste = "javascript: return false;"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtendertdt" runat="server" TargetControlID="txtDDDate" Format="dd/MM/yyyy" Enabled="True"></cc1:CalendarExtender>
                                                    </td>
                                                    <td style="width: 5%;"></td>
                                                    <td style="width: 10%;"><span style="color: red;">*&nbsp;</span>
                                                        <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:TextBox ID="txtAmount" runat="server" Enabled="false" Width="150px" Height="20px" MaxLength="10" onkeypress="return CreateNumericwithdotTextBox(this,event)"></asp:TextBox>
                                                        
                                                    </td>
                                                    <td style="width: 5%;"></td>
                                                    <td style="width: 10%;">
                                                    </td>
                                                    <td style="width: 15%;">
                                                        
                                                    </td>
                                                    <td colspan="2" style="width: 15%;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <%--<hr style="color: brown;" />--%>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td style="width: 10%;"><span style="color: red;">*&nbsp;</span>
                                                        <asp:Label ID="Label1" runat="server" Text="Upload DD"></asp:Label>
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:FileUpload ID="fu_DD" runat="server" onchange="previewFile(this)" />
                                                        <%--<br />--%>

                                                        <span style="color: red">(.jpg or.jpeg upto 200kb)</span>
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:Image ID="imageDD" runat="server" Width="150px" Height="150px" />
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
                                                    
                                                    <td colspan="10" align="center">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                            OnClientClick="return ValidationCheck();" OnClick="btnSubmit_Click" />&nbsp;
                                                        <%--<asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="GenerateReport" Visible="false" Enabled="false" />--%>
                                            &nbsp;<asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnExit_Click" />
                                                    </td>
                                                    <td>
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
                                                    <td colspan="11"></td>

                                                    <tr>
                                                        <td></td>
                                                        <td colspan="4" style="height: 25px; vertical-align: middle;">
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
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSubmit" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>