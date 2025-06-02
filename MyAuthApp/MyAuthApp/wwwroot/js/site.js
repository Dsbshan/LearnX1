var currencyFormat = "0,0.00";
var globalDateFormat = "dd-mm-yy";

$(document).ready(function () {
    $(".required").each(function (i, obj) {
        $(obj).append("&nbsp;<span class='required-text'>*</span>")
    });
});
function formatDecimal(value) {
    var val = numeral(value).format(currencyFormat);
    return val;
}

function displayLoader() {
    $("#loaderWrapper").show();
}
function hideLoader() {
    $("#loaderWrapper").hide();

}

function formatControlls() {
    $("span.decimal").each(function (i) {
        var object = $(this);
        var textValue = object.html();
        //console.log(textValue);
        var result = numeral(textValue).format(currencyFormat);
        object.html(result);
    });
    $("p.decimal").each(function (i) {
        var object = $(this);
        var textValue = object.html();
        //console.log(textValue);
        var result = numeral(textValue).format(currencyFormat);
        object.html(result);
    });
    $("input:text.decimal").each(function (i) {
        var object = $(this);
        var textValue = object.val();
        var result = numeral(textValue).format(currencyFormat);
        //console.log(result);
        object.val(result);
    });
    $("td.decimal").each(function (i) {
        var object = $(this);
        var textValue = object.html();
        //console.log(textValue);
        var result = numeral(textValue).format(currencyFormat);
        object.html(result);
    });
    $("label.decimal").each(function (i) {
        var object = $(this);
        var textValue = object.text();
        var result = numeral(textValue).format(currencyFormat);
        //console.log(result);
        object.text(result);
    });
    $("td.date").each(function (i) {
        var object = $(this);
        var textValue = object.html();
        //console.log(textValue);
        var result = moment(textValue).format(globalDateFormat);
        object.html(result);
    });
    $("td.datetime").each(function (i) {
        var object = $(this);
        var textValue = object.html();
        //console.log(textValue);
        var result = moment(textValue).format("DD-MM-YYYY HH:mm:ss");
        object.html(result);
    });
    $(".numeric").on('click', function () {
        var textValue = $(this).val();
        $(this).select();
    });

    $(".numeric").keypress(function (e) {
        var charCode = (e.which) ? e.which : e.keyCode
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        var index = numericAllowed.indexOf(charCode);
        if ((charCode == 46 && $(this).val().indexOf('.') == 0) || index < 0) {
            return false;
        }

        return true;
    });

    $('.decimal').on('input', function (e) {
        var charCode = (e.which) ? e.which : e.keyCode
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        var index = decimalAllowed.indexOf(charCode);
        if ((charCode == 46 && $(this).val().indexOf('.') == 0) || index < 0) {
            e.preventDefault();
        }
        return true;
    });

    $(".decimal").on('click', function () {
        var textValue = $(this).val();
        $(this).select();
    });

    $(".decimal").blur(function () {
        var textValue = $(this).val();
        var result = numeral(textValue).format(currencyFormat);
        $(this).val(result);
    });

    $(".decimalMinus").blur(function () {
        var textValue = $(this).val();
        var result = numeral(textValue).format(currencyFormat);
        $(this).val(result);
    });

    $(".decimalMinus").each(function (i) {
        var object = $(this);
        var textValue = object.val();
        var result = numeral(textValue).format(currencyFormat);
        object.val(result);
    });

    $(".decimalMinus").focus(function () {
        var textValue = $(this).val();
        if (numeral(textValue) == 0) {
            $(this).val("");
        }
    });

}



$('.email').on('input', function (e) {
    var txtPText = $("#" + e.currentTarget.id + "").val();
    var cursorPosition = $("#" + e.currentTarget.id + "").prop("selectionStart");

    if (txtPText !== undefined && cursorPosition !== undefined) {
        txtPText = txtPText.replace(/^ +/, '');

        var intPLength = "";
        var txtOutput = "";
        var initChar = txtPText.substring(0, 1);

        if (initChar == "@" || initChar == "." || initChar == "_" || initChar == "-") {
            txtPText = txtPText.substring(1, txtPText.length);
        }
        intPLength = txtPText.length;
        for (i = 0; i < intPLength; i++) {
            var chkString = txtOutput + txtPText[i];
            txtOutput = emailMask(chkString);
        }
        $("#" + e.currentTarget.id + "").val(txtOutput);
        $("#" + e.currentTarget.id + "").focus();
        $("#" + e.currentTarget.id + "").get(0).setSelectionRange(cursorPosition, cursorPosition);

        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(txtOutput)) {
            $("#" + e.currentTarget.id + "").css('color', '#555');
        }
        else {
            $("#" + e.currentTarget.id + "").css('color', '#f53b57');
        }
    }

});

$('.email').on('paste', function (e) {
    setTimeout(function () {
        var txtPText = $("#" + e.currentTarget.id + "").val();
        var cursorPosition = $("#" + e.currentTarget.id + "").prop("selectionStart");
        if (txtPText !== undefined && cursorPosition !== undefined) {
            $("#" + e.currentTarget.id + "").val(txtPText);
            $("#" + e.currentTarget.id + "").focus();
            $("#" + e.currentTarget.id + "").get(0).setSelectionRange(cursorPosition, cursorPosition);

            if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(txtPText)) {

                $("#" + e.currentTarget.id + "").css('color', '#555');
            }
            else {
                $("#" + e.currentTarget.id + "").css('color', '#f53b57');
            }
        }

    }, 50);
});

function emailMask(txtText) {
    if (txtText !== undefined) {
        txtText = txtText.toLowerCase();
        txtText = txtText.replace(/ /g, '');
        var txtLength = txtText.length;
        var reg = /[^a-z0-9\@\_\-\.|]/;

        if (reg.test(txtText)) {
            txtText = txtText.substring(0, txtText.length - 1);
        }
        return txtText;
    }
    else
        return null;
};

function isValidEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return (true)
    }
    return (false)
}