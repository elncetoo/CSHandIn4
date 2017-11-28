<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ProgrammingHandIn3.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Log In Dentists</title>
        <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
         <div class="header">
                <div class="myMenuBar">
                    <asp:Menu ID="Navigationmenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal" >
                        <Items>
                            <asp:MenuItem NavigateUrl="~/HomePage.aspx" Text="Home"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dentists.aspx" Text="Dentists"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Patients.aspx" Text="Patients"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/LogInP.aspx" Text="Log In Patients"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/LogIn.aspx" Text="Log In Dentists"></asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </div>
            </div>
        <div style="margin-left: 40px; text-align: center; margin-top: 6px;">
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            <br />
&nbsp;<asp:Label ID="LabelUName" runat="server" Text="Dentist Еmail" CssClass="label"></asp:Label>
        
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxDName" runat="server" Width="194px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelPass" runat="server" Text="Dentist Password" CssClass="label"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxDPass" runat="server" Width="194px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp; <asp:Button ID="ButtonLogIn" runat="server" CssClass="button" Text="Log In" Width="180px" OnClick="ButtonLogIn_Click" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelMessageLogIn" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <asp:GridView runat="server" ID="mygrid"></asp:GridView>
        <br />
        <asp:Button runat="server" ID="readfilebutton" OnClick="readfilebutton_Click" />
    </form>
</body>
</html>
