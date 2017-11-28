<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatDash.aspx.cs" Inherits="ProgrammingHandIn3.PatDash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patients Dashboard</title>
      <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />
        
</head>
<body>
     <form id="form1" runat="server">
        <div style="text-align: center">
             <div style="background: white;" >
             <br />
            <asp:Label ID="LabelPat1" runat="server" CssClass="label" Text="Patient logged in with email: "></asp:Label>
            <asp:Label ID="LabelPatDash" runat="server" CssClass="label" ForeColor="Black"></asp:Label>
            <br />
                 <br />
             </div>
                 <br />
            <br />
            <asp:Button ID="ButtonUPDP" runat="server" CssClass="button" PostBackUrl="~/UpdatePat.aspx" Text="Edit Patient" Width="181px" />
            <asp:Button runat="server" ID="logoutbtn" OnClick="logoutbtn_Click" CssClass="button" Text="Log Out" Width="181px"/>
        &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" Height="667px" ImageUrl="~/Styles/general-dentist.jpg" Width="1000px" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
