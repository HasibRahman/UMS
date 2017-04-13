<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UI.aspx.cs" Inherits="UniversityManagementSystemWebApp.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:TextBox ID="nameTextBox" runat="server" name="Name"></asp:TextBox>
    
    </div>
        <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Reg No"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="regNoTextBox" runat="server"></asp:TextBox>
        <br />
        &nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
