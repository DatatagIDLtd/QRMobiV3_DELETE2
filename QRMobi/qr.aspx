<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qr.aspx.cs" Inherits="QRMobi.qr"
    MasterPageFile="" %>

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
        .auto-style1 {
            width: 511px;
        }
        .auto-style2 {
            text-align: right;
            height: 115px;
            width: 511px;
        }
        .auto-style3 {
            text-align: right;
            width: 511px;
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
            width: 545px;
            height: 42px;
        }
        .auto-style8 {
            height: 42px;
        }
        </style>
</head>
<body style="height: 1324px; width: 1154px" onload="getLocation()">
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
    style="background-image: url('Imagescsrm/bg-large.jpg');" class="style88">&nbsp;<table class="style61">
        <tr>
            <td class="style57">
                &nbsp;</td>
            <td class="style54">
                <table class="auto-style4">
                    <tr>
                        <td class="auto-style5">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/ImagesMaster/master-logo.png" />
                        </td>
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
                <table class="style87">
                    <tr>
                        <td class="style90">
                            &nbsp;</td>
                        <td class="style76">
                            <asp:Image ID="imgAsset" runat="server"      />                           
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style90">
                            &nbsp;</td>
                        <td class="style76">
                                                     
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="style90">
                            &nbsp;</td>
                        <td class="style91">
                            <table class="style71">
                                <tr>
                                    <td style="background-position: right; background-image: url('Imagescsrm/field-id-qr.png'); background-repeat: no-repeat" 
                                        class="style74">
                                        <div class="dleft">
                                            <asp:Label ID="lbID" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                    <td style="background-image: url('Imagescsrm/field-vrm.png'); background-repeat: no-repeat; background-position: left">
                                        <div class="dright">
                                            <asp:Label ID="lbVRM" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-position: right; background-image: url('Imagescsrm/field-make.png'); background-repeat: no-repeat" 
                                        class="style74">
                                        <div class="dleft">
                                            <asp:Label ID="lbMake" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                    <td style="background-image: url('Imagescsrm/field-model.png'); background-repeat: no-repeat; background-position: left">
                                        <div class="dright">
                                            <asp:Label ID="lbModel" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style74" 
                                        
                                        style="background-image: url('Imagescsrm/field-type.png'); background-repeat: no-repeat; background-position: right">
                                        <div class="dleft">
                                            <asp:Label ID="lbType" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                    <td style="background-image: url('Imagescsrm/field-colour.png'); background-repeat: no-repeat; background-position: left">
                                        <div class="dright">
                                            <asp:Label ID="lbColour" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style74" 
                                        
                                        style="background-image: url('ImagesMaster/chassis_no.png'); background-repeat: no-repeat; background-position: right">
                                        <div class="dleft">
                                            <asp:Label ID="lbSerial" runat="server" Font-Names="Arial" Font-Size="X-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                    <td style="background-image: url('Imagescsrm/field-engine.png'); background-repeat: no-repeat; background-position: left" class="auto-style8">
                                        <div class="dright">
                                            <asp:Label ID="lbEngine" runat="server" Font-Names="Arial" Font-Size="X-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style78" 
                                        
                                        style="display: none;">
                                        <asp:TextBox ID="lat" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="display: none;">
                                        <asp:TextBox ID="long" runat="server" style="height: 22px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </td>
            <td class="style60">
                </td>
        </tr>
        <tr>
            <td class="style57">
                &nbsp;</td>
            <td class="style54">
                <table class="style86">
                    <tr>
                        <td class="style65">
                            <asp:ImageButton ID="ibHire" runat="server"      />                           
                        </td>
                        <td class="style65">
                            <asp:ImageButton ID="ibStolen" runat="server"  />
                        </td>
                        <td class="style65">
                            <asp:ImageButton ID="ibScan" runat="server" 
                                Width="300px" />
                        </td>
                    </tr>
                </table>
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
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td class="style64">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td class="style64">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:ImageButton ID="ib1Left" runat="server" />
                        </td>
                        <td class="style81">
                            </td>
                        <td class="style82">
                            <asp:ImageButton ID="ib1Right" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:ImageButton ID="ib2Left" runat="server"  />
                        </td>
                        <td class="style64">
                            &nbsp;</td>
                        <td class="style63">
                            <asp:ImageButton ID="ib2Right" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:ImageButton ID="ib3Left" runat="server"  />
                        </td>
                        <td class="style64">
                            &nbsp;</td>
                        <td class="style63">
                            <asp:ImageButton ID="ib3Right" runat="server"  />
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:ImageButton ID="ib4Left" runat="server"  />
                        </td>
                        <td class="style64">
                            &nbsp;</td>
                        <td class="style63">
                            <asp:ImageButton ID="ib4Right" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td class="style64">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td class="style64">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style63" colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style63" colspan="3">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                ImageUrl="~/ImagesMaster/contact.png" 
                                onclientclick="dolink('http://masterscheme.org/app/contact/')" 
                                Width="960px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td class="style64">
                            &nbsp;</td>
                        <td>
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
