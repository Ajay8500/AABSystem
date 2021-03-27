function getAllRegion(currentList) {
    ajaxFunctionWithoutParam("BRServices.asmx/GetAllRegions", "xml", "post", false, function (data) {
        var json = $.parseJSON($(data).find("string").text());
        currentList.empty();
        var html = "";
        html += '<option value="">' + "Select Region" + '</option>';
        if (json.Table.length > 0) {
            _.forEach(json.Table, function (item, key) {
                html += '<option value="' + item.RegionId + '">' + item.RegionName + '</option>';
            })
        }
        currentList.append(html);
    });
}

function getAllArea(currentList) {
    ajaxFunctionWithoutParam("BRServices.asmx/GetAllLocation", "xml", "post", false, function (data) {
        var json = $.parseJSON($(data).find("string").text());
        currentList.empty();
        var html = "";
        html += '<option value="">Select Area</option>';
        if (json.Table.length > 0) {
            _.forEach(json.Table, function (item, key) {
                html += '<option value="' + item.LocationId + '">' + item.LocationName + '</option>';
            })
        }
        currentList.append(html);
    });
}
