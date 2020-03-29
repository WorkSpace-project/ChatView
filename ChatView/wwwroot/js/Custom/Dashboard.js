function GetAllUsers() {
    $.ajax({
        type: "GET",
        url: "/Dashboard/GetAllUsers",
        success: function (result) {
            console.log(result);
            debugger
            
        },
        error: function (xhr) {
        }
    });
}
function LogOut() {
    $.ajax({
        type: "POST",
        url: "/Login/LogOut",
        success: function (data) {
            if (data === "success") {
                window.location.href = ('/Login/Index');
            }
        },
        error: function (xhr) {
        }
    });
} 