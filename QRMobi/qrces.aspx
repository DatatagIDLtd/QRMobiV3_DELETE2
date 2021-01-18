<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qrces.aspx.cs" Inherits="QRMobi.Webcsr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            text-align: left;
        }

        .uppercase {
            text-transform: uppercase;
        }

        #form2 {
            text-align: left;
        }

        .cButton {
            border-style: hidden;
            border-radius: 0;
            width: 270px;
            height: 130px;
            color: White;
            font-size: 25px;
        }

        .tfooter {
            text-align: left;
            background-color: #00CC00;
        }

        .style54 {
            width: 1094px;
        }

        .style55 {
            width: 581px;
            text-align: center;
        }

        .style56 {
            text-align: right;
        }

        .style57 {
            width: 21px;
        }

        .style58 {
            width: 21px;
            height: 835px;
        }

        .style59 {
            width: 1094px;
            height: 835px;
        }

        .style60 {
            height: 835px;
        }

        .style61 {
            width: 100%;
            height: 1837px;
        }

        .style63 {
            text-align: left;
        }

        .style64 {
            width: 17px;
        }

        .style65 {
            text-align: center;
        }

        .style71 {
            width: 101%;
        }

        .style74 {
            width: 545px;
        }

        .style76 {
            text-align: center;
            width: 1095px;
        }

        .style78 {
            width: 545px;
            text-align: right;
        }

        .style79 {
            width: 102%;
            height: 531px;
        }

        .style80 {
            text-align: right;
            height: 153px;
            width: 515px;
        }

        .style81 {
            width: 17px;
            height: 153px;
        }

        .style82 {
            text-align: left;
            height: 153px;
        }

        .style83 {
            width: 515px;
        }

        .style84 {
            text-align: right;
            width: 515px;
        }

        .style86 {
            width: 99%;
        }

        .style87 {
            width: 103%;
        }

        .style88 {
            width: 100%;
            height: 2116px;
        }

        .style90 {
            width: 5px;
        }

        .style91 {
            width: 1095px;
        }



        .cesCol {
            width: 135px;
            font-family: Arial;
            font-display: block;
            text-align: left;
            color: white;
            padding-left: 20px;
            font-size: 25px;
        }

        .cesColValue {
            width: 164px;
            font-family: Arial;
            font-display: block;
            text-align: left;
            font-size: 25px;
            color: #66FF66;
            font-weight: bold;
        }

        .cesLabel {
            font-family: Arial;
            font-size: 25px;
            font-weight: bold;
            color: #66FF66;
        }

        .tblCES {
            width: 95%;
        }

        .tbLeftCol {
            width: 538px;
            background-color: black;
            border-radius: 5px;
        }

        .divPic {
            width: 50px;
            height: 50px;
        }


        .auto-style26 {
            width: 255px;
            height: 131px;
        }

        .auto-style60 {
            width: 255px;
        }

        .auto-style73 {
            width: 356px;
        }

        .auto-style81 {
            text-align: left;
            width: 7px;
            height: 131px;
        }

        .auto-style82 {
            width: 27px;
            height: 359px;
        }

        .auto-style83 {
            width: 738px;
            height: 359px;
        }

        .auto-style85 {
            width: 255px;
            height: 59px;
        }

        .auto-style86 {
            width: 39%;
            height: 48px;
        }

        .auto-style89 {
            text-align: left;
            width: 270px;
            height: 59px;
        }

        .auto-style90 {
            text-align: left;
            width: 270px;
        }

        .auto-style102 {
            text-align: left;
            width: 270px;
            height: 104px;
        }

        .auto-style104 {
            width: 255px;
            height: 104px;
        }

        .auto-style106 {
            width: 54px;
        }

        .auto-style111 {
            width: 27px;
            height: 560px;
        }

        .auto-style113 {
            text-align: left;
            width: 320px;
        }

        .auto-style115 {
            width: 51px;
        }

        .bbody {
            height: 1096px;
            width: 1236px;
            margin-bottom: 0px;
            overflow-x: hidden;
        }

        .tblTop {
        }

        .fform {
            background-size: 100% 100%;
            background-image: url('Imagescsrm/bg-large.jpg');
        }


        .auto-style117 {
            width: 1203px;
        }

        .auto-style45 {
            width: 92%;
            height: 465px;
            margin-top: 0px;
        }

        .auto-style15 {
            width: 957px;
            border-radius: 5px;
            margin-left: 73px;
            height: 337px;
        }

        .auto-style13 {
            width: 518px;
            background-color: black;
        }

        .auto-style16 {
            width: 481px;
        }

        .auto-style105 {
            font-family: Arial;
            font-display: block;
            text-align: center;
            color: white;
            padding-left: 20px;
            font-size: 25px;
        }

        .auto-style47 {
            width: 206px;
            font-family: Arial;
            font-display: block;
            text-align: left;
            color: white;
            padding-left: 20px;
            font-size: 25px;
        }

        .auto-style107 {
            width: 215px;
            font-family: Arial;
            font-display: block;
            text-align: left;
            font-size: 25px;
            color: #66FF66;
            font-weight: bold;
        }

        .auto-style44 {
            width: 681px;
        }

        .divAsset {
            height: 600px;
        }

        .topbox {
            background-size: 100% 100%;
            background-image: url('Imagescsrm/box-top.png');
            background-repeat: no-repeat;
        }

        .bottombox {
            background-size: 100% 75%;
            background-image: url('Imagescsrm/box-bottom.png');
            background-repeat: no-repeat;
        }

        .auto-style119 {
            width: 56px;
        }

        .auto-style124 {
            text-align: left;
            width: 174px;
            height: 59px;
        }

        .auto-style125 {
            text-align: left;
            width: 174px;
            height: 104px;
        }

        .auto-style126 {
            text-align: left;
            width: 174px;
        }

        .auto-style127 {
            width: 27px;
        }

        .auto-style129 {
            width: 174px;
        }

        .auto-style130 {
            text-align: left;
            width: 7px;
            height: 59px;
        }

        .auto-style131 {
            text-align: left;
            width: 7px;
            height: 104px;
        }

        .auto-style132 {
            text-align: left;
            width: 7px;
        }

        .auto-style133 {
            width: 270px;
        }

        .auto-style134 {
            height: 120px;
            width: 1039px;
        }
    </style>
