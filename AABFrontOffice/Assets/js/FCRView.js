$(document).ready(function () {
    var requestId = $.url().param('requestId');
    function getTicketList() {

        ajaxFunction("BRServices.asmx/ShowRequestDetailsById", { requestId: requestId},"xml", "post", false, function (data) {
            var json = $.parseJSON($(data).find("string").text());
            console.log(json);
            $('#_requestNo').html(json.Table[0].TicketNo)
            $('#_createdDate').html(moment(json.Table[0].RequestCreatedDate).format('DD-MMM-YYYY'))
            $('#_requestStatus').html('Closed')
            $('#_totalRequests').html(json.Table1[0].TotalAssets)
            $('#_requestDetail').html(json.Table[0].Remarks)

            $('#_branchCode').html(json.Table[0].BranchCode)
            $('#_branchName').html(json.Table[0].BranchName)
            $('#_location').html(json.Table[0].Location)
            $('#_branchEmail').html(json.Table[0].Email)
            $('#_address').html(json.Table[0].Address)

            $('#_assetNo').html(json.Table[0].AssetsNo)
            $('#_assetName').html(json.Table[0].AssetName)
            $('#_tagNo').html(json.Table[0].TagNo)
            $('#_datePlace').html(json.Table[0].DataPlace);
        });


    }

    getTicketList()

})