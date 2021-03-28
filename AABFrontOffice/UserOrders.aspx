<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserOrders.aspx.cs" Inherits="AabCars.UserOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
                    <div class="row">
                        <div class="table-responsive">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <table class="table table-bordered  table-hover table-condensed dataTable" id="_orderList">
                                    <thead class="_changeHeaderColor">
                                        <tr>
                                            <th>Id</th>
                                            <th>Model</th>
                                            <th>Price</th>
                                            <th>Body Style</th>
                                            <th>Color</th>
                                            <th>Added On</th>
                                            <th>Confirmed</th>
                                        </tr>
                                    </thead>

                                    <tbody id="_ticketList">
                                    </tbody>

                                </table>
                            </div>
                        </div>

                    </div>

    <script>
        $(document).ready(function () { 

            var isStaff = '<%=Session["isStaff"] %>';
        function getAllCars() {
            ajaxFunction("AabCarService.asmx/GetOrders", { ticketStatus: "Total" }, "xml", "post", false, function (data) {
                var jsonData = $.parseJSON($(data).find("string").text());
                $("#_orderList").dataTable().fnClearTable();
                $("#_orderList").dataTable().fnDestroy();
                console.log(jsonData);

                $('#_orderList').DataTable({
                    data: jsonData.Table,
                    "paging": true,
                    columns: [


                        {
                            'data': 'purchaseId',
                        },


                        {
                            'data': 'Model',
                        },


                        {
                            'data': 'TotalAmount',
                        },

                        {
                            'data': 'BodyStyle',
                        },

                        {
                            'data': 'Color',
                        },

                        {
                            'data': 'PurchaseOn',
                        },

                        {
                            "data": null,
                            "render": function (data, type, row) {
                                var val = '';
                                if (row.IsConfirmed == 0) {
                                    val = 'Order not confirmed yet'
                                }
                                else if (row.IsConfirmed == 1) {
                                    val = 'Your order confirmed'
                                }
                                else if (row.IsConfirmed == 2) {
                                    val = 'Order Canceled'
                                }

                                
                                

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
                                columns: [0, 1, 2, 3, 4, 5, 7]
                            },
                            title: 'Tickets' + "_" + moment().format("DD-MM-YYYY")
                        },
                    ]

                });


            });
            }


            //$(document).on('click', '._cancelOrConfirm', function () {
            //    var purchaseId = $(this).attr('data-id');
            //    var confirm = $(this).attr('confirm-id');

            //    CancelOrConfirm(purchaseId, confirm);
                
            //})



            //function CancelOrConfirm(purchaseId, confirm) {
            //    var param = {
            //        purchaseId: purchaseId,
            //        confirm: confirm
            //    }

            //    ajaxForInsertAndUpdate("AabCarService.asmx/UpdateOrder", param, "post", false, function (data) {
            //        var response = $.parseJSON($(data).find("string").text());

            //        if (response.statusCode == '00') {
            //            toastr.success("Order Confirmed successfully..", "Success");
            //            setTimeout(function () {
            //                getAllCars();
            //            }, 1500);
            //        }
            //        else if (response.statusCode == '010') {
            //            toastr.warning("Order canceled..", "warning");
            //            setTimeout(function () {
            //                getAllCars();
            //            }, 1500);
            //        }
            //        else {
            //            toastr.error("Something went wrong.. Please check your internet Connection", "Error")
            //        }
            //    });
            //}


        getAllCars()
        });

    </script>
</asp:Content>
