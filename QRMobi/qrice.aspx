<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qrice.aspx.cs" Inherits="QRMobi.Webice" %>

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
            width: 1078px;
            height: 672px;
            text-align: left;
        }
        .style45
        {
            width: 822px;
            font-family: Arial;
            height: 485px;
        }
        .style29
        {
            font-family: Arial;
            font-size: xx-large;
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
        .style53
        {
            font-size: medium;
        }
        .style54
        {
            font-size: xx-large;
            }
        .style55
        {
            font-size: xx-large;
            width: 171px;
        }
        .style57
        {
            font-size: x-large;
            width: 171px;
        }
        .style58
        {
            font-size: large;
            color: #FF0000;
        }
        .style59
        {
            font-size: large;
            width: 171px;
            color: #FF3300;
        }
        .style60
        {
            width: 190px;
            height: 99px;
        }
        .style61
        {
            width: 622px;
            height: 99px;
        }
        </style>
</head>
<body style="text-align: center; height: 510px">
    <form id="qrIceForm" runat="server" class="style52">
    <br />
    <table id="tCode" class="style45" align="center">
        <tr>
            <td class="style53" colspan="2">
                <img alt="" class="style60" src="Images/header.png" /><img alt="" 
                    class="style61" src="Images/header_ani.gif" /></td>
        </tr>
        <tr>
            <td class="style57">
                <strong>ID</strong></td>
            <td id="">
                <asp:TextBox ID="tbID" runat="server" Width="478px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style57">
                <strong>Full Name</strong></td>
            <td id="">
                <asp:TextBox ID="tbFullName" runat="server" Width="480px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style57">
                <strong>Date Of Birth</strong></td>
            <td id="">
                <asp:TextBox ID="tbDOB" runat="server" Width="480px" ReadOnly="True" 
                    CssClass="style29" BorderStyle="None"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style55">
                <asp:TextBox ID="tbUsername" runat="server" Visible="False" Width="197px"></asp:TextBox>
            </td>
            <td id="" class="style58">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="style59">
                Emergency Contacts</td>
            <td id="" class="style58">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style54" colspan="2">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    Height="21px" PageSize="5" Width="815px" Font-Size="Large">
                    <Columns>
                        <asp:BoundField DataField="Contact" HeaderText="Contact" 
                            SortExpression="Contact" />
                        <asp:BoundField DataField="Tel" HeaderText="Tel" SortExpression="Tel" />
                        <asp:BoundField DataField="Relationship" HeaderText="Relationship" 
                            SortExpression="Relationship" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DTICE_CS %>" 
                    SelectCommand="SELECT [Contact], [Tel], [Relationship] FROM [MSMemberContacts] WHERE ([Username] = @Username)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="tbUsername" Name="Username" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>
    <span>
    <br />
    </span>
    </form>
</body>
</html>
