var thisuserguid = "";
var thisuserfirstname = "";
var thisuserlastname = "";
var thisusercustomercode = "";

function GetAllUsers() {
    $.ajax({
        type: "GET",
        url: "/Dashboard/GetAllUsers",
        success: function (result) {
            //console.log(result);
            $("#customers").html('');
            $.each(result, function (i, v) {
                if (v.id != userguid) {
                    var area = CreateUserArea(v);
                    $("#customers").append(area);
                }
            });
        },
        error: function (xhr) {
        }
    });
}
function CreateUserArea(v) {
    //console.log(v);
    var area = "";
    if (v.online == true) {
        area = '<a href="Javascript:void(0)" onclick=ThisUser(this) id="CustomerNo' + v.id + '" data-id=' + v.id + ' data-firstname=' + v.firstName + ' data-lastname=' + v.lastName + ' data-customercode=' + v.customerCode + '>' +
            '<hr class="mt-0">' +
            '<input readonly id="userstatus' + v.id + '" class="onlineuser" value="" />' +
            '<h5 class="pl-3 pr-3">' + "  " + v.firstName + " " + v.lastName + '<span class="float-right badge badge-pill badge-danger" id="ChatCounter' + v.id + '">25</span></h5 >' +
            '<hr class="mb-0">' +
            '</a>';
    }
    else {
        area = '<a href="Javascript:void(0)" onclick=ThisUser(this) id="CustomerNo' + v.id + '" data-id=' + v.id + ' data-firstname=' + v.firstName + ' data-lastname=' + v.lastName + ' data-customercode=' + v.customerCode + '>' +
            '<hr class="mt-0">' +
            '<input readonly id="userstatus' + v.id + '" class="offlineuser" value="" />' +
            '<h5 class="pl-3 pr-3">' + "  " + v.firstName + " " + v.lastName + '<span class="float-right badge badge-pill badge-danger" id="ChatCounter' + v.id + '">25</span></h5 >' +
            '<hr class="mb-0">' +
            '</a>';
    }
    return area;
}
function ThisUser(elem) {
    thisuserguid = $(elem).data('id');
    thisuserfirstname = $(elem).data('firstname');
    thisuserlastname = $(elem).data('lastname');
    thisusercustomercode= $(elem).data('customercode');
    debugger
    $("#username").text(" - " + thisuserfirstname + " " + thisuserlastname);

}



//logout
function LogOut() {
    $.ajax({
        type: "POST",
        url: "/Login/LogOut",
        success: function (data) {
            if (data === "success") {
                connection.invoke("LeaveMyHub", userguid);
                window.location.href = ('/Login/Index');
            }
        },
        error: function (xhr) {
        }
    });
} 