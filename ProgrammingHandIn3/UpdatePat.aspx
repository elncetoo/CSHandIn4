<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePat.aspx.cs" Inherits="ProgrammingHandIn3.UpdatePat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Patient</title>
       <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
             <div style="background: white;" >
             <br />
            <asp:Label ID="LabelInfoP" runat="server" CssClass="label" Text="Patient logged in: "></asp:Label>
            <asp:Label ID="LabelPatDash" runat="server" CssClass="label" ForeColor="Black"></asp:Label>
            <br />
            <br />
                 </div>
            <br />
            <asp:Button ID="Button2" runat="server" CssClass="button" PostBackUrl="~/PatDash.aspx" Text="Go Back" Width="181px" />
            <asp:Button runat="server" ID="ButtonSaveToFile"  CssClass="button" Text="Save to File" Width="181px" OnClick="ButtonSaveToFile_Click"/>
        &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <div>
                <asp:Label ID="LabelNameP" runat="server" CssClass="label" Text="Name"></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxNameP" runat="server" Width="271px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelAgeP" runat="server" CssClass="label" Text="Age"></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxAgeP" runat="server" Width="271px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelEmail" runat="server" CssClass="label" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxEmailP" runat="server" Width="271px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelPassP" runat="server" CssClass="label" Text="Password"></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxPassP" runat="server" Width="271px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelSocialNrP" runat="server" CssClass="label" Text="Social Nr"></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxSocialNrP" runat="server" Width="271px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="ButtonUpdateP" runat="server" CssClass="button" Text="Update Patient" Width="271px" OnClick="ButtonUpdateP_Click" />
                <br />
                <asp:Button ID="ButtonDelP" runat="server" CssClass="button" Text="Delete Patient" Width="271px" OnClick="ButtonDelP_Click" />
                <br />
                <br />
                <asp:Label ID="LabelPatInfo" runat="server" CssClass="label" ForeColor="Black" Text="Patient Info:"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GridViewPatInfo" runat="server" CssClass="mytable" Width="953px">
                    <Columns>
                        <asp:ButtonField CommandName="Select" Text="Select" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <br />
                <asp:Label ID="LabelDNames" runat="server" CssClass="label" ForeColor="Black" Text="Dentists Names:"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GridViewDNames" runat="server" CssClass="mytable" Width="817px"></asp:GridView>

            </div>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
