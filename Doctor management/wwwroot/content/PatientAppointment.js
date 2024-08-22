
jQuery(document).ready(function () {
    BindDropdownlist('BindPatientName', 'ddlPatientName', '');
    BindDropdownlist('BindMedicinePres', 'ddlMedPres', '');
    BindDropdownlist('BindDiagnosticPres', 'ddldaigpres', '');

    $('#ddlMedPres').select2({
        placeholder: 'Select options',
        allowClear: true
    });

    $('#ddldaigpres').select2({
        placeholder: 'Select options',
        allowClear: true
    });

});


function BindDropdownlist(url, Dropdownlist, ID) {
    $.ajax({
        type: "GET",
        url: url,
        data: "{}",
        success: function (data) {
            if (data != null && data != '' && data != undefined) {
                var s = '<option value="0" selected="selected">--Select--</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].id + '">' + data[i].name + '</option>';
                }
                $("#" + Dropdownlist).html(s);
                if (ID != null && ID != undefined && ID != '') {
                    $("#" + Dropdownlist).find('option[value="' + ID + '"]').attr('selected', 'selected');
                }
               
            }
        }
    });

}