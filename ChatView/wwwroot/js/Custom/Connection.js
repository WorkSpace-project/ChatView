var connection;
    connection = new signalR.HubConnectionBuilder()
    .withUrl("/MyHub")
    .build();
var userguid = $("#currentuserid").val();
connection.start().then(function () {
    connection.invoke("JoinMyHub", userguid);
});
$(window).on('beforeunload', function () {
    connection.invoke("LeaveMyHub", userguid);
});
connection.on("UserOnline", function (userguid) {
    $("#userstatus" + userguid).removeClass('offlineuser');
    $("#userstatus" + userguid).addClass('onlineuser');
});
connection.on("UserOffline", function (userguid) {
    $("#userstatus" + userguid).removeClass('onlineuser');
    $("#userstatus" + userguid).addClass('offlineuser');
});
window.play = function () {
    var audioElement = document.createElement('audio');
    audioElement.setAttribute('src', "/to-the-point.ogg");
    audioElement.play();
};