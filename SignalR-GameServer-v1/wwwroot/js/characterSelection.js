"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();
var playerIsReady = false;
//Disable send button until connection is established
document.getElementById("selectButton").disabled = true;


connection.start().then(function() {
    document.getElementById("selectButton").disabled = false;
}).catch(function(err) {
    return console.error(err.toString());
});

connection.on("ReturnAvatarTitle", function(avatarTitle) {
    var avatarTitle = avatarTitle.toString();
    sessionStorage.setItem("character", avatarTitle);
    window.location.href = "/Game";
});

connection.on("SentTimeDifference", function(time) {
    alert(time);
});

document.getElementById("selectButton").addEventListener("click", function(event) {
    var character = document.getElementById("character-select").value;

    sessionStorage.setItem("characterTitle", character);

    connection.invoke("SelectCharacter", character, sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});