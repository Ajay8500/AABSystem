function ajaxFunction(serviceUrl, param, type, methodType, as, successCallBack) {

    $.ajax({
        url: serviceUrl,
        data: param,
        dataType: type,
        async: as,
        method: methodType,
        success: successCallBack,
        error: function (data) {
            $("#_msgPopUp").popUp({
                title: "Error",
                message: "Something went wrong",
                messageType: "error"
            }).css({width : "300px",fontSize : 14});
        }
    });
}



 function ajaxFunctionWithoutParam(serviceUrl,type,methodType,as,successCallBack) {

     $.ajax({
         url: serviceUrl,
         dataType: type,
         async: as,
         method: methodType,
         success: successCallBack,
         error: function (data) {
             $("#_msgPopUp").popUp({
                 title: "Error",
                 message: "Something went wrong",
                 messageType: "error"
             }).css({width : "300px",fontSize : 14});
             //alert("Error");
         }
     });
 }


 function ajaxForInsertAndUpdate(url, params, methodType, as,successCallBack, errorCallBack) {
     $.ajax({
         url: url,
         data: params,
         async : as,
         method: methodType,
         success: successCallBack,
         error: errorCallBack
     });

 }



 function colResizing() {
     var pressed = false;
     var start = undefined;
     var startX, startWidth;

     $(document).on("mousedown", "table th", function (e) {
         start = $(this);
         pressed = true;
         startX = e.pageX;
         startWidth = $(this).width();
         $(start).addClass("resizing");
     });

     $(document).mousemove(function (e) {
         if (pressed) {
             $(start).width(startWidth + (e.pageX - startX));
         }
     });

     $(document).mouseup(function () {
         if (pressed) {
             $(start).removeClass("resizing");
             pressed = false;
         }
     });
 }






 