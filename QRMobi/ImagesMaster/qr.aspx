<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qr.aspx.cs" Inherits="QRMobi.Qr"
    MasterPageFile="" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .uppercase
        {
            text-transform: uppercase;
        }
        
        #form1
        {
            text-align: left;
        }
        .style29
        {
            font-family: Arial;
            font-size: xx-large;
        }
        .style45
        {
            width: 557px;
            font-family: Arial;
            height: 379px;
        }
        .style50
        {
            font-size: medium;
            text-align: left;
            width: 342px;
        }
        .style52
        {
            width: 908px;
            height: 531px;
        }
        .style54
        {
            text-align: left;
        }
        .style56
        {
            font-family: Arial;
            font-size: xx-large;
            margin-left: 0px;
        }
        .style57
        {
            font-size: x-large;
            width: 337px;
            text-align: left;
        }
        .style60
        {
            font-size: x-large;
            width: 337px;
            text-align: left;
            height: 42px;
        }
        .style61
        {
            text-align: left;
            height: 42px;
            width: 342px;
        }
        .style62
        {
            width: 74%;
        }
        .style63
        {
            width: 193px;
            height: 101px;
        }
        .style64
        {
            width: 470px;
            height: 100px;
        }
        .style65
        {
            width: 182px;
        }
        .style66
        {
            width: 494px;
        }
        .style67
        {
            font-size: medium;
            text-align: left;
            width: 337px;
        }
        .style68
        {
            text-align: left;
            width: 342px;
        }
        .style69
        {
            font-size: x-large;
            text-align: left;
        }
        .style70
        {
            font-size: large;
        }
    </style>
</head>
<body style="height: 521px; width: 1023px; text-align: center" onload="getLocation()">
    <script type="text/javascript" language="javascript">
        function getLocation() {

            if (navigator.geolocation) {

                document.getElementById('Long').value = 0;
                document.getElementById('Lat').value = 0;

                navigator.geolocation.getCurrentPosition(showPosition,showError);
            }

        }

        function showPosition(position) {
            //var latlondata = position.coords.latitude + "," + position.coords.longitude;
            //var latlon = "Your Latitude Position is:=" + position.coords.latitude + "," + "Your Longitude Position is:=" + position.coords.longitude;
            //alert(latlon);
            document.getElementById('Long').value = position.coords.longitude;
            document.getElementById('Lat').value = position.coords.latitude;
        }

        function showError(error) {

            //alert(error.code);

        }


    </script>
    <form id="qrMaster" runat="server" class="style52">
    <div class="style54">
        <table align="center" class="style62" frame="void">
            <tr>
                <td class="style65">
                    <img alt="" class="style63" src="Images/header.png" />
                </td>
                <td class="style66">
                    <img alt="" class="style64" src="Images/header_ani.gif" />
                </td>
            </tr>
        </table>
        <br />
        <table id="tCode" class="style45" align="center">
            <tr>
                <td class="style67">
                    &nbsp;
                </td>
                <td class="style50" style="display: none">
                    <asp:TextBox ID="Lat" runat="server">0</asp:TextBox>
                    &nbsp;-
                    <asp:TextBox ID="Long" runat="server">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style60">
                    <asp:Label ID="lbID" runat="server" Text="id"></asp:Label>
                </td>
                <td id="" class="style61">
                    <asp:TextBox ID="tbID" runat="server" ReadOnly="True" CssClass="style29" Width="339px"
                        BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style57">
                    <asp:Label ID="lbMake" runat="server" Text="Make"></asp:Label>
                </td>
                <td id="" class="style68">
                    <asp:TextBox ID="tbModel" runat="server" Width="342px" ReadOnly="True" CssClass="style29"
                        BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style57">
                    <asp:Label ID="lbModel" runat="server" Text="Model"></asp:Label>
                </td>
                <td id="" class="style68">
                    <asp:TextBox ID="tbMake" runat="server" Width="341px" ReadOnly="True" CssClass="style29"
                        BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style57">
                    <asp:Label ID="lbType" runat="server" Text="Type"></asp:Label>
                </td>
                <td id="" class="style68">
                    <asp:TextBox ID="tbType" runat="server" Width="342px" ReadOnly="True" CssClass="style56"
                        BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style57">
                    <asp:Label ID="lbColour" runat="server" Text="Colour"></asp:Label>
                </td>
                <td id="" class="style68">
                    <asp:TextBox ID="tbColours" runat="server" Width="342px" ReadOnly="True" CssClass="style29"
                        BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style57">
                    <asp:Label ID="lbVinSer" runat="server" Text="Vin/Ser"></asp:Label>
                </td>
                <td id="" class="style68">
                    <asp:TextBox ID="tbVINSER" runat="server" Width="342px" ReadOnly="True" CssClass="style29"
                        BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style57">
                    <asp:Label ID="lbEngine" runat="server" Text="Engine"></asp:Label>
                </td>
                <td id="" class="style68">
                    <asp:TextBox ID="tbEngine" runat="server" Width="342px" ReadOnly="True" CssClass="style29"
                        BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style57">
                    &nbsp;
                </td>
                <td id="" class="style68">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style69" colspan="2">
                    <strong>
                        <asp:Label ID="lbPolice" runat="server" CssClass="style70"></asp:Label>
                    </strong>
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>
