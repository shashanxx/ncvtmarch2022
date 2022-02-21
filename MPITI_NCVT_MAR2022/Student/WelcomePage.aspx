<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WelcomePage.aspx.cs" Inherits="Student_WelcomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome!!!</title>
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

                   <%-- </td>
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
                                            <td colspan="7" style="font-size: 15px; font-weight: bold;">Welcome !!!</td>
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
                                          <tr style="height:40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="height: 25px;" colspan="7">
                                                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                          <tr id="trcan" style="height:40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="width: 25%; height: 25px;">
                                                <asp:Label ID="Label3" runat="server" Text="Candidate Name :"></asp:Label></td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                  <asp:Label ID="lblcandidatename" runat="server" style="font-weight: 700" Text=""></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                                  <tr id="tr1" style="height:40px" runat="server">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="width: 15%; height: 25px;">
                                                Preference 1 :</td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:Label ID="lblexamcity1" runat="server" Text="" style="font-weight: 700"></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                          <tr id="tr2" style="height:40px" runat="server">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="width: 25%; height: 25px;">
                                                Preference 2 :</td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:Label ID="lblexamcity2" runat="server" Text="" style="font-weight: 700"></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                          <tr id="tr3" style="height:40px" runat="server">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="width: 25%; height: 25px;">
                                                Preference 3 :</td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:Label ID="lblexamcity3" runat="server" Text="" style="font-weight: 700"></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>

                                         <tr id="tr4" style="height:40px" runat="server">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="width: 25%; height: 25px;">
                                                District :</td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:Label ID="lbldistrict" runat="server" Text="" style="font-weight: 700"></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>

                                           <tr id="tr5" style="height:40px" runat="server">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="width: 25%; height: 25px;">
                                                Zone :</td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:Label ID="lblzone" runat="server" Text="" style="font-weight: 700"></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                      
                                          <tr id="trverification" style="height:40px" runat="server">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="width: 25%; height: 25px;">
                                                Verification Status :</td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <asp:Label ID="lblverificationstatus" runat="server" Text="" style="font-weight: 700"></asp:Label>
                                                &nbsp;<asp:Label ID="lblpendingmsg" runat="server" Text="" style="font-weight: 700" ForeColor="Red"></asp:Label>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                
                                          <tr style="height:40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                <span style="color: red;">&nbsp;</span>
                                            </td>
                                            <td style="width: 25%; height: 25px;">
                                                &nbsp;</td>
                                            <td style="width: 2%;"></td>
                                            <td colspan="5">
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                
                                          <tr style="height:40px">
                                            <td style="vertical-align: middle; text-align: right;">
                                                &nbsp;</td>
                                            
                                            <td style="width: 2%;">&nbsp;</td>
                                            <td colspan="5">
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
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
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="7">
                                              <p style="font-size:13px"><strong>Disclaimer :</strong> If center is not available in your selected exam city preference then you will be alloted in your selected district and If district is also not available then allotment will be done in your selected Zone</p>
                                            </td>

                                            
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        
                                      
                                   <tr>
                                       <td></td>
                                   </tr>
                                    
                             
                        
                                        <tr>
                                            <td></td>
                                            <td style="height: 18px;">
                                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="window.print();" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" 
                                                />
                                            </td>
                                            <td></td>
                                            <td>
                                            <asp:Button ID="btnexit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnexit_Click" 
                                                />
                                            </td>
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
                                            <td colspan="4" align="center">
                                                &nbsp;
                                                        <%--<asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="GenerateReport" Visible="false" Enabled="false" />--%>
                                            &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
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
