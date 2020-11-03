"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
document.getElementById("word-input").disabled = true;
document.getElementById("useSpecialAbility").disabled = true;
document.getElementById("bronzeTalismanButton").disabled = true;
document.getElementById("silverTalismanButton").disabled = true;
document.getElementById("goldTalismanButton").disabled = true;

connection.on("ReceiveAllUsernames", function(message) {

    var i;
    var winPicture = "<img style='max-width:40px' src='https://icons.iconarchive.com/icons/thesquid.ink/free-flat-sample/1024/cup-icon.png'></img>";
    var losePicture = "<img style='max-width:40px' src='https://cdn.iconscout.com/icon/free/png-512/sad-emoji-17-894764.png'></img>";
    var tankPicture = "<img style='max-width:100px' src='https://d1nhio0ox7pgb.cloudfront.net/_img/g_collection_png/standard/256x256/tank.png'></img>";
    var carPicture = "<img style='max-width:100px' src='https://d1nhio0ox7pgb.cloudfront.net/_img/g_collection_png/standard/256x256/car_compact2.png'></img>";
    var personPicture = "<img style='max-width:100px' src='https://d1nhio0ox7pgb.cloudfront.net/_img/g_collection_png/standard/256x256/soldier.png'></img>";
    var planePicture = "<img style='max-width:100px' src='https://d1nhio0ox7pgb.cloudfront.net/_img/g_collection_png/standard/256x256/airplane.png'></img>";

    for (i = 0; i < message.length; i++) {

        if (message[i].character == "FirstTank") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " " + message[i].points + tankPicture;

        } else if (message[i].character == "FirstCar") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " " + message[i].points + carPicture;

        } else if (message[i].character == "FirstPerson") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " " + message[i].points + personPicture;

        } else if (message[i].character == "FirstPlane") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " " + message[i].points + planePicture;

        }

        if (message[i].isWinner) {
            document.getElementById(i + 1 + "-player").innerHTML += " " + winPicture;
        }
        if (message[i].isLoser) {
            document.getElementById(i + 1 + "-player").innerHTML += " " + losePicture;
        }
        //pridet cia talismano foto nx




        if (message[i].username == sessionStorage.getItem('username')) {

            if (message[i].points >= 25) {

                document.getElementById("bronzeTalismanButton").disabled = false;
                document.getElementById("silverTalismanButton").disabled = false;
                document.getElementById("goldTalismanButton").disabled = false;
            } else if (message[i].points >= 15) {

                document.getElementById("bronzeTalismanButton").disabled = false;
                document.getElementById("silverTalismanButton").disabled = false;
                document.getElementById("goldTalismanButton").disabled = true;
            } else if (message[i].points >= 10) {

                document.getElementById("bronzeTalismanButton").disabled = false;
                document.getElementById("silverTalismanButton").disabled = true;
                document.getElementById("goldTalismanButton").disabled = true;
            } else {

                document.getElementById("bronzeTalismanButton").disabled = true;
                document.getElementById("silverTalismanButton").disabled = true;
                document.getElementById("goldTalismanButton").disabled = true;
            }

            if (sessionStorage.getItem('talismanBought') == "true") {

                document.getElementById("bronzeTalismanButton").disabled = true;
                document.getElementById("silverTalismanButton").disabled = true;
                document.getElementById("goldTalismanButton").disabled = true;
            }
        }

        document.getElementById(i + 1 + "-player-bar").setAttribute("aria-valuenow", message[i].points);
        document.getElementById(i + 1 + "-player-bar").setAttribute("style", "width:" + message[i].points + "%");
    }

});

connection.on("ReceiveCountdown", function(time, word) {


    if (sessionStorage.getItem('abilityUsed') == "true") {
        document.getElementById("useSpecialAbility").disabled = true;
    } else {
        document.getElementById("useSpecialAbility").disabled = false;
    }

    countdown(time, word);

    connection.invoke("RequestGameRound").catch(function(err) {
        return console.error(err.toString());
    });
});

connection.on("GetGameRound", function(round) {

    document.getElementById("round-place").innerHTML = "Round: " + round;
});

connection.start().then(function() {

    connection.invoke("GetUsernames").catch(function(err) {
        return console.error(err.toString());
    });

    connection.invoke("PlayerReadyInGameWindow", sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });

}).catch(function(err) {
    return console.error(err.toString());
});


