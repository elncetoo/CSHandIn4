<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ProgrammingHandIn3.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dental clinic page</title>
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
                <div class="header-wrap">
                    <div style="display:flex; justify-content:center;">
                        <asp:Label ID="LabelHeaderWrap" runat="server" CssClass="headertext" EnableTheming="false" Text="The Østerbro`s Dental Clinic – Dr. Jensen A/S"></asp:Label>
                    </div>
                    <div>
                        <img src="/Styles/background.jpg" alt="HTML5 Icon" style="width:100%;"/>
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <div style="display:flex; justify-content:center;">
                        <asp:Button ID="ButtonGoDentistsP" runat="server"  Text="Dentists" CssClass="button" Style="vertical-align: middle; text-align: center;" PostBackUrl="~/Dentists.aspx"/>
                        <asp:Button ID="ButtonGoPatientsP" runat="server" CssClass="button"  Text="Patients" PostBackUrl="~/Patients.aspx" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
