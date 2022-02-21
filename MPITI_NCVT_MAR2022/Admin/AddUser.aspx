<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="Admin_AddUser" MaintainScrollPositionOnPostback="true" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Details</title>
    <style type="text/css">
        @charset "utf-8";
        /* CSS Document */

        @import url(http://fonts.googleapis.com/css?family=Lato:300,400,700);

        @font-face {
            font-family: 'fontawesome';
            src: url('../fonts/fontawesome.eot');
            src: url('../fonts/fontawesome.eot?#iefix') format('embedded-opentype'), url('../fonts/fontawesome.svg#fontawesome') format('svg'), url('../fonts/fontawesome.woff') format('woff'), url('../fonts/fontawesome.ttf') format('truetype');
            font-weight: normal;
            font-style: normal;
        }

        .icon_center_div {
            width: 100%;
            height: 550px;
            margin-left: auto;
            margin-right: auto;
            padding: 10px;
        }

        .icon_box {
            text-decoration: none;
            width: 305px;
            height: 137px;
            float: left;
            padding-left: 5px;
            padding-right: 5px;
            border: #fff solid 1px;
            display: block;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -khtml-border-radius: 5px;
            border-radius: 5px;
            font-family: 'Lato', Calibri, Arial, sans-serif;
            margin-top: 5px;
        }


            .icon_box:hover {
                border-color: #cc632a;
                background-color: #d8b3778f;
            }

            .icon_box h1 {
                text-decoration: none;
                width: 240px;
                font-size: 16px;
                color: #d1383e;
                font-family: 'Lato', Calibri, Arial, sans-serif;
                text-align: left;
                margin: 0px;
                padding: 0px;
                line-height: 35px;
            }

                .icon_box h1 a {
                    color: #cc632a;
                }

            .icon_box p {
                text-decoration: none;
                font-size: 13px;
                font-weight: 400;
                color: #626262;
                font-family: 'Lato', Calibri, Arial, sans-serif;
                width: 240px;
                margin-left: 0 px;
            }

        .alink {
            text-decoration: none;
        }

        .div_img_style {
            float: left;
            margin-right: 5px;
            width: 55px;
            vertical-align: top;
        }

        .imgstyle {
            float: left;
            margin-top: 12px;
            margin-right: 5px;
            border: 0px;
        }

        .data {
            width: 100px;
            float: left;
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
            <tr style="background-color: #d8b377; height: 50px;">
                <td colspan="20" style="height: 25px; float: left; text-align: center; font-weight: bold;">
                    <br />
                    User Details
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                    <br />
                    <br />
                    <table border="1" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 200px; padding-left: 25px;">ITI Name:<br />
                                <asp:TextBox ID="txtItiName" runat="server" Width="140" />
                                <br />
                                <br />
                            </td>
                            <td style="width: 200px; padding-left: 25px;">ITI Code (User Name) :<br />
                                <asp:TextBox ID="txtUserName" runat="server" Width="140" />
                                <br />
                                <br />
                            </td>
                            <td style="width: 200px; padding-left: 25px;">Password:<br />
                                <asp:TextBox ID="txtPassword" runat="server" Width="140" />
                                <br />
                                <br />
                            </td>
                            <td style="width: 200px; padding-left: 25px;">User Type:<br />
                                <asp:DropDownList ID="ddlUserType" runat="server" Width="140">
                                    <asp:ListItem Text="JD" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="ITI" Value="2"></asp:ListItem>
                                </asp:DropDownList>

                                <br />
                                <br />
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 200px; padding-left: 25px;">Division:<br />
                                <asp:TextBox ID="txtDivision" runat="server" Width="140" />
                                <br />
                                <br />
                            </td>
                            <td style="width: 200px; padding-left: 25px;">District:<br />
                                <asp:TextBox ID="txtDistrict" runat="server" Width="140" />
                                <br />
                                <br />
                            </td>
                            <td style="width: 200px; padding-left: 25px;">Mobile No:<br />
                                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" Width="140" onkeypress="return onlyNumbersWithDot(this, event)" />
                                <br />
                                <br />
                            </td>
                            <td style="width: 250px; padding-left: 25px;">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="return Validate();" OnClick="btnAdd_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" Width="750px"
                        OnRowDataBound="gvData_RowDataBound" OnRowEditing="gvData_RowEditing" OnRowCancelingEdit="gvData_RowCancelingEdit"
                        OnRowUpdating="gvData_RowUpdating" OnRowDeleting="gvData_RowDeleting" EmptyDataText="No records found." BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <Columns>
                            <asp:TemplateField HeaderText="ITI Code" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName" runat="server" Enabled="false" Text='<%# Eval("UserName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ITIName" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblITIName" runat="server" Text='<%# Eval("ITIName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtITIName" runat="server" Text='<%# Eval("ITIName") %>' MaxLength="100"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPassword" runat="server" Text='<%# Eval("Password") %>' MaxLength="25"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UserType" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlUserType" runat="server" Width="140" Text='<%# Eval("UserType") %>' Enabled="false">
                                        <asp:ListItem Text="JD" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="ITI" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlUserType" runat="server" Width="140" Text='<%# Eval("UserType") %>'>
                                        <asp:ListItem Text="JD" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="ITI" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MobileNo" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMobileNo" runat="server" Text='<%# Eval("MobileNo") %>' MaxLength="10" onkeypress="return onlyNumbersWithDot(this, event)"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Division" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("Division") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDivision" runat="server" Text='<%# Eval("Division") %>' MaxLength="50"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="District" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDistrict" runat="server" Text='<%# Eval("District") %>' MaxLength="50"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ItemStyle-Width="150" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>

                        </center>
                </td>
            </tr>
        </table>

        <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
        <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
        <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
            rel="Stylesheet" type="text/css" />

        <script type="text/javascript">

            function onlyNumbersWithDot(evt) {
                var e = event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;
                if (charCode == 46)
                    return false;
                if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;

                return true;

            }

            function Validate() {
                var txtItiName = document.getElementById("txtItiName");
                var txtUserName = document.getElementById("txtUserName");
                var txtPassword = document.getElementById("txtPassword");
                var txtMobileNo = document.getElementById("txtMobileNo");
                var txtDivision = document.getElementById("txtDivision");
                var txtDistrict = document.getElementById("txtDistrict");

                if (txtItiName.value == '') {
                    txtItiName.focus();
                    alert('Please enter ITI Name');
                    return false;
                }
                if (txtUserName.value == '') {
                    txtUserName.focus();
                    alert('Please enter ITI Code');
                    return false;
                }
                if (txtPassword.value == '') {
                    txtPassword.focus();
                    alert('Please enter Password');
                    return false;
                }
                if (txtDivision.value == '') {
                    txtDivision.focus();
                    alert('Please enter Division.');
                    return false;
                }
                if (txtDistrict.value == '') {
                    txtDistrict.focus();
                    alert('Please enter District.');
                    return false;
                }
                if (txtMobileNo.value == '') {
                    txtMobileNo.focus();
                    alert('Please enter Mobile No');
                    return false;
                }
                if (txtMobileNo.value.length != 10) {
                    txtMobileNo.focus();
                    alert('Please enter valid Mobile No');
                    return false;
                }

                return true;
            }
        </script>


    </form>
</body>
</html>

