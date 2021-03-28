<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AabCars.Login" %>

<!DOCTYPE html>

<html xmlns="">
<head runat="server">
    <title></title>

    <%--<script src="<%= ResolveUrl("customjs/jquery.js") %>" type="text/javascript"></script>--%>

    <link href="Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />--%>
    <link href="Assets/css/Login.css" rel="stylesheet" type="text/css" />

</head>
<body>

    <script src="Assets/js/jquery-3.4.1.min.js"></script>
    <script src="Assets/js/modernizr-2.8.3.js"></script>

    <script>
        $(document).ready(function () {
            localStorage.clear();
            sessionStorage.clear();
        });

    </script>


    <div class="wrapper">


        <form id="_form" runat="server">

            <div class="login">
                <img style="margin: 15px" src="Assets/images/alfalah.png" width="180px" />
                <div class="row" style="color:red">
                     <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
               <br />
                <input type="email" textmode="Email" placeholder="email" runat="server" id="_txtEmail" required="required" autofocus="autofocus" tabindex="1" />
                        <input type="password" placeholder="password" runat="server" id="_txtPassword" required="required" tabindex="2" />
                        <button id="_btnLogin" runat="server" onserverclick="_btnLogin_ServerClick" >Login</button>
                   <br />         
                    <a id="_btn" runat="server" onserverclick="_btnRegister_ServerClick" >Create Account</a>


            </div>
        </form>
    </div>

</body>
</html>
