<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlertDataView.aspx.cs" Inherits="AlertDataView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#B5B5B5-->
    <title>Alerts Data</title>
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
        .auto-style1 {
            color:#FFFFFF;
            width: 100%;
        }
        .white{
            color:#FFFFFF;
        }
        .auto-style3 {
            font-size: 550%;
            color: #FFFFFF;
            font-family: haettenschweiler;
        }
        .auto-style4 {
            color: #FFFFFF;
            font-size: x-large;
        }
        .auto-style5 {
            width: 790px;
            text-align: right;
        }
        .auto-style6 {
            text-align: left;
        }
        </style>
</head>
<body>
        <div>
            <ul id="nav">
                <li><a href="Alerts.aspx">Alerts Entry Form</a></li>
                <li><a href="AlertDataView.aspx">Alert Data</a></li>
                <li><a href="FollowUp.aspx">Follow Up</a></li>
                <li><a href="FollowUpData.aspx">Follow Up Data</a></li>
            </ul>
       </div>
            <div id ="cobra">
                <span class="auto-style3"><em>COBRA TRACKER</em></span><br />
        <span class="auto-style4">CCC&TI Early Alert Tracking System
    </span>
    </div>
    <form id="form1" runat="server">
    <div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style5">

        <asp:Label ID="Label1" runat="server" Text="Search Alert ID:"></asp:Label></td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtAlertID" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtAlertIdEnd" runat="server" Width="148px"></asp:TextBox>
                    <asp:Button ID="btnAlertIDSEarch" runat="server" OnClick="btnAlertIDSEarch_Click" Text="Search" />
                    <asp:Label ID="Label2" runat="server" Text="(Two fields allows for a range search. ex. 87 in the top field, 100 in the bottom field)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Search Student ID:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtStudentID" runat="server" Width="150px" MaxLength="7"></asp:TextBox>
                    <asp:Button ID="btnStudentIDSEarch" runat="server" OnClick="btnStudentIDSEarch_Click" Text="Search" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Search Course:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlCourse" runat="server" Width="150px">
                    </asp:DropDownList>
                    <asp:Button ID="btnCourseSearch" runat="server" OnClick="btnCourseSearch_Click" Text="Search" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
                </td>
            </tr>
        </table>
    </div> 
    <div>
        <span class="white">
        <asp:GridView ID="gridViewAlerts" runat="server" OnSelectedIndexChanged="gridViewAlerts_SelectedIndexChanged" style="color: #FFFFFF" EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None">
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
