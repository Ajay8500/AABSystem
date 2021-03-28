<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AABFrontOffice.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="modal fade" id="exampleModalCenter1" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" style="color: white;" id="exampleModalCenterTitle1">Add Category</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" style="color: white;">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label>Date</label>
                    <input id="_bookingDate" class="form-control" type="date" autofocus="autofocus"/>
                    <input id="_carId" class="form-control" type="number" autofocus="autofocus" hidden/>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" id="_btnBookApp" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>


        <div class="modal fade" id="CarPurchase" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" style="color: white;" id="CarPurchaseTitle">Add Card Details</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" style="color: white;">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label>Card No</label>
                    <input id="_cardNo" class="form-control" type="text" autofocus="autofocus"/>
                    <br />
                    <label>CVV</label>
                    <input id="_cvv" class="form-control" type="text" autofocus="autofocus"/>
                    <%--<input id="_carId" class="form-control" type="number" autofocus="autofocus" hidden/>--%>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" id="_btnPurchase" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>


    <div class="container-fluid" style="color: black">

        <div class="col-md-12 col-sm-12">
            <div class="card shadow mb-4">
                <div class="card-header">
                    <h6 class="m-0 font-weight-bold  centerHead">Cars -Book an appointment to see a car</h6>
                </div>
                <br />
                <div class="card-body">

                    <br />
                    <div class="row">
                        <div class="table-responsive">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <table class="table table-bordered  table-hover table-condensed dataTable" id="_carList">
                                    <thead class="_changeHeaderColor">
                                        <tr>
                                            <th>Id</th>
                                            <th>Model</th>
                                            <th>Price</th>
                                            <th>Body Style</th>
                                            <th>Color</th>
                                            <th>Added On</th>
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



            var name = '<%=Session["UserName"] %>';
            
            if (name == '') {
                window.location.replace("Login.aspx");
            }


            function getAllCars() {
                ajaxFunction("AabCarService.asmx/GetAllCars", { ticketStatus: "Total" }, "xml", "post", false, function (data) {
                    var jsonData = $.parseJSON($(data).find("string").text());
                    $("#_carList").dataTable().fnClearTable();
                    $("#_carList").dataTable().fnDestroy();
                    console.log(jsonData);

                    $('#_carList').DataTable({
                        data: jsonData.Table,
                        "paging": true,
                        columns: [


                            {
                                'data': 'carId',
                            },


                            {
                                'data': 'Model',
                            },


                            {
                                'data': 'Price',
                            },

                            {
                                'data': 'BodyStyle',
                            },

                            {
                                'data': 'Color',
                            },

                            {
                                'data': 'CreatedOn',
                            },

                            {
                                "data": null,
                                "render": function (data, type, row) {
                                    var val =
                                        //'<i data-id="' + row.carId + '" class="fa fa-edit mx-1 _btnEdit" id="_btnedit" style="color: #0101DF"></i>' +
                                        '<button type="button" class="btn btn-primary btn-sm _bookAppointment _adminSR" placeholder="Book Appointment" data-id="' + row.carId + '"style="background-color: #0101DF; width: 70px"">Book Appointment</button>' +
                                        '<button type="button" class="btn btn-info btn-sm _purchaseCar _adminSR" placeholder="Purchase Car" data-id="' + row.carId + '"style="background-color: #c90076; width: 90px"">Purchase Car</button>';
;

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
            getAllCars()
            $(document).on('click', '#_btnAdd', function () {
                window.location.href = "AddCar.aspx"
            })



            function BookAppointment(carId, BookingDate) {

                var parameters = {

                    CarId: carId,
                    BookingDate: BookingDate
                };

                ajaxForInsertAndUpdate("AabCarService.asmx/AddBooking", parameters, "post", false, function (data) {
                    var response = $.parseJSON($(data).find("string").text());

                    if (response.statusCode == '00') {
                        toastr.success("Booking successfully..", "Success");
                        setTimeout(function () {
                            window.location.replace("BookedAppointments.aspx")
                        }, 2000);
                    }
                    else if (response.statusCode == '01') {
                        toastr.warning("Sorry this slot is already booked choose other date..", "Warning");
                        setTimeout(function () {
                            //window.location.replace("Home.aspx");
                        }, 1500);
                    }
                    else if (response.statusCode == '010') {
                        toastr.warning("You already booked an appointment for this car..", "Warning");
                        setTimeout(function () {
                            //window.location.replace("Home.aspx");
                        }, 1500);
                    }
                    else {
                        toastr.error("Something went wrong.. Please check your internet Connection", "Error")
                    }
                });
            }

            function CarPurchase(carId, cardNo, cvv) {

                var parameters = {

                    CarId: carId,
                    CardNo: cardNo,
                    Cvv: cvv
                };

                ajaxForInsertAndUpdate("AabCarService.asmx/CarPurchase", parameters, "post", false, function (data) {
                    var response = $.parseJSON($(data).find("string").text());

                    if (response.statusCode == '00') {
                        toastr.success("Your car purchase order has been placed successfully! Please wait for confirmations..", "Success");
                        setTimeout(function () {
                            getAllCars();
                        }, 3000);
                    
                    }
                    else {
                        toastr.error("Something went wrong.. Please check your internet Connection", "Error")
                    }
                });
            }
            

            $(document).on('click', '._purchaseCar', function () {

                var carId = $(this).attr('data-id');
                $('#_carId').val(carId);

                $('#CarPurchase').modal('toggle');
            })

            $(document).on('click', '._bookAppointment', function () {

                var carId = $(this).attr('data-id');
                $('#_carId').val(carId);

                $('#exampleModalCenter1').modal('toggle');
            })

            $(document).on("click", "#_btnBookApp", function () {
                var carId = $('#_carId').val();
                var BookingDate = $('#_bookingDate').val();
                BookAppointment(carId, BookingDate)
            })

            $(document).on("click", "#_btnPurchase", function () {
                var carId = $('#_carId').val();
                var CardNo = $('#_cardNo').val();
                var Cvv = $('#_cvv').val();


                CarPurchase(carId, CardNo, Cvv)
            })

            

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
                                    toastr.success("Employee deleted successfully..")
                                    getAllCars()
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
