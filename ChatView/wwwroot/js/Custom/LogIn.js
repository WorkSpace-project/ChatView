$(document).keypress(function (e) {
    if (e.which == 13) {
        LogIn();
    }
});
function LogIn() {
    var email = $("#email").val();
    var password = $("#password").val();
    var remember = $("#remember").val();
    $.ajax({
        type: "Get",
        url: "/LogIn/LogIn",
        data: { email: email, password: password, RememberMe: remember },
        success: function (result) {
            if (result === "Invalid Email or Password") {
                $("#msg").text("Invalid Email or Password");
            }
            else {
                window.location.href = ('/Dashboard/Index');
            }
        },
        error: function (xhr) {
            $("#msg").text("Invalid Email or Password");
        }
    });
}
$(document).on("click", ".logincheckbox", function (e) {
    var value = $(this).val();
    if (value == "true") {
        this.value = false;
    }
    else {
        this.value = true;
    }
});