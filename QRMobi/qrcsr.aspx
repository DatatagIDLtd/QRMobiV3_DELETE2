<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qrcsr.aspx.cs" Inherits="QRMobi.Webcsr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            text-align: left;
        }
        .style52
        {
            width: 981px;
            height: 509px;
            margin-bottom: 23px;
        }
        .style45
        {
            width: 747px;
            font-family: Arial;
        }
        .style50
        {
            font-size: xx-large;
            width: 159px;
            text-align: left;
            height: 8px;
        }
        .style29
        {
            font-family: Arial;
            font-size: xx-large;
        }
        
        .uppercase
        {
            text-transform: uppercase;
        }
        
        #form2
        {
            text-align: left;
        }
        .style53
        {
            font-size: medium;
            text-align: left;
        }
        .style54
        {
            text-align: center;
        }
        .style56
        {
            width: 179px;
            height: 100px;
        }
        .style57
        {
            width: 555px;
            height: 100px;
        }
        .style67
        {
            font-size: medium;
            text-align: left;
            width: 165px;
            height: 8px;
        }
        .style60
        {
            width: 165px;
            text-align: left;
        }
        .style68
        {
            text-align: left;
            width: 342px;
        }
        .style69
        {
            width: 596px;
            font-family: Arial;
        }
        .style71
        {
            text-align: left;
            width: 342px;
            height: 20px;
        }
        .style72
        {
            width: 165px;
            height: 20px;
            text-align: left;
        }
        .style73
        {
            width: 165px;
            height: 4px;
            text-align: left;
        }
        .style74
        {
            text-align: left;
            width: 342px;
            height: 4px;
        }
        .style75
        {
            width: 165px;
            height: 6px;
            text-align: left;
        }
        .style76
        {
            text-align: left;
            width: 342px;
            height: 6px;
        }
        .style78
        {
            width: 165px;
            height: 1px;
            text-align: left;
        }
        .style79
        {
            text-align: left;
            width: 342px;
            height: 1px;
        }
        .style80
        {
            font-size: x-large;
        }
        .style81
        {
            font-family: Arial;
            font-size: x-large;
        }
    </style>
</head>
<body style="height: 495px; width: 1199px">
    <form id="qrCycForm" runat="server" class="style52">
    <div class="style54">
        <br />
        <table id="tCode" class="style45" align="center">
            <tr>
                <td class="style53">
                    &nbsp;<img alt="" class="style56" src="Images/header.png" /><img alt="" class="style57" 
                        src="Images/header_ani.gif" /></td>
            </tr>
            </table>
        <br />
    <table id="tCode0" class="style69" align="center">
        <tr>
            <td class="style67">
                </td>
            <td class="style50">
                </td>
        </tr>
        <tr>
            <td class="style60">
                <asp:Label ID="lbID" runat="server" Text="id" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style68">
                <asp:TextBox ID="tbID" runat="server" ReadOnly="True" CssClass="style29" 
                    Width="339px" BorderStyle="None" Height="30px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style78">
                <asp:Label ID="lbMake" runat="server" Text="Make" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style79">
                <asp:TextBox ID="tbMake" runat="server" Width="341px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None" Height="30px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style60">
                <asp:Label ID="lbModel" runat="server" Text="Model" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style68">
                <asp:TextBox ID="tbModel" runat="server" Width="342px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None" Height="30px" 
                    ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style60">
                <asp:Label ID="lbType" runat="server" Text="Type" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style68">
                <asp:TextBox ID="tbType" runat="server" Width="342px" ReadOnly="True" 
                    BorderStyle="None" Height="30px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style60">
                <asp:Label ID="lbColour" runat="server" Text="Colour" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style68">
                <asp:TextBox ID="tbColours" runat="server" Width="342px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None" Height="30px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style72">
                <asp:Label ID="lbVinSer" runat="server" Text="Vin/Ser" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style71">
                <asp:TextBox ID="tbVINSER" runat="server" Width="342px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None" Height="30px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style73">
                <asp:Label ID="lbEngine" runat="server" Text="Engine" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style74">
                <asp:TextBox ID="tbEngine" runat="server" Width="342px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None" Height="30px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style75">
                <asp:Label ID="lbPolice" runat="server" Text="Police" CssClass="style80"></asp:Label>
                <span class="style80">&nbsp;Interest</span></td>
            <td id="" class="style76">
                <asp:TextBox ID="tbPolice" runat="server" Width="340px" ReadOnly="True" 
                    CssClass="style81" BorderStyle="None" Height="30px" >None</asp:TextBox>
            </td>
        </tr>
        </table>
        <span>
            <br />
        </span>
    </div>
    </form>
</body>
</html>
