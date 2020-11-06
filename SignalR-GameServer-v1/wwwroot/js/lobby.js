"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();
var playerIsReady = false;
//Disable send button until connection is established
document.getElementById("setReadyButton").disabled = true;

connection.on("LoginLock", function(username) {
    var username = username.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

    document.getElementById("usernameInput").disabled = true
    document.getElementById("setReadyButton").disabled = true;

});

connection.on("ReadyUserCount", function(readyUserCount) {
    var readyUserCount = readyUserCount.toString();

    document.getElementById('readyUserCount').innerHTML = readyUserCount + "/4 users ready";
});

connection.on("PlayerIsReady", function(isReady) {
    playerIsReady = isReady;
});

connection.on("SentRedirectToAllPlayers", function() {
    if (playerIsReady) {
        window.location.href = "/CharacterSelection";
    } else {
        alert("NESPEJAI");
    }
});


connection.start().then(function() {
    document.getElementById("setReadyButton").disabled = false;

    connection.invoke("GetReadyUsersCount", ).catch(function(err) {
        return console.error(err.toString());
    });


}).catch(function(err) {
    return console.error(err.toString());
});

document.getElementById("setReadyButton").addEventListener("click", function(event) {
    var username = document.getElementById("usernameInput").value;

    sessionStorage.setItem("username", username);
    sessionStorage.setItem("talismanBought", false)

    connection.invoke("SetReady", username).catch(function(err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("generateUsername").addEventListener("click", function(event) {
    var username = document.getElementById("usernameInput").value;

    connection.invoke("SendUsernameToAPI", username).catch(function(err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("ReceiveUsernameFromAPI", function(username) {
    document.getElementById("usernameInput").value = username;
});