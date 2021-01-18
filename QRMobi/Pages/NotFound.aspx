<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotFound.aspx.cs" Inherits="QRMobi.Pages.NotFound" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            text-align: left;
        }
                
        .uppercase
        {
            text-transform: uppercase;
        }
        
        #form2
        {
            text-align: left;
        }
        .cButton
        {
            border-style: hidden;
            border-radius: 0;
            width: 270px;
            height: 130px;
            color: White;
            font-size: 25px;
        }
        .tfooter
        {
            text-align: left;
            background-color: #00CC00;
        }
        .style54
        {
            width: 1094px;
        }
        .style55
        {
            width: 581px;
            text-align: center;
        }
        .style56
        {
            text-align: right;
        }
        .style57
        {
            width: 21px;
        }
        .style58
        {
            width: 21px;
            height: 835px;
        }
        .style59
        {
            width: 1094px;
            height: 835px;
        }
        .style60
        {
            height: 835px;
        }
        .style61
        {
            width: 100%;
            height: 1837px;
        }
        .style63
        {
            text-align: left;
        }
        .style64
        {
            width: 17px;
        }
        .style65
        {
            text-align: center;
        }
        .style71
        {
            width: 101%;
        }
        .dleft
        {
            width: 314px;
            margin-left: 230px;
        }
        .dright
        {
            width: 302px;
            margin-left: 111px;
        }
        .style74
        {
            width: 545px;
        }
        .style76
        {
            text-align: center;
            width: 1095px;
        }
        .style78
        {
            width: 545px;
            text-align: right;
        }
        .style79
        {
            width: 102%;
            height: 531px;
        }
        .style80
        {
            text-align: right;
            height: 153px;
            width: 515px;
        }
        .style81
        {
            width: 17px;
            height: 115px;
        }
        .style82
        {
            text-align: left;
            height: 115px;
        }
        .style83
        {
            width: 515px;
        }
        .style84
        {
            text-align: right;
            width: 515px;
        }
        .style86
        {
            width: 99%;
        }
        .style87
        {
            width: 103%;
        }
        .style88
        {
            width: 101%;
            height: 2116px;
        }
        .style90
        {
            width: 5px;
        }
        .style91
        {
            width: 1095px;
        }
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            width: 559px;
            text-align: center;
        }
        .auto-style6 {
            text-align: right;
            width: 488px;
        }
        .auto-style7 {
            text-align: left;
            height: 350px;
        }
        </style>
</head>
<body style="height: 2109px; width: 1154px" onload="getLocation()">
    <script type="text/javascript">

        function dolink(link) {
            window.open(link);
        }

        function doalert(a) {
            alert(a);
        }

        function showPosition(position) {

            document.getElementById('lat').value = position.coords.latitude;
            document.getElementById('long').value = position.coords.longitude;

            //var url = "http://maps.google.com/maps?q=" + lat + "," + long;

            //alert(url);

            //window.open(url, '_blank');

        }


        function showError(error) {

            //alert(error.code);

        }

        function getLocation() {

            if (navigator.geolocation) {

                var options = {
                    enableHighAccuracy: true,
                    timeout: 30000
                };

                document.getElementById('lat').value = 0;
                document.getElementById('long').value = 0;


                navigator.geolocation.getCurrentPosition(showPosition, showError, options);

            }

        }

        function displaymap() {

            var url = "http://maps.google.com/maps?q=" + document.getElementById('lat').value + "," + document.getElementById('long').value;

            window.open(url, '_blank');

        }

    </script>

    <form id="qrCesar" runat="server" 
    style="background-image: url('../Imagescsrm/bg-large.jpg');" class="style88">&nbsp;<table class="style61">
        <tr>
            <td class="style57">
                &nbsp;</td>
            <td class="style54">
                <table class="auto-style4">
                    <tr>
                        <td class="auto-style5">
                            &nbsp;</td>
                        <td class="auto-style6">
                            <asp:Image ID="Image2" runat="server" 
                                ImageUrl="~/Imagescsrm/datatag-logo.png" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style58">
                </td>
            <td class="style59" 
                style="background-image: url('Imagescsrm/box-top.png'); background-repeat: no-repeat">
                <div align="center">
                    <h1 style="color:white;font-size:100px">No data found for this QR Code</h1>
                </div></td>
            <td class="style60">
                
                </td>
        </tr>
        <tr>
            <td class="style57">
                &nbsp;</td>
            <td align="center">
                <asp:HyperLink ID="hlContinue" runat="server" Font-Size="60px" Font-Names="Arial" ForeColor="White">Click to Continue to product site</asp:HyperLink>
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style57">
                &nbsp;</td>
            <td class="style54" 
                style="background-image: url('ImagesMaster/box-bottom.png'); background-repeat: no-repeat">
                <table class="style79">
                    <tr>
                        <td class="auto-style7">
                            &nbsp;</td>
                    </tr>
                    </table>
            </td>

            <td>
                &nbsp;</td>
        </tr>
        </table>
        </form>

</body>
</html>