</head>
<body class="bbody" onload="getLocation()">
    <script type="text/javascript">

        //$(document).ready(function () {
        //    getLocation();
        //});

        function dolink(link) {
            window.open(link);
        }

        function doalert(a) {
            alert(a);
        }

        function showPosition(position) {

            document.getElementById('tbLat').value = position.coords.latitude;
            document.getElementById('tbLong').value = position.coords.longitude;

            //var url = "https://maps.google.com/maps?q=" + position.coords.latitude + "," + position.coords.longitude;

            //alert(position.coords.latitude);

            //window.open(url, '_blank');
        }


        function showError(error) {

            //alert(error.code);
        }

        function getLocation() {

            if (navigator.geolocation) {

                var options = {
                    enableHighAccuracy: true,
                    timeout: 30000,
                    maximumAge: 75000
                };

                document.getElementById('tbLat').value = 9999;
                document.getElementById('tbLong').value = 9999;

                navigator.geolocation.getCurrentPosition(showPosition, showError, options);
            }

        }

        function displaymap() {

            var url = "http://maps.google.com/maps?q=" + document.getElementById('tbLat').value + "," + document.getElementById('tbLong').value;

            window.open(url, '_blank');

        }

    </script>
    <form id="qrCesar" runat="server" class="fform">
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
        <table class="auto-style117">
            <tr>
                <td class="auto-style127"></td>
                <td class="topbox">
                    <table class="auto-style45">
                        <tr>
                            <td></td>
                            <td class="" style="display: none">
                                <asp:TextBox Name="tbLate" ID="tbLat" runat="server">0</asp:TextBox>
                                <asp:TextBox Name="tbLong" ID="tbLong" runat="server">0</asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <div class="auto-style134">
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>
                                <div class="divAsset">
                                    <table class="auto-style15">
                                        <tr>
                                            <td class="auto-style13">
                                                <table class="auto-style16">
                                                    <tr>
                                                        <td class="auto-style105" colspan="2">Vehicle Details</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">&nbsp;</td>
                                                        <td class="auto-style107">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">CESAR ID:</td>
                                                        <td class="auto-style107">
                                                            <asp:Label ID="lbID" runat="server" Text="-"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">MAKE:</td>
                                                        <td class="auto-style107">
                                                            <asp:Label ID="lbMake" runat="server" Text="-"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">MODEL:</td>
                                                        <td class="auto-style107">
                                                            <asp:Label ID="lbModel" runat="server" Text="-"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">COLOUR:</td>
                                                        <td class="auto-style107">
                                                            <asp:Label ID="lbColour" runat="server" Text="-"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">HOSDB Category:</td>
                                                        <td class="auto-style107">
                                                            <asp:Label ID="lbHOSDBCategory" runat="server" Text="-"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">SERIAL/VIN:</td>
                                                        <td class="auto-style107">
                                                            <asp:Label ID="lbSerial" runat="server" Text="-"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">ENGINE NO:</td>
                                                        <td class="auto-style107">
                                                            <asp:Label ID="lbEngine" runat="server" Text="-"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">ECV FITTED:</td>
                                                        <td class="auto-style107">
                                                            <asp:Label ID="lbECV" runat="server" Text="-"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style47">&nbsp;</td>
                                                        <td class="auto-style107">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td>
                                                <div style="margin-left:20px">
                                                    <asp:Image ID="imgAsset" runat="server"  Width="400px" Height="300px" />
                                                </div>
                                            </td>

                                        </tr>
                                    </table>
                                </div>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style82"></td>
                <td class="auto-style83">
                    <table class="">
                        <tr>
                            <td class="auto-style119"></td>
                            <td class="style63">
                                <asp:ImageButton ID="ibHire" runat="server" ImageUrl="~/Imagescsrm/button-hire-it.png" OnClientClick="doalert('Feature Disabled')" />
                            </td>
                            <td class="auto-style106"></td>
                            <td class="style63">
                                <asp:ImageButton ID="ibStolen" runat="server"
                                    ImageUrl="~/Imagescsrm/button-report-stolen.png" OnClientClick="doalert('Feature Disabled')" />
                            </td>
                            <td class="auto-style115"></td>
                            <td class="auto-style113">
                                <asp:ImageButton ID="ibScan" runat="server" ImageUrl="~/CesarECV/Theft_Check.png" OnClientClick="doalert('Feature Disabled')" Width="304px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style111"></td>
                <td class="bottombox">
                    <div style="height: 70px;"></div>
                    <table>
                        <tr>
                            <td class="auto-style129">&nbsp;</td>
                            <td class="auto-style133">

                                <asp:ImageButton ID="ibDealer" runat="server"
                                    ImageUrl="~/Imagescsrm/button-dealer.png" OnClientClick="target='blank'" PostBackUrl="https://www.cesarscheme.org/Dealer_Locator.html" />
                            </td>
                            <td class="auto-style81"></td>
                            <td class="auto-style26">
                                <asp:ImageButton ID="ibSafety" runat="server" ImageUrl="~/CesarECV/Blue_Outer_Blank_80pc.png" OnClientClick="target='blank'" />

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style124">&nbsp;</td>
                            <td class="auto-style89">
                                <asp:ImageButton ID="ibECV" runat="server" ImageUrl="~/CesarECV/ECV_Details_BUTTON.png" />
                            </td>
                            <td class="auto-style130"></td>
                            <td class="auto-style85">
                                <asp:ImageButton ID="ibParts" runat="server" ImageUrl="~/CesarECV/Blue_Outer_Blank_80pc.png" OnClientClick="target='blank'" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style125"></td>
                            <td class="auto-style102">
                                <asp:ImageButton ID="ibParts0" runat="server" ImageUrl="~/CesarECV/Blue_Outer_Blank_80pc.png" OnClientClick="target='blank'" />
                            </td>
                            <td class="auto-style131"></td>
                            <td class="auto-style104">
                                <asp:ImageButton ID="ibService" runat="server" ImageUrl="~/CesarECV/Blue_Outer_Blank_80pc.png" OnClientClick="target='blank'" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style126">&nbsp;</td>
                            <td class="auto-style90">&nbsp;</td>
                            <td class="auto-style132">&nbsp;</td>
                            <td class="auto-style60">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style126">&nbsp;</td>
                            <td class="auto-style90">&nbsp;</td>
                            <td class="auto-style132">&nbsp;</td>
                            <td class="auto-style60">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style126">&nbsp;</td>
                            <td class="auto-style90">&nbsp;</td>
                            <td class="auto-style132">&nbsp;</td>
                            <td class="auto-style60">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style126">&nbsp;</td>
                            <td class="auto-style90">&nbsp;</td>
                            <td class="auto-style132">&nbsp;</td>
                            <td class="auto-style60">&nbsp;</td>
                        </tr>

                    </table>
                    <div style="margin-left: 70px; margin-top: 50px;">
                        <asp:ImageButton ID="ImageButton1" runat="server"
                            ImageUrl="~/Imagescsrm/contact.png"
                            OnClientClick="dolink('http://www.datatag.co/stihl/contact/')" />
                    </div>
                </td>
            </tr>
        </table>
        <table class="auto-style86">
            <tr>
                <td class="auto-style73" style="display: none">
                    <asp:Label ID="lbECVCode" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style73">
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>

</html>
