<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="test.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            

            <asp:Label ID="lbltest" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="hellow">

                    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                </asp:Label>
           
        </div>
    </form>
</body>
</html>
