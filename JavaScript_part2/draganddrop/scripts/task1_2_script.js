var userStartTime = 0; //clock time at user start
var userGarbageCount = 0; //number of trash items collected
var trashCount = 0; //number of all trash items

//---DRAG AND DROP FUNCTIONALITY
function allowDrop(ev) {
    ev.stopPropagation();
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("dragged-id", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    userGarbageCount++;

    ev.target.className = 'notover';
    document.getElementById('arrow').className = 'hidden';
    document.getElementById("trash-bin").src = "images/full.png";
    document.getElementById("current-score").innerHTML = userGarbageCount + " / " + trashCount;

    //all garbage is collected
    if (userGarbageCount == trashCount) {
        showUserInput();
    }

    var data = ev.dataTransfer.getData("dragged-id");
    //ev.target.appendChild(document.getElementById(data));
    document.body.removeChild(document.getElementById(data));
}

function handleDragEnter(ev) {
    ev.target.className = 'over';
    document.getElementById('arrow').className = 'move';
}

function handleDragLeave(ev) {
    ev.target.className = 'notover';
    document.getElementById('arrow').className = 'hidden';
}

//-----STOPWATCH FUNCTIONALITY------
var minutes = 0;
var seconds = 0;
var hundredths = 0;
var startchrono = 0;
var interval = 0;

function chronometer() {
    if (startchrono == 1) {
        hundredths += 1;

        if (hundredths > 9) {
            hundredths = 0;
            seconds += 1;
        }

        if (seconds > 59) {
            seconds = 0;
            minutes += 1;
        }

        document.getElementById('chrono').innerHTML = minutes + ' . ' + seconds + ' : ' + hundredths;

        interval = setTimeout("chronometer()", 100);
    }
}

function startChronometer() {
    startchrono = 1;
    chronometer();
}

function stopChronometer() {
    startchrono = 0;
}

function resetChronometer() {
    startchrono = 0;
    clearTimeout(interval);

    minutes = 0;
    seconds = 0;
    hundredths = 0;

    document.getElementById('chrono').innerHTML = minutes + ' . ' + seconds + ' : ' + hundredths;
}


//-----GAME FUNCTIONALITY-------
function newGame() {
    function resetField() {
        var trashElements = document.querySelectorAll("div.piece-of-trash");
        for (var i = 0; i < trashElements.length; i++) {
            document.body.removeChild(trashElements[i]);
        }

        userGarbageCount = 0;
    }

    function createTrash() {
        function getRandomInteger(min, max) {
            return Math.floor(Math.random() * (max - min) + min);
        }

        userStartTime = new Date().getTime();
        var level = document.getElementById("game-level");
        trashCount = parseInt(level.options[level.selectedIndex].value) * 5;

        for (var i = 0; i < trashCount; i++) {
            var left = getRandomInteger(200, 820);
            var top = getRandomInteger(70, 470);
            var picture = getRandomInteger(1, 5);

            var trash = document.createElement("div");
            var scoreLabel = document.getElementById("current-score");

            var scoreText = userGarbageCount + " / " + trashCount;
            scoreLabel.innerHTML = scoreText;

            trash.id = i;
            trash.className = "piece-of-trash";
            trash.style.top = top + "px";
            trash.style.left = left + "px";

            switch (picture) {
                case 1:
                    trash.style.backgroundImage = "url(./images/blankdocument.png)";
                    break;
                case 2:
                    trash.style.backgroundImage = "url(./images/document.png)";
                    break;
                case 3:
                    trash.style.backgroundImage = "url(./images/documents.png)";
                    break;
                case 4:
                    trash.style.backgroundImage = "url(./images/linesdocument.png)";
                    break;
                default:
                    trash.style.backgroundImage = "url(./images/document.png)";
                    break;
            }

            var rotationDegree = getRandomInteger(0, 360);
            var rotationString = "rotate(" + rotationDegree + "deg)";
            trash.style.MozTransform = rotationString;
            trash.style.WebkitTransform = rotationString;
            trash.style.OTransform = rotationString;
            trash.style.transform = rotationString;

            trash.setAttribute("draggable", "true");
            trash.addEventListener('dragstart', drag, false);

            document.body.appendChild(trash);
        }
    }

    resetChronometer();
    resetField();
    createTrash();
    startChronometer();
}

//-------USER INPUT-------------

function showUserInput() {
    stopChronometer();

    var scoreLabel = document.getElementById("scoreInput");
    var userFinishTime = new Date().getTime();
    var levelElem = document.getElementById("game-level");
    var level = parseInt(levelElem.options[levelElem.selectedIndex].value);
    var score = parseInt((userFinishTime - userStartTime) / 10 * (19 / level));
    scoreLabel.innerHTML = score.toString();

    var input = document.getElementById("user-input");
    if(input.classList.contains("start")){
        input.classList.remove("start");
    }

    input.classList.remove("hidden");
    input.classList.add("show");    
}

function saveUserInput() {
    var username = document.getElementById("username").value;
    var score = parseInt(document.getElementById("scoreInput").innerHTML);

    localStorage.setItem(score, username);

    var input = document.getElementById("user-input");
    input.classList.remove("show");
    input.classList.add("hidden");
}

//------WALL OF FAME----------

function populateWall() {
    var highScores = [];
    for (var i = 0; i < localStorage.length; i++) {
        highScores.push(localStorage.key(i));
    }

    //highScores.sort(function (a, b) {
    //    var key1 = parseInt(a[1]);
    //    var key2 = parseInt(a[1]);
    //    return key2 - key1;
    //});
    var sortedKeys = Object.keys(localStorage).sort(function (a, b) {
        return a - b;
    });

    var wallOfFameDiv = document.getElementById("wall-of-fame");
    wallOfFameDiv.innerHTML = "";

    var userPlace = 1;
    for (var iter in sortedKeys) {
        if (userPlace > 5) {
            break;
        }

        var userScore = sortedKeys[iter];
        var userName = localStorage.getItem(userScore);

        if (userScore === "" || userScore === "undefined") {
            continue;
        }

        var currentUser = document.createElement("span");
        currentUser.innerHTML += userPlace + ". " + userName + "    " + userScore;

        wallOfFameDiv.appendChild(currentUser);
        userPlace++;
    }
}

function showWallOfFame() {
    populateWall();

    var wall = document.getElementById("wall-of-fame");
    wall.classList.remove("hidden");
    wall.classList.add("show");

    var closeButton = document.getElementById("close-button");
    closeButton.classList.remove("hidden");
    closeButton.classList.add("show");
}

function hideWallOfFame() {
    var wall = document.getElementById("wall-of-fame");
    wall.classList.remove("show");
    wall.classList.add("hidden");

    var closeButton = document.getElementById("close-button");
    closeButton.classList.remove("show");
    closeButton.classList.add("hidden");
}
