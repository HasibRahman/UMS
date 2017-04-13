<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEntryUI.aspx.cs" Inherits="UniversityManagementSystem.UI.StudentEntryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Name</td>
                <td><asp:TextBox runat="server" ID="nameTextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Address</td>
                <td><asp:TextBox runat="server" ID="addressTextBox" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Reg No</td>
                <td><asp:TextBox runat="server" ID="regNoTextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Phone No.</td>
                <td><asp:TextBox runat="server" ID="phoneNumberTextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button runat="server" ID="saveButton" OnClick="saveButton_Click" Text="Save"></asp:Button></td>
            </tr>
            <tr>
                <td colspan ="2">
                    <asp:Label runat="server" ID="messageLabel"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
