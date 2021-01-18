<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qrecv.aspx.cs" Inherits="QRMobi.Webecv"
    MasterPageFile="" %>

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

        .style64 {
            width: 17px;
        }

        .style65 {
            text-align: center;
        }

        .style71 {
            width: 101%;
        }

        .dleft {
            width: 314px;
            margin-left: 230px;
        }

        .dright {
            width: 302px;
            margin-left: 111px;
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

        .ecvCol {
            width: 135px;
            font-family: Arial;
            font-display: block;
            text-align: left;
            color: white;
            padding-left: 30px;
            font-size: 25px;
        }

        .ecvColValue {
            width: 164px;
            font-family: Arial;
            font-display: block;
            text-align: left;
            font-size: 25px;
            color: #66FF66;
        }

        .ecvLabel {
            font-family: Arial;
            font-size: 25px;
            font-weight: bold;
            color: #66FF66;
        }

        .tblECV {
            width: 95%;
        }

        .tbLeftCol {
            width: 561px;
            background-color: black;
        }


        .auto-style2 {
            width: 87px;
        }

        .auto-style3 {
            width: 1080px;
        }

        .auto-style7 {
            width: 98%;
        }

        .auto-style8 {
            width: 87px;
            height: 23px;
        }

        .auto-style9 {
            text-align: center;
            width: 1048px;
            height: 23px;
        }

        .auto-style10 {
            text-align: center;
            width: 1048px;
        }

        .auto-style11 {
            width: 1048px;
        }

        .auto-style12 {
            width: 491px;
            height: 481px;
        }

        .auto-style14 {
            width: 99%;
            height: 31px;
        }

        .auto-style15 {
            width: 581px;
            text-align: left;
        }

        .auto-style16 {
            width: 28px;
        }

        .auto-style17 {
            width: 28px;
            height: 811px;
        }

        .auto-style18 {
            width: 100%;
        }

        .auto-style19 {
            width: 154px;
            font-family: Arial;
            font-display: block;
            text-align: left;
            color: white;
            padding-left: 30px;
            font-size: 25px;
        }

        .auto-style20 {
            width: 625px;
            background-color: black;
            height: 481px;
        }

        .auto-style21 {
            width: 505px;
        }

        .auto-style22 {
            text-align: right;
            height: 153px;
            width: 505px;
        }

        .auto-style23 {
            text-align: right;
            width: 505px;
        }

        .auto-style24 {
            font-family: Arial;
            font-display: block;
            text-align: left;
            color: white;
            padding-left: 30px;
            font-size: 25px;
        }

        .auto-style25 {
            font-family: Arial;
            font-display: block;
            text-align: center;
            color: white;
            padding-left: 30px;
            font-size: 25px;
        }

        .auto-style26 {
            width: 99%;
            height: 494px;
        }

        .auto-style27 {
            width: 99%;
            height: 339px;
        }

        .auto-style28 {
            width: 1080px;
            height: 811px;
        }

        .auto-style29 {
            height: 811px;
            width: 18px;
        }

        .auto-style30 {
            width: 106%;
            height: 670px;
            margin-top: 0px;
        }

        .auto-style31 {
            height: 68px;
        }

        .bbody {
            height: 1096px;
            width: 1236px;
            margin-bottom: 0px;
        }

        .fform {
            background-image: url('Imagescsrm/bg-large.jpg');
        }
        .auto-style32 {
            width: 18px;
        }
    </style>
</head>
<body class="bbody" onload="getLocation()" style="width: 1152px">
    <script type="text/javascript">

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

                document.getElementById('tbLat').value = 0;
                document.getElementById('tbLong').value = 0;


                navigator.geolocation.getCurrentPosition(showPosition, showError, options);

            }

        }

        function displaymap() {

            var url = "http://maps.google.com/maps?q=" + document.getElementById('tbLat').value + "," + document.getElementById('tbLong').value;

            window.open(url, '_blank');

        }
    </script>
    <form id="qrCesarECV" runat="server" class="fform">
        &nbsp;<table class="style61">
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style3">
                    <table class="auto-style7">
                        <tr>
                            <td class="auto-style15">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/CesarECV/cesar-logo.png" />
                            </td>
                            <td class="style56">
                                <asp:Image ID="Image2" runat="server"
                                    ImageUrl="~/Imagescsrm/datatag-logo.png" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style32">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17"></td>
                <td class="auto-style28"
                    style="background-image: url('Imagescsrm/box-top.png'); background-repeat: no-repeat">
                    <table class="auto-style7">
                        <tr>
                            <td class="auto-style8"></td>
                            <td class="auto-style9">
                                <asp:Image ID="imgAsset" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style10">
                                <table class="auto-style26">
                                    <tr>
                                        <td class="auto-style20">
                                            <table class="auto-style18">
                                                <tr>
                                                    <td class="auto-style25" colspan="2">Engine&nbsp; Details</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style24" colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">ECV CODE:</td>
                                                    <td class="ecvColValue">
                                                        <asp:Label ID="lbID" runat="server" Text="-" CssClass="ecvLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">CESAR ID:</td>
                                                    <td class="ecvColValue">
                                                        <asp:Label ID="lbCesarID" runat="server" Text="-" CssClass="ecvLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">MAKE:</td>
                                                    <td class="ecvColValue">
                                                        <asp:Label ID="lbMake" runat="server" Text="-" CssClass="ecvLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">MODEL:</td>
                                                    <td class="ecvColValue">
                                                        <asp:Label ID="lbModel" runat="server" Text="-" CssClass="ecvLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">FUEL:</td>
                                                    <td class="ecvColValue">
                                                        <asp:Label ID="lbFuel" runat="server" Text="-" CssClass="ecvLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">ENGINE NO:</td>
                                                    <td class="ecvColValue">
                                                        <asp:Label ID="lbEngNo" runat="server" Text="-" CssClass="ecvLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">DPF FITTED:</td>
                                                    <td class="ecvColValue">
                                                        <asp:Label ID="lbDPFFitted" runat="server" Text="-" CssClass="ecvLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">STAGE:</td>
                                                    <td class="ecvColValue">
                                                        <asp:Label ID="lbStage" runat="server" Text="-" CssClass="ecvLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">&nbsp;</td>
                                                    <td class="ecvColValue">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">&nbsp;</td>
                                                    <td class="ecvColValue">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">&nbsp;</td>
                                                    <td class="ecvColValue">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style19">&nbsp;</td>
                                                    <td class="ecvColValue">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="auto-style12">
                                            <asp:Image ID="imgECV" runat="server" Height="472px" Width="350px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">
                                <table class="auto-style14">
                                    <tr>
                                        <td style="display: none;" class="style56">
                                            <asp:TextBox ID="tbLat" runat="server">0</asp:TextBox>
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="tbLong" runat="server">0</asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style29"></td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style3">
                    <table class="auto-style27">
                        <tr>
                            <td class="style65">
                                <asp:ImageButton ID="ibHire" runat="server" ImageUrl="~/Imagescsrm/button-hire-it.png" OnClientClick="dolink('http://www.gap-group.co.uk/contact-us/find-a-depot')" />
                            </td>
                            <td class="style65">
                                <asp:ImageButton ID="ibStolen" runat="server"
                                    ImageUrl="~/Imagescsrm/button-report-stolen.png"
                                    OnClientClick="dolink('http://www.cesarscheme.org/form.html')" />
                            </td>
                            <td class="style65">
                                <asp:ImageButton ID="ibScan" runat="server" ImageUrl="~/CesarECV/Theft_Check.png" OnClientClick="doalert('Exciting New Feature Coming Soon')" Width="300px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td class="auto-style32">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style3"
                    style="background-image: url('Imagescsrm/box-bottom.png'); background-repeat: no-repeat">
                    <table class="auto-style30">
                        <tr>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="style64">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="style64">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style22">
                                <%-- <asp:ImageButton ID="ibUser" runat="server"
                                    ImageUrl="~/Imagescsrm/button-user.png" OnClientClick="target='blank'" />--%>
                                <asp:ImageButton ID="ibAsset" runat="server" ImageUrl="~/CesarECV/CESAR_Details_BUTTON.png" />
                            </td>
                            <td class="style81"></td>
                            <td class="style82">
                                <%--<asp:ImageButton ID="ibSafety" runat="server"
                                    ImageUrl="~/Imagescsrm/button-safety.png" OnClientClick="target='blank'" />--%>
                                <asp:ImageButton ID="ibDealer" runat="server"
                                    ImageUrl="~/Imagescsrm/button-dealer.png" OnClientClick="target='blank'" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23">
                                <%-- <asp:ImageButton ID="ibParts" runat="server"
                                    ImageUrl="~/Imagescsrm/button-parts.png" OnClientClick="target='blank'" />--%>
                            </td>
                            <td class="style64">&nbsp;</td>
                            <td class="style63">
                                <%-- <asp:ImageButton ID="ibDealer" runat="server"
                                    ImageUrl="~/Imagescsrm/button-dealer.png" OnClientClick="target='blank'" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23">
                                <%--<asp:ImageButton ID="ibAsset" runat="server" ImageUrl="~/CesarECV/CESAR_Details_BUTTON.png" />--%>
                            </td>
                            <td class="style64">&nbsp;</td>
                            <td class="style63">
                                <%--<asp:ImageButton ID="ibService" runat="server"
                                    ImageUrl="~/Imagescsrm/button-servise.png" OnClientClick="target='blank'" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="style64">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="style64">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style63" colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style31" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server"
                                ImageUrl="~/Imagescsrm/contact.png"
                                OnClientClick="dolink('http://www.datatag.co/stihl/contact/')"
                                Width="960px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style21">
                                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                                </asp:Timer>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td class="style64">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>

                <td class="auto-style32">&nbsp;
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
