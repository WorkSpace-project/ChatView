var connection = new signalR.HubConnectionBuilder()
    .withUrl("/MyHub")
    .build();
var userguid = $("#currentuserid").val();
connection.start().then(function () {
       connection.invoke("JoinMyHub", userguid);
});
$(window).on('beforeunload', function () {
    connection.invoke("LeaveMyHub", userguid);
});
window.play = function () {
    var audioElement = document.createElement('audio');
    audioElement.setAttribute('src', "/to-the-point.ogg");
    audioElement.play();
};