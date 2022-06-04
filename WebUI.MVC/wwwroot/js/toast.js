$(document).ready(function () {
    var message = $("#Toastr").text();
    if (message != "") {
        toastr.success(message);
    }
});
