<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="AABFrontOffice.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


            <div class="col-md-12 col-sm-12">
            <div class="card shadow mb-4">
                <div class="card-header">
                    <h6 class="m-0 font-weight-bold  centerHead">Customer List</h6>
                </div>
                <br />

                <div class="card-body">

                    <br />
                    <div class="row">
                        <div class="table-responsive">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <table class="table table-bordered  table-hover table-condensed dataTable" id="_customerList">
                                    <thead class="_changeHeaderColor">
                                        <tr>
                                            <th>Id</th>
                                            <th>Customer Name</th>
                                            <th>Email</th>
                                            <th>Contact</th>
                                            <th>Address</th>
                                            <th>Registered On</th>
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


    <script>

        $(document).ready(function () {


            <%--role = '<%=Session["Roles"] %>';
            // window.location.replace("CreateComplaint.aspx");
            if (role == 'Helpline Representative' || role == 'Supervisor' || role == 'Manager' || role == 'Head of Department' || role == 'Unit Head') {
                window.location.replace("CreateComplaint.aspx");
            }--%>

                    $(".customerList").addClass("active")

                    function getAllCustomers() {
                        ajaxFunction("AABCarService.asmx/GetAllCustomers", { ticketStatus: "Total" }, "xml", "post", false, function (data) {
                            var jsonData = $.parseJSON($(data).find("string").text());
                            $("#_customerList").dataTable().fnClearTable();
                            $("#_customerList").dataTable().fnDestroy();
                            console.log(jsonData);

                            $('#_customerList').DataTable({
                                data: jsonData.Table,
                                "paging": true,
                                columns: [


                                    {
                                        'data': 'UserID',
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
                                        'data': 'CreatedOn',
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
                                            columns: [0, 1, 2, 3, 4, 5, 7]
                                        },
                                        title: 'Tickets' + "_" + moment().format("DD-MM-YYYY")
                                    },
                                ]

                            });


                        });
                    }
                    getAllCustomers()
                   

                    //$(document).on('click', '._btnEdit', function () {
                    //    var EmpId = $(this).attr('data-id')
                    //    window.location.href = "AddorUpdateEmp.aspx?EmpId=" + EmpId;
                    //})



                    $(document).on("click", "._btnDelete", function (event) {
                        var carId = $(this).attr("data-id")

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
                                        carId: carId
                                    }

                                    ajaxForInsertAndUpdate("AabCarService.asmx/DeleteCar", param, "post", false, function (data) {
                                        var response = $.parseJSON($(data).find("boolean").text());
                                        if (response) {
                                            toastr.success("Car deleted successfully..")
                                            getAllCustomers()
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
