$(document).ready(function () {
//--------------------------------------------------------
    //عدد صحیح بزرگتر از صفر
    $(document).on("keypress", ".Numeric", function (evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    });


    //عدد صحیح
    $(document).on("keypress", ".Integer", function (evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        //کاراکتر '-' اول وارد شود و فقط یکبار وارد شود
        if (charCode == 45 && ($(evt.target).val().indexOf('-') > -1 || evt.target.selectionStart != 0)) {
            return false;
        }
        return true;
    });


    //عدد اعشاری بزرگتر از صفر
    $(document).on("keypress", ".FloatPositive", function (evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }

        //کاراکتر '.'  فقط یکبار وارد شود
        if (charCode == 46 && $(evt.target).val().indexOf('-') > -1) {
            return false;
        }
        return true;
    });


    //عدد اعشاری
    $(document).on("keypress", ".Float", function (evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }

        //کاراکتر '-'  اول وارد شود و فقط یکبار وارد شود
        if (charCode == 45 && ($(evt.target).val().indexOf('-') > -1 || evt.target.selectionStart != 0)) {
            return false;
        }



        if (charCode == 46 && (
            ($(evt.target).val().indexOf('.') > -1) || // کارکتر '.' بیش از یکبار وارد نشود
            ($(evt.target).val().indexOf('-') > -1 && evt.target.selectionStart < 1) // اگر کاراکتر '-' وجود داشت، کاراکتر '.' بعد از آن وارد شود
        )) {
            return false;
        }

        return true;
    });





//--------------------------------------------------------
//function AlertDanger(msg,duration=3000) {
//    AlertMsg(msg,"danger",duration)
//}
//function AlertSuccess(msg, duration = 3000) {
//    AlertMsg(msg, "duccess", duration)
//}
//function AlertInfo(msg, duration = 3000) {
//    AlertMsg(msg, "info", duration)
//}
//function AlertWarning(msg, duration = 3000) {
//    AlertMsg(msg, "warning", duration)
//}
//function AlertMsg(msg, type,duration) {
//    $("#errorMsg").empty();
//    $("#errorMsg").append("<div class='alert alert-" + type + "'>" + msg + "</div>");
//    setTimeout(function () {
//        $("#errorMsg").empty();
//    }, duration)

//}

//--------------------------------------------------------
//ShowAlert('text',?'type',?6000)
//type : primary , secondary , success , danger , warning , info , light , dark
function ShowAlert(text, type = "danger", length = 6000) {

    var lastId = 0;
    if ($("#alertContainer").css("display") != "block") {
        $("#alertContainer").show();
    }
    else {
        lastId = parseInt($(".alertBox:last-child").attr("id").split('_')[1]);
    }

    var alertHtmlStr = '<div class="alertBox alert alert-' + type + '" role="alert"  id="alertBox_' + (lastId + 1) + '">' + text + '</div>';
    $("#alertContainer").append(alertHtmlStr);

    var alertBox = $("#alertBox_" + (lastId + 1));

    alertBox.css("opacity", 1);


    setTimeout(function () {

        alertBox.css("opacity", 0);

        setTimeout(function () {
            alertBox.remove();
            if ($(".alertBox").length == 0) {
                $("#alertContainer").hide();
            }
        }, 1000);
    }, length);
}
//--------------------------------------------------------
});