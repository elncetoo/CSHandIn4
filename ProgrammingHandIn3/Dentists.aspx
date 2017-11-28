<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dentists.aspx.cs" Inherits="ProgrammingHandIn3.Dentists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dentists page</title>
        <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
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
            <div class="auto-style1">
                <br />
                <div style="display: flex; justify-content: center; flex-direction: row;">
                    <asp:Button ID="ButtonSaveDentistFile" runat="server" Text="Save to File" CssClass="button" Width="271px" OnClick="ButtonSaveDentistFile_Click1" />
                    <asp:Button ID="ButtonReadDentistFile" runat="server" Text="Read from file" CssClass="button" Width="271px" OnClick="ButtonReadDentistFile_Click" />
                </div>  
                <br />
                    <asp:Label ID="MessageDentistForm" runat="server"  CssClass="label" Font-Size="Medium" ForeColor="#0A3474"></asp:Label>
                    <br />
                    <asp:Label ID="MessageNewFormDent" runat="server" CssClass="label" Font-Size="Medium" ForeColor="#0A3474"></asp:Label>
                <br />
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <div style="display:flex; justify-content:center; padding:3%;">
                            <asp:GridView runat="server" ID="DentistsGridView" OnSelectedIndexChanged="DentistsGridView_SelectedIndexChanged" Width="1109px">
                                <Columns>
                                    <asp:ButtonField CommandName="Select" Text="Select" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            </div>
                    <div class="col-md-6">
                        <div>
                               
                        </div>
                    </div>
                    </div>
                </div>
             </div>
            <div class="header-wrap">
                    <div style="display:flex; justify-content:center;">
                        <asp:Label ID="LabelHeaderWrap" runat="server" CssClass="headertext" EnableTheming="false" Text="The Østerbro`s Dental Clinic – Dr. Jensen A/S"></asp:Label>
                    </div>
                    <div style="padding:1% 15%;" >
                        <asp:Label ID="LabelCreateDentist" runat="server" Text="Enter Dentist`s Name" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxCRDName" runat="server" Width="271px" ></asp:TextBox>
                        <br />
                        <br />

                        <asp:Label ID="LabelCRDAge" runat="server" Text="Enter Dentist`s Age" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxCRDAge" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        <br />

                        <asp:Label ID="LabelCRDPass" runat="server" Text="Enter Dentist`s Password" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxCRDPass" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        <br />

                        <asp:Label ID="LabelCRDEmail" runat="server" Text="Enter Dentist`s Email" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxCRDEmail" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        <br />   
                        
                        <asp:Label ID="LabelCRDSocialNr" runat="server" Text="Enter Dentist`s Social Security Number" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxCRDSocialNr" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <div style="display: flex; justify-content: center; flex-direction: column; padding-left: 37.7%;">
                        <asp:Button ID="ButtonCRNewDentist" runat="server"  Text="Add new dentist to list" CssClass="button" Style="vertical-align: middle; text-align: center;" OnClick="ButtonCRNewDentist_Click" Width="271px" />
                        <asp:Button ID="ButtonDeleteSelectedDentist" runat="server" Text="Delete selected dentist" CssClass="button" Width="271px" OnClick="ButtonDeleteSelectedDentist_Click" />
                        <asp:Button ID="ButtonUpdateSelectedDentist" runat="server" Text="Update selected dentist" CssClass="button" Width="271px" OnClick="ButtonUpdateSelectedDentist_Click" />

                    </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>