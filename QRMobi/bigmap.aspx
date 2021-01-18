<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bigmap.aspx.cs" Inherits="QRMobi.bigmap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

        .hiddencol {
            display: none;
        }

        #map {
            position:absolute;
            top: 0px;
            left: 0;
            bottom: 0px;
            right: 0;
        }

        #mapold {
            height: 1000px;
            width: 1000px;
            /*margin-left: 80px;*/
        }
        


    </style>
</head>
<body style="height:100%; width:100%">
    <script type="text/javascript">

    </script>

    <form id="form1" runat="server" >
        <div id="map" style="height:100%;width:100%"></div>   
        <script>
            var map, infoWindow, geocoder;

            function initMap() {
                map = new google.maps.Map(document.getElementById('map'), {
                    center: { lat: 0, lng: 0},
                    zoom: 10
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

                        //infoWindow.open(map);
                        //map.setCenter(pos);

                        var input = position.coords.latitude + ',' + position.coords.longitude;
                        var latlngStr = input.split(',', 2);
                        var latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };

                        geocoder.geocode({ 'location': latlng }, function (results, status) {
                            if (status == 'OK') {
                                if (results[0]) {
                                    map.setZoom(10);
                                    var marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });

                                    infoWindow.setContent('Your Location: ' + results[0].formatted_address);
                                    infoWindow.open(map, marker);

                                    infoWindow.open(map);
                                    map.setCenter(pos);

                                    input = '<%=this.latlng1.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng2.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng3.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng4.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng5.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng6.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng7.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng8.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng9.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng10.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng11.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng12.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng13.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng14.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng15.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng16.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng17.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng18.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng19.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng20.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng21.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng22.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng23.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng24.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng25.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng26.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng27.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng28.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng29.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);

                                    input = '<%=this.latlng30.Text %>';
                                    latlngStr = input.split(',', 2);
                                    latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
                                    marker = new google.maps.Marker({
                                        position: latlng,
                                        map: map
                                    });
                                    infoWindow.open(map, marker);


                                    document.getElementById('tbHIDAddress').value = results[0].formatted_address;

                                    document.getElementById('lat').value = latlngStr[0];
                                    document.getElementById('lng').value = latlngStr[1];


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
        <script <%--async defer--%>
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC4HFYPpRxO9KimpmBerRXC_oR1HLyiJbc&callback=initMap&iwloc=A&output=embed">
        </script>

        <div class="hiddencol" align="center">
            <asp:TextBox ID="SessionCurrent" runat="server"></asp:TextBox>
            <asp:TextBox ID="lng" runat="server"></asp:TextBox>
            <asp:TextBox ID="lat" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbHIDAddress" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbHIDPostCode" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbHIDGUID" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbHIDUsername" runat="server"></asp:TextBox>
            <asp:TextBox ID="btnLeftMode" runat="server"></asp:TextBox>
            <asp:TextBox ID="btnRightMode" runat="server"></asp:TextBox>
            <asp:TextBox ID="btnMiddleMode" runat="server"></asp:TextBox>

        </div>
        <div class="hiddencol">
            <asp:TextBox ID="latlng1" runat="server"></asp:TextBox>
            <asp:TextBox ID="add1" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng2" runat="server"></asp:TextBox>
            <asp:TextBox ID="add2" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng3" runat="server"></asp:TextBox>
            <asp:TextBox ID="add3" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng4" runat="server"></asp:TextBox>
            <asp:TextBox ID="add4" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng5" runat="server"></asp:TextBox>
            <asp:TextBox ID="add5" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng6" runat="server"></asp:TextBox>
            <asp:TextBox ID="add6" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng7" runat="server"></asp:TextBox>
            <asp:TextBox ID="add7" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng8" runat="server"></asp:TextBox>
            <asp:TextBox ID="add8" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng9" runat="server"></asp:TextBox>
            <asp:TextBox ID="add9" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng10" runat="server"></asp:TextBox>
            <asp:TextBox ID="add10" runat="server"></asp:TextBox>

            <asp:TextBox ID="latlng11" runat="server"></asp:TextBox>
            <asp:TextBox ID="add11" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng12" runat="server"></asp:TextBox>
            <asp:TextBox ID="add12" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng13" runat="server"></asp:TextBox>
            <asp:TextBox ID="add13" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng14" runat="server"></asp:TextBox>
            <asp:TextBox ID="add14" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng15" runat="server"></asp:TextBox>
            <asp:TextBox ID="add15" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng16" runat="server"></asp:TextBox>
            <asp:TextBox ID="add16" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng17" runat="server"></asp:TextBox>
            <asp:TextBox ID="add17" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng18" runat="server"></asp:TextBox>
            <asp:TextBox ID="add18" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng19" runat="server"></asp:TextBox>
            <asp:TextBox ID="add19" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng20" runat="server"></asp:TextBox>
            <asp:TextBox ID="add20" runat="server"></asp:TextBox>

            <asp:TextBox ID="latlng21" runat="server"></asp:TextBox>
            <asp:TextBox ID="add21" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng22" runat="server"></asp:TextBox>
            <asp:TextBox ID="add22" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng23" runat="server"></asp:TextBox>
            <asp:TextBox ID="add23" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng24" runat="server"></asp:TextBox>
            <asp:TextBox ID="add24" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng25" runat="server"></asp:TextBox>
            <asp:TextBox ID="add25" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng26" runat="server"></asp:TextBox>
            <asp:TextBox ID="add26" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng27" runat="server"></asp:TextBox>
            <asp:TextBox ID="add27" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng28" runat="server"></asp:TextBox>
            <asp:TextBox ID="add28" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng29" runat="server"></asp:TextBox>
            <asp:TextBox ID="add29" runat="server"></asp:TextBox>
            <asp:TextBox ID="latlng30" runat="server"></asp:TextBox>
            <asp:TextBox ID="add30" runat="server"></asp:TextBox>

        </div>
    </form>
</body>
</html>
