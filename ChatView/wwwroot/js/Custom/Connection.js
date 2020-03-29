var connection = new signalR.HubConnectionBuilder()
    .withUrl("/MyHub")
    .build();
//var userguid = $("#userguid").val();
//var userrole = $("#userrole").val();
//var globalguid = "0705a73a-f95b-40c8-8ab9-f5956feb6334";
connection.start().then(function () {
    //if (userrole == "1") {
    //    connection.invoke("JoinMyHub", globalguid);
    //}
});
window.play = function () {
    var audioElement = document.createElement('audio');
    audioElement.setAttribute('src', "/to-the-point.ogg");
    audioElement.play();
};