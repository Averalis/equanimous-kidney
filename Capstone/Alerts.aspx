<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alerts.aspx.cs" Inherits="Alerts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Early Alert Form</title>
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
        .auto-style3 {
            width: 360px;
            color: #FFFFFF;
            text-align: center;
            font-size: x-large;
            height: 30px;
        }
        .auto-style4 {
            color: #FFFFFF;
          width: 436px;
          text-align: right;
        }
        .auto-style5 {
            color: #FFFFFF;
            width: 436px;
            text-align: right;
            height: 294px;
        }
        .auto-style7 {
            color: #FFFFFF;
            height: 294px;
        }
        .textbox {
            width: 360px;
            text-align: left;
        }
        .auto-style8{
            color:#FFFFFF;
        }
        .auto-style9 {
            color: #FFFFFF;
          width: 436px;
          text-align: right;
          height: 26px;
        }
        .auto-style11 {
            color: #FFFFFF;
            height: 26px;
        }
        .auto-style12 {
            color: #FFFFFF;
            width: 436px;
            text-align: left;
            height: 32px;
        }
        .auto-style13 {
            color: #FFFFFF;
            width: 360px;
            text-align: left;
            height: 32px;
        }
        .auto-style14 {
            color: #FFFFFF;
            height: 32px;
        }
        .auto-style15 {
            color: #FFFFFF;
            width: 436px;
            text-align: right;
            height: 23px;
        }
        .auto-style16 {
            color: #FFFFFF;
            height: 23px;
        }
        .auto-style17 {
            color: #FFFFFF;
            width: 436px;
            text-align: right;
            height: 30px;
        }
        .auto-style18 {
            color: #FFFFFF;
            width: 360px;
            text-align: center;
            text-decoration: underline;
            font-size: x-large;
            height: 30px;
        }
        .auto-style19 {
            color: #FFFFFF;
            height: 30px;
        }
        .auto-style24 {
            color: #FFFFFF;
            width: 436px;
            text-align: right;
            height: 25px;
        }
        .auto-style26 {
            color: #FFFFFF;
            height: 25px;
        }
        .auto-style27 {
            color: #FFFFFF;
            width: 436px;
            text-align: right;
            height: 31px;
        }
        .auto-style28 {
            color: #FFFFFF;
            width: 360px;
            text-align: center;
            font-size: x-large;
            height: 31px;
        }
        .auto-style29 {
            color: #FFFFFF;
            height: 31px;
        }

        .table{
            vertical-align: middle;
            left: 0px;
            right: 0px;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style30 {
            font-size: 550%;
            color: #FFFFFF;
            font-family: haettenschweiler;
        }
        .auto-style31 {
            color: #FFFFFF;
            font-size: x-large;
        }
        .auto-style32 {
            height: 30px;
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
                <span class="auto-style30"><em>COBRA TRACKER</em></span><br />
        <span class="auto-style31">CCC&TI Early Alert Tracking System
    </span>
    </div>
    <form id="form1" runat="server">
    <div class ="table-cell-wrapper">
        <table class="table">
            <tr>
                <td class="auto-style17">
                    </td>
                <td class="auto-style3"><strong style="text-decoration: underline">Student Information</strong></td>
                <td class="auto-style32">
                    <asp:Label ID="lblSpecial" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style27">
                    <asp:Label ID="Label7" runat="server" Text="All fields with * are required"></asp:Label>
                    </td>
                <td class="auto-style28">
                    <asp:Label ID="lblError" runat="server" style="font-size: large; text-align: justify; color: #FF0000" Text="*All fields highlighted in red are required" Visible="False"></asp:Label>
                </td>
                <td class="auto-style29"></td>
            </tr>
            <tr>
                <td class="auto-style4" style="text-align: right">Student ID*:</td>
                <td class="textbox">
                    <asp:TextBox ID="txtStudentID" runat="server" Width="150px" MaxLength="7"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Enabled="False" />
                </td>
                <td>
                    <asp:Label ID="lblIDError" runat="server" Font-Bold="False" ForeColor="Red" Text="*Student ID must be 7 digits long and all numbers." Visible="False" style="font-size: large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" style="text-align: right">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="Label14" runat="server" Text="If any student information is wrong, please correct it and then use the &quot;Update&quot; button." style="color: #FFFFFF"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">First Name*:</td>
                <td class="textbox">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="150px" MaxLength="50" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Middle Initial:</td>
                <td class="textbox">
                    <asp:TextBox ID="txtMiddleInit" runat="server" Width="150px" MaxLength="10" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Last Name*:</td>
                <td class="textbox">
                    <asp:TextBox ID="txtLastName" runat="server" Width="150px" MaxLength="50" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Student E-mail*:</td>
                <td class="textbox">
                    <asp:TextBox ID="txtEmail" runat="server" Width="259px" MaxLength="50" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17"></td>
                <td class="auto-style18"><strong>Alert</strong></td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td class="auto-style15">Course Number &amp; Section Number*:</td>
                <td class="textbox">
                    <asp:DropDownList ID="cmbCourse" runat="server" Width="150px" Enabled="False">
                    </asp:DropDownList>
                </td>
                <td class="auto-style16">
                    <asp:Label ID="Label6" runat="server" Text="Type the first three letters to search."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Alert Type*:</td>
                <td class="textbox">
                    <asp:DropDownList ID="cmbAlertType" runat="server" style="margin-left: 0px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cmbAlertType_SelectedIndexChanged" OnTextChanged="cmbAlertType_SelectedIndexChanged" Enabled="False" BackColor="White" ForeColor="Black">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Absence</asp:ListItem>
                        <asp:ListItem>Tardy</asp:ListItem>
                        <asp:ListItem>Grade</asp:ListItem>
                        <asp:ListItem>Absence/Tardy</asp:ListItem>
                        <asp:ListItem>Absence/Grade</asp:ListItem>
                        <asp:ListItem>Absence/Tardy/Grade</asp:ListItem>
                        <asp:ListItem>Tardy/Grade</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">Reporting Faculty*:</td>
                <td class="textbox">
                    <asp:DropDownList ID="cmbReportingFaculty" runat="server" Width="150px" Enabled="False">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">
                    <asp:Label ID="Label5" runat="server" Text="Type last name to search."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Number of Absences(0-15):</td>
                <td class="textbox">
                    <asp:DropDownList ID="ddlAbsences" runat="server" Width="150px" Enabled="False">
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Max Allowed Absences(0-15):</td>
                <td class="textbox">
                    <asp:DropDownList ID="ddlMaxAbsences" runat="server" Width="150px" Enabled="False">
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Number of Tardies(0-15):</td>
                <td class="textbox">
                    <asp:DropDownList ID="ddlNumTardies" runat="server" Width="150px" Enabled="False">
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">Academic Progress*:</td>
                <td class="textbox">
                    <asp:DropDownList ID="cmbAcademicProgress" runat="server" Width="150px" Enabled="False">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Satisfactory</asp:ListItem>
                        <asp:ListItem>Unsatisfactory</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24">Drop/Withdrawal Risk*:</td>
                <td class="textbox">
                    <asp:DropDownList ID="cmbWithdrawalRisk" runat="server" style="margin-left: 0px" Width="150px" Enabled="False">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Low</asp:ListItem>
                        <asp:ListItem>Moderate</asp:ListItem>
                        <asp:ListItem>High</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style26">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Current Number Grade:</td>
                <td class="textbox">
                    <asp:TextBox ID="txtCurrentGrade" runat="server" Width="150px" MaxLength="10" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="(ex. GPA, A-F, Number Grade)" 
                        ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Comments:</td>
                <td class="textbox">
                    <asp:TextBox ID="txtComments" runat="server" Height="279px" 
                        style="text-align: left; margin-left: 3px" TextMode="MultiLine" Width="365px" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="lblExceptionError" runat="server" Text="ERROR" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style13">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="Button1_Click" style="text-align: left" Text="Submit" Enabled="False" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"/>
                </td>
                <td class="auto-style14"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
