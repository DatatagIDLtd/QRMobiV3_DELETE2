<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="QRApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to QR Demo</h2>
    <p>
        &nbsp;
        <asp:Image ID="Image1" runat="server" Height="336px" 
            ImageUrl="Images/qrstuff.png" Width="488px" />
    </p>
    <a href="Default.aspx">Default.aspx</a>
    <p>
        To find out more go to
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="http://www.qrstuff.com">http://www.qrstuff.com</asp:HyperLink>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
