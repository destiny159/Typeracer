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

    for (i = 0; i < message.length; i++) {
        
       
        if (message[i].character == "FirstTank") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401681705533450/tank-removebg-preview.png'>";

        } else if (message[i].character == "FirstCar") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401685761425418/car_compact2-removebg-preview.png'>";

        } else if (message[i].character == "FirstPerson") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774402929657511966/soldier__1_-removebg-preview.png'>";

        } else if (message[i].character == "FirstPlane") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774399475095568434/airplane-removebg-preview.png'>";
        }

        if (message[i].character == "SecondTank") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401678938079242/tank2-removebg-preview.png'>";

        } else if (message[i].character == "SecondCar") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401688860884993/car_compactb-removebg-preview.png'>";

        } else if (message[i].character == "SecondPerson") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401677759479808/soldier2-removebg-preview.png'>";

        } else if (message[i].character == "SecondPlane") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401719420321802/airplane2-removebg-preview.png'>";
        }

        if (message[i].character == "ThirdTank") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401680325607434/tank3-removebg-preview.png'>";

        } else if (message[i].character == "ThirdCar") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401687208722483/car_compact3-removebg-preview.png'>";

        } else if (message[i].character == "ThirdPerson") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401676031164436/soldier_3-removebg-preview.png'>";

        } else if (message[i].character == "ThirdPlane") {

            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='https://cdn.discordapp.com/attachments/753258314535665734/774401684255539220/airplane3-removebg-preview.png'>";
        }

        if (message[i].skin != null) {
            document.getElementById(i + 1 + "-player").innerHTML = message[i].username + " <b style='color:" + message[i].pointsColor + "'>" + message[i].points + "</b>";
            document.getElementById(i + 1 + "-player-bar").innerHTML = "<img style='margin-bottom:0px;margin-right: -25px;max-width: 50px;z-index: 1;' src='" + (message[i].skin).slice(34,-8) + "'>";
        }

        if (message[i].isWinner) {
            document.getElementById(i + 1 + "-player").innerHTML += " " + winPicture;
        }
        if (message[i].isLoser) {
            document.getElementById(i + 1 + "-player").innerHTML += " " + losePicture;
        }


        if (message[i].username == sessionStorage.getItem('username')) {

            if(!message[i].commandPermission){
                document.getElementById("command-card").setAttribute("style", "display:none");
            }else{
                document.getElementById("command-card").removeAttribute("style");
            }
            if(!message[i].shopPermission){
                document.getElementById("shop-card").setAttribute("style", "display:none");
            }else{
                document.getElementById("shop-card").removeAttribute("style");
            }
            
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
        document.getElementById(i + 1 + "-player-bar").setAttribute("style", "width:" + message[i].points + "%; background-color: grey");
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
    document.getElementById("time-place").innerHTML = message;
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

document.getElementById("changePointsColorGreen").addEventListener("click", function(event) {
    connection.invoke("receivePointsColor", "green", sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
document.getElementById("changePointsColorBlue").addEventListener("click", function(event) {
    connection.invoke("receivePointsColor", "blue", sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
document.getElementById("changePointsColorRed").addEventListener("click", function(event) {
    connection.invoke("receivePointsColor", "red", sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("changeSkin").addEventListener("click", function(event) {
    connection.invoke("receiveSkin", sessionStorage.getItem('username')).catch(function(err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});