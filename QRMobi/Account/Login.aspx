<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="QRMobi.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .pBtnSize {
            height: 150px;
            width: 300px;
            padding-bottom: 10px;
            padding-top: 10px;
        }

        .divTop {
            width: 100%;
            background-size: 100% 100%;
            background-image: url('../Imagescsrm/bg-large.jpg');
        }

        .labelField {
            color: white;
        }

        .divTitle {
            width: 100%;
        }

        btnLogin {
            font-size: x-large;
        }

        labelError {
            color:white;
        }

        .auto-style1 {
            width: 844px;
        }

    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="divTop" class="divTop">
        <div id="divTitle">
            <table style="width: 95%">
                <tr>
                    <td style="text-align: left">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/CesarECV/cesar-logo.png" Style="margin-left: 30px" />
                    </td>
                    <td></td>
                    <td style="text-align: right">
                        <asp:Image ID="Image2" runat="server"
                            ImageUrl="~/Imagescsrm/datatag-logo.png" />
                    </td>
                </tr>
            </table>
        </div>

        <h1 style="margin-left:10px; text-align: left; color: white; font-size: 50px" class="">Log In
        </h1>

        <p  style="text-align: left; margin-left:10px; color: white; font-size: x-large;" class="auto-style1">
            Please enter your username and password.
        </p>
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
            <LayoutTemplate>
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="LoginUserValidationGroup" />
                <div>
                    <fieldset>
                        <legend>Account Information</legend>
                        <p>
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="XX-Large" CssClass="labelField">Username:</asp:Label>
                            &nbsp;
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Font-Size="XX-Large" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Size="XX-Large" CssClass="labelField">Password:</asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" Font-Size="XX-Large" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:CheckBox ID="RememberMe" runat="server" Visible="False" />
                            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline" Visible="False">Keep me logged in</asp:Label>
                        </p>
                    </fieldset>
                    <div>
                        <br />
                        <p>
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click" Height="84px" Width="182px" CssClass="btnLogin" Font-Size="XX-Large" />
                        </p>
                        <br />
                    </div>
                </div>
            </LayoutTemplate>

        </asp:Login>
    </div>
</asp:Content>
