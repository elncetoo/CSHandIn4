<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInP.aspx.cs" Inherits="ProgrammingHandIn3.LogInP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In Patients</title>
        <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
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


        </div>
        <div style="text-align: center">
            <br />
            <br />
            <br />
            <asp:Label ID="LabelEmail" runat="server" CssClass="label" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxEmail" runat="server" Width="194px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LabelPassword" runat="server" CssClass="label" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxPassword" runat="server" Width="194px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonLogInP" runat="server" CssClass="button" Text="Log In as Patient" OnClick="ButtonLogInP_Click"  />
            <br />
            <asp:Label ID="LabelLogInD" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView runat="server" ID="mygridpat" CssClass="mytable" Width="823px"></asp:GridView>
        <br />
        <asp:Button runat="server" ID="readfilebutton" OnClick="readfilebutton_Click" />


        </div>
    </form>
</body>
</html>
