<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="ProgrammingHandIn3.Patients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patients page</title>
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
                <div class="auto-style1">
                    <br />
                    <div style="display: flex; justify-content: center; flex-direction: row;">
                    <asp:Button ID="ButtonSavePatientFile" runat="server" OnClick="ButtonSavePatientFile_Click" Text="Save to File" CssClass="button" Width="271px" />
                    <asp:Button ID="ButtonReadPatientFile" runat="server" OnClick="ButtonReadPatientFile_Click" Text="Read from file" CssClass="button" Width="271px" />
                    </div>  
                    <br />
                    <div>
                    <asp:Label ID="MessagePatientForm" runat="server" CssClass="label" Font-Size="Medium" ForeColor="#0A3474"></asp:Label>
                    <br />
                    <asp:Label ID="MessageNewFormPat" runat="server" CssClass="label" Font-Size="Medium" ForeColor="#0A3474"></asp:Label>
                    </div>
                    <div class="container">
                     <div class="row">
                        <div class="col-md-6">
                            <div style="display:flex; justify-content:center; padding:1%;">
                               <asp:GridView runat="server" ID="PatientsGridView" Width="1109px" OnSelectedIndexChanged="PatientsGridView_SelectedIndexChanged">
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
                    <div>
                        <asp:Label ID="LabelPatientName" runat="server" Text="Patient name:" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxPatientName" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelPatientAge" runat="server" Text="Patient age:" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxPatientAge" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelPatientPassword" runat="server" Text="Patient password:" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxPatientPassword" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelPatientEmail" runat="server" Text="Patient email:" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxPatientEmail" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelPatientSocialNr" runat="server" Text="Patient Social Security Number:" CssClass="label"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxPatientSocialNr" runat="server" Width="271px"></asp:TextBox>
                        <br />
                        <br />
                     </div>
                  <div style="display: flex; justify-content: center; flex-direction: column; padding-left: 39.5%;">
                    <asp:Button ID="ButtonAddPatientList" runat="server" OnClick="ButtonAddPatientList_Click" Text="Add new patient to list" CssClass="button" Width="271px" />
                    <asp:Button ID="ButtonDeleteSelectedPatient" runat="server" OnClick="ButtonDeleteSelectedPatient_Click" Text="Delete selected patient" CssClass="button" Width="271px" />
                    <asp:Button ID="ButtonUpdateSelectedPatient" runat="server" Text="Update selected patient" CssClass="button" Width="271px" OnClick="ButtonUpdateSelectedPatient_Click" />
                  </div>
               </div>
            </div>
        </div>
      </div>
    </form>
</body>
</html>
