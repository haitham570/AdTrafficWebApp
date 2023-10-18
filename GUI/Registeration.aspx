<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="AdTrafficWebApp.GUI.Registeration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ad Tracking System - Registration</title>
    <!-- Include your CSS styles here -->
    <style>
         body {
             display: flex;
             justify-content: center;
             align-items: center;
             height: 100vh;
             margin: 0;
             font-family: Arial, sans-serif;
             background-color: #f4f4f4;
         }
         .registration-container{
             background-color: white;
             padding: 30px;
             border-radius: 10px;
             box-shadow: 0 0 20px rgba(0,0,0,0.1);
             text-align: center;
             width:300px;
         }
         .input-group{
             margin-bottom: 20px;
         }
         .input-group label{
             display: block;
             font-weight: bold;
             margin-bottom: 5px;
             text-align: left;
         }
         .form-control{
             width: calc(100% - 20px);
             padding: 10px;
             font-size: 16px;
             border: 1px solid #ccc;
             border-radius: 5px;
         }
         .registeration-button{
             background-color:#4caf50;
             color: white;
             padding: 10px 20px;
             border: none;
             border-radius: 5px;
             cursor: pointer;
             font-size:16px;
             transition: background-color 0.3s;
         }
         .registeration-button:hover{
             background-color: #45a049;
         }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="registration-container">
            <h2>Register for Ad Tracking System</h2>
            <div class="input-group">
                <label for="userid">Userid:</label>
                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="input-group">
                <label for="username">UserName:</label>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="input-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="input-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email" required></asp:TextBox>
            </div>
            <div class="input-group">
                <label for="role">Role:</label>
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" required>
                    <asp:ListItem Text="Student" Value="Student" />
                    <asp:ListItem Text="Teacher" Value="Teacher" />
                </asp:DropDownList>
            </div>
            <div class="input-group">
                 <asp:Button ID="BtnRegister" runat="server" CssClass="form-control" Text="Register" OnClick="BtnRegister_Click" />
            </div>
            
        </div>
    </form>
    
</body>
</html>
