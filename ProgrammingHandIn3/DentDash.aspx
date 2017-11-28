<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DentDash.aspx.cs" Inherits="ProgrammingHandIn3.DentDash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dentists Dashboard</title>
      <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />
        
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <div style="background: white;" >
                <br />
                <asp:Label ID="LabelDent1" runat="server" CssClass="label" Text="Dentist logged in: "></asp:Label>
                <asp:Label ID="LabelDentDash" runat="server" CssClass="label" ForeColor="Black"></asp:Label>
                <br /><br />
             </div>
            <asp:Button ID="Button1" runat="server" CssClass="button" PostBackUrl="~/UpdateDent.aspx" Text="Edit Dentist" Width="181px" />
        &nbsp;<asp:Button runat="server" ID="logoutbtn" OnClick="logoutbtn_Click" CssClass="button" Text="Log Out" Width="181px"/>
            &nbsp;&nbsp;<br />
            <asp:Image ID="Image1" runat="server" Height="528px" ImageUrl="~/Styles/funny-clipart-dental-2.png" Width="506px" />
        </div>
    </form>
</body>
</html>
