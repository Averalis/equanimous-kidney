<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FollowUpData.aspx.cs" Inherits="FollowUpData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Follow Up Data</title>
    <style type="text/css">
         body{
            background-color : #2B4E80;
        }
        #nav {
	        width: 100%;
	        float: left;
	        margin: 0 0 3em 0;
	        padding: 0;
	        list-style: none;
	        background-color: #f2f2f2;
	        border-bottom: 1px solid #ccc; 
	        border-top: 1px solid #ccc; }
        #nav li a {
		    display: block;
		    padding: 8px 15px;
		    text-decoration: none;
		    font-weight: bold;
		    color: #069;
		    border-right: 1px solid #ccc; }
        #nav li {
	        float: left; }
        #nav li a:hover {
		    color: #c00;
		    background-color: #fff; }
        .auto-style30 {
            font-size: 550%;
            color: #FFFFFF;
            font-family: haettenschweiler;
        }
        .auto-style31 {
            color: #FFFFFF;
            font-size: x-large;
        }
        .big {
            color: #FFFFFF;
            font-size: x-large;
            
        }
        .white{
            color:#FFFFFF;
        }
        .auto-style32 {
          color: #FFFFFF;
          font-size: x-large;
          text-align: center;
        }
        </style>
</head>
<body>
            <ul id="nav">
                <li><a href="Alerts.aspx">Alerts Entry Form</a></li>
                <li><a href="AlertDataView.aspx">Alert Data</a></li>
                <li><a href="FollowUp.aspx">Follow Up</a></li>
                <li><a href="FollowUpData.aspx">Follow Up Data</a></li>
            </ul>
    <div>
                <span class="auto-style30"><em>COBRA TRACKER</em></span><br />
        <span class="auto-style31">CCC&TI Early Alert Tracking System
    </span>
    </div>
    <p class ="auto-style32">Follow Up Data View</p>
    <form id="form1" runat="server">
    <div>

        <asp:Label ID="lblError" runat="server"></asp:Label>

    </div>
    <div>
        <span class ="white">
        <asp:GridView ID="gridViewFollowUp" runat="server" style="color: #FFFFFF" EnableModelValidation="True" Width="402px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        </span>
    </div>
    </form>
</body>
</html>
