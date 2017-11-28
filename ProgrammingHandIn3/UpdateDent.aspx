<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDent.aspx.cs" Inherits="ProgrammingHandIn3.UpdateDent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Dentist</title>
          <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />
            
    <style type="text/css">
        #form1 {
            text-align: center;
        }
    </style>
            
</head>
<body>
    <form id="form1" runat="server">
       <div style="background: white;" >
             <br />
    &nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelInfo" runat="server" CssClass="label">Dentist logged in with email: </asp:Label>

                <asp:Label ID="LabelUpdate" runat="server" CssClass="label" ForeColor="Black"></asp:Label>
                <br />
           <asp:Label ID="LabelStatusD" runat="server" Text="" CssClass="label" ForeColor="Black"></asp:Label>
                <br />
                <asp:Button ID="ButtonBack" runat="server" CssClass="button" PostBackUrl="~/DentDash.aspx" Text="Go Back" Width="181px" />
            <asp:Button ID="Button1" runat="server" OnClick="ButtonSaveDentist_Click" Text="Save to file" CssClass="button" Width="181px" />
                <br />
            </div>

            <br />
            <br />
            <asp:Label ID="LabeName" runat="server" Text="Update Name:" CssClass="label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxName" runat="server" Width="271px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LabelAge" runat="server" Text="Update Age:" CssClass="label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxAge" runat="server" Width="271px"></asp:TextBox>

            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Update Email:" CssClass="label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxEmail" runat="server" Width="271px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LabelPass" runat="server" Text="Update Pass:" CssClass="label"></asp:Label>
            <br />

            <asp:TextBox ID="TextBoxPass" runat="server" Width="271px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LabelSocialNr" runat="server" Text="Update Social Nr:" CssClass="label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxSocialNr" runat="server" Width="271px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonUpdate" runat="server"  Text="Update Dentist" OnClick="ButtonUpdate_Click" CssClass="button" Width="181px" />
            <br />
            <asp:Button ID="ButtonDelD" runat="server" CssClass="button" Text="Delete Dentist" Width="181px" OnClick="ButtonDelD_Click" />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="LabelAllD" runat="server" CssClass="label" ForeColor="Black" Text="List of all Dentists:"></asp:Label>
            <br />
           
            &nbsp;&nbsp;&nbsp;
           <div>
           
               <asp:GridView runat="server" ID="mygrid" CssClass="mytable" Width="979px">
                    <Columns>
                        <asp:ButtonField CommandName="Select" Text="Select" />
                    </Columns>

               </asp:GridView>
               <br />
               <br />
               <br />
               <asp:Button ID="ButtonReadPatientFile" runat="server" CssClass="button" OnClick="ButtonReadPatientFile_Click" Text="Read from patient file" Width="181px" />
               <br />
&nbsp;&nbsp;&nbsp;
               <br />
               <asp:Label ID="LabelAllP" runat="server" CssClass="label" ForeColor="Black" Text="List of all Patients:"></asp:Label>
               &nbsp;<br />
               <br />
                <asp:GridView runat="server" ID="mygridallp" CssClass="mytable" Width="979px"> </asp:GridView>
               <br />
               <asp:Label ID="MessagePatientForm" runat="server" CssClass="label"></asp:Label>
               <br />
               <br />
               <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" CssClass="mytable" Width="509px">
            </asp:GridView>
            <br style="text-align: right" />
           </div>
    </form>
</body>
</html>
