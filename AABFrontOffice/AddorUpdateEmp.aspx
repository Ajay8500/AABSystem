<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddorUpdateEmp.aspx.cs" Inherits="AabCars.AddorUpdateEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .error {
            font-size: 12px;
            color: red;
        }
    </style>


    <div class="card shadow mb-4">
        <div class="card-header">
            <h6 class="m-0 font-weight-bold centerHead">Add Staff</h6>
        </div>
        <div class="card-body">

            <div class="row divTopMargin">
                <div class="col-md-6">
                    <label>Staff Name</label>
                    <input id="_staffid" value="0" class="form-control _requiredInputs d-none" type="text" />
                    <input id="_staffname" name="StaffName" class="form-control _requiredInputs" type="text" autofocus="autofocus" />

                 </div>
                    <div class="col-md-5">
                        <label>Staff Contact Number</label>
                        <input id="_staffContact" name="ContactNumber" class="form-control _requiredInputs" type="text" autofocus="autofocus" />
                    </div>

            </div>
            <div class="row divTopMargin">

                <div class="col-md-6">
                    <label>Staff Email Address</label>
                    <input id="_staffEmail" name="StaffEmailAddress" class="form-control _requiredInputs" type="email" autofocus="autofocus" />
                </div>

                <div class="col-md-6">
                    <label>Password</label>
                    <input id="_password" name="password" class="form-control _requiredInputs" type="password" autofocus="autofocus" />
                </div>

            </div>


            <div class="row divTopMargin">

                <div class="col-md-6">
                    <label>Address</label>
                    <input id="_staffAddress" name="Address" class="form-control _requiredInputs" autofocus="autofocus" />
                </div>

                <div class="col-md-6 d-none">
                    <label>Date of birth</label>
                    <input id="_Dob"  class="form-control _requiredInputs" type="date" autofocus="autofocus" />
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


            var EmpId = $.url().param("EmpId") ? $.url().param("EmpId") : 0;

            if (EmpId) {
                ajaxFunction("AABCarService.asmx/GetStaffById", { EmpId: EmpId }, "xml", "post", false, function (data) {
                    var json = $.parseJSON($(data).find("string").text());
                    var response = json.Table[0];
                    
                    $("#_staffname").val(response.UserName);
                    $("#_staffContact").val(response.Contact);
                    $("#_staffEmail").val(response.Email);
                    $('#_staffAddress').val(response.Address);
                    $('#_password').val(response.password);


                    $("#_btnAdd").html("Update");
                });
            }


            var form = $('#form1');
            $("#form1").validate({
                rules: {
                    StaffName: "required",
                    StaffDesignation: "required",
                    StaffEmailAddress: {
                        required: true,
                        email: true
                    },
                    ContactNumber: "required",
                },
                messages: {
                    StaffName: "Please input Staff Name",
                    StaffDesignation: "Please input Staff Designation",
                    ContactNumber: "Please input PhoneNo",
                    StaffEmailAddress: {
                        required: "Please input your Email.",
                        email: "Invalid email address"
                    },
                }
            });

            function addStaff() {

                var parameters = {

                    EmpId: EmpId,
                    StaffName: $("#_staffname").val(),
                    password: $("#_password").val(),
                    ContactNumber: $("#_staffContact").val(),
                    StaffEmailAddress: $("#_staffEmail").val(),
                    Address: $('#_staffAddress').val(),
                    DOB: $('#_Dob').val()
                };

                ajaxForInsertAndUpdate("AABCarService.asmx/AddOrUpdateEmp", parameters, "post", false, function (data) {
                    var response = $.parseJSON($(data).find("string").text());

                    if (response.statusCode > 0) {
                        toastr.success("New Employee created successfully..", "Success");
                        setTimeout(function () {
                            window.location.replace("StaffList.aspx");
                        }, 1500);
                    }

                    else if (response.statusCode == '000') {
                        toastr.success("Employee updated successfully..", "Success");
                        setTimeout(function () {
                            window.location.replace("StaffList.aspx");
                        }, 2000);

                    }
                    else if (response.statusCode == '01') {
                        toastr.warning("Email Is Already Exists..", "Warning");
                        setTimeout(function () {
                            //window.location.replace("VendorList.aspx");
                        }, 2000);

                    }
                    else {
                        toastr.error("Something went wrong.. Please check your internet Connection", "Error")
                    }
                });
            }




            $(document).on("click", "#_btnAdd", function (e) {

                var formValid = form.valid();



                if (formValid) {

                    addStaff();
                }
                else {
                    toastr.warning("Please add all detail before submit", "Warning")
                }
            });

        });
        </script>


</asp:Content>
