<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AdTrafficWebApp.GUI.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ad Trcking System - Login</title>
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

        .login-container {
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 20px rgba(0,0,0,0.1);
            text-align: center;
            width: 300px;
        }

        .input-group{
            margin-bottom: 20px;
        }

        .input-group label {
            display:block;
            font-weight: bold;
            margin-bottom: 5px;
            text-align: left;
        }

        .form-control {
            width: calc(100% - 20px);
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .login-button, .register-button{
            background-color: #4caf50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            transition: background-color 0.3s;
            right: 10px;
            margin-top: 20px;
            
        }

        .login-button:hover, .register-button:hover {
            background-color: #45a049;
        }
        
        
        
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login to Ad Tracking System</h2>
            <div class="input-group">
                <label for="userid">Userid:</label>
                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group">
                <label for="password">Password:</label>
            </div>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <div class="input-group">
                <asp:Button ID="btnLogin" runat="server" CssClass="login-button" Text="Login" OnClick="btnLogin_Click" />
                <asp:Button ID="btnRegister" runat="server" CssClass="register-button" Text="Register" OnClick="btnRegister_Click" />
            </div>
         </div>
    </form>
</body>
</html>
