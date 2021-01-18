<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qrcsrmHire.aspx.cs" Inherits="QRMobi.WebcsrmHire"
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
            width: 100%;
        }
        .dleft
        {
            width: 314px;
            margin-left: 230px;
        }
                .dleft2
        {
            width: 314px;
            margin-left: 128px;
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
            width: 1000px;
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
            height: 153px;
        }
        .style82
        {
            text-align: left;
            height: 153px;
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
            height: 153px;
            width: 511px;
        }
        .auto-style3 {
            text-align: right;
            width: 511px;
        }
        .auto-style6 {
            width: 102%;
        }
        .auto-style7 {
            margin-left: 107px;
            text-align: center;
            re;
        }
        .auto-style8 {
            text-align: center;
            width: 1168px;
            height: 44px;
        }
        .auto-style9 {
            width: 100px;
        }
        .auto-style10 {
            width: 301px;
            margin-left: 111px;
        }
        .auto-style11 {
            width: 305px;
            margin-left: 230px;
        }
        .auto-style12 {
            width: 23px;
        }
        .auto-style13 {
            width: 23px;
            height: 835px;
        }
        .auto-style15 {
            width: 1096px;
            height: 835px;
        }
        .auto-style16 {
            width: 1096px;
        }
        .auto-style17 {
            margin-left: 105px;
            text-align: center;
            re;
        }
        .auto-style18 {
            height: 44px;
        }
        .auto-style19 {
            height: 7px;
        }
        .auto-style20 {
            width: 100px;
            height: 7px;
        }
        .auto-style22 {
            text-align: center;
            width: 1168px;
            height: 10px;
        }
        .auto-style23 {
            height: 10px;
        }
        .auto-style24 {
            margin-top: 21px;
        }
        .auto-style25 {
            margin-left: 0px;
        }
    </style>
</head>
<body style="height: 1324px; width: 1154px" onload="getLocation()">
    <p>
        <br />
    </p>
    <p>
        <br />
    </p>
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
    <form id="qrCesarMic" runat="server" 
    style="background-image: url('Imagescsrm/bg-large.jpg');" class="style88">&nbsp;<table class="style61">
        <tr>
            <td class="auto-style12">
                &nbsp;</td>
            <td class="auto-style16">
                <table style="width:100%;">
                    <tr>
                        <td class="style55">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagescsrm/cesar-logo.png" />
                        </td>
                        <td class="style56">
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
            <td class="auto-style13">
                </td>
            <td class="auto-style15" 
                style="background-image: url('Imagescsrm/box-top.png'); background-repeat: no-repeat">
                <table class="auto-style6">
                    <tr>
                        <td class="auto-style23">
                            </td>
                        <td class="auto-style22">
                        </td>
                        <td class="auto-style23">
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style18">
                            </td>
                        <td class="auto-style8">
                            <asp:Image ID="imgAsset" height="350px" runat="server" CssClass="auto-style24" />
                        </td>
                        <td class="auto-style18">
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style19">
                            </td>
                        <td class="auto-style20">
                                    </td>
                        <td class="auto-style19">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="auto-style9" 
                            
                            style="background-image: url('Imagescsrm/field-id.png'); background-repeat: no-repeat; background-position: center">
                            <div class="auto-style11">
                                <asp:Label ID="lbID" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                    ForeColor="#66FF66" Text="-"></asp:Label>
                            </div>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="auto-style9">
                            <table class="style71">
                                <tr>
                                    <td style="background-position: right; background-image: url('Imagescsrm/field-make.png'); background-repeat: no-repeat" 
                                        class="style74">
                                        <div class="dleft">
                                            <asp:Label ID="lbMake" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                    <td style="background-image: url('Imagescsrm/field-model.png'); background-repeat: no-repeat; background-position: left">
                                        <div class="auto-style10">
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
                                        
                                        style="background-image: url('Imagescsrm/field-serial.png'); background-repeat: no-repeat; background-position: right">
                                        <div class="dleft">
                                            <asp:Label ID="lbSerial" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                    <td style="background-image: url('Imagescsrm/field-engine.png'); background-repeat: no-repeat; background-position: left">
                                        <div class="dright">
                                            <asp:Label ID="lbEngine" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                  <td>&nbsp;</td>
                                  <td>&nbsp;</td>
                                </tr>
                                 <tr>
                                    <td class="style78" 
                                        
                                        style="display: none;">
                                        <asp:TextBox ID="lat" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="display: none;">
                                        <asp:TextBox ID="long" runat="server"></asp:TextBox>
                                    </td>
                                </tr>       
                                <tr>
                                    <td rowspan="2" class="style74">
                                        <div class="dleft2">
                                            <asp:Image ID="HireCompLogo"  height="100"  runat="server" CssClass="auto-style25" ImageAlign="Left" />
                                        </div>
                                    </td>
                                    
                                    <td style="background-image: url('Imagescsrm/field-branch.png'); background-repeat: no-repeat; background-position: left">
                                        <div class="dright">
                                            <asp:Label ID="lbBranch" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td style="background-image: url('Imagescsrm/field-hiretime.png'); background-repeat: no-repeat; background-position: left">
                                        <div class="dright">
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbHireTime" runat="server" Font-Names="Arial" Font-Size="XX-Large" 
                                                ForeColor="#66FF66">-</asp:Label>
                                            
                                             </div>
                                    </td>


                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                                        <asp:TextBox ID="stolenMessageA" runat="server" ForeColor="#CC0000" Width="854px" style="background-color: transparent" BorderStyle="None" CssClass="auto-style17" Font-Size="XX-Large"  ></asp:TextBox>
                                        <asp:TextBox ID="stolenMessageB" runat="server" ForeColor="Red" Width="850px" style="background-color: transparent" BorderStyle="None" CssClass="auto-style7" Font-Size="XX-Large"  ></asp:TextBox>
                </td>
            <td class="style60">
                </td>
        </tr>
        <tr>
            <td class="auto-style12">
                &nbsp;</td>
            <td class="auto-style16">
                <table class="style86">
                    <tr>
                        <td class="style65">
                            <asp:ImageButton ID="ibButtonL" runat="server"      />                           
                        </td>
                        <td class="style65">
                            <asp:ImageButton ID="ibButtonC" runat="server"  />
                        </td>
                        <td class="style65">
                            <asp:ImageButton ID="ibButtonR" runat="server" 
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
            <td class="auto-style12">
                &nbsp;</td>
            <td class="auto-style16" 
                style="background-image: url('Imagescsrm/box-bottom.png'); background-repeat: no-repeat">
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
                            <asp:ImageButton ID="ibUser" runat="server" />
                        </td>
                        <td class="style81">
                            </td>
                        <td class="style82">
                            <asp:ImageButton ID="ibSafety" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:ImageButton ID="ibParts" runat="server"  />
                        </td>
                        <td class="style64">
                            &nbsp;</td>
                        <td class="style63">
                            <asp:ImageButton ID="ibDealer" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:ImageButton ID="ibSoon" runat="server"  />
                        </td>
                        <td class="style64">
                            &nbsp;</td>
                        <td class="style63">
                            <asp:ImageButton ID="ibService" runat="server"  />
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
                                ImageUrl="~/Imagescsrm/contact.png" 
                                onclientclick="dolink('http://www.datatag.co/stihl/contact/')" 
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
                &nbsp;
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
