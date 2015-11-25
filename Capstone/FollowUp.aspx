<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FollowUp.aspx.cs" Inherits="FollowUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 783px;
            position: absolute;
            left: 10px;
            top: 257px;
            color:#FFFFFF;
        }
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
        .auto-style6 {
            height: 23px;
            width: 57px;
        }
        .auto-style8 {
            height: 23px;
            width: 357px;
        }
        .auto-style10 {
            height: 23px;
            width: 454px;
            font-size: large;
            text-align: right;
        }
        .auto-style12 {
            height: 23px;
            width: 454px;
            text-align: right;
        }
        .auto-style13 {
            height: 24px;
            width: 454px;
            font-size: large;
            text-align: right;
        }
        .auto-style14 {
            height: 24px;
            width: 57px;
        }
        .auto-style15 {
            height: 24px;
            width: 357px;
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
        </style>
    <title>Follow Up</title>
</head>
<body>
            <ul id="nav">
                <li><a href="Alerts.aspx">Alerts Entry Form</a></li>
                <li><a href="AlertDataView.aspx">Alert Data</a></li>
                <li><a href="FollowUp.aspx">Follow Up</a></li>
                <li><a href="FollowUpData.aspx">Follow Up Data</a></li>
            </ul>
        <div id ="cobra">
                <span class="auto-style3"><em>COBRA TRACKER</em></span><br />
        <span class="auto-style4">CCC&TI Early Alert Tracking System</span>
    </div>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">Alert ID:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlAlertID" runat="server" Width="150px">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">
                    <asp:Label ID="Label1" runat="server" Text="Select an AlertID and then click Search."></asp:Label>
                </td>
                <td class="auto-style15">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">Dropped:</td>
                <td class="auto-style14">
                    <asp:DropDownList ID="ddlDropped" runat="server" Width="150px" Enabled="False">
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style15">
                    </td>
            </tr>
            <tr>
                <td class="auto-style10">Drop Date:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtDropDate" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="Label2" runat="server" Text="Use mm-dd-yyyy format."></asp:Label>
                </td>
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">Student Services Faculty*:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlFollowUpFaculty" runat="server" Width="150px" Enabled="False">
                    </asp:DropDownList>
                    <asp:Label ID="lblFacultyError" runat="server" Font-Bold="True" ForeColor="Red" Text="*Is a required field" Visible="False"></asp:Label>
                </td>
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">Contact by Phone:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlPhone" runat="server" Width="150px" Enabled="False">
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">Contact by Email:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlEmail" runat="server" Width="150px" Enabled="False">
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">Other Contact:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlOther" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" Width="150px" Enabled="False">
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">Notes:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtNotes" runat="server" Height="250px" TextMode="MultiLine" Width="275px" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Enabled="False" /> 
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Record" Enabled="False" OnClick="btnUpdate_Click" />
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
    
</body>
</html>
