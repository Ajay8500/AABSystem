<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="AABFrontOffice.EmployeeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container-fluid" style="color: black">

        <div class="col-md-12 col-sm-12">
            <div class="card shadow mb-4">
                <div class="card-header">
                    <h6 class="m-0 font-weight-bold  centerHead">Employee List</h6>
                </div>
                <br />
        <div class="row col-md-12 col-sm-12 d-flex justify-content-center">
            <button type="button" class="btn btn-success col-md-2" id="_btnAdd">Add New Employee</button>

        </div>
                <div class="card-body">

                    <br />
                    <div class="row">
                        <div class="table-responsive">
                              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <table class="table table-bordered  table-hover table-condensed dataTable" id="_staffList">
                                <thead class="_changeHeaderColor">
                                    <tr>
                                        <th>Id</th>
                                        <th>Staff Name</th>
                                        <th>Email Address</th>
                                        <th>Contact Number</th>
                                        <th>Address</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>

                                <tbody id="_ticketList">
                                </tbody>

                            </table>
                        </div>
                        </div>
                      
                    </div>

                </div>
            </div>
        </div>

    </div>

    <script>
        $(document).ready(function () {


            <%--role = '<%=Session["Roles"] %>';
            // window.location.replace("CreateComplaint.aspx");
            if (role == 'Helpline Representative' || role == 'Supervisor' || role == 'Manager' || role == 'Head of Department' || role == 'Unit Head') {
                window.location.replace("CreateComplaint.aspx");
            }--%>

            $(".staffList").addClass("active")

            function getAllBranches() {
                ajaxFunction("AABCarService.asmx/GetAllStaff", { ticketStatus: "Total" }, "xml", "post", false, function (data) {
                var jsonData = $.parseJSON($(data).find("string").text());
                    $("#_staffList").dataTable().fnClearTable();
                    $("#_staffList").dataTable().fnDestroy();
                console.log(jsonData);

                    $('#_staffList').DataTable({
                    data: jsonData.Table,
                        "paging": true,
                    columns: [


                        {
                            'data': 'userid',
                        },


                        {
                            'data': 'UserName',
                        },


                        {
                            'data': 'Email',
                        },

                        {
                            'data': 'Contact',
                        },

                        {
                            'data': 'Address',
                        },

                        {
                            "data": null,
                            "render": function (data, type, row) {
                                var val = '<i data-id="' + row.userid + '" class="fa fa-edit mx-1 _btnEdit" id="_btnedit" style="color: #0101DF"></i>' +
                                    '<i class="fa fa-trash mx-1  _btnDelete _adminSR" data-id="' + row.userid + '"style="color: red"></i>';
                                    
                                return val;
                            }
                        },

                    ],

                    "rowCallback": function (row, data, index) {

                        if (data.Status == "Resolved") {
                            $(row).find("td:eq(0) ._cbChange").attr("disabled", true);
                        }

                    },



                    dom: "fltip",
                    //"lengthChange": false,
                        "paging": true,
                    'searching': true,
                    "pageLength": 10,
                    buttons: [
                        {
                            extend: 'excel',
                            footer: true,
                            exportOptions: {
                                columns: [0, 1, 2,3, 4, 5, 7]
                            },
                            title: 'Tickets' + "_" + moment().format("DD-MM-YYYY")
                        },
                    ]

                });


            });
            }
            getAllBranches()
            $(document).on('click', '#_btnAdd', function () {
                window.location.href = "AddorUpdateEmp.aspx"
            })

            $(document).on('click', '._btnEdit', function () {
                var EmpId = $(this).attr('data-id')
                window.location.href = "AddorUpdateEmp.aspx?EmpId=" + EmpId;
            })

            

            $(document).on("click", "._btnDelete", function (event) {
                var officeId = $(this).attr("data-id")

                $.confirm({
                    title: 'Delete!',
                    icon: 'fa fa-question',
                    theme: 'modern',
                    closeIcon: true,
                    animation: 'scale',
                    type: 'blue',
                    buttons: {
                        yes: function () {

                            var param = {
                                empid: officeId
                            }

                            ajaxForInsertAndUpdate("AABCarService.asmx/DeleteStaff", param, "post", false, function (data) {
                                var response = $.parseJSON($(data).find("boolean").text());
                                if (response) {
                                    toastr.success("Employee deleted successfully..")
                                    getAllBranches()
                                }
                                else {
                                    toastr.error("Something went wrong.. Please check your internet Connection", "Error")
                                }
                            }, null);
                        },
                        no: function () {

                        }
                    }
                });

            });

        });
    </script>


</asp:Content>
