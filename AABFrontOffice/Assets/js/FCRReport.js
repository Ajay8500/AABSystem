$(document).ready(function () {


    function getTicketList() {
        $(".fcrReportNav").addClass("active")

        ajaxFunctionWithoutParam("BRServices.asmx/ShowRequestDetails", "xml", "post", false, function (data) {

            var ticketList = $("#_ticketList");
            var employeeList = '';

            $("#_tblTicketList").dataTable().fnClearTable();
            $("#_tblTicketList").dataTable().fnDestroy();

            ticketList.empty();

            var jsonData = $.parseJSON($(data).find("string").text());
            var isActive = "";
            var index = 1;
            var vendorName = '';
            var remarks = '';
            var parentCategory = '';
            _.forEach(jsonData.Table, function (item, i) {
                vendorName = item.VendorName ? item.VendorName : '--'
                remarks = item.Remarks ? item.Remarks : '--'
                parentCategory = item.ParentCategory ? item.ParentCategory : ''
                employeeList += "<tr>" +
                    "<td><a class='_ticketNoLink' href='FCRView.aspx?requestId=" + item.TicketNo + "'>" + item.TicketNo + "</a></td>" +
                    "<td>" + item.BranchCode + "</td>" +                   
                    "<td>" + item.BranchName + "</td>" +
                    "<td>" + (moment(item.TicketCreateDate).format('DD-MMM-YYYY')) + "</td>" +
                    "<td>" + (item.TagNo + ' - ' + item.AssetsNo) + "</td>" +
                    "<td>" + (parentCategory + ' - ' + item.CategoryName) + "</td>" +
                    "<td>" + remarks + "</td>" +
                    "<td>Closed</td>" +                   
                    "</td>" +
                    "</tr>"

            });

            ticketList.append(employeeList);

            $("#_tblTicketList").dataTable({
                dom: 'Bfrtip',
                "lengthChange": false,
                "paging": true,
                'searching': true,
                "pageLength": 10,
                buttons: [
                    'excelHtml5'
                ],

                "order": [[0, "desc"]],
  
            });

        });


    };

    getTicketList()

  

})