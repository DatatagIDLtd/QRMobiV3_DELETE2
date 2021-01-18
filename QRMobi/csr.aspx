<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="csr.aspx.cs" Inherits="QRMobi.csr" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .bbody {
            height: 2200px;
            width: 1225px;
            overflow-x: hidden;
            margin: 0 auto;
        }

        .fform {
            /*background-size: 100% 100%;*/
            background-image: url('Imagescsrm/bg-large.jpg');
            background-repeat: no-repeat;
            height: 2200px;
        }

        .tblBanner {
            width: 100%;
        }

        .divBanner {
            width: 100%;
        }

        .rightAlign {
            float: right;
        }

        .ImageRight {
            float: right;
            Height: 175px;
            Width: 400px;
        }

        .divScreen1 {
            height: 1000px;
            width: 1500px;
            margin-left: 75px;
        }

        .divAssetImage {
            position: relative;
            text-align: center;
            width: 1100px;
        }

        .divFields {
        }

        .tblFields {
            position: relative;
            width: 1069px;
            left: 0px;
            top: 0px;
        }

        .tblRow {
            height: 50px;
        }

        .fieldRight {
            margin-left: 120px
        }

        .fieldLeft {
            margin-left: 220px;
        }

        .auto-style1 {
            width: 521px;
        }
    </style>
</head>
<body class="bbody">
    <form id="form1" class="fform" runat="server">
        <div class="divBanner">
            <table class="tblBanner">
                <tr>
                    <td>
                        <asp:Image ID="ImageLeft" runat="server" ImageUrl="~/Imagescsrm2/CESAR_Datatag_Logo.png" Height="181px" Style="margin-right: 0px" Width="452px" />
                    </td>
                    <td>
                        <asp:Image ID="ImageRight" class="ImageRight" runat="server" ImageUrl="~/Imagescsrm2/CESAR_Datatag_Logo.png" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div class="divScreen1" style="background-image: url('Imagescsrm2/box_top.png'); background-repeat: no-repeat">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="vInfo1" runat="server">
                    <div style="display: none" id="map"></div>
                    <script>
                        var map, infoWindow, geocoder;

                        function initMap() {
                            map = new google.maps.Map(document.getElementById('map'), {
                                center: { lat: -34.397, lng: 150.644 },
                                zoom: 6
                            });

                            infoWindow = new google.maps.InfoWindow;
                            geocoder = new google.maps.Geocoder;

                            // Try HTML5 geolocation.
                            if (navigator.geolocation) {
                                navigator.geolocation.getCurrentPosition(function (position) {
                                    var pos = {
                                        lat: position.coords.latitude,
                                        lng: position.coords.longitude
                                    };

                                    //infoWindow.setPosition(pos);
                                    //infoWindow.setContent('Location found.');

                                    infoWindow.open(map);
                                    map.setCenter(pos);

                                    var input = position.coords.latitude + ',' + position.coords.longitude;
                                    var latlngStr = input.split(',', 2);
                                    var latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };

                                    geocoder.geocode({ 'location': latlng }, function (results, status) {
                                        if (status == 'OK') {
                                            if (results[0]) {
                                                map.setZoom(11);
                                                var marker = new google.maps.Marker({
                                                    position: latlng,
                                                    map: map
                                                });

                                                //infoWindow.setContent(results[0].formatted_address);


                                                document.getElementById('tbHIDAddress').value = results[0].formatted_address;
                                                //document.getElementById('tbHIDPostCode').value = results[0].;
                                                document.getElementById('lat').value = latlngStr[0];
                                                document.getElementById('lng').value = latlngStr[1];

                                                infoWindow.open(map, marker);
                                            } else {

                                                window.alert('No results found');
                                            }
                                        } else {
                                            window.alert('Geocoder failed due to: ' + status);
                                        }
                                    });

                                }, function () {
                                    handleLocationError(true, infoWindow, map.getCenter());
                                });
                            } else {
                                // Browser doesn't support Geolocation
                                handleLocationError(false, infoWindow, map.getCenter());
                            }
                        }

                        function handleLocationError(browserHasGeolocation, infoWindow, pos) {
                            infoWindow.setPosition(pos);
                            infoWindow.setContent(browserHasGeolocation ?
                                'Error: The Geolocation service failed.' :
                                'Error: Your browser doesn\'t support geolocation.');
                            infoWindow.open(map);
                        }
                    </script>
                    <script async defer
                        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC4HFYPpRxO9KimpmBerRXC_oR1HLyiJbc&callback=initMap">
                    </script>
                    <div class="divAssetImage">
                        <br />
                        <br />
                        <asp:Image ID="imgAsset" ImageUrl="~/Imagescsrm2/CESAR_Datatag_Logo.png" runat="server" Height="300px" Width="400px" />
                    </div>
                    <div class="divFields">
                        <table class="tblFields">
                            <tr class="tblRow">
                                <td class="auto-style1"></td>
                                <td></td>
                            </tr>
                            <tr class="tblRow">
                                <td colspan="2" style="background-image: url('Imagescsrm/field-id.png'); background-repeat: no-repeat; background-position: center;">
                                    <div class="fieldLeft">
                                        <asp:Label ID="lbID" runat="server" Font-Names="Arial" Font-Size="XX-Large"
                                            ForeColor="#66FF66" Text="-"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr class="tblRow">
                                <td style="background-image: url('Imagescsrm/field-make.png'); background-repeat: no-repeat; background-position: right" class="auto-style1">
                                    <div class="fieldLeft">
                                        <asp:Label ID="lbMake" runat="server" Font-Names="Arial" Font-Size="XX-Large"
                                            ForeColor="#66FF66">-</asp:Label>
                                    </div>
                                </td>
                                <td style="background-image: url('Imagescsrm/field-model.png'); background-repeat: no-repeat; background-position: left">
                                    <div class="fieldRight">
                                        <asp:Label ID="lbModel" runat="server" Font-Names="Arial" Font-Size="XX-Large"
                                            ForeColor="#66FF66">-</asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr class="tblRow">
                                <td style="background-image: url('Imagescsrm/field-type.png'); background-repeat: no-repeat; background-position: right" class="auto-style1">
                                    <div class="fieldLeft">
                                        <asp:Label ID="lbType" runat="server" Font-Names="Arial" Font-Size="XX-Large"
                                            ForeColor="#66FF66">-</asp:Label>
                                    </div>
                                </td>
                                <td style="background-image: url('Imagescsrm/field-colour.png'); background-repeat: no-repeat; background-position: left">
                                    <div class="fieldRight">
                                        <asp:Label ID="lbColour" runat="server" Font-Names="Arial" Font-Size="XX-Large"
                                            ForeColor="#66FF66">-</asp:Label>
                                    </div>
                                </td>

                            </tr>
                            <tr class="tblRow">
                                <td style="background-image: url('Imagescsrm/field-serial.png'); background-repeat: no-repeat; background-position: right">
                                    <div class="fieldLeft">
                                        <asp:Label ID="lbSerial" runat="server" Font-Names="Arial" Font-Size="XX-Large"
                                            ForeColor="#66FF66">-</asp:Label>
                                    </div>
                                </td>
                                <td style="background-image: url('Imagescsrm/field-engine.png'); background-repeat: no-repeat; background-position: left">
                                    <div class="fieldRight">
                                        <asp:Label ID="lbEngine" runat="server" Font-Names="Arial" Font-Size="XX-Large"
                                            ForeColor="#66FF66">-</asp:Label>
                                    </div>
                                </td>
                            </tr>

                        </table>
                    </div>
                </asp:View>
            </asp:MultiView>

        </div>
    </form>
</body>
</html>
