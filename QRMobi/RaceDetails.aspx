<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RaceDetails.aspx.cs" Inherits="QRMobi.RaceDetails" %>



<html>
<head>
    <title>MASTER Item Found Page</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet">
    <link href='https://fonts.googleapis.com/css?family=Lato:300,400,700' rel='stylesheet' type='text/css'>
    <link href='custom.css' rel='stylesheet' type='text/css'>
</head>
 
<body>

    <form id="form1" runat="server">

    <div class="container" style="background-image: url(&#39;Imagescsrm/bg-large.jpg&#39;); color:white;" >

        <div class="row">

            <div class="col-lg-8 col-lg-offset-2">

                <div class="row">

                    <div class="col-md-12">
                        <img src="ImagesMaster/mastermx-banner.png" class="img-responsive" alt="Master Logo">

                        <p class="center-block" style="font-size: x-large; right: auto; left: auto;">

                            <center>RACE HISTORY</center></p>
                            <center>
<asp:GridView ID="searchData" runat="server" AllowPaging="True" AutoGenerateColumns="False" Font-Size="10px" Height="81px" 
                          EmptyDataText="No entries were found in the Stolen database. Please press reset to search again."  
                              Width="300px" ForeColor="Black" BackColor="White" CssClass="center-block">
                          <Columns>
                              <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>
                              <asp:BoundField DataField="Event" HeaderText="Event" SortExpression="Event">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>
                              <asp:BoundField DataField="Organised_By" HeaderText="Scanned By" SortExpression="Organised_By">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>

                          </Columns>
                      </asp:GridView>                    
                        <p>&nbsp;</p>
        <p>
                            <asp:Button ID="backButton" runat="server" ForeColor="#000066" OnClick="backButton_Click" Text="Close Page" />
                        </p></center>  
                        <p>
                            &nbsp;</p>
                    </div>

                </div>

   

            </div><!-- /.8 -->

        </div> <!-- /.row-->

    </div> <!-- /.container-->

    <script src="https://code.jquery.com/jquery-1.12.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="validator.js"></script>
    <script src="contact.js"></script>
    </form>
</body>
</html>
