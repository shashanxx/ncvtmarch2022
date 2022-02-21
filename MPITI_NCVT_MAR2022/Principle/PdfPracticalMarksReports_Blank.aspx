<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PdfPracticalMarksReports_Blank.aspx.cs" Inherits="Principle_PdfPracticalMarksReports_Blank" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script lang="javascript" type="text/javascript">
        function Print() {
            document.getElementById('<%=btnPrint.ClientID %>').style.visibility = "hidden";
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

    <div class="element">
        <br /><br />
            <table style="width: 100%; border: 1px solid black;font-family:Calibri;font-size:20px;" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 2%;"></td>
                    <td runat="server" id="tbExamType" colspan="5" align="center" style="border-bottom: 1px solid; border-left: 1px solid; border-right: 1px solid; font-weight: bold; font-size: 20px; background-color: #E9B395"></td>
                    <td style="width: 2%;"></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="5" align="center" style="border-bottom: 1px solid; border-left: 1px solid; border-right: 1px solid; font-size: 20px; font-weight: bold;">User Name :
                        <asp:Label ID="lblUName" runat="server" Text="" Font-Size="20px"></asp:Label></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="5" style="font-size: 14px;">
                        <asp:Label ID="lblData" runat="server" Text="" Font-Size="14px"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="5"></td>
                    <td></td>
                </tr>
            </table>
            <%--<input type="button" runat="server" style="width: 125px; border-radius: 5px; color: black; font-weight: bold; height: 35px;" text="Print" visible="true" onclick="window.print();"/>--%>
            <input id="btnPrint" runat="server" class="btnbx" name="btnPrint" onclick="return Print();" style="width: 100px; font-weight: bold; background-color: #cc632a; color: white; border-radius: 10px; height: 40px;" type="submit" value="Print" />
            <%-- <input id="btnback" runat="server" class="btnbx" name="btnback" onclick="return Print();" style="width: 100px; font-weight: bold; background-color: #cc632a; color:white; border-radius:10px; height:40px;" type="submit" value="Back" />--%>
<%--            <asp:Button ID="btnback" runat="server" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Back" Visible="false" OnClick="btnback_Click" />--%>
        </div>
    </form>
</body>
</html>
