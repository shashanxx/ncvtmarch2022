<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentEntry.aspx.cs" Inherits="Student_StudentEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>STUDENT CITY PREFERENCE</title>
    <script type="text/javascript">

        function ValidationMessage() {
            if (document.getElementById('ddlexamcity1').value == "0") {

                alert("Please Select Preference 1");
                return false;
            }
            if (document.getElementById('ddlexamcity2').value == "0") {
                alert("Please Select Preference 2");
                return false;
            }
            if (document.getElementById('ddlexamcity3').value == "0") {
                alert("Please Select Preference 3");
                return false;
            }
            if (document.getElementById('ddldistrict').value == "0") {
                alert("Please Select district");
                return false;
            }

            if (document.getElementById('ddlzone').value == "0") {
                alert("Please Select Zone");
                return false;
            }
            //debugger;
            var index1 = document.getElementById('ddlexamcity1').selectedIndex;
            var index2 = document.getElementById('ddlexamcity2').selectedIndex;
            var index3 = document.getElementById('ddlexamcity3').selectedIndex;
            var index4 = document.getElementById('ddldistrict').selectedIndex;
            var index5 = document.getElementById('ddlzone').selectedIndex;
            var res = confirm("Selected Preference 1 - '" + document.getElementById('ddlexamcity1').options[index1].text + "', Preference 2 '"
                + document.getElementById('ddlexamcity2').options[index2].text + "', Preference 3 '"
                + document.getElementById('ddlexamcity3').options[index3].text + "' , District '"
                + document.getElementById('ddldistrict').options[index4].text + "' , Zone '"
                + document.getElementById('ddlzone').options[index5].text + "'  ")
                
                
            if (res) {
                return true;
            } else {
                return false;
            }
        }

    </script>


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
                <tr>
                    <td colspan="20" style="background-color: #cc632a; height: 25px; text-align:center;">
                        <asp:Label ID="lblUName" runat="server" Text="" style="margin-left:10%; font-weight:bold;" ></asp:Label>
                        <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" style="float:right; margin-right:10%;">Logout</asp:LinkButton>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="20" style="background-color: #cc632a; height: 25px;" align="right">--%>

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

                    <%--</td>
                </tr>--%>
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
                                            <td colspan="7" style="font-size: 15px; font-weight: bold;">STUDENT CITY PREFERENCE
                                            </td>
                                            <td style="width: 5%;"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 5%; height: 18px;">&nbsp;
                                            </td>
                                            <td colspan="7">&nbsp;
                                            </td>
                                            <td style="width: 5%;">&nbsp;
                                            </td>
                                        </tr>
                                        <tr style="height: 40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                              <%--  <span style="color: red;">*&nbsp;</span>--%>
                                            </td>
                                            <td style="width: 15%; height: 25px;">
                                                <asp:Label ID="Label3" runat="server" Text="Candidate Name :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:Label ID="lblcandidatename" runat="server" Style="font-weight: 700" Text=""></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 25px;">
                                                <asp:Label ID="lbl1" runat="server" Text="Preference 1 :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:DropDownList ID="ddlexamcity1" runat="server" Width="200px" AutoPostBack="true" Height="30px" Font-Bold="True" OnSelectedIndexChanged="ddlexamcity1_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 25px;">
                                                <asp:Label ID="Label1" runat="server" Text="Preference 2 :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:DropDownList ID="ddlexamcity2" runat="server" Width="200px" Height="30px" AutoPostBack="true" Font-Bold="True" OnSelectedIndexChanged="ddlexamcity2_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 25px;">
                                                <asp:Label ID="Label2" runat="server" Text="Preference 3 :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:DropDownList ID="ddlexamcity3" runat="server" Width="200px" Height="30px" Font-Bold="True">
                                                </asp:DropDownList>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr style="height: 40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 25px;">
                                                <asp:Label ID="Label4" runat="server" Text="District :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:DropDownList ID="ddldistrict" runat="server" Width="200px" Height="30px" Font-Bold="True">
                                                </asp:DropDownList>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr style="height: 40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 25px;">
                                                <asp:Label ID="Label5" runat="server" Text="Zone :"></asp:Label>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:DropDownList ID="ddlzone" runat="server" Width="200px" Height="30px" Font-Bold="True">
                                                </asp:DropDownList>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="7">
                                                <hr style="color: brown;" />
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>






                                        <tr>
                                            <td></td>
                                            <td style="height: 18px;">&nbsp;
                                            <asp:Button ID="btnsave" runat="server" Text="Save" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClientClick="return ValidationMessage();" OnClick="btnsave_Click" />
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Button ID="btnexit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnexit_Click" /></td>
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
                                            <td colspan="4" align="center">&nbsp;
                                                        <%--<asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="GenerateReport" Visible="false" Enabled="false" />--%>
                                            &nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td align="center" colspan="4">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td colspan="8">

                                               <p style="font-size:13px;margin-left:25px"><strong>Disclaimer :</strong> If center is not available in your selected exam city preference then you will be alloted in your selected district and If district is also not available then allotment will be done in your selected Zone</p>
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
