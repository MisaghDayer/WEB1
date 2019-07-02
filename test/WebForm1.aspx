<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="test.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" runat="server">
        <div>
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtFamily" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click1" />

            <br />
            <br />
            <br />
            <br />

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Width="100%" style="margin-top: 0px">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="family" HeaderText="family" SortExpression="family" />
                    <asp:BoundField DataField="pic" HeaderText="pic" SortExpression="pic" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("pic", "{0}") %>' Width="100px" />
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:gsddsklConnectionString %>" DeleteCommand="DELETE FROM [Table_1] WHERE [id] = @id" InsertCommand="INSERT INTO [Table_1] ([name], [family]) VALUES (@name, @family)" SelectCommand="SELECT * FROM [Table_1]" UpdateCommand="UPDATE [Table_1] SET [name] = @name, [family] = @family WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="family" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="family" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
