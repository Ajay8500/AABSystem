<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="AABFrontOffice.AddCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .error {
            font-size: 12px;
            color: red;
        }
    </style>

    
    <div class="card shadow mb-4">
        <div class="card-header">
            <h6 class="m-0 font-weight-bold centerHead">Add Car</h6>
        </div>
        <div class="card-body">

            <div class="row divTopMargin">
                <div class="col-md-6">
                    <label>Car Model</label>

                    <input id="_carMdel" name="Model" class="form-control _requiredInputs" type="text" autofocus="autofocus" />

                 </div>
                    <div class="col-md-5">
                        <label>Car Price</label>
                        <input id="_carPrice" name="Price" class="form-control _requiredInputs" type="text" autofocus="autofocus" />
                    </div>

            </div>
            <div class="row divTopMargin">

                <div class="col-md-6">
                    <label>Body Style</label>
                    <input id="_body" name="Body" class="form-control _requiredInputs" type="text" autofocus="autofocus" />
                </div>

                <div class="col-md-6">
                    <label>Color</label>
                    <input id="_color" name="Color" class="form-control _requiredInputs" type="text" autofocus="autofocus" />
                </div>

            </div>
            <br />

        </div>
    </div>

    <div class="row divTopMargin">
        <div class="col-md-3"></div>
        <div class="col-md-6 divTopMargin-sm">
            <button type="button" id="_btnAdd" class="form-control btn btn-success">Add</button>
        </div>
        <div class="col-md-3"></div>
    </div>

        <script>
        $(document).ready(function () {


            <%--role = '<%=Session["Roles"] %>';
            // window.location.replace("CreateComplaint.aspx");
            if (role == 'Helpline Representative' || role == 'Supervisor' || role == 'Manager' || role == 'Head of Department' || role == 'Unit Head') {
                window.location.replace("CreateComplaint.aspx");
            }
--%>

            function AddCar() {

                var parameters = {

                    CarId: 0,
                    Model: $("#_carMdel").val(),
                    Price: $("#_carPrice").val(),
                    Body: $("#_body").val(),
                    Color: $("#_color").val()
                };

                ajaxForInsertAndUpdate("AABCarService.asmx/AddOrUpdateCar", parameters, "post", false, function (data) {
                    var response = $.parseJSON($(data).find("string").text());

                    if (response.statusCode == '00') {
                        toastr.success("New Car Added successfully..", "Success");
                        setTimeout(function () {
                            window.location.replace("CarList.aspx");
                        }, 1500);
                    }
                    else {
                        toastr.error("Something went wrong.. Please check your internet Connection", "Error")
                    }
                });
            }




            $(document).on("click", "#_btnAdd", function () {
                    AddCar();
                
            });

        });
        </script>



</asp:Content>
