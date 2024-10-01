function NotifyToast(title, message) {

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "onclick": null,
        "showDuration": "400",
        "hideDuration": "800",
        "timeOut": "4000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    if (title == "Error" || title == "Failed") {
        toastr.error(message, title);
    }
    else {
        toastr.success(message, title);
    }
}

function CreateDatePicker(ctrlDateId, isCurrentDate = true) {
    $('#' + ctrlDateId).datepicker({
        dateFormat: 'yy-mm-dd',
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true,
        yearRange: '2020:2030',
        buttonImageOnly: true,
        minDate: new Date(2020, 1 - 1, 1),
        maxDate: '+30Y',
        inline: true,
        onSelect: function () {
            var domelem = document.getElementById(ctrlDateId);
            mutateDOM(domelem, domelem.value);
        }
    });
}

function CreateTimerPicker(ctrlTimerId) {
    $('#' + ctrlTimerId).timepicker({
        timeFormat: 'hh:mm p',
        interval: 15,
        minTime: '12:00am',
        maxTime: '11:00pm',
        //defaultTime: '8',
        //startTime: '08:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true,
        zindex: 99999,
        change: function (time) {
            // the input field
            var element = $('#' + ctrlTimerId);
            // get access to this Timepicker instance
            var timepicker = element.timepicker();
            let text = timepicker.format(time);
            element.prop("value", text);

            var domelem = document.getElementById(ctrlTimerId);
            mutateDOM(domelem, domelem.value);

        }
    });

}

function DisableEnterKey() {
    $(':input:not(textarea):not([type=submit])', '.modal-dialog').on("keyup keypress", function (e) {
        var code = e.keyCode || e.which;
        if (code == 13) {
            e.preventDefault();
            return false;
        }
    });
};

var LastElementDOM;
var LastValueDOM;

function mutateDOM(ElementDOM, value) {
    if (LastElementDOM == ElementDOM && LastValueDOM == value)
        return false;

    LastElementDOM = ElementDOM;
    LastValueDOM = value;

    var event = new Event('change');
    ElementDOM.dispatchEvent(event);
}

function tooglePasswordShow(inputId, iconId) {

    let type = $('#' + inputId).prop('type');

    if (type == 'password') {
        $('#' + inputId).prop('type', ' ');
        $('#' + iconId).prop('class', 'fa fa-eye ');
    } else {
        $('#' + inputId).prop('type', 'password');
        $('#' + iconId).prop('class', 'fa fa-eye-slash');
    }

}

function setPageTitle(pageTitle) {
    if (pageTitle)
        $(document).prop("title", pageTitle);
}



