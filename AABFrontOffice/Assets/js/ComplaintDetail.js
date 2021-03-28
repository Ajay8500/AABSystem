$(document).ready(function () {

    var ticketNo = $.url().param('ticketno');
    var ticketStatusId = 0;
    var CategoryName = "";
    var message = null;
    var engineerEmpId = 0;
    var ActualCost = 0;
    getAssetsViaBranchCat(ticketNo);
    $('#_resolutionTime').prop('disabled', true);
    $("#_vendor").prop("disabled", true);

    $("#_userList").prop("disabled", true);
    $("#btnshow").addClass('d-none');
    $(function () {
        $("#_resolutionTime").datepicker();
    });


    var currentVendorSelect = 0;
    var currentUserSelect = 0;

    GetBranch();




    function GetBranch() {
        ajaxFunction("BRServices.asmx/GetBranchDetailByTicketNo", { TicketNo: parseInt(ticketNo) }, "xml", "post", false, function (data) {
            var jsonData = $.parseJSON($(data).find("string").text());
            if (jsonData.Table.length > 0) {
                $('#_branchCode').html(jsonData.Table[0].BranchCode ? jsonData.Table[0].BranchCode : "--");
                $('#_branchName').html(jsonData.Table[0].BranchName ? jsonData.Table[0].BranchName : "--");
                $('#_managerName').html(jsonData.Table[0].EmployeeName ? jsonData.Table[0].EmployeeName : "--");
                $('#_branchEmail').html(jsonData.Table[0].Email ? jsonData.Table[0].Email : "--");
                $('#_branchAddress').html(jsonData.Table[0].Address ? jsonData.Table[0].Address : "--");
            }
        })

    }



    $(document).on("click", '.BtnTicketLate', function () {

        var id = $(this).attr('data-id');

        showLoader();
        ajaxFunction("BRServices.asmx/GetUsersDetailsForEmail",
            {
                TicketNo: parseInt(ticketNo),
                Escalation: id
            },
            "xml", "post", false, function (data) {

                var json = $.parseJSON($(data).find("string").text());
                if (json.message == "Success") {
                    toastr.warning("Emails Sent");
                }


        });
        hideLoader();
    });

    function getAssetsViaBranchCat(ticketNo) {
        showLoader();
        ajaxFunction("BRServices.asmx/GetAssetDetailviaTicketNo",
            {
                TicketNo: parseInt(ticketNo)
            },
            "xml", "post", false, function (data) {

                var json = $.parseJSON($(data).find("string").text());

                if (json.Table.length > 0) {

                    _.forEach(json.Table, function (item, key) {
                        $('#_complaintTypelbl').html((item.ParentCategory ? item.ParentCategory : "--"))
                        $('#_assetsTypelbl').html((item.CategoryName ? item.CategoryName : "--"))
                        CategoryName = item.CategoryName;
                        $('#_assetNolbl').html((item.AssetsNo ? item.AssetsNo : "--"))
                        $('#_tagNolbl').html((item.TagNo ? item.TagNo : "--"))
                        $('#_descriptionlbl').html((item.Description ? item.Description : "--"))
                        $('#_qauantitylbl').html((item.Quantity ? item.Quantity : "--"))
                        $('#_dateOfPlacelbl').html((item.DataPlace ? item.DataPlace : "--"))
                        $('#_currentCostlbl').html((item.CurrentCost ? item.CurrentCost : "--"))
                        ActualCost = item.CurrentCost;
                        //console.log(item.WDV);
                        $('#_wdvlbl').html(item.WDV)
                        //console.log(item.NameOfSupplier);
                        $('#_nameofSupplierlbl').html((item.NameOfSupplier))
                        $('#_nameOfManufacturerlbl').html((item.NameOfManufacturer ? item.NameOfManufacturer : "--"))
                        $('#_productSerialNolbl').html((item.ProductSrNo ? item.ProductSrNo : "--"))

                    })
                }
                if (json.Table1.length > 0) {
                    _.forEach(json.Table1, function (item, key) {
                        $('#_issueDetails').html((item.TicketDesc ? item.TicketDesc : "Not Available"))
                    });

                }

        })

        hideLoader();
    }




    $(document).on('click', '._history', function () {
        $(this).addClass('active')
        $('._history1').addClass('show')
        $('._history1').addClass('active')

        $('._comment').removeClass('active')
        $('._comment1').removeClass('show')
        $('._comment1').removeClass('active')
    })

    $(document).on('click', '._comment', function () {
        $('._history').removeClass('active')
        $('._history1').removeClass('show')
        $('._history1').removeClass('active')

        $(this).addClass('active')
        $('._comment1').addClass('show')
        $('._comment1').addClass('active')
    })

    //getAllVendor($('._vendorlist'));

    getAllUsers($('#_userList'));




    function getAllUsers(currentList) {

        showLoader();
        ajaxFunctionWithoutParam("BRServices.asmx/GetAllUsers", "xml", "post", false, function (data) {

            hideLoader();

            var json = $.parseJSON($(data).find("string").text());
            currentList.empty();
            //var html = "";
            var html = '<option value="0">Assigned To</option>';
            if (json.Table.length > 0) {
                _.forEach(json.Table, function (item, key) {
                    html += '<option value="' + item.EmpId + '">' + item.EmpName + '</option>';
                    //console.log(item.EmpId);
                })
            }

            currentList.append(html);
        });
    }

    function getAllVendor(currentList, Flag) {
        var params = {
            TicketNo: ticketNo,
            CategoryName: CategoryName,
            flag: Flag
        }

        showLoader();
        ajaxFunction("BRServices.asmx/GetAllVendor", params, "xml", "post", false, function (data) {

            hideLoader();
            var json = $.parseJSON($(data).find("string").text());
            currentList.empty();
            var html = "";
            html += '<option value="0">' + "Select Vendor" + '</option>';
            var flag = false;


            if (json.Table.length > 0) {

                for (var i = 0; i < json.Table.length; i++) {
                    if (vendorId == json.Table[i].VendorId) {
                        flag = true;
                    }
                }

                _.forEach(json.Table, function (item, key) {
                    html += '<option value="' + item.VendorId + '">' + item.VendorCompany + '  (' + item.TicketCount + ')</option>';

                })

            }
            if (flag == false && VendorCompany != null) {
                html += '<option value="' + vendorId + '">' + VendorCompany + '</option>';
            }
            else {
                html += '<option value="37">Other</option>';
            }            

            currentList.append(html);
        });
    }

    function getVendorBySelection(currentList, officeId, categoryId, byoffice) {


        if (byoffice) {

            var parameters = {
                OfficeId: officeId,
                CategoryId: categoryId
            }
            showLoader();
            ajaxFunction("BRServices.asmx/GetVendorsByOfficeByCategory", parameters, "xml", "post", false, function (data) {
                hideLoader();
                var json = $.parseJSON($(data).find("string").text());
                currentList.empty();
                var html = "";
                html += '<option value="">' + "Select Vendor" + '</option>';
                if (json.Table.length > 0) {
                    _.forEach(json.Table, function (item, key) {
                        html += '<option value="' + item.VendorId + '">' + item.VendorCompany + '    (' + item.TicketCount + ')</option>';
                    })

                }
                html += '<option value="37">Other</option>';
                currentList.append(html);
            });
        }

        else {
            var parameters = {
                RegionId: officeId,
                CategoryId: categoryId
            }
            showLoader();
            ajaxFunction("BRServices.asmx/GetVendorsByRegionByCategory", parameters, "xml", "post", false, function (data) {
                hideLoader();
                var json = $.parseJSON($(data).find("string").text());
                currentList.empty();
                var html = "";
                html += '<option value="">' + "Select Vendor" + '</option>';
                if (json.Table.length > 0) {
                    _.forEach(json.Table, function (item, key) {

                        html += '<option value="' + item.VendorId + '">' + item.VendorCompany + '    (' + item.TicketCount + ')</option>';
                    });
                }
                html += '<option value="37">Other</option>';
                currentList.append(html);
            });


        }


    }

    $(document).on("click", "#_ChangeUser", function (e) {

        $("#_userList").prop("disabled", false);
        $(this).addClass('d-none');
        $("#_saveUser").removeClass('d-none');
        currentUserSelect = $("#_userList").val();
    })

    $(document).on("click", "#_saveUser", function (e) {

        showLoader();

        var userId = $('#_userList').val();
        message = $("#_hiddenFieldEmail").val() + " has Assigned Ticket " + ticketNo + " to " + $('#_userList option:selected').text();

        if (userId != currentUserSelect) {
            if (userId > 0) {
                ajaxFunction("BRServices.asmx/EditTicketAssignedUser", { userId: userId, ticketNo: ticketNo, message: message }, "xml", "post", false, function (data) {
                    var statusCode = $(data).find("string").text();
                    hideLoader();
                    if (statusCode == "000") {
                        toastr.success("Ticket Assigned Successfully..", "Success");
                        getTicketDetailByTicketNo(ticketNo)
                        $("#_userModal").modal("hide");
                    }
                    else {
                        toastr.warning("something went wrong...", "warning");
                    }
                })
            }
            else {
                toastr.warning("please select Vendor...", "warning");
            }
        }

       

        $("#_userList").prop("disabled", true);
        $(this).addClass('d-none');
        $("#_ChangeUser").removeClass('d-none');
    })









    $(document).on("click", "#_ChangeVendor", function (e) {

        

        $("#btnshow").removeClass('d-none');
        $("#_vendor").prop("disabled", false);
        $(this).addClass('d-none');
        $("#_saveVendor").removeClass('d-none');

        currentVendorSelect = $("#_vendor").val();

    })


    $(document).on("click", "#_saveVendor", function (e) {

        showLoader();

        var vendorId = $('#_vendor').val();
        message = $("#_hiddenFieldEmail").val() + " has Updated Vendor "

        if (vendorId != currentVendorSelect) {
            if (vendorId > 0) {
                ajaxFunction("BRServices.asmx/EditVendorById", { vendorId: vendorId, ticketNo: ticketNo, message: message }, "xml", "post", false, function (data) {

                    
                    var statusCode = $(data).find("string").text();
                    if (statusCode == "000") {
                        toastr.success("Vendor Updated Successfully..", "Success");
                        getTicketDetailByTicketNo(ticketNo)
                        $("#_vendorModal").modal("hide");

                    }
                    else {
                        toastr.warning("Something went wrong...", "Warning");
                    }
                })
            }
            else {
                toastr.warning("Please select Vendor...", "Warning");
            }
        }
        hideLoader();
        $("#_vendor").prop("disabled", true);
        $(this).addClass('d-none');
        $("#_ChangeVendor").removeClass('d-none');
        $("#btnshow").addClass('d-none');
    })


    var vendorId = 0;
    var VendorCompany = "";
    function getTicketDetailByTicketNo(ticketNo) {
        showLoader();
       

        ajaxFunction("BRServices.asmx/GetTicketDetailByTicketNo", { ticketNo: ticketNo }, "xml", "post", false, function (data) {

            var jsonData = $.parseJSON($(data).find("string").text());
            var loggedInUser = $("#_hiddenFieldEmpId").val();

            $("#_ticketno").html(jsonData.Table[0].TicketNo);
            $("#_issue").html(jsonData.Table[0].CategoryName);
            CategoryName = jsonData.Table[0].CategoryName;
            vendorId = jsonData.Table[0].VendorId;
            VendorCompany = jsonData.Table[0].VendorCompany;
            $("#_assignedTo").html(jsonData.Table[0].EmpName + ' (' + jsonData.Table[0].AssigneeEmail + ') ');
            $("#_ticketStatus").html(jsonData.Table[0].TicketStatusDesc);
            $("#_vendorName").html(jsonData.Table[0].VendorCompany);

            $("#_vendorEmail").html(jsonData.Table[0].VendorEmail);
            $("._vendorlist").val(jsonData.Table[0].VendorId);
            $("#_userList").val(jsonData.Table[0].AssignedToEmpId);
            $("#_userName").html(jsonData.Table[0].EmpName);
            $("#_userEmail").html(jsonData.Table[0].AssigneeEmail);

            $("#_resolutionTime").val(moment(jsonData.Table[0].expectedTime).format("YYYY-MM-DD"));
            //console.log(moment(jsonData.Table[0].expectedTime).format("MM/DD/YYYY"));
            if (jsonData.Table[0].Assets == 0) {
                $(".assetsDetail").addClass('d-none');

                //$('._Changestatusonresolved').removeClass('d-none');
                //$('#_btnResolved').removeClass('d-none');
                //$('._changeStatusDiv').addClass('d-none');

            }

         

            var loggedInUserTeamId = $("#_hiddenFieldTeamId").val();

            var currentDate = new Date();
            currentDate = moment(currentDate);
            var updateDate = moment(jsonData.Table[0].TicketUpdateTime);

            if (jsonData.Table[0].TicketStatusId == 3) {
                $("#_ticketStatus").html(jsonData.Table[0].TicketStatusDesc);
                if (loggedInUser == jsonData.Table[0].CreatorId) {
                    $("._changeStatusRow").removeClass("d-none");
                    //$("._changeStatusDiv").addClass("d-none");
                    $("#_btnResolveYes").removeClass("d-none");
                    $("#_btnResolveNo").removeClass("d-none");

                    $('#_btnresolutionTimeEdit').prop("disabled", true);
                    $("._isRepairable").addClass("d-none");
                    $("._assetsCost").addClass("d-none");
                    $("._recommend").addClass("d-none");
                    $("._finalActionnd").addClass("d-none");

                    $("._Changestatusonresolved").addClass("d-none");
                    //$("#_btnClose").removeClass("d-none");
                    //$("#_btnClose").prop("disabled",true);
                }

            }

            else {
                if (jsonData.Table[0].TicketStatusId == 1) {
                    $("#_ticketStatus").html(jsonData.Table[0].TicketStatusDesc);
                    if (loggedInUser == jsonData.Table[0].CreatorId) {
                        $("._changeStatusRow").removeClass("d-none");
                        $("#_btnResolveYes").removeClass("d-none");
                        $("#_btnResolveNo").removeClass("d-none");
                        $("#_btnEditTicket").removeClass("d-none");

                    }
                }

                else if (jsonData.Table[0].TicketStatusId == 2) {
                    $("#_ticketStatus").html(jsonData.Table[0].TicketStatusDesc);
                    if (loggedInUser == jsonData.Table[0].CreatorId) {
                        $("._changeStatusRow").removeClass("d-none");
                        $("#_btnClose,#_btnReOpen").removeClass("d-none");
                        $("#_btnResolved").addClass("d-none");
                        $('#_btnresolutionTimeEdit').prop("disabled", true);
                        //$("#_btnResolveNo").addClass("d-none");

                        $("._isRepairable").addClass("d-none");
                        $("._assetsCost").addClass("d-none");
                        $("._recommend").addClass("d-none");
                        $("._finalActionnd").addClass("d-none");
                        //_btnClose _btnReOpen
                        $('._Changestatusonresolved').removeClass('d-none');
                        $('#_btnClose').removeClass('d-none');
                        $('#_btnReOpen').removeClass('d-none');
                        $('#editbtn').prop("disabled", true);

                    }


                }

                else {

                    $("#_ticketStatus").html(jsonData.Table[0].TicketStatusDesc);

                    if (loggedInUser == jsonData.Table[0].CreatorId) {
                        $("#_btnEditTicket").removeClass("d-none");
                        $("._changeStatusRow").removeClass("d-none");
                        $("#_btnClose").removeClass("d-none");
                    }

                }


            }


            //if (loggedInUser == jsonData.Table[0].AssignedToEmpId || loggedInUser == jsonData.Table[0].CreatorId) {
            if (jsonData.Table[0].VendorResolved == 1) {
                $("#_btnResolveNo").addClass('d-none');
                $("#_btnResolveYes").prop("disabled", true);

                // _Changestatusonresolved _btnClose _btnReOpen _btnResolved

                $('._Changestatusonresolved').removeClass('d-none');
                $('#_btnResolved').removeClass('d-none');
                $('#_btnClose').addClass('d-none');
                $('#_btnReOpen').addClass('d-none');


            }
            else if (jsonData.Table[0].VendorResolved == 0) {
                $("#_btnResolveYes").addClass('d-none');
                $("#_btnResolveNo").prop("disabled", true);


                $('._isRepairable').removeClass('d-none');
                $("#ticketinfo").html("Is Part Repairable ?");
                $("#_replace").addClass('d-none');
                $('#_Noreplace').addClass('d-none');
                $('#_ticketCost').addClass('d-none');
                //$('#_NotReovledModal').modal('toggle')
                $('#_notResolved').removeClass('d-none');
                $('#_btnRepairableNo').removeClass('d-none');
                $('#_btnRepairableYes').removeClass('d-none');


            }


            if (jsonData.Table[0].IsRepairable != null && jsonData.Table[0].IsRepairable == 1) {

                $("#_btnRepairableYes").addClass('d-none');
                $("#_btnRepairableNo").prop("disabled", true);

            }
            else if (jsonData.Table[0].IsReplaced != null && jsonData.Table[0].IsReplaced == 1) {
                $('#_btnRepairableNo').addClass('d-none');
                $("#_btnRepairableYes").prop("disabled", true);
            }

            if (jsonData.Table[0].TotalCost != null && jsonData.Table[0].TotalCost < (ActualCost * 0.6)) {
                $('._assetsCost').removeClass('d-none');
                $('#_ticketItemCost').val(jsonData.Table[0].TotalCost);
                $('#_replaceItemCost').val(jsonData.Table[0].ReplaceCost);
                //$('#cost').html('Repair Cost');
                $("#_btnCostOkay").addClass("colorchange");
                $('#_btnCostOkay').prop("disabled", true);

                $("._recommend").addClass('d-none');
                $("#recommended").html('Repair');
                $('#_ticketItemCost').prop("disabled", true);
                $('#_replaceItemCost').prop("disabled", true);
                $("._finalActionnd").removeClass('d-none');
                $("#_btnReplace").removeClass('d-none'); $('#_btnRepair').removeClass('d-none');


            }
            else if (jsonData.Table[0].TotalCost != null && jsonData.Table[0].TotalCost >= (ActualCost * 0.6)) {
                $('._assetsCost').removeClass('d-none');
                $('#_ticketItemCost').val(jsonData.Table[0].TotalCost);
                $('#_replaceItemCost').val(jsonData.Table[0].ReplaceCost);
                // $('#cost').html('Replace Cost');
                $('#_ticketItemCost').prop("disabled", true);
                $('#_replaceItemCost').prop("disabled", true);
                $('#_btnCostOkay').prop("disabled", true);
                $("#_btnCostOkay").addClass("colorchange");
                $("._recommend").addClass('d-none');
                $("#recommended").html('Replace');
                $("._finalActionnd").removeClass('d-none');
                $("#_btnReplace").removeClass('d-none'); $('#_btnRepair').removeClass('d-none');
            }


            if (jsonData.Table[0].Finalstep != null && jsonData.Table[0].Finalstep == 1) {
                //_finalActionnd _btnRepair _btnReplace

                $("._finalActionnd").removeClass('d-none');
                $("#_btnReplace").addClass('d-none');
                $("#_btnRepair").prop("disabled", true);
                $("#_btnRepair").addClass("colorchange");

                $('._Changestatusonresolved').removeClass('d-none');
                $('#_btnResolved').removeClass('d-none');

            }
            else if (jsonData.Table[0].Finalstep != null && jsonData.Table[0].Finalstep == 0) {
                $("._finalActionnd").removeClass('d-none');
                $('#_btnRepair').addClass('d-none');
                $("#_btnReplace").prop("disabled", true);
                $("#_btnReplace").addClass("colorchange");

                $('._Changestatusonresolved').removeClass('d-none');
                $('#_btnResolved').removeClass('d-none');

            }

            if (jsonData.Table[0].TicketStatusId == 2) {
                $('#_btnResolved').addClass('d-none');
                $("#_btnClose,#_btnReOpen").removeClass("d-none");
            }
            //}
            //else {
            //    //$("#_btnResolveNo").addClass('d-none');
            //    //$("#_btnResolveYes").addClass('d-none');    
            //}

            if (jsonData.Table[0].TicketStatusId == 3) {
                $('._Changestatusonresolved').addClass('d-none');
                $('#editbtn').prop("disabled", true);  
            }

            if (jsonData.Table[0].TicketStatusId == 4) {
                $('#_btnReOpen').addClass('d-none');
                $('#_btnClose').addClass('d-none');
            }

            if (jsonData.Table1.length > 0) {
                var json = jsonData.Table1;

                var commentList = $("#_commentList");
                var html = '';
                commentList.empty();

                _.forEach(json, function (item, i) {
                    html += '<tr><td class="col-xs-8"><i class="fa fa-user _adjustAvatarIcon" aria-hidden="true"></i> ' + (item.Comment ? item.Comment : 'None') + '</td><td class="col-xs-4">' + moment(item.Date).format("DD/MMM/YYYY hh:mm A") + '</td><td data-documenturl="' + item.DocumentURL + '" class="col-xs-8">' + (item.DocumentName ? '<a href="' + item.DocumentURL + '" class="_fileURL" download>' + item.DocumentName + '</a>' : '--') + '</td>';
                });
                commentList.append(html);
            }

            if (jsonData.Table2.length > 0) {
                var json2 = jsonData.Table2;

                var historyList = $("#_historyList");
                var html = '';
                historyList.empty();
                _.forEach(json2, function (item, i) {

                    if (item.CommentId) {
                        html += '<tr id="history' + i + '" data-toggle="collapse" data-target="#_innerCommentTableCell_history' + i + '" data-commentid="' + item.CommentId + '" data-ticketno="' + item.TicketNo + '" class="_historyRow expand"><td class="col-xs-8"><i class="fa fa-user _adjustAvatarIcon" aria-hidden="true"></i> ' + (item.Message ? item.Message : 'None') + '</td><td class="col-xs-3">' + moment(item.Date).format("DD/MMM/YYYY hh:mm A") + '</td></tr>';
                    }
                    else {
                        html += '<tr data-commentid="' + item.CommentId + '" data-ticketno="' + item.TicketNo + '" ><td class="col-xs-8"><i class="fa fa-user _adjustAvatarIcon" aria-hidden="true"></i> ' + item.Message + '</td><td class="col-xs-3">' + moment(item.Date).format("DD/MMM/YYYY hh:mm A") + '</td></tr>';
                    }

                });
                historyList.append(html);
            }

            if (jsonData.Table[0].JVC != '' || jsonData.Table[0].JVC != null) {
                $('#_jvcNo').val(jsonData.Table[0].JVC);
            }


            if (jsonData.Table[0].TicketStatusId == 3 || jsonData.Table[0].TicketStatusId == 2) {
                $('#_ChangeUser').addClass('d-none');
                $('#_ChangeVendor').addClass('d-none');
                $('#_btnresolutionTimeEdit').addClass('d-none')
            }
            else {
                $('#_ChangeUser').removeClass('d-none');
                $('#_ChangeVendor').removeClass('d-none');
                $('#_btnresolutionTimeEdit').removeClass('d-none')
                $('#_btnresolutionTimeEdit').prop("disabled", false);
            }

           

        });
        hideLoader();


        getAllVendor($('#_vendor'), 1);
        //getVendorBySelection($('#_vendor'), officeId, currentCat, true);
        $('#_vendor').val(vendorId);

        $('.container-fluid').removeClass('d-none');

        hideLoader();

    }

    $(document).on("click", ".btnselectAllVendor", function () {
        showLoader();
        var id = $('#_vendor').val();
        getAllVendor($('#_vendor'), 0);
        $('#_vendor').val(id)
        hideLoader();
    })

    getTicketDetailByTicketNo(ticketNo)


    var commentId = 0;
    function addComment(ticketNo, comment) {
        //setTimeout(function () {
        showLoader();
        ajaxFunction("BRServices.asmx/AddComment", { ticketNo: ticketNo, comment: comment }, "xml", "post", true, function (data) {
            var jsonData = $(data).find("string").text();
            var responseArray = jsonData.split(',');
            var statusCode = responseArray[0];
            commentId = parseInt(responseArray[1]);

            hideLoader();
            if (statusCode = '00') {
                $('#_commentModal').modal('hide')
                toastr.success("Comment saved successfully");
                if (commentUpload.files.length > 0) {
                    commentUpload.processQueue();

                }
            }
        });

    }


    $(document).on("click", "#_btnresolutionTimeEdit", function () {

        $('#_resolutionTime').prop('disabled', false);

        $(this).addClass('d-none');
        $("#_btnresolutionTimeSave").removeClass('d-none');

    })




    function showCommentModal(param, isStatusUpdate) {
        var response = false;
        $('#_commentModal').modal('toggle')

    }





    $(document).on("click", "#_btnresolutionTimeSave", function (e) {

        $('#_submitresolveyes').addClass('d-none');
        $('#_submitresolve').addClass('d-none');
        $('#_submitreopen').addClass('d-none');
        $('#_submitclose').addClass('d-none');
        $('#_submitSaveDate').removeClass('d-none');
        $('#_submit').addClass('d-none');

        $('#_commentModal').modal('toggle')


    });

    $(document).on('click', '#_submitSaveDate', function () {
        var comment = $('#_comment').val()
        addComment(ticketNo, comment)

        var date = $('#_resolutionTime').val();

        showLoader();

        ajaxFunction("BRServices.asmx/ChangeTicketDateLog", { TicketNo: ticketNo, Date: date }, "xml", "post", true, function (data) {
            var jsonData = $(data).find("string").text();
            var responseArray = jsonData.split(',');
            var statusCode = responseArray[0];
            hideLoader();
            if (statusCode = '00') {
                toastr.success("Date has Changed Successfully");
                $('#_resolutionTime').prop('disabled', true);
                $('#_btnresolutionTimeSave').addClass('d-none');
                $("#_btnresolutionTimeEdit").removeClass('d-none');
                getTicketDetailByTicketNo(ticketNo)
            }
            else {
                $.alert(statusCode);
            }
        });


        //setTimeout(function () {
            //location.reload();
            getTicketDetailByTicketNo(ticketNo)
        //}, 2000)



        $('#_comment').val('');
    })

    $(document).on("click", "#_btnOpenAddCommentModal", function (e) {
        $("#_jvcNo").addClass("d-none");
        $('#_submitresolveyes').addClass('d-none');
        $('#_submitresolve').addClass('d-none');
        $('#_submitreopen').addClass('d-none');
        $('#_submitclose').addClass('d-none');
        $('#_submitSaveDate').addClass('d-none');
        $('#_submit').removeClass('d-none');


        $('#_commentModal').modal('toggle')



    });


    $(document).on('click', '#_submit', function () {

        showLoader();
        var comment = $('#_comment').val()

        addComment(ticketNo, comment)
        //setTimeout(function () {
            //location.reload();
            getTicketDetailByTicketNo(ticketNo)
        //}, 2000)

        $('#_comment').val('');

        //hideLoader();
    })


    function AddorUpdateTicketStep(TicketNo, flag) {



        var parameters = {
            TicketNo: TicketNo,
            Flag: flag
        };
        showLoader();
        ajaxForInsertAndUpdate("BRServices.asmx/AddorUpdateTicketStep", parameters, "post", false, function (data) {
            var response = $.parseJSON($(data).find("string").text());

            hideLoader();
            if (response.statusCode == '00') {

            }

            else if (response.statusCode == '000') {
                $("#_btnResolveYes").addClass('d-none');
                $("#_btnResolveNo").prop("disabled", true);
            }
            else {
                toastr.error("Something went wrong.. Please check your internet Connection", "Error")
            }
        });
    }


    function AddFinalTicketStatus(TotalCost, replaceCost, Flag) {
        var parameters = {
            TicketNo: ticketNo,
            RepairedCost: TotalCost,
            ReplaceCost: replaceCost,
            Flag: Flag
        };
        showLoader();
        ajaxForInsertAndUpdate("BRServices.asmx/AddFinalTicketStatus", parameters, "post", false, function (data) {
            var response = $.parseJSON($(data).find("string").text());
            hideLoader();
            if (response.statusCode == '00' || response.statusCode == '000') {

                var actualCost = ActualCost;

                $("._recommend").addClass('d-none');
                if (TotalCost < (actualCost * 0.6)) {

                    $("#recommended").html('Repair');
                    $('._finalActionnd').removeClass('d-none');
                    $('#_ticketItemCost').prop("disabled", true);
                    $('#_replaceItemCost').prop("disabled", true);
                    $('#_btnCostOkay').prop("disabled", true);
                }
                else {

                    $("#recommended").html('Replace');
                    $('._finalActionnd').removeClass('d-none');
                    $('#_ticketItemCost').prop("disabled", true);
                    $('#_replaceItemCost').prop("disabled", true);
                    $('#_btnCostOkay').prop("disabled", true);
                }

            }

            else if (response.statusCode == '000') {
                //toastr.success("Poc Vendor updated successfully..", "Success");
                //setTimeout(function () {
                //    //window.location.replace("VendorList.aspx");
                //}, 2000);

            }
            else if (response.statusCode == '01') {

                $('#_btnReplace').prop("disabled", true);
                $('#_btnRepair').addClass('d-none');

            }
            else if (response.statusCode == '10') {
                $('#_btnRepair').prop("disabled", true);
                $('#_btnReplace').addClass('d-none');
            }
            else {
                toastr.error("Something went wrong.. Please check your internet Connection", "Error")
            }
        });
    }


    //$(document).on("click", "#_btnReplacedOkay", function () {
    //    var repairableitemCost = $("#_ticketItemCost").val();
    //    //var formValid = form.valid();
    //    //if (formValid) {
    //    AddFinalTicketStatus(repairableitemCost, 0);
    //    //}
    //});
    //$(document).on("click", "#_btnNotReplaceOkay", function () {
    //    var repairableitemCost = $("#_ticketItemCost").val();
    //    //var formValid = form.valid();
    //    //if (formValid) {
    //    AddFinalTicketStatus(repairableitemCost, 1);
    //    //}
    //});

    $(document).on("click", "#_btnRepairableYes", function () {

        $(this).prop('disabled', true);
        $("#_btnRepairableNo").addClass('d-none');
        $("._assetsCost").removeClass('d-none');
        //$("#cost").html("Repaired Cost")
        $("#ticketinfo").html("Repairable Cost")
        $("#_ticketItemCost").val(0);
        $("#_replaceItemCost").val(0);
        $("#_replace").addClass('d-none');
        $('#_Noreplace').addClass('d-none');
        $('#_ticketCost').addClass('d-none');
        $('#_ticketCost').removeClass('d-none');

        $(document).on("click", "#_btnCostOkay", function () {
            //AddFinalTicketStatus
            $("#_replace").addClass('d-none');
            $('#_Noreplace').addClass('d-none');
            var repairableitemCost = $("#_ticketItemCost").val();
            var replaceitemCost = $("#_replaceItemCost").val();
            //console.log(repairableitemCost);
            var actualCost = ActualCost;
            //console.log(actualCost);
            $("._finalActionnd").removeClass('d-none');
            $("#_btnReplace").removeClass('d-none'); $('#_btnRepair').removeClass('d-none');
            AddFinalTicketStatus(repairableitemCost, replaceitemCost, 1);
            //if (repairableitemCost > (actualCost * 0.6)) {
            //    console.log((actualCost * 0.6));
            //    $("#_replace").removeClass('d-none');
            //}
            //else {
            //    //var formValid = form.valid();
            //    //if (formValid) {
            //    AddFinalTicketStatus(repairableitemCost, 1);
            //    //}
            //}
        })

    })




    $(document).on("click", "#_btnRepairableNo", function () {
        $("._assetsCost").removeClass('d-none');
        //$("#_btnRepairableNo").addClass('d-none');
        $("#_btnRepairableYes").addClass('d-none');
        //$("#cost").html("Replacement Cost")
        $(this).prop('disabled', true);
        //$("#ticketinfo").html("Replaced Cost")
        $("#_ticketItemCost").val(0);
        $("#_replaceItemCost").val(0);
        $("#_replace").addClass('d-none');
        $('#_Noreplace').addClass('d-none');
        $('#_ticketCost').addClass('d-none');
        $('#_ticketCost').removeClass('d-none');


        $(document).on("click", "#_btnCostOkay", function () {
            //AddFinalTicketStatus
            $("#_replace").addClass('d-none');
            $('#_Noreplace').addClass('d-none');
            var repairableitemCost = $("#_ticketItemCost").val();
            var replaceitemCost = $("#_replaceItemCost").val();
            //console.log(repairableitemCost);
            var actualCost = ActualCost;
            //console.log(actualCost);
            $("._finalActionnd").removeClass('d-none');
            $("#_btnReplace").removeClass('d-none'); $('#_btnRepair').removeClass('d-none');
            AddFinalTicketStatus(repairableitemCost, replaceitemCost, 0);
            //if (repairableitemCost < (actualCost * 0.6)) {
            //    $("#_Noreplace").removeClass('d-none');
            //}
            //else {
            //    //    var formValid = form.valid();
            //    //    if (formValid) {
            //    AddFinalTicketStatus(repairableitemCost, 0);
            //    //}
            //}

        })
    })


    $(document).on("click", "#_btnResolveNo", function (e) {

        AddorUpdateTicketStep(ticketNo, 0)

        var comment = $('#_comment').val()
       // addComment(ticketNo, comment)

        message = $("#_hiddenFieldEmail").val() + " has marked the Vendor Visit"

        showLoader();

        var params = {
            ticketNo: ticketNo,
            ticketStatusId: 1,
            assignedToEmpId: engineerEmpId,
            message: message,
            statusId: 1,
            JvcNumber: $("#_jvcNo").val()
        }

        showLoader();

        ajaxFunction("BRServices.asmx/UpdateTicket", params, "xml", "post", false, function (data) {
            hideLoader();
            toastr.success("Ticket updated successfully..", "Success");
            //setTimeout(function () {
                //location.reload();
            getTicketDetailByTicketNo(ticketNo)
            hideLoader();
            //}, 2000)
        })



        $('._isRepairable').removeClass('d-none');
        //$("#ticketinfo").html("Is Part Repairable ?");
        $("#_replace").addClass('d-none');
        $('#_Noreplace').addClass('d-none');
        $('#_ticketCost').addClass('d-none');
        //$('#_NotReovledModal').modal('toggle')
        $('#_notResolved').removeClass('d-none');
        $('#_btnRepairableNo').removeClass('d-none');
        $('#_btnRepairableYes').removeClass('d-none');
        $("#_btnResolveYes").addClass('d-none');
        $("#_btnResolveNo").prop("disabled", true);

    });


    $(document).on("click", "#_btnRepair", function (e) {
        AddFinalTicketStatus(0, 0, 1);

        $('#_btnRepair').prop("disabled", true);
        $('#_btnReplace').addClass('d-none');
        $('._Changestatusonresolved').removeClass('d-none');
        $('#_btnResolved').removeClass('d-none');
        $('#_btnClose').addClass('d-none');
    });

    $(document).on("click", "#_btnReplace", function (e) {
        AddFinalTicketStatus(0, 0, 0);

        $('#_btnReplace').prop("disabled", true);
        $('#_btnRepair').addClass('d-none');
        //_Changestatusonresolved _btnResolved _btnClose _btnReOpen
        $('._Changestatusonresolved').removeClass('d-none');
        $('#_btnResolved').removeClass('d-none');
        $('#_btnClose').addClass('d-none');

    });

    $(document).on("click", "#_btnResolveYes, #_btnResolved", function (e) {

        var id = $(this).attr('data-id');
        if (id == 2) {
            $("#_jvcNo").addClass("d-none");
            $(".jvcNo").addClass("d-none");
            $('#_submitresolve').removeClass('d-none');
            $('#_submitresolveyes').addClass('d-none');
        }

        else {
            $('#_submitresolve').addClass('d-none');
            $('#_submitresolveyes').removeClass('d-none');
            $("#_jvcNo").removeClass("d-none");
            $(".jvcNo").removeClass("d-none");
        }

        $('#_submit').addClass('d-none');
        $('#_submitreopen').addClass('d-none');
        $('#_submitclose').addClass('d-none');
        $('#_submitSaveDate').addClass('d-none');
        $('#_submit').addClass('d-none');
        $('#_commentModal').modal('toggle')


    });

    $(document).on('click', '#_submitresolve', function () {

        showLoader();

        AddorUpdateTicketStep(ticketNo, 1)

        var comment = $('#_comment').val()
        addComment(ticketNo, comment)

        message = $("#_hiddenFieldEmail").val() + " has marked the Vendor Visit"
        var params = {
            ticketNo: ticketNo,
            ticketStatusId: 1,
            assignedToEmpId: engineerEmpId,
            message: message,
            statusId: 1,
            JvcNumber: $("#_jvcNo").val()
        }

        ajaxFunction("BRServices.asmx/UpdateTicket", params, "xml", "post", false, function (data) {
            toastr.success("Ticket updated successfully..", "Success");
            hideLoader();
            //setTimeout(function () {
                //location.reload();
                getTicketDetailByTicketNo(ticketNo)
            //}, 2000)
        })




       
        getTicketDetailByTicketNo(ticketNo)

        $('#_btnResolved').removeClass('d-none');

        $('#_btnResolveYes').removeClass('d-none');
        $('#_btnResolveYes').prop("disabled", true);
        $('._Changestatusonresolved').removeClass('d-none');
        $('#_btnResolved').removeClass('d-none');
        $('#_btnClose').addClass('d-none');
        $('#_btnReOpen').addClass('d-none');
        $('#_submit').addClass('d-none');



        $('#_comment').val('');


        hideLoader();

    })


    $(document).on('click', '#_submitresolveyes', function () {

        showLoader();

        var id = $(this).attr('data-id');
        var comment = $('#_comment').val()

        //console.log($("#_jvcNo").val());

        if ($("#_jvcNo").val() == "0" || $("#_jvcNo").val() == "" || $("#_jvcNo").val() == null) {
            toastr.warning('Please Enter JVC Number');
        }

        else {

            showLoader();
            addComment(ticketNo, comment)
            message = $("#_hiddenFieldEmail").val() + " has marked the ticket Resolved"
            var params = {
                ticketNo: ticketNo,
                ticketStatusId: 2,
                assignedToEmpId: engineerEmpId,
                message: message,
                statusId: 4,
                JvcNumber: $("#_jvcNo").val()
            }

            showLoader();
            ajaxFunction("BRServices.asmx/UpdateTicket", params, "xml", "post", false, function (data) {
                hideLoader();
                toastr.success("Ticket updated successfully..", "Success");
                //setTimeout(function () {
                    //location.reload();
                getTicketDetailByTicketNo(ticketNo)
                hideLoader();
                //}, 2000)
            })

            $('._Changestatusonresolved').removeClass('d-none');
            $('#_btnClose').removeClass('d-none');
            $('#_btnReOpen').removeClass('d-none');

            $('#_commentModal').modal('toggle')
            $('#_comment').val('');

        }

        hideLoader();
    });


    $(document).on("click", "#_btnReOpen", function (e) {



        $('#_submitresolveyes').addClass('d-none');
        $('#_submitresolve').addClass('d-none');
        $('#_submitreopen').removeClass('d-none');
        $('#_submitclose').addClass('d-none');
        $('#_submitSaveDate').addClass('d-none');
        $('#_submit').addClass('d-none');


        $('#_commentModal').modal('toggle')

    });



    $(document).on('click', '#_submitreopen', function () {

        var comment = $('#_comment').val()

        $("#_jvcNo").addClass("d-none");

        addComment(ticketNo, comment)


        message = $("#_hiddenFieldEmail").val() + " has re-opened the ticket"
        var params = {
            ticketNo: ticketNo,
            ticketStatusId: 4,
            assignedToEmpId: engineerEmpId,
            message: message,
            statusId: 2,
            JvcNumber: $("#_jvcNo").val()
        }

        showLoader();
        ajaxFunction("BRServices.asmx/UpdateTicket", params, "xml", "post", false, function (data) {
            hideLoader();
            toastr.success("Ticket updated successfully..", "Success");
            //setTimeout(function () {
                //location.reload();
                getTicketDetailByTicketNo(ticketNo)
            //}, 2000)
        })

        $('#_btnReOpen').addClass('d-none');
        $('#_btnClose').addClass('d-none');

        $('#_comment').val('');

        hideLoader();

    })

    $(document).on("click", "#_btnClose", function (e) {

        $("#_jvcNo").removeClass("d-none");
        $(".jvcNo").removeClass("d-none");
        $('#_submitresolveyes').addClass('d-none');
        $('#_submitresolve').addClass('d-none');
        $('#_submitreopen').addClass('d-none');
        $('#_submitclose').removeClass('d-none');
        $('#_submitSaveDate').addClass('d-none');
        $('#_submit').addClass('d-none');

        $('#_commentModal').modal('toggle')

        
    });


    $(document).on('click', '#_submitclose', function () {

        showLoader();
        var comment = $('#_comment').val()
        //setTimeout(function () {

        if (commentUpload.files.length > 0) {

            addComment(ticketNo, comment)

            message = $("#_hiddenFieldEmail").val() + " has closed the ticket"
            var params = {
                ticketNo: ticketNo,
                ticketStatusId: 3,
                assignedToEmpId: engineerEmpId,
                message: message,
                statusId: 3,
                JvcNumber: $("#_jvcNo").val()
            }


            showLoader();
            ajaxFunction("BRServices.asmx/UpdateTicket", params, "xml", "post", false, function (data) {

                hideLoader();
                toastr.success("Ticket updated successfully..", "Success");
                //setTimeout(function () {
                    //location.reload();
                    getTicketDetailByTicketNo(ticketNo)
                //}, 1000)
            })

            $('#_comment').val('');
        }
        else {
            toastr.warning("Please Insert FSR Document First.");
           

        }


        hideLoader();
        
    })

    $(document).on("click", "._fileURL", function () {
        var documentURL = $(this).attr("data-documenturl")
        var link = document.createElement('a');
        link.href = documentURL;
        link.download = documentURL.split('/').pop();
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    });

    var imageList = [];
    var commentUpload = InitiateDropzone("._imgContainer", "Upload");
    function InitiateDropzone(divElement, imgLabel) {
        Dropzone.autoDiscover = false;
        showLoader();
        return new Dropzone(divElement, {
            
            url: "BRServices.asmx/UploadTicketCommentImages",
            uploadMultiple: true,
            parallelUploads: 50, //all images should upload same time
            autoProcessQueue: false,
            addRemoveLinks: true,
            maxFiles: 1,
            maxFilesize: 100, //50mb file size
            acceptedFiles: ".png,.jpg,.jpeg,.pdf,.doc,.docx,.xls,.xlsx",
            dictDefaultMessage: "<i title='Click or drag to upload Document / Image' style='font-size: 91px;color: #d6d6d6;' class='fa fa-cloud-upload' aria-hidden='true'></i>",
            success: function (file, response) {
                if (response.indexOf('00') >= 0) {
                    toastr.success("Document added successfully..", "Success");
                    this.removeAllFiles();
                    //$('#_docUploadModal').modal('toggle');
                    //getDocumentURL(applicationId, DocTypeId)
                } else if (response.indexOf('000') >= 0) {
                    toastr.success("Document updated successfully..", "Success");
                    this.removeAllFiles();
                    //$('#_docUploadModal').modal('toggle');
                    //getDocumentURL(applicationId, DocTypeId)
                }
                else if (response.indexOf('111') >= 0) {
                    toastr.warning("Document Type Already Exist..", "Warning");
                }
                else if (response.indexOf('1010') >= 0) {
                    toastr.error("Something went wrong, Please check Your Internet Connection", "Failed");
                }

                $("#_message").removeClass("hidden alert-warning alert-danger").addClass("alert-success");
                $("#_message").append("Document / Image uploaded successfully");
            },
            sending: function (file, xhr, data) {

                data.append("imgLabel", imgLabel);
                if (commentId) {
                    data.append("commentId", commentId);
                }
            },
            init: function () {
                this.on("maxfilesexceeded", function (file) {
                    this.removeAllFiles();
                    this.addFile(file);
                });
                if (imageList.length > 0) {
                    var imgContainer = $(this.element);
                    if (imgContainer.attr("class").indexOf("_imgContainer") >= 0) {
                        var imgs = imageList.filter(function (obj) {
                            return obj.DocumentName == "Upload";
                        })
                        showImages(imgs, this);
                    }
                }
            },

        });
        hideLoader();
    }

})