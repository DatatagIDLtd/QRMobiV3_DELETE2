<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qrcom.aspx.cs" Inherits="QRMobi.Webcom" %>

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
            width: 951px;
            height: 562px;
            text-align: left;
        }
                
        .uppercase
        {
            text-transform:uppercase;
        }

        #form2
        {
            text-align: left;
        }
        .style45
        {
            width: 747px;
            font-family: Arial;
        }
        .style53
        {
            font-size: medium;
            text-align: left;
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
        .style69
        {
            width: 645px;
            font-family: Arial;
        }
        .style67
        {
            font-size: medium;
            text-align: left;
            width: 175px;
            height: 8px;
        }
        .style50
        {
            font-size: xx-large;
            width: 342px;
            text-align: left;
            height: 8px;
        }
        .style60
        {
            width: 175px;
            text-align: left;
        }
        .style80
        {
            font-size: x-large;
        }
        .style68
        {
            text-align: left;
            width: 342px;
        }
        .style29
        {
            font-family: Arial;
            font-size: xx-large;
        }
        
        .style78
        {
            width: 175px;
            height: 1px;
            text-align: left;
        }
        .style79
        {
            text-align: left;
            width: 342px;
            height: 1px;
        }
        .style72
        {
            width: 175px;
            height: 20px;
            text-align: left;
        }
        .style71
        {
            text-align: left;
            width: 342px;
            height: 20px;
        }
        .style73
        {
            width: 175px;
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
            width: 175px;
            height: 6px;
            text-align: left;
        }
        .style76
        {
            text-align: left;
            width: 342px;
            height: 6px;
        }
        .style81
        {
            font-family: Arial;
            font-size: x-large;
        }
        </style>
</head>
<body style="text-align: center; height: 559px; width: 1143px;" onload="getLocation()">
<script type="text/javascript" language=javascript>
 function getLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        }
        else { x.innerHTML = "Geolocation is not supported by this browser."; }
    }
    function showPosition(position) {
        var latlondata = position.coords.latitude + "," + position.coords.longitude;
        var latlon = "Your Latitude Position is:=" + position.coords.latitude + "," + "Your Longitude Position is:=" + position.coords.longitude;
        //alert(latlon);
        document.getElementById('Long').value = position.coords.longitude;
        document.getElementById('Lat').value = position.coords.latitude;
    }
    </script>

    <form id="qrDatForm" runat="server" class="style52" >
    <br />
        <table id="tCode" class="style45" align="center">
            <tr>
                <td class="style53">
                    &nbsp;<img alt="" class="style56" src="standard/header.png" /><img alt="" class="style57" 
                        src="standard/header_ani.gif" /></td>
            </tr>
            </table>
    <span>
    <br />
    </span>
    <table id="tCode0" class="style69" align="center">
        <tr>
            <td class="style67" style="visibility: hidden">
                &nbsp;</td>
            <td class="style50" style="visibility: hidden"  >
&nbsp;<asp:TextBox ID="Long" runat="server"></asp:TextBox>
                -
                <asp:TextBox ID="Lat" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="tbMake" runat="server" Width="402px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None" Height="30px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style60">
                <asp:Label ID="lbModel" runat="server" Text="Model" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style68">
                <asp:TextBox ID="tbModel" runat="server" Width="411px" ReadOnly="True" 
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
                <asp:TextBox ID="tbColours" runat="server" Width="403px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None" Height="30px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style72">
                <asp:Label ID="lbSerial" runat="server" Text="Serial No" CssClass="style80"></asp:Label>
            </td>
            <td id="" class="style71">
                <asp:TextBox ID="tbSerial" runat="server" Width="406px" ReadOnly="True" 
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
    <asp:Timer ID="Timer1" runat="server" Interval="2000" ontick="Timer1_Tick" Enabled="False">
    </asp:Timer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>
</body>
</html>
