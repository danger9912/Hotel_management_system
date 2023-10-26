<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hotel_Management_System.Views.Login" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Assets/Lib/bootsrap/css/bootstrap.min.css" />
    <style>
        body {
            background-image: url(../Assets/Images/image1.jpg);
            background-size: cover;
        }

        .container-fluid {
            opacity: 0.9;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row" style="height: 120px;"></div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4 bg-light rounded-3">
                    <h1 class="text-success text-center">Golden Stay Hotel</h1>

                    <div class="mb-3">
                        <label for="UserTb" class="form-label">Email address</label>
                        <input type="text" class="form-control" id="UserTb" runat="server" required="required"/>

                    </div>
                    <div class="mb-3">
                        <label for="PasswordTb" class="form-label">Password</label>
                        <input type="password" class="form-control" id="PasswordTb" runat="server" />
                    </div>
                    <div class="mb-3 ">
                        <label id="ErrMsg" class="text-danger" runat="server"></label>
                        <input type="radio" class="form-check-input" id="AdminCb"  runat="server" name="Role" checked /><label class="text-success">Admin</label>
                        <input type="radio" class="form-check-input" id="UserCb" runat="server" name="Role" /><label class="text-danger">User</label>

                    </div>
                    <div class="d-grid">

                        <asp:Button ID="LoginBtn" runat="server" Text="Login" class="btn btn-primary" OnClick="LoginBtn_Click" />
                    </div>

                    <br />
                   
                </div>
                <div class="col-md-4"></div>

            </div>
        </div>
    </form>
</body>
</html>
