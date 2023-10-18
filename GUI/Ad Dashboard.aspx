<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ad Dashboard.aspx.cs" Inherits="AdTrafficWebApp.GUI.Ad_Dashboard" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }

        .dashboard {
            display: flex;
            flex-direction: row;
            justify-content: space-around;
            padding: 20px;
        }
        .dashboard-title {
            text-align: center;
            background-color: black;
            color:white;
            padding: 20px;
        }

        .dashboard-left {
            width: 80%;
            padding: 20px;
            background-color: black;
            border-radius: 10px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            margin-right: 20px;
        }

        .dashboard-right {
            width: calc(70% - 40px);
            padding: 20px;
            background-color: orange;
            border-radius: 10px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }

        .campaign-list {
            list-style: none;
            padding: 0;
        }

        .campaign-list-item {
            margin-bottom: 10px;
            cursor: pointer;
        }
        .input-group {
            margin-bottom: 20px;
            display: flex;
            flex-direction: column; /* Stack items vertically */
            align-items: flex-start; /* Align items to the start of the container */
        }

        .input-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            text-align: left;
            color:white;
        }
        /* Add this style to your existing CSS */
        .input-group input[type="file"] {
            color: white; /* Set the text color to white */
        }

        /* You can also style the background color when hovering over the file input */
        .input-group input[type="file"]:hover {
            background-color: #45a049;
        }

        
        .head2{
            color:orange;
        }
        
        .create-button{
            background-color: #4caf50;
            color:white;
            border:none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor:pointer;
            margin-right: 10px;
            transition: background-color 0.3s;
            margin-bottom: 40px;
        }
        .logout-button{
            background-color: red;
            color:white;
            border:none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor:pointer;
            margin-right: 10px;
            transition: background-color 0.3s;
            margin-bottom: 10px;
        }
        .create-button:hover,
        .logout-button:hover {
            background-color: #45a049;
        }

        .campaign-details {
            border: 1px solid #ccc;
            padding: 20px;
        }
        ul.campaign-list{
            color: white;
        }
        ul.campaign-list .campaign-list-item:hover{
            background-color:lightblue;
            color:white;
        }
        
    </style>
</head>
<body>
    <div class="dashboard-title">
        <h1>AD Dashboard</h1>
    </div>
    <div class="dashboard">
       <form id="form1" runat="server">
            <div class="dashboard-left">
                <h2 class="head2">Campaigns:</h2>
                <ul class="campaign-list" id="campaignList" runat="server">
                    
                </ul>

                <h2 class="head2">Create a Campaign:</h2>
                <div class="input-group">
                    <label for="campaignTitle">Title:</label>
                    <asp:TextBox ID="txtCampaignTitle" runat="server" CssClass="form-control"></asp:TextBox> 

                </div>
                <div class="input-group">
                    <label for="campaignDescription">Description:</label>
                    <asp:TextBox ID="txtCampaignDescription" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                </div>
                <div class="input-group">
                    <label for="campaignImage">BrowseImage:</label>
                    <asp:FileUpload ID="fileCampaignImage" runat="server" CssClass="form-control" />
                </div>
                <asp:Button ID="btnCreateCampaign" runat="server" CssClass="create-button" Text="Create Campaign" OnClick="btnCreateCampaign_Click" />
                <asp:Button ID="btnLogout" runat="server" CssClass="logout-button" Text="Log Out" OnClick="btnLogout_Click" />
                
            </div>
       </form>
        <div class="dashboard-right">
            <div class="campaign-details" id="campaign-details">
                    <!-- Campaign details will be displayed here -->
            </div>
        </div>
        
    </div>
    
</body>
</html>

