<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roster.aspx.cs" Inherits="SchedulerJune2016_Roster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" media="print">

</style>
</head>
<body onload="window.print();">
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
</html>