//SINGLETON- viso game laikas
connection.on("ReceiveTimer", function(message) {
    alert(message);
});


connection.on("GetWinMessage", function(lastAbilityUser) {

    document.getElementById("sendButton").disabled = true;
    document.getElementById("word-input").disabled = true;
    document.getElementById("word-place").innerHTML = 'Word Place';

    if (lastAbilityUser != "") {
        document.getElementById("win-lose-place").innerHTML = "LAIMEJAI!!! <br> Bet buvo panaudota " + lastAbilityUser + " galia";
    } else {
        document.getElementById("win-lose-place").innerHTML = "LAIMEJAI!!!";
    }

});

connection.on("InformThatSomeoneUseAbility", function() {
    document.getElementById("useSpecialAbility").disabled = true;
});

connection.on("GetLoseMessage", function() {

    document.getElementById("sendButton").disabled = true;
    document.getElementById("word-input").disabled = true;
    document.getElementById("word-place").innerHTML = 'Word Place';

    document.getElementById("win-lose-place").innerHTML = "Pralaimėjai!!!";
});



//Gaunam viso game laika
document.getElementById("sendButton").addEventListener("click", function(event) {


    var userWord = document.getElementById("word-input").value;

    connection.invoke("CheckWord", userWord, sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });

    document.getElementById("word-input").value = '';

    /*
    connection.invoke("GetTimer").catch(function (err) {
        return console.error(err.toString());
    });
    */

    event.preventDefault();
});

document.getElementById("goldTalismanButton").addEventListener("click", function(event) {

    connection.invoke("BuyGoldTalisman", sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

document.getElementById("silverTalismanButton").addEventListener("click", function(event) {

    connection.invoke("BuySilverTalisman", sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

document.getElementById("bronzeTalismanButton").addEventListener("click", function(event) {

    connection.invoke("BuyBronzeTalisman", sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

connection.on("DisableAllTalismans", function() {

    document.getElementById("bronzeTalismanButton").disabled = true;
    document.getElementById("silverTalismanButton").disabled = true;
    document.getElementById("goldTalismanButton").disabled = true;

    sessionStorage.setItem("talismanBought", true);
});


//special ability button
document.getElementById("useSpecialAbility").addEventListener("click", function(event) {
    connection.invoke("UseSpecialAbility", sessionStorage.getItem('characterTitle')).catch(function(err) {
        return console.error(err.toString());
    });

    sessionStorage.setItem("abilityUsed", true);
    document.getElementById("useSpecialAbility").disabled = true;

    event.preventDefault();
});

document.getElementById("penaltyButton").addEventListener("click", function(event) {
    connection.invoke("PenaltyCommand").catch(function(err) {
        return console.error(err.toString());
    });
    connection.invoke("GetUsernames").catch(function(err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("enableSpecialAbilityButton").addEventListener("click", function(event) {
    connection.invoke("UnlockAbilityCommand").catch(function(err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

document.getElementById("prizeButton").addEventListener("click", function(event) {
    connection.invoke("PrizeCommand").catch(function(err) {
        return console.error(err.toString());
    });
    connection.invoke("GetUsernames").catch(function(err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

document.getElementById("cloneButton").addEventListener("click", function(event) {
    connection.invoke("clonePrototype").catch(function(err) {
        return console.error(err.toString());
    });
    document.getElementById("cloneButton").disabled = true;
    event.preventDefault();
});

connection.on("EnableAbilityButton", function() {

    sessionStorage.setItem("abilityUsed", false);
    document.getElementById("useSpecialAbility").disabled = false;
});


function countdown(secs, word) {
    var milli = secs * (1000);
    var counter = setInterval(function() {
        if (milli <= 0) {
            clearInterval(counter);
            document.getElementById("sendButton").disabled = false;
            document.getElementById("word-input").disabled = false;
            document.getElementById("useSpecialAbility").disabled = true;
            document.getElementById("word-place").innerHTML = word;
            document.getElementById("win-lose-place").innerHTML = "";
            return;
        }
        milli -= 5;
        document.getElementById("countdown-place").innerHTML = milli + " millisecs"; // watch for spelling
    }, 5);

}