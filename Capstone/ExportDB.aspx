<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportDB.aspx.cs" Inherits="ExportDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Export</title>
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
        #btnExport {
            width: 114px;
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
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnExportAlerts" runat="server" OnClick="btnExportAlerts_Click" Text="Export Alerts" />
        <asp:Button ID="btnExportStudents" runat="server" OnClick="btnExportStudents_Click1" Text="Export Students" />
    
        
    
    </div>
    </form>
    <script>
        function mouseDownEvent() {

        }
    </script>
</body>
</html>
