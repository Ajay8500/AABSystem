<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterOrLogin.aspx.cs" Inherits="AABFrontOffice.RegisterOrLogin" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
    font-family: "Open Sans", sans-serif;
    height: 100vh;
    /*background: url("../images/alfalah-back.jpg") 50% fixed;
    background-size: cover;*/
    /* height: 100%;*/
    width: 100%;
    background-image: url(../assets/images/alfalah-back2.jpg);
    background-size: 100% auto;
    background-repeat-y: no-repeat;
}

    </style>

    <div class="b2 col-md-8 issueDetails center">
        <div class="card shadow mb-4 center">
            <div class="card-header">
                <h6 class="m-0 font-weight-bold centerHead headerText">Registeration</h6>
            </div>

            <div class="row" style="color: green">
                    <asp:Label ID="lblMsgsuccess" runat="server"></asp:Label>
                </div>

                <div class="row" style="color: red">
                    <asp:Label ID="lblMsgfail" runat="server"></asp:Label>
                </div>

            <div class="card-body">
                
                <div class="row divTopMargin">
                    <div class="col-md-6">
                        <label>User Name</label>
                        <input type="text" class="form-control" runat="server" id="_userId" value="0" required="required" hidden />

                        <input type="text" placeholder="Name" class="form-control" runat="server" id="_txtName" required="required" autofocus="autofocus" tabindex="1" />
                    </div>
                    <div class="col-md-6">
                        <label>User Email</label>
                        <input type="email" textmode="Email" class="form-control" placeholder="Email" runat="server" id="_txtEmail" required="required" autofocus="autofocus" tabindex="2" />
                    </div>
                </div>
                <div class="row divTopMargin">
                    <div class="col-md-6">
                        <label>Contact Number</label>
                        <input type="text" textmode="text" class="form-control" placeholder="Contact" runat="server" id="_userContact" required="required" autofocus="autofocus" tabindex="3" />

                    </div>
                    <div class="col-md-6">
                        <label>Password</label>
                        <input type="password" class="form-control" placeholder="password" runat="server" id="_txtPassword" required="required" tabindex="4" />

                    </div>
                </div>
                <div class="row divTopMargin">
                    <div class="col-md-6">
                        <label>Address</label>
                        <input id="_address" runat="server" placeholder ="Address" name="Address" class="form-control _requiredInputs" type="text" autofocus="autofocus" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row divTopMargin" id="btncreatediv">
            <div class="col-md-3"></div>
            <div class="col-md-6 divTopMargin-sm">
                <button type="button" id="Register" class="form-control btn btn-success" runat="server" onserverclick="_btnRegister_ServerClick">Submit</button>
            </div>

            <div class="col-md-3 divTopMargin-sm">
                <a  class="form-control btn btn-success login" runat="server" href="Login.aspx">Have a account: Login</a>
            </div>

            <div class="col-md-3"></div>
        </div>
        <br />
    </div>



    <script>
        $(document).ready(function () {

            var name = '<%=Session["UserName"] %>';

            if (name != '') {
                $('.login').addClass('d-none');
                $('.headerText').html('User Profile');
            }
            else {
                $('.login').removeClass('d-none');
            }

                

        })

    </script>

</asp:Content>



